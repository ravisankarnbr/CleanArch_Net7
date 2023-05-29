using CleanArch.Infra.IOC;
using ClearArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var UnivDBconnectionString = builder.Configuration.GetConnectionString("UnivDBConnection");
builder.Services.AddDbContext<UniversityDBContext>(options =>
    options.UseSqlServer(UnivDBconnectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(S =>
{
    S.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "University Api", Version = "v1" });
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

DependencyContainer.RegisterServices(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "University Api V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
