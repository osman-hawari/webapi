using Microsoft.EntityFrameworkCore;
using webapi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = new ConfigurationBuilder()
                            //.AddJsonFile($"appsettings.json", true)
                            //.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true)
                            .AddEnvironmentVariables()
                            .Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(l => l.AddSimpleConsole());

builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true);

builder.Services.AddDbContext<CustomerDbContext>(
        (services, options) =>
        {            
            options.UseSqlServer(configuration.GetValue<string>("SqlConnectionString"));
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
