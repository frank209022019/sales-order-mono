using Microsoft.EntityFrameworkCore;
using SalesOrder.Database;
using SalesOrder.Service.Interfaces;
using SalesOrder.Service.Services;
using SalesOrder.Shared.Utilities;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Database Context
builder.Services.AddDbContext<SalesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(SalesOrderContstants.DevConnectionStringName)).UseLazyLoadingProxies());

// Serilog
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console());

// Services
builder.Services.AddTransient<ISalesOrderService, SalesOrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();