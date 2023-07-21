using Practica1_programacion2.Application.Core;
using Practica1_programacion2.Application.Dtos.Employee;
using Practica1_programacion2.Domain.Entities;
using System;

namespace Practica1_programacion2.Application.Extensions
{
    public static class EmployeeAppExtension
    {
        public static ServiceResult IsValidEmployee(this EmployeeDto model)
        {
            ServiceResult result = new ServiceResult();

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

            return result;
        }

        public static Employee ConvertFromEmployeeAddDtoToEmployeeEntity(this EmployeeAddDto employeeAddDto)
        {
            return new Employee()
            {
                lastname = employeeAddDto.lastname,
                firstname = employeeAddDto.firstname,
                title = employeeAddDto.title,
                titleofcourtesy = employeeAddDto.titleofcourtesy,
                birthdate = employeeAddDto.birthdate,
                hiredate = employeeAddDto.hiredate,
                address = employeeAddDto.address,
                city = employeeAddDto.city,
                region = employeeAddDto.region,
                postalcode = employeeAddDto.postalcode,
                country = employeeAddDto.country,
                phone = employeeAddDto.phone,
                creation_date = employeeAddDto.modify_date,
                creation_user = employeeAddDto.modify_user.Value
            };
        }

        public static Employee ConvertFromEmployeeUpdateDtoToEmployeeEntity(this EmployeeUpdateDto employeeUpdateDto)
        {
            return new Employee()
            {
                empid = employeeUpdateDto.empid,
                lastname = employeeUpdateDto.lastname,
                firstname = employeeUpdateDto.firstname,
                title = employeeUpdateDto.title,
                titleofcourtesy = employeeUpdateDto.titleofcourtesy,
                birthdate = employeeUpdateDto.birthdate,
                hiredate = employeeUpdateDto.hiredate,
                address = employeeUpdateDto.address,
                city = employeeUpdateDto.city,
                region = employeeUpdateDto.region,
                postalcode = employeeUpdateDto.postalcode,
                country = employeeUpdateDto.country,
                phone = employeeUpdateDto.phone,
                modify_date = employeeUpdateDto.modify_date,
                modify_user = employeeUpdateDto.modify_user
            };
        }

        public static Employee ConvertFromEmployeeRemoveDtoToEmployeeEntity(this EmployeeRemoveDto employeeRemoveDto)
        {
            return new Employee()
            {
                empid = employeeRemoveDto.empid,
                deleted = employeeRemoveDto.deleted,
                delete_date = DateTime.Now,
                delete_user = employeeRemoveDto.modify_user.Value
            };
        }
    }
}
