using Newtonsoft.Json;
using Practica1_programacion2.Application.Dtos.Employee;
using Practica1_programacion2.Web.Models.Responses;
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
                employeeList = EmpleadoDataResponse.GetEmployeeListResponse(httpClientFactory, baseUrl);
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
                employeeDetail = EmpleadoDataResponse.GetEmployeeDetailResponse(id, httpClientFactory, baseUrl);
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
                employeeSaveResponse = EmpleadoDataResponse.GetEmployeeSaveResponse(employeeAddDto, httpClientFactory, baseUrl);
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
                employeeUpdateResponse = EmpleadoDataResponse.GetEmployeeUpdateResponse(employeeUpdateDto, httpClientFactory, baseUrl);
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
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<EmployeeHttpClientHandler> logger;
        private string baseUrl = string.Empty;
        public EmployeeHttpClientHandler(IHttpClientFactory httpClientFactory,
                               IConfiguration configuration,
                               ILogger<EmployeeHttpClientHandler> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"];
        }

        public EmployeeDetailResponse GetEmployee(int id)
        {
            EmployeeDetailResponse employeeDetail = new EmployeeDetailResponse();

            try
            {
                employeeDetail = EmpleadoDataResponse.EmployeeGetDetail($"{baseUrl}/Employee/GetEmployee?id={id}", httpClientFactory);
            }
            catch (Exception ex)
            {
                employeeDetail.success = false;
                employeeDetail.message = "Error conectando a la API de empleado";
                this.logger.LogError($"{employeeDetail.message}", ex.ToString());
            }

            return employeeDetail;
        }

        public EmployeeListResponse GetEmployees()
        {
            EmployeeListResponse employeeList = new EmployeeListResponse();

            try
            {
                employeeList = EmpleadoDataResponse.EmployeeGetList($"{baseUrl}/Employee/GetEmployees", httpClientFactory);
            }
            catch (Exception ex)
            {
                employeeList.success = false;
                employeeList.message = "Error obteniendo los empleados";
                this.logger.LogError($"{employeeList.message}", ex.ToString());
            }
            return employeeList;
        }

        public EmployeeSaveResponse Save(EmployeeAddDto employeeAddDto)
        {
            EmployeeSaveResponse employeeSaveResponse = new EmployeeSaveResponse();

            try
            {
                employeeSaveResponse = EmpleadoDataResponse.EmployeePostSave($"{baseUrl}/Employee/Save", employeeAddDto, httpClientFactory);
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
                employeeUpdateResponse = EmpleadoDataResponse.EmployeePostUpdate($"{baseUrl}/Employee/Update", employeeUpdateDto, httpClientFactory);
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
}
