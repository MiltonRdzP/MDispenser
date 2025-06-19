using MDispenser.Infrastructure;
using MDispenser.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services from Application and Infrastructure layers
builder.Services.AddApplication(); // You can define this extension
builder.Services.AddInfrastructure(builder.Configuration); // Already exists

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MDispenser API V1");
        c.RoutePrefix = string.Empty; // <- Opens Swagger UI at root URL: https://localhost:7211/
    });
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
