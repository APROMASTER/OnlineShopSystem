using System;

namespace Practica1_programacion2.Application.Dtos
{
    public abstract class DtoBase
    {
        public DateTime modify_date { get; set; }
        public int modify_user { get; set; }
    }
}
