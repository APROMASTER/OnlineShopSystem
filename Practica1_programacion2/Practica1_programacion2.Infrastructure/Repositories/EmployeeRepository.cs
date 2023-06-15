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

namespace Practica1_programacion2.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private ILogger<EmployeeRepository> logger;
        private ShopContext context;

        public EmployeeRepository(ILogger<EmployeeRepository> logger,
                                ShopContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
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

        public override void Add(Employee entity)
        {

            if (this.Exists(cd => cd.firstname == entity.firstname))
            {
                throw new EmployeeException("El empleado ya existe");
            }

            //base.Add(entity);
            base.SaveChanges();
        }

        public override void Delete(Employee entity)
        {
            if (this.Exists(cd => cd.firstname == entity.firstname))
            {
                throw new EmployeeException("");
            }

            base.SaveChanges();
        }

        public override void Update(Employee entity)
        {
            base.Update(entity);
        }

    }
}
