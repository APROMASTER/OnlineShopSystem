using Practica1_programacion2.Domain.Entities;
using Practica1_programacion2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using System.Text;

namespace Practica1_programacion2.Infrastructure.Extension
{
    public static class EmployeeExtension
    {
        public static EmployeeModel ConvertEmployeeEntityToModel(this Employee employee)
        {
            EmployeeModel employeeModel = new EmployeeModel()
            {
                empid = employee.empid,
                firstname = employee.firstname,
                lastname = employee.lastname,
                title = employee.title,
                titleofcourtesy = employee.titleofcourtesy,
                birthdate = employee.birthdate,
                hiredate = employee.hiredate,
                address = employee.address,
                city = employee.city,
                region = employee.region,
                postalcode = employee.postalcode,
                country = employee.country,
                phone = employee.phone
            };

            return employeeModel;
        }
    }
}
