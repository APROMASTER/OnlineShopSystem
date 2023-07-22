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
                convertedEmployeeModelList.Add(ConvertEmployeeModelFromInfrastructureToWeb(employeeModels[i]));
            }
            return convertedEmployeeModelList;
        }

        public static EmployeeModel ConvertEmployeeModelFromInfrastructureToWeb(this Infrastructure.Models.EmployeeModel employeeModel)
        {
            EmployeeModel convertedEmployeeModel = new EmployeeModel
            {
                empid = employeeModel.empid,
                firstname = employeeModel.firstname,
                lastname = employeeModel.lastname,
                title = employeeModel.title,
                titleofcourtesy = employeeModel.titleofcourtesy,
                birthdate = employeeModel.birthdate.ToString("dd/MM/yyyy"),
                hiredate = employeeModel.hiredate.ToString("dd/MM/yyyy"),
                address = employeeModel.address,
                city = employeeModel.city,
                region = employeeModel.region,
                postalcode = employeeModel.postalcode,
                country = employeeModel.country,
                phone = employeeModel.phone
            };
            return convertedEmployeeModel;
        }

    }
}
