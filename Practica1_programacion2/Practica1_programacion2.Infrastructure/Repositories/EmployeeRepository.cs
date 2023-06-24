using Microsoft.Extensions.Logging;
using Practica1_programacion2.Domain.Entities;
using Practica1_programacion2.Infrastructure.Context;
using Practica1_programacion2.Infrastructure.Core;
using Practica1_programacion2.Infrastructure.Exceptions;
using Practica1_programacion2.Infrastructure.Interfaces;
using Practica1_programacion2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Practica1_programacion2.Infrastructure.Extension;
using System.Net;
using System.Numerics;

namespace Practica1_programacion2.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly ILogger<EmployeeRepository> logger;
        private readonly ShopContext context;

        public EmployeeRepository(ILogger<EmployeeRepository> logger,
                                ShopContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public override void Add(Employee entity)
        {

            if (this.Exists(cd => cd.lastname == entity.lastname))
            {
                throw new EmployeeException("El empleado ya existe");
            }

            base.Add(entity);
            base.SaveChanges();
        }

        public override void Delete(Employee entity)
        {
            try
            {
                Employee employeeToRemove = base.GetEntity(entity.empid);

                if (employeeToRemove is null)
                    throw new EmployeeException("El empleado no existe.");


                employeeToRemove.deleted = true;
                employeeToRemove.delete_date = DateTime.Now;
                employeeToRemove.delete_user = entity.delete_user;

                base.Update(employeeToRemove);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error actualizando el empleado", ex.ToString());
            }
        }

        public override void Update(Employee entity)
        {
            try
            {
                Employee employeeToUpdate = base.GetEntity(entity.empid);

                if (employeeToUpdate is null)
                throw new EmployeeException("El empleado no existe.");

                entity.GetType().GetProperties().ToList().ForEach(cd =>
                {

                    var propertyValue = cd.GetValue(entity);

                    employeeToUpdate.GetType()
                                      .GetProperty(cd.Name)
                                      .SetValue(employeeToUpdate,
                                                propertyValue,
                                                null);
                });

                //employeeToUpdate.empid = entity.empid;
                //employeeToUpdate.firstname = entity.firstname;
                //employeeToUpdate.lastname = entity.lastname;
                //employeeToUpdate.title = entity.title;
                //employeeToUpdate.titleofcourtesy = entity.titleofcourtesy;
                //employeeToUpdate.birthdate = entity.birthdate;
                //employeeToUpdate.hiredate = entity.hiredate;
                //employeeToUpdate.address = entity.address;
                //employeeToUpdate.city = entity.city;
                //employeeToUpdate.region = entity.region;
                //employeeToUpdate.postalcode = entity.postalcode;
                //employeeToUpdate.country = entity.country;
                //employeeToUpdate.phone = entity.phone;
                //employeeToUpdate.modify_date = DateTime.Now;
                //employeeToUpdate.modify_user = entity.modify_user;

                base.Update(employeeToUpdate);
                base.SaveChanges();

            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error actualizando el empleado", ex.ToString());
            }
        }

        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();

            try
            {
                employees = this.context.Employees.Select(de => new EmployeeModel()
                {
                    empid = de.empid,
                    firstname = de.firstname,
                    lastname = de.lastname,
                    title = de.title,
                    titleofcourtesy = de.titleofcourtesy,
                    birthdate = de.birthdate,
                    hiredate = de.hiredate,
                    address = de.address,
                    city = de.city,
                    region = de.region,
                    postalcode = de.postalcode,
                    country = de.country,
                    phone = de.phone
                }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error obteniendo empleados: {ex.Message}", ex.ToString());
            }

            return employees;
        }

        public EmployeeModel GetEmployee(int employeeId)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            try
            {
                employeeModel = base.GetEntity(employeeId).ConvertEmployeeEntityToModel();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo el curso", ex.ToString());
            }
            return employeeModel;
        }
    }
}
