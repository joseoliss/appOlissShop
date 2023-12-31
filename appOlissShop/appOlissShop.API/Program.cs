using Microsoft.EntityFrameworkCore;

using appOlissShop.Repositorio.Contrato;
using appOlissShop.Repositorio.Implementacion;
using appOlissShop.Repositorio.DBContext;
using appOlissShop.Utilidades;
using appOlissShop.Servicio.Contrato;
using appOlissShop.Servicio.Implementacion;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbEcommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlString"));
});

builder.Services.AddTransient(typeof(iGenericoReporitorio<>), typeof(GenericoRepositorio<>));
builder.Services.AddScoped<iVentaRepositorio, VentaRepositorio>();
builder.Services.AddScoped<iUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<iCategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<iDashboardService, DashboardServicio>();
builder.Services.AddScoped<iProductoServicio, ProductoServicio>();
builder.Services.AddScoped<iVentaServicio, VentaServicio>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(option =>
{
    option.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
