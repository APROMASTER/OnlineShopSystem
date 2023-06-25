
using Microsoft.EntityFrameworkCore;
using Practica1_programacion2.Domain.Entities;

namespace Practica1_programacion2.Infrastructure.Context
{
    public class ShopContext : DbContext
    {
        public ShopContext()
        {

        }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }
        public DbSet<Producto> ProductionProducts { get; set; }
    }
}
