using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OperationAPI.API.MiddelWares;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Mapper;
using OperationAPI.Identity;
using OperationAPI.Identity.DBContext;
using OperationAPI.Presistence;
using OperationAPI.Presistence.MapperConfig;
using OperationAPI.Presistence.Models;
using OperationAPI.Presistence.Repositories;
using OperationAPI.Presistence.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.Load("OperationAPI.Application"));
});

builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.RegisterPersistenceServices(builder.Configuration);

builder.Services.AddScoped<IAirlineAgentService, AirlineAgentRepository>();
builder.Services.AddScoped<IAircraftSizeService, AircraftSizeRepository>();
builder.Services.AddScoped<IAircraftRegistrationService, AircraftRegisterationRepository>();
builder.Services.AddScoped<IWorkOnService, WorkOnRepository>();
builder.Services.AddScoped<IAircraftTypeService, AircraftTypeRepository>();
builder.Services.AddScoped<ICountryService, CountryRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IAirlineAgentService, AirlineAgentRepository >();
builder.Services.AddScoped<IHandlingAgentsCompanyService, HandlingAgentsCompanyRepository >();

builder.Services.AddScoped<ICompanyInfoSercice, CompanyInfoRepository>();

builder.Services.AddScoped<ITowerDataService, TowerDataRepository>();
builder.Services.AddScoped<IOfficerDataService, OfficerDataRepository>();




builder.Services.AddAutoMapper(typeof(MapperConfig).Assembly);
builder.Services.AddAutoMapper(typeof(ApplicationMappingConfig).Assembly);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();





// Middlewares
app.UseMiddleware<ExceptionMiddleWare>();
app.UseMiddleware<SuccessResponseMiddleWare>();


app.UseRouting();
app.UseCors("AllowAll");
//app.UseHttpsRedirection();




app.UseAuthorization();

app.MapControllers();

app.Run();
