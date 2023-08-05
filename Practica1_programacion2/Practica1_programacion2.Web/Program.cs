using Microsoft.EntityFrameworkCore;
using Practica1_programacion2.Ioc.Dependencies;
using Practica1_programacion2.Infrastructure.Context;
using Practica1_programacion2.Web.Services;
using Practica1_programacion2.Web.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Registro de dependencia base de datos
builder.Services.AddDbContext<ShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShopContext")));

// Registros de app services //
builder.Services.AddEmployeeDependency();

builder.Services.AddTransient<IEmpleadoApiService, EmpleadoApiService>();
builder.Services.AddTransient<EmpleadoController>();
builder.Services.AddTransient<EmpleadoApiService>();

builder.Services.AddTransient<IEmpleadoApiService, EmployeeHttpClientHandler>();
builder.Services.AddTransient<EmployeeHttpClientHandler>();
builder.Services.AddTransient<EmpleadoHttpController>();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
