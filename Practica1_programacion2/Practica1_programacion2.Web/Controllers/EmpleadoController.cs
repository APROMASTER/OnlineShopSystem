using Microsoft.AspNetCore.Mvc;
using Practica1_programacion2.Application.Dtos.Employee;
using Practica1_programacion2.Web.Models.Responses;
using Practica1_programacion2.Web.Services;

namespace Practica1_programacion2.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoApiService empleadoApiService;

        public EmpleadoController(IEmpleadoApiService empleadoApiService)
        {
            this.empleadoApiService = empleadoApiService;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            EmployeeListResponse employeeList = new EmployeeListResponse();
            employeeList = empleadoApiService.GetEmployees();

            return View(employeeList.data);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            EmployeeDetailResponse employeeDetail = new EmployeeDetailResponse();
            employeeDetail = empleadoApiService.GetEmployee(id);

            return View(employeeDetail.data);
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
                result = empleadoApiService.Save(employeeAddDto);

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
            EmployeeDetailResponse employeeDetail = new EmployeeDetailResponse();
            employeeDetail = empleadoApiService.GetEmployee(id);

            return View(employeeDetail.data);
        }

        // POST: EmployeeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeUpdateDto employeeUpdateDto)
        {
            EmployeeUpdateResponse result;

            try
            {
                result = empleadoApiService.Update(employeeUpdateDto);

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
