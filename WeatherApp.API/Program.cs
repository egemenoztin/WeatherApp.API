using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WeatherApp.API.Interfaces;
using WeatherApp.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IWeatherService, WeatherService>();

builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo
  {
    Title = "Weather API",
    Version = "v1",
    Description = "API for fetching weather data"
  });
});

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAngularApp",
      builder =>
      {
        builder.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
      });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather API v1");
  c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAngularApp");
app.UseAuthorization();
app.MapControllers();

app.Run();