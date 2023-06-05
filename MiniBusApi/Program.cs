using Microsoft.EntityFrameworkCore;
using MiniBusManagement.Repositories.Data;
using MiniBusManagement.Services.Administration;
using MiniBusManagement.Repositories.Administration;
using MiniBusManagement.Api;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.ApplicationInsights.DependencyCollector;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddControllers(options => { 
//    options.ReturnHttpNotAcceptable = true; 
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
builder.Services.AddScoped<IMiniBusRepository, MinibusRepository>();
builder.Services.AddScoped<IMiniBusService, MiniBusService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JwtOptions>(
builder.Configuration.GetSection("Jwt"));

// Configuracion ApplicationInsights

//aiOptions.EnableAdaptiveSampling = false;
//aiOptions.EnableQuickPulseMetricStream = false;


//builder.Logging.AddApplicationInsights(
//        configureTelemetryConfiguration: (config) =>
//            config.ConnectionString = builder.Configuration.GetConnectionString("APPLICATIONINSIGHTS_CONNECTION_STRING"),
//            configureApplicationInsightsLoggerOptions: (options) => { }
//    );
//var aiOptions = new Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions();
builder.Services.AddApplicationInsightsTelemetry();

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
