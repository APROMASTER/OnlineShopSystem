using Microsoft.Extensions.DependencyInjection;
using Practica1_programacion2.Application.Contract;
using Practica1_programacion2.Application.Service;
using Practica1_programacion2.Infrastructure.Interfaces;
using Practica1_programacion2.Infrastructure.Repositories;

namespace Practica1_programacion2.Ioc.Dependencies
{
    public static class EmployeeDependency
    {
        public static void AddEmployeeDependency(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
        }
    }
}
