using HealthPets.Application.Services;
using HealthPets.Infrastructure;
using HealthPets.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//TODO: USE FAST ENDPOINTS!!!!!!!!!
builder.Services.ConfigurePersistenceApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

CreateDatabase(app);


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();

static void CreateDatabase(WebApplication app)
{
    var serviceScopeFactory = app.Services.CreateScope();
    var dataContext = serviceScopeFactory.ServiceProvider.GetService<AppDbContext>();
    dataContext?.Database.EnsureCreated();
}
