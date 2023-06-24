using System;

namespace Practica1_programacion2.Infrastructure.Exceptions
{
    public class EmployeeException : Exception
    {
        public EmployeeException(string message) : base(message) 
        {
            
        }

        public class EmployeeDataException : Exception
        {
            public EmployeeDataException(string message) : base(message)
            {

            }

        }
    }
}
