﻿using System;

namespace Practica1_programacion2.Domain.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.creation_date = DateTime.Now;
            this.deleted = false;
        }
        public DateTime creation_date { get; set; }
        public int creation_user { get; set; }
        public DateTime? modify_date { get; set; }
        public Nullable<int> modify_user { get; set; }
        public Nullable<int> delete_user { get; set; }
        public DateTime? delete_date { get; set; }
        public bool deleted { get; set; }
    }
}
