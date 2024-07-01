using Infrastructure.Abstraction;
using Application.Abstractions;
using API.Exceptions;
using Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
IConfiguration configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json", false)
                                    .AddJsonFile($"appsettings.{env}.json", true, true)
                                    .Build();

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (!dbContext.Database.CanConnect())
    {
        throw new NotImplementedException("Cant connect to db");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
