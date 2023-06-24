
using Practica1_programacion2.Application.Core;
using Practica1_programacion2.Application.Dtos.Employee;

namespace Practica1_programacion2.Application.Contract
{
    public interface IEmployeeService : IBaseService<EmployeeAddDto, EmployeeUpdateDto, EmployeeRemoveDto>
    {
    }
}
