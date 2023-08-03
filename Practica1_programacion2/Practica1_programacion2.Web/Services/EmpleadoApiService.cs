using Newtonsoft.Json;
using Practica1_programacion2.Application.Dtos.Employee;
using Practica1_programacion2.Web.Models;
using Practica1_programacion2.Web.Models.Responses;
using System.Net.Http;
using System.Text;

namespace Practica1_programacion2.Web.Services
{
    public class EmpleadoApiService : IEmpleadoApiService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<EmpleadoApiService> logger;
        private string baseUrl = string.Empty;
        public EmpleadoApiService(IHttpClientFactory httpClientFactory,
                               IConfiguration configuration,
                               ILogger<EmpleadoApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"];
        }

        public EmployeeListResponse GetEmployees()
        {
            EmployeeListResponse employeeList = new EmployeeListResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($"{this.baseUrl}/Employee/GetEmployees").Result)
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
            }
            catch (Exception ex)
            {
                employeeList.success = false;
                employeeList.message = "Error obteniendo los empleados";
                this.logger.LogError($"{ employeeList.message }", ex.ToString());
            }
            return employeeList;
        }

        public EmployeeDetailResponse GetEmployee(int id)
        {
            EmployeeDetailResponse employeeDetail = new EmployeeDetailResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($"{this.baseUrl}/Employee/GetEmployee?id={id}").Result)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            employeeDetail = JsonConvert.DeserializeObject<EmployeeDetailResponse>(apiResponse);
                        }
                        else
                        {
                            employeeDetail.success = false;
                            employeeDetail.message = "Error conectando a la API de empleado";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                employeeDetail.success = false;
                employeeDetail.message = "Error conectando a la API de empleado";
                this.logger.LogError($"{employeeDetail.message}", ex.ToString());
            }
            
            return employeeDetail;
        }

        public EmployeeSaveResponse Save(EmployeeAddDto employeeAddDto)
        {
            EmployeeSaveResponse employeeSaveResponse = new EmployeeSaveResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(employeeAddDto), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync($"{this.baseUrl}/Employee/Save", content).Result)
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
            }
            catch (Exception ex)
            {
                employeeSaveResponse.success = false;
                employeeSaveResponse.message = "Error guardando el empleado";
                this.logger.LogError($"{employeeSaveResponse.message}", ex.ToString());
            }
            return employeeSaveResponse;
        }

        public EmployeeUpdateResponse Update(EmployeeUpdateDto employeeUpdateDto)
        {
            EmployeeUpdateResponse employeeUpdateResponse = new EmployeeUpdateResponse();
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(employeeUpdateDto), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PutAsync($"{this.baseUrl}/Employee/Update", content).Result)
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
            }
            catch (Exception ex)
            {
                employeeUpdateResponse.success = false;
                employeeUpdateResponse.message = "Error actualizando el empleado";
                this.logger.LogError($"{employeeUpdateResponse.message}", ex.ToString());
            }
            return employeeUpdateResponse;
        }

    }

    public class EmployeeHttpClientHandler : IEmpleadoApiService
    {
        public EmployeeDetailResponse GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public EmployeeListResponse GetEmployees()
        {
            throw new NotImplementedException();
        }

        public EmployeeSaveResponse Save(EmployeeAddDto employeeAddDto)
        {
            throw new NotImplementedException();
        }

        public EmployeeUpdateResponse Update(EmployeeUpdateDto employeeUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
