using Microsoft.EntityFrameworkCore;
using MiniBusManagement.Repository.Data;
using MiniBusManagement.Service.Administration;
using MiniBusManagement.Repository.Administration;
using MiniBusManagement.Api;

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
