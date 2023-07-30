using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practica1_programacion2.Application.Dtos.Employee;
using Practica1_programacion2.Web.Models;
using Practica1_programacion2.Web.Models.Responses;
using System.Text;

namespace Practica1_programacion2.Web.Controllers.Responses
{
    public static class EmpleadoDataResponse
    {
        public static List<EmployeeModel> GetEmployeeListResponse(HttpClientHandler httpClientHandler)
        {
            EmployeeListResponse employeeList = new EmployeeListResponse();

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                using (var response = httpClient.GetAsync("http://localhost:5298/api/Employee/GetEmployees").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        employeeList = JsonConvert.DeserializeObject<EmployeeListResponse>(apiResponse);
                    }
                }
                return employeeList.data;
            }
        }

        public static EmployeeModel GetEmployeeDetailResponse(HttpClientHandler httpClientHandler, int id)
        {
            EmployeeDetailResponse employeeDetail = new EmployeeDetailResponse();

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                using (var response = httpClient.GetAsync($"http://localhost:5298/api/Employee/GetEmployee?id={id}").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        employeeDetail = JsonConvert.DeserializeObject<EmployeeDetailResponse>(apiResponse);
                    }
                }
            }
            return employeeDetail.data;
        }

        public static bool GetEmployeeUpdateResponse(HttpClientHandler httpClientHandler, EmployeeUpdateDto employeeUpdate, out EmployeeUpdateResponse employeeUpdateResponse)
        {
            employeeUpdateResponse = new EmployeeUpdateResponse();

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employeeUpdate), Encoding.UTF8, "application/json");

                using (var response = httpClient.PostAsync("http://localhost:5298/api/Employee/Update", content).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        employeeUpdateResponse = JsonConvert.DeserializeObject<EmployeeUpdateResponse>(apiResponse);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
