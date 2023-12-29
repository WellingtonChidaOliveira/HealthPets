using HealthPets.Api.Extensions;
using HealthPets.Application.Services;
using HealthPets.Infrastructure;
using HealthPets.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistenceApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();
builder.Services.ConfigureCoresPolicy();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

CreateDatabase(app);

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();

static void CreateDatabase(WebApplication app)
{
    var serviceScopeFactory = app.Services.CreateScope();
    var dataContext = serviceScopeFactory.ServiceProvider.GetService<AppDbContext>();
    dataContext?.Database.EnsureCreated();
}
