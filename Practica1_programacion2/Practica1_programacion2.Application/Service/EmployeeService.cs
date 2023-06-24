using Microsoft.Extensions.Logging;
using Practica1_programacion2.Application.Contract;
using Practica1_programacion2.Application.Core;
using Practica1_programacion2.Application.Dtos.Employee;
using Practica1_programacion2.Domain.Entities;
using Practica1_programacion2.Infrastructure.Interfaces;
using System;
using static Practica1_programacion2.Infrastructure.Exceptions.EmployeeException;

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

            try
            {
                if (string.IsNullOrEmpty(model.lastname))
                {
                    result.Message = "El apellido del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.lastname.Length > 20)
                {
                    result.Message = "La longitud del apellido es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.firstname))
                {
                    result.Message = "El nombre del nombre esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.firstname.Length > 10)
                {
                    result.Message = "La longitud del nombre es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.title))
                {
                    result.Message = "El titulo del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.title.Length > 30)
                {
                    result.Message = "La longitud del titulo es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.titleofcourtesy))
                {
                    result.Message = "El titulo de cortesia del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.titleofcourtesy.Length > 25)
                {
                    result.Message = "La longitud del titulo de cortesia es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.address))
                {
                    result.Message = "La direccion del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.address.Length > 60)
                {
                    result.Message = "La longitud de la direccion es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.city))
                {
                    result.Message = "La ciudad del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.city.Length > 15)
                {
                    result.Message = "La longitud de la ciudad es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.region))
                {
                    result.Message = "La region del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.region.Length > 15)
                {
                    result.Message = "La longitud de la region es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.postalcode))
                {
                    result.Message = "El titulo de codigo postal esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.postalcode.Length > 10)
                {
                    result.Message = "La longitud del codigo postal es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.country))
                {
                    result.Message = "El nombre del pais del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.country.Length > 15)
                {
                    result.Message = "La longitud del nombre del pais es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.phone))
                {
                    result.Message = "El numero de telefono del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.phone.Length > 24)
                {
                    result.Message = "La longitud del numero de telefono es invalida";
                    result.Success = false;
                    return result;
                }

                this.employeeRepository.Add(new Domain.Entities.Employee()
                {
                    lastname = model.lastname,
                    firstname = model.firstname,
                    title = model.title,
                    titleofcourtesy = model.titleofcourtesy,
                    birthdate = model.birthdate,
                    hiredate = model.hiredate,
                    address = model.address,
                    city = model.city,
                    region = model.region,
                    postalcode = model.postalcode,
                    country = model.country,
                    phone = model.phone,
                    creation_date = model.modify_date,
                    creation_user = model.modify_user.Value
                });

                result.Message = "Empleado Creado correctamente";
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

            try
            {
                if (string.IsNullOrEmpty(model.lastname))
                {
                    result.Message = "El apellido del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.lastname.Length > 20)
                {
                    result.Message = "La longitud del apellido es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.firstname))
                {
                    result.Message = "El nombre del nombre esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.firstname.Length > 10)
                {
                    result.Message = "La longitud del nombre es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.title))
                {
                    result.Message = "El titulo del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.title.Length > 30)
                {
                    result.Message = "La longitud del titulo es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.titleofcourtesy))
                {
                    result.Message = "El titulo de cortesia del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.titleofcourtesy.Length > 25)
                {
                    result.Message = "La longitud del titulo de cortesia es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.address))
                {
                    result.Message = "La direccion del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.address.Length > 60)
                {
                    result.Message = "La longitud de la direccion es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.city))
                {
                    result.Message = "La ciudad del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.city.Length > 15)
                {
                    result.Message = "La longitud de la ciudad es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.region))
                {
                    result.Message = "La region del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.region.Length > 15)
                {
                    result.Message = "La longitud de la region es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.postalcode))
                {
                    result.Message = "El titulo de codigo postal esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.postalcode.Length > 10)
                {
                    result.Message = "La longitud del codigo postal es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.country))
                {
                    result.Message = "El nombre del pais del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.country.Length > 15)
                {
                    result.Message = "La longitud del nombre del pais es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.phone))
                {
                    result.Message = "El numero de telefono del modelo esta vacio";
                    result.Success = false;
                    return result;
                }

                if (model.phone.Length > 24)
                {
                    result.Message = "La longitud del numero de telefono es invalida";
                    result.Success = false;
                    return result;
                }

                this.employeeRepository.Update(new Domain.Entities.Employee()
                {
                    empid = model.empid,
                    lastname = model.lastname,
                    firstname = model.firstname,
                    title = model.title,
                    titleofcourtesy = model.titleofcourtesy,
                    birthdate = model.birthdate,
                    hiredate = model.hiredate,
                    address = model.address,
                    city = model.city,
                    region = model.region,
                    postalcode = model.postalcode,
                    country = model.country,
                    phone = model.phone,
                    modify_date = model.modify_date,
                    modify_user = model.modify_user
                });

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
                this.employeeRepository.Delete(new Employee()
                {
                    empid = model.empid,
                    deleted = model.deleted,
                    delete_date = DateTime.Now,
                    delete_user = model.modify_user.Value,
                });

                result.Message = "Producto eliminado correctamente.";
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
