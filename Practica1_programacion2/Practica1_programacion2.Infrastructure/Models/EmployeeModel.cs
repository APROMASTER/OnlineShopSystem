using System;

namespace Practica1_programacion2.Infrastructure.Models
{
    public class EmployeeModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string country { get; set; }
        public string Phone { get; set; }
    }
}
