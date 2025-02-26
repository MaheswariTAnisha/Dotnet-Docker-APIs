using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configure the app to use a specific URL
builder.WebHost.UseUrls("http://0.0.0.0:80");

// Add services for Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger UI in development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Uncomment this if you need HTTPS redirection
// app.UseHttpsRedirection();

// Simple Hello World API
app.MapGet("/hello", () => "Hello from .NET API!")
   .WithName("HelloAPI")
   .WithOpenApi();

app.Run();
