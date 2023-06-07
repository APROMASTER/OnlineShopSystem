using Practica1_programacion2.Domain.Entities;
using Practica1_programacion2.Domain.Repository;
using Practica1_programacion2.Infrastructure.Core;
using System.Collections.Generic;
using System.Dynamic;

namespace Practica1_programacion2.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IRepositoryBase<Employee>
    {
        public override List<Employee> GetEntities()
        {
            return base.GetEntities();
        }
    }
}
