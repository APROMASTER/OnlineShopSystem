using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practica1_programacion2.Application.Dtos.Employee;
using Practica1_programacion2.Web.Models;
using Practica1_programacion2.Web.Models.Responses;
using Practica1_programacion2.Web.Services;

namespace Practica1_programacion2.Web.Controllers
{
    public class EmpleadoHttp : Controller
    {
        private readonly IEmpleadoApiService empleadoApiService;

        public EmpleadoHttp(IEmpleadoApiService empleadoApiService)
        {
            this.empleadoApiService = empleadoApiService;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            EmployeeListResponse employeeListResponse = new EmployeeListResponse();
            employeeListResponse = empleadoApiService.GetEmployees();


            return View(employeeListResponse.data);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            EmployeeDetailResponse employeeDetailResponse = new EmployeeDetailResponse();
            employeeDetailResponse = empleadoApiService.GetEmployee(id);

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
            EmployeeSaveResponse employeeSaveResponse = new EmployeeSaveResponse();
            employeeSaveResponse = empleadoApiService.Save(employeeAddDto);
            return View(employeeSaveResponse);
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeDetailResponse employeeDetailResponse = new EmployeeDetailResponse();
            employeeDetailResponse = empleadoApiService.GetEmployee(id);

            return View(employeeDetailResponse.data);
        }

        // POST: EmployeeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeUpdateDto employeeUpdateDto)
        {
            //EmployeeUpdateResponse employeeUpdateResponse = new EmployeeUpdateResponse();
            //employeeUpdateResponse = empleadoApiService.Update(employeeUpdateDto);
            return View();
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
