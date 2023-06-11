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

        public override void Add(Employee entity)
        {

            if (this.Exists(cd => cd.FirstName == entity.FirstName))
            {
                throw new EmployeeException("");
            }

            base.SaveChanges();
        }

        public List<EmployeeModel> GetEmployees()
        {

            List<EmployeeModel> employees = new List<EmployeeModel>();

            try
            {
                employees = this.context.Employees.Select(de => new EmployeeModel()
                {
                    FirstName = de.FirstName,
                    LastName = de.LastName,
                    Title = de.Title,
                    TitleOfCourtesy = de.TitleOfCourtesy,
                    BirthDate = de.BirthDate,
                    HireDate = de.HireDate,
                    Address = de.Address,
                    City = de.City,
                    Region = de.Region,
                    PostalCode = de.PostalCode,
                    country = de.country,
                    Phone = de.Phone
                }).ToList();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo empleados", ex.ToString());
            }

            return employees;
        }
    }
}
