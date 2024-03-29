using Microsoft.EntityFrameworkCore;
using MiniBusManagement.Services.Administration;
using MiniBusManagement.Api;
using MiniBusManagement.Data.Repositories;
using MiniBusManagement.Data.Repositories.Administration;



var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddControllers(options =>
{
    //    options.ReturnHttpNotAcceptable = true; 
}).AddNewtonsoftJson(options =>
      options.SerializerSettings.ReferenceLoopHandling =
        Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddScoped<IMiniBusRepository, MinibusRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMiniBusService, MiniBusService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(Program));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<HaciendaOptions>(
    builder.Configuration.GetSection("Hacienda")
);



// Configuracion ApplicationInsights

//builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();
// Services


// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
