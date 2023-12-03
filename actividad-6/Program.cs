using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using actividad_6.Data;
using actividad_6.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<actividad_6Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("actividad_6Context") ?? throw new InvalidOperationException("Connection string 'actividad_6Context' not found.")));

// Add services to the container.

builder.Services.AddControllers();

// Configurar servicios de autorización con políticas personalizadas
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Enter", policy =>
    {
        policy.RequireAuthenticatedUser();
        // Otros requisitos para la política...
    });
    // Puedes agregar más políticas según sea necesario
});



// Configuración del servicio de autenticación JWT
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // Configura tu lógica de validación de tokens aquí
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:7011", // Asegúrate de reemplazar esto con tu emisor
            ValidAudience = "Usuarios", // Asegúrate de reemplazar esto con tu audiencia
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("xTNE|~zf!a9YX$)i,ovls|y{}]_&k,9*\r\n")) // Reemplaza con tu clave secreta
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Aquí registras el middleware personalizado
app.UseMiddleware<LoggingMiddleware>();


app.Run();
