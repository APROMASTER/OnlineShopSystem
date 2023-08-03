using Practica1_programacion2.Application.Dtos.Employee;
using Practica1_programacion2.Web.Models;
using Practica1_programacion2.Web.Models.Responses;

namespace Practica1_programacion2.Web.Services
{
    public interface IEmpleadoApiService
    {
        EmployeeListResponse GetEmployees();
        EmployeeDetailResponse GetEmployee(int id);
        EmployeeUpdateResponse Update(EmployeeUpdateDto employeeUpdateDto);
        EmployeeSaveResponse Save(EmployeeAddDto employeeAddDto);

    }
}
