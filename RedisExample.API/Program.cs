using Microsoft.EntityFrameworkCore;
using RedisExample.API.Models;
using RedisExample.API.Repository;
using RedisExampleApp.Cache;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("mydatabase");
});
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddSingleton<RedisService>(sp =>
{
    return new RedisService(builder.Configuration["CacheOptions:Url"]);
});
var app = builder.Build();
using var scope = app.Services.CreateScope();
var dbContext=scope.ServiceProvider.GetRequiredService<DbContext>();
dbContext.Database.EnsureCreated();
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
