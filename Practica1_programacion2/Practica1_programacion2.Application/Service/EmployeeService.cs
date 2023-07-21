using Microsoft.Extensions.Logging;
using Practica1_programacion2.Application.Contract;
using Practica1_programacion2.Application.Core;
using Practica1_programacion2.Application.Dtos.Employee;
using Practica1_programacion2.Domain.Entities;
using Practica1_programacion2.Infrastructure.Interfaces;
using System;
using static Practica1_programacion2.Infrastructure.Exceptions.EmployeeException;
using Practica1_programacion2.Application.Extensions;

namespace Practica1_programacion2.Application.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ILogger<EmployeeService> logger;
        public EmployeeService(IEmployeeRepository employeeRepository, ILogger<EmployeeService> logger) 
        {
            this.employeeRepository = employeeRepository;
            this.logger = logger;
        }
        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var employees = this.employeeRepository.GetEmployees();
                result.Data = employees;
            }
            catch (EmployeeDataException eEx)
            {
                result.Success = false;
                result.Message = eEx.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los empleados";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var employee = this.employeeRepository.GetEmployee(id);
                result.Data = employee;
            }
            catch (EmployeeDataException eEx)
            {
                result.Success = false;
                result.Message = eEx.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el empleado";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(EmployeeAddDto model)
        {
            ServiceResult result = new ServiceResult();

            result = model.IsValidEmployee();
            if (!result.Success)
                return result;

            try
            {
                Employee employee = model.ConvertFromEmployeeAddDtoToEmployeeEntity();
                this.employeeRepository.Add(employee);

                result.Message = "Empleado creado correctamente";
            }
            catch (EmployeeDataException eEx)
            {
                result.Success = false;
                result.Message = eEx.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el empleado";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(EmployeeUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            result = model.IsValidEmployee();
            if (!result.Success)
                return result;

            try
            {
                Employee employee = model.ConvertFromEmployeeUpdateDtoToEmployeeEntity();
                this.employeeRepository.Update(employee);

                result.Message = "Empleado modificado correctamente";
            }
            catch (EmployeeDataException eEx)
            {
                result.Success = false;
                result.Message = eEx.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el empleado";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(EmployeeRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            if (!model.modify_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
                return result;
            }
            try
            {
                Employee employee = model.ConvertFromEmployeeRemoveDtoToEmployeeEntity();
                this.employeeRepository.Delete(employee);

                result.Message = "Empleado eliminado correctamente.";
            }
            catch (EmployeeDataException eEx)
            {
                result.Success = false;
                result.Message = eEx.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el producto.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
