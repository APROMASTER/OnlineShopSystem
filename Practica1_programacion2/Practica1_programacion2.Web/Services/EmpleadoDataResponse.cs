using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practica1_programacion2.Application.Dtos.Employee;
using Practica1_programacion2.Web.Models;
using Practica1_programacion2.Web.Models.Responses;
using System.Text;

namespace Practica1_programacion2.Web.Services
{
    public static class EmpleadoDataResponse
    {
        public static EmployeeListResponse GetEmployeeListResponse(IHttpClientFactory httpClientFactory,
                                                                   string baseUrl)
        {
            EmployeeListResponse employeeList = new EmployeeListResponse();

            using (var httpClient = httpClientFactory.CreateClient())
            {
                using (var response = httpClient.GetAsync($"{baseUrl}/Employee/GetEmployees").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        employeeList = JsonConvert.DeserializeObject<EmployeeListResponse>(apiResponse);
                    }
                    else
                    {

                    }
                }
            }
            return employeeList;
        }

        public static EmployeeDetailResponse GetEmployeeDetailResponse(int id,
                                                              IHttpClientFactory httpClientFactory,
                                                              string baseUrl)
        {
            EmployeeDetailResponse employeeDetail = new EmployeeDetailResponse();

            using (var httpClient = httpClientFactory.CreateClient())
            {
                using (var response = httpClient.GetAsync($"{baseUrl}/Employee/GetEmployee?id={id}").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        employeeDetail = JsonConvert.DeserializeObject<EmployeeDetailResponse>(apiResponse);
                    }
                }
            }
            return employeeDetail;
        }

        public static EmployeeSaveResponse GetEmployeeSaveResponse(EmployeeAddDto employeeAddDto,
                                                                   IHttpClientFactory httpClientFactory,
                                                                   string baseUrl)
        {
            EmployeeSaveResponse employeeSaveResponse = new EmployeeSaveResponse();

            using (var httpClient = httpClientFactory.CreateClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employeeAddDto), Encoding.UTF8, "application/json");

                using (var response = httpClient.PostAsync($"{baseUrl}/Employee/Save", content).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        employeeSaveResponse = JsonConvert.DeserializeObject<EmployeeSaveResponse>(apiResponse);
                    }
                    else
                    {

                    }
                }
            }
            return employeeSaveResponse;
        }

        public static EmployeeUpdateResponse GetEmployeeUpdateResponse(EmployeeUpdateDto employeeUpdateDto,
                                                     IHttpClientFactory httpClientFactory,
                                                     string baseUrl)
        {
            EmployeeUpdateResponse employeeUpdateResponse = new EmployeeUpdateResponse();

            using (var httpClient = httpClientFactory.CreateClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employeeUpdateDto), Encoding.UTF8, "application/json");

                using (var response = httpClient.PostAsync($"{baseUrl}/Employee/Update", content).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        employeeUpdateResponse = JsonConvert.DeserializeObject<EmployeeUpdateResponse>(apiResponse);
                    }
                    else
                    {
                        
                    }
                }
            }
            return employeeUpdateResponse;
        }

        public static EmployeeListResponse EmployeeGetList(string url, 
                                                  IHttpClientFactory httpClientFactory)
        {
            EmployeeListResponse employeeResponse = new EmployeeListResponse();

            using (var httpClient = httpClientFactory.CreateClient())
            {
                using (var response = httpClient.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        employeeResponse = JsonConvert.DeserializeObject<EmployeeListResponse>(apiResponse);
                    }
                    else
                    {

                    }
                }
            }
            return employeeResponse;
        }

        public static EmployeeDetailResponse EmployeeGetDetail(string url,
                                                  IHttpClientFactory httpClientFactory)
        {
            EmployeeDetailResponse employeeResponse = new EmployeeDetailResponse();

            using (var httpClient = httpClientFactory.CreateClient())
            {
                using (var response = httpClient.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        employeeResponse = JsonConvert.DeserializeObject<EmployeeDetailResponse>(apiResponse);
                    }
                    else
                    {

                    }
                }
            }
            return employeeResponse;
        }

        public static EmployeeSaveResponse EmployeePostSave(string url,
                                                EmployeeAddDto employeeDto,
                                                IHttpClientFactory httpClientFactory)
        {
            EmployeeSaveResponse employeeResponse = new EmployeeSaveResponse();

            using (var httpClient = httpClientFactory.CreateClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employeeDto), Encoding.UTF8, "application/json");

                using (var response = httpClient.PostAsync(url, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        employeeResponse = JsonConvert.DeserializeObject<EmployeeSaveResponse>(apiResponse);
                    }
                    else
                    {

                    }
                }
            }
            return employeeResponse;
        }

        public static EmployeeUpdateResponse EmployeePostUpdate(string url,
                                                EmployeeUpdateDto employeeDto,
                                                IHttpClientFactory httpClientFactory)
        {
            EmployeeUpdateResponse employeeResponse = new EmployeeUpdateResponse();

            using (var httpClient = httpClientFactory.CreateClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employeeDto), Encoding.UTF8, "application/json");

                using (var response = httpClient.PostAsync(url, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        employeeResponse = JsonConvert.DeserializeObject<EmployeeUpdateResponse>(apiResponse);
                    }
                    else
                    {

                    }
                }
            }
            return employeeResponse;
        }
    }
}
