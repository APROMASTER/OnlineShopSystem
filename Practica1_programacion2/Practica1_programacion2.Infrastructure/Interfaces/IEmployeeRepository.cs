using Practica1_programacion2.Domain.Entities;
using Practica1_programacion2.Domain.Repository;
using Practica1_programacion2.Infrastructure.Models;
using System.Collections.Generic;

namespace Practica1_programacion2.Infrastructure.Interfaces
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        List<EmployeeModel> GetEmployees();
    }
}
