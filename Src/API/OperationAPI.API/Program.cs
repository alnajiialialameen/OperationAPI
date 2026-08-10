using OperationAPI.API.MiddelWares;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Identity;
using OperationAPI.Presistence.MapperConfig;
using OperationAPI.Presistence.Repositories;
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
builder.Services.AddScoped<IAircraftRegistration, AircraftRegisterationRepository>();


builder.Services.AddAutoMapper(typeof(MapperConfig).Assembly);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





// Middlewares
app.UseMiddleware<ExceptionMiddleWare>();
app.UseMiddleware<SuccessResponseMiddleWare>();

app.UseHttpsRedirection();




app.UseAuthorization();

app.MapControllers();

app.Run();
