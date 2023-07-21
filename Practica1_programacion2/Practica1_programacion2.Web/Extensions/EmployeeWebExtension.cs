using System.Net;
using EmployeeModel = Practica1_programacion2.Web.Models.EmployeeModel;

namespace Practica1_programacion2.Web.Extensions
{
    public static class EmployeeWebExtension
    {
        public static List<EmployeeModel> ConvertEmployeeModelsFromInfrastructureToWeb(this List<Infrastructure.Models.EmployeeModel> employeeModels)
        {
            List<EmployeeModel> convertedEmployeeModelList = new List<EmployeeModel>();
            
            for(int i = 0; i < employeeModels.Count; i++)
            {
                convertedEmployeeModelList.Add(new EmployeeModel
                {
                    empid = employeeModels[i].empid,
                    firstname = employeeModels[i].firstname,
                    lastname = employeeModels[i].lastname,
                    title = employeeModels[i].title,
                    titleofcourtesy = employeeModels[i].titleofcourtesy,
                    birthdate = employeeModels[i].birthdate.ToString("dd/MM/yyyy"),
                    hiredate = employeeModels[i].hiredate.ToString("dd/MM/yyyy"),
                    address = employeeModels[i].address,
                    city = employeeModels[i].city,
                    region = employeeModels[i].region,
                    postalcode = employeeModels[i].postalcode,
                    country = employeeModels[i].country,
                    phone = employeeModels[i].phone
                });
            }
            return convertedEmployeeModelList;
        }

    }
}
