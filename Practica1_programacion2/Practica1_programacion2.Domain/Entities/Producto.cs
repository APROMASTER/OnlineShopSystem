

using Practica1_programacion2.Domain.Core;
using System;

namespace Practica1_programacion2.Domain.Entities
{
    public class Producto : BaseEntity
    {
        public int productid { get; set; }
         
        public string productname { get; set; }

        public int supplierid { get; set; }

        public int categoryid { get; set; }

        public byte unitprice { get; set; }

        public bool discontinued { get; set; }

                             

    }
}
