using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica1_programacion2.Application.Contract;
using Practica1_programacion2.Application.Dtos.Employee;
using Practica1_programacion2.Web.Extensions;

namespace Practica1_programacion2.Web.Controllers
{
    
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService) 
        { 
            this.employeeService = employeeService;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            var result = this.employeeService.Get();
            
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            var employees = EmployeeWebExtension.ConvertEmployeeModelsFromInfrastructureToWeb((List<Infrastructure.Models.EmployeeModel>)result.Data);

            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var result = this.employeeService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            var employee = EmployeeWebExtension.ConvertEmployeeModelFromInfrastructureToWeb((Infrastructure.Models.EmployeeModel)result.Data);

            return View(employee);
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
            try
            {
                var result = this.employeeService.Save(employeeAddDto);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
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
            var result = this.employeeService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            var employee = EmployeeWebExtension.ConvertEmployeeModelFromInfrastructureToWeb((Infrastructure.Models.EmployeeModel)result.Data);

            return View(employee);
        }

        // POST: EmployeeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeUpdateDto employeeUpdate)
        {
            try
            {
                var result = this.employeeService.Update(employeeUpdate);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
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
