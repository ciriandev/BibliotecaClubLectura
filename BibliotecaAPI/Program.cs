using BibliotecaAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexión a MariaDB
builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("BibliotecaDatabase"),
        new MySqlServerVersion(new Version(10, 6))
    )
);

// Otras configuraciones
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Biblioteca API v1");
        c.RoutePrefix = string.Empty; // Para que Swagger esté en la raíz
    });
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
