using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OperationAPI.Application.Contracts.Identity;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Models.IdentityModel;
using OperationAPI.Domain;
using OperationAPI.Identity.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration configuration;
        private readonly IAirlineAgentService airlineAgentService; 

        public AuthService(UserManager<ApplicationUser> userManager,
        IOptions<JwtSettings> jwtSettings, IHttpContextAccessor contextAccessor,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IAirlineAgentService airlineAgentService)
        {
            this._userManager = userManager;
            this._contextAccessor = contextAccessor;
            this._jwtSettings = jwtSettings.Value;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this.configuration = configuration;
            this.airlineAgentService = airlineAgentService;
        }
        public async Task<AuthResponse> Loging(AuthRequest request)
        {
            // check is user email already registered or not
            ApplicationUser? user = null;

            if (!string.IsNullOrEmpty(request.Email))
            {
                user = await _userManager.FindByEmailAsync(request.Email);
            }
            else
            {
                user = await _userManager.FindByNameAsync(request.UserName);
            }

            if (user == null) // invalid email
            {
                throw new NotFoundException($"user with Email {request.Email} not found", request.Email??request.UserName);
            }
            // valid email---> check is valid cridential?
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);

            // invalid cridentials
            if (result.Succeeded == false)
            {
                throw new BadRequestException($"Credentials for '{request.Email} aren't Valid'.");
            }

            // generate jwt security token
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new AuthResponse
            {
                UserId = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email!,
                UserName = user.UserName!,
            };

            // get Airline agent info depending on returned userId
            response.AirlineAgent = await GetAirlineAgentInfo(response.UserId);

            // رجع النتيجة كاملة
            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email !),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("Uid", user.Id),
            }
            .Union(userClaims)
            .Union(roleClaims);


            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signinCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: Claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signinCredentials
                );

            return jwtSecurityToken;
        }

        public async Task<RegisterationResponse> Register(RegisterationRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new BadRequestException("BadRequest: Email already exist");
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FullName = request.FullName!,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, request.Password!);

            if (result.Succeeded)
            {
                foreach (var role in request.UserRoles!.ToList())
                {
                    await _userManager.AddToRoleAsync(user, role);
                }
              
                return new RegisterationResponse() { UserId = user.Id };
            }
            else
            {
                StringBuilder str = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    str.AppendFormat(".{0}\n", err.Description);
                }

                throw new BadRequestException($"{str}");
            }
        }

        public string? GetUserId()
        {
            var user = _contextAccessor.HttpContext?.User;

            return user?.FindFirst("Uid")?.Value;
        }

        public async Task<List<string>> GetAllRolesAsync()
        {
            // جلب كل الأدوار من قاعدة البيانات وإرجاع أسمائها
            var roles = await _roleManager.Roles
            .Select(r => r.Name)
            .ToListAsync();

            return roles;
        }

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            // Check if role already exists
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var role = new IdentityRole(roleName);
                var result = await _roleManager.CreateAsync(role);

                return result.Succeeded;
            }

            // لو الدور موجود بالفعل
            return false;
        }

        public async Task<EditUserRequest> Edit(EditUserRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.Id!);
            // Apply updates again, then save

            user.Id = request.Id!;
            user.Email = request.Email;
            user.FullName = request.FullName!;
            user.UserName = request.UserName;
            user.PhoneNumber = request.PhoneNumber;
            user.EmailConfirmed = true;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                // get user roles
                var currentUserRoles = await _userManager.GetRolesAsync(user);
                var newRoles = request.UserRoles ?? new List<string>();

                var rolesToAdd = newRoles.Except(currentUserRoles).ToList();
                var rolesToRemove = currentUserRoles.Except(newRoles).ToList();

                // حذف الادوار المراد حذفها
                if (rolesToRemove.Any())
                {
                    var removeResult = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
                    if (!removeResult.Succeeded)
                        throw new BadRequestException("Error in Removing Roles");
                }

                // نضيف الأدوار الجديدة
                if (rolesToAdd.Any())
                {
                    var addResult = await _userManager.AddToRolesAsync(user, rolesToAdd);
                    if (!addResult.Succeeded)
                        throw new BadRequestException("Error in Adding Roles");
                }

                return request;
            }
            else
            {
                StringBuilder str = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    str.AppendFormat(".{0}\n", err.Description);
                }

                throw new BadRequestException($"{str}");
            }
        }

        public async Task<AuthResponse> VerifyEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
                throw new BadRequestException($"Credentials for user with  ID=[{userId}] aren't Valid.");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new NotFoundException($"user with Email {user!.Email} not found", user.Email!);

            // var decodedToken = WebUtility.UrlDecode(token);
            var decodedBytes = WebEncoders.Base64UrlDecode(token);
            var decodedToken = Encoding.UTF8.GetString(decodedBytes);

            var result = await _userManager.ConfirmEmailAsync(user, decodedToken); // email confirmed(verified)

            var response = new AuthResponse
            {
                UserId = user.Id,
                Token = token,
                Email = user.Email!,
                UserName = user.UserName!,
            };
            return response;
        }
    
        private async Task<AirLineAgentDomain> GetAirlineAgentInfo(string userId)
        {
            var data = await this.airlineAgentService.getByUserId(userId);

            if (data == null)
            {
                return new AirLineAgentDomain();
            }

            return data;
        }
    }
}
