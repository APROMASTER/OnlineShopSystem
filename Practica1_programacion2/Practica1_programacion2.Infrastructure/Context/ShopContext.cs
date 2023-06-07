using Microsoft.EntityFrameworkCore;
using Practica1_programacion2.Domain.Entities;

namespace Practica1_programacion2.Infrastructure.Context
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
        {

        }

        public ShopContext(DbContextOptions<ShopContext> options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
