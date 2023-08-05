using Microsoft.AspNetCore.Mvc;
using Practica1_programacion2.Application.Dtos.Employee;
using Practica1_programacion2.Web.Models.Responses;
using Practica1_programacion2.Web.Services;

namespace Practica1_programacion2.Web.Controllers
{
    public class EmpleadoHttpController : Controller
    {
        private readonly IEmpleadoApiService empleadoApiService;
        private readonly EmployeeHttpClientHandler employeeHttpClientHandler;

        public EmpleadoHttpController(IEmpleadoApiService empleadoApiService, EmployeeHttpClientHandler employeeHttpClientHandler)
        {
            this.employeeHttpClientHandler = employeeHttpClientHandler;
            this.empleadoApiService = empleadoApiService;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            EmployeeListResponse employeeListResponse = new EmployeeListResponse();
            employeeListResponse = employeeHttpClientHandler.GetEmployees();

            return View(employeeListResponse.data);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            EmployeeDetailResponse employeeDetailResponse = new EmployeeDetailResponse();
            employeeDetailResponse = employeeHttpClientHandler.GetEmployee(id);

            return View(employeeDetailResponse.data);
        }

        // GET: EmployeeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeAddDto employeeAddDto)
        {
            EmployeeSaveResponse result;

            try
            {
                result = employeeHttpClientHandler.Save(employeeAddDto);

                if (!result.success)
                {
                    ViewBag.Message = result.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeDetailResponse employeeDetailResponse = new EmployeeDetailResponse();
            employeeDetailResponse = employeeHttpClientHandler.GetEmployee(id);

            return View(employeeDetailResponse.data);
        }

        // POST: EmployeeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeUpdateDto employeeUpdateDto)
        {
            EmployeeUpdateResponse result;

            try
            {
                result = employeeHttpClientHandler.Update(employeeUpdateDto);

                if (!result.success)
                {
                    ViewBag.Message = result.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
