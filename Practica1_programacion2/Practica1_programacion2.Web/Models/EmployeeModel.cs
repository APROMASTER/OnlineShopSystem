namespace Practica1_programacion2.Web.Models
{
    public class EmployeeModel
    {
        public int empid { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string title { get; set; }
        public string titleofcourtesy { get; set; }
        public string birthdate { get; set; }
        public string hiredate { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string? region { get; set; }
        public string? postalcode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
    }
}
