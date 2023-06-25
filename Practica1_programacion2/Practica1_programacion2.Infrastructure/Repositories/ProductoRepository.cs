
using Practica1_programacion2.Domain.Entities;
using Practica1_programacion2.Domain.Repository;
using Practica1_programacion2.Infrastructure.Core;
using Practica1_programacion2.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Practica1_programacion2.Infrastructure.Repositories
{
    public class ProductoRepository : BaseRepository<Producto> , IProductoRepository
    {
        
    }
}
