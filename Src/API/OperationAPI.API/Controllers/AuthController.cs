using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Contracts.Identity;
using OperationAPI.Application.Models.IdentityModel;

namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // 2147483648
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            this._authService = authService;
            this._userService = userService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authService.Loging(request));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegisterationResponse>> Register(RegisterationRequest request)
        {
            var data = await _authService.Register(request);
            return Ok(data);
        }

        // أكشن لاسترجاع بيانات المستخدم بناءً على الـ JWT
        [HttpGet("GetUserId")]
        public IActionResult GetUserId()
        {
            // الوصول إلى الـ userId من الـ Claims
            //var userId = User.FindFirst("Id")?.Value;
            var userId = this._authService.GetUserId();

            if (userId == null)
            {
                return Unauthorized("User ID not found in token.");
            }

            // إرجاع الـ userId
            return Ok(new { UserId = userId });
        }

        [HttpGet("GetRoles")]
        public async Task<List<string>> GetRoles()
        {
            var rolesList = await this._authService.GetAllRolesAsync();

            //if (rolesList == null)
            //{
            //    return NotFound("No Data Found");
            //}

            // إرجاع الـ userId
            return rolesList;
        }

        [HttpPost("CraeteRole")]
        public async Task<IActionResult> CraeteNewRole(string roleName)
        {
            var res = await this._authService.CreateRoleAsync(roleName);

            if (!res)
            {
                return BadRequest(new { Message = $"Role [{roleName}] Already Exist" });
            }

            // إرجاع الـ userId
            return Ok(new { Message = "Role Created Successfuly" });
        }

        [HttpGet("GetUsers")]
        public async Task<List<Employee>> GetEmployees()
        {
            var Employees = await this._userService.GetAllEmployees();

            return Employees;
        }

        [HttpGet("GetUserDetails")]
        public async Task<Employee> GetUserDetails(string userId)
        {
            var Employee = await this._userService.GetEmployee(userId);

            return Employee;
        }

        [HttpPost("ResetPassword")]
        public async Task<ActionResult<bool>> ResetPasswordAsync(string userId, string password)
        {
            var res = await this._userService.ResetPasswordAsync(userId, password);

            if(res)
                return Ok(true);

            return BadRequest(false);
        }

        [HttpPut("UpdateUserAsync")]
        public async Task<ActionResult<EditUserRequest>> UpdateUserAsync(EditUserRequest request)
        {
            var res = await this._authService.Edit(request);

            if (res == request)
                return Ok(res);

            return BadRequest(request);
        }
    }
}
