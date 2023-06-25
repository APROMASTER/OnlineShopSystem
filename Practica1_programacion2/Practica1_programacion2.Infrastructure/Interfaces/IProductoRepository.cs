using Practica1_programacion2.Domain.Entities;
using Practica1_programacion2.Domain.Repository;
using System;

namespace Practica1_programacion2.Infrastructure.Interfaces
{
    public interface IProductoRepository : IBaseRepository<Producto>
    {
    }
}
