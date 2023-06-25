

using System;

namespace Practica1_programacion2.Infrastructure.Models
{
    public class ProductoModel
    {

        public int productid { get; set; }

        public string productname { get; set; }

        public int supplierid { get; set; }

        public int MyProperty { get; set; }

        public int categoryid { get; set; }

        public byte unitprice { get; set; }

        public bool discontinued { get; set; }

        public DateTime creation_date { get; set; }

        public int creation_user { get; set; }

        public DateTime? modify_date { get; set; }

        public int? modify_user { get; set; }


        public int? delete_user { get; set; }


        public DateTime? delete_date { get; set; }


        public bool deleted { get; set; }

    }
}
