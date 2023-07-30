using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practica1_programacion2.Application.Dtos.Employee;
using Practica1_programacion2.Web.Controllers.Responses;
using Practica1_programacion2.Web.Models.Responses;
using System.Text;

namespace Practica1_programacion2.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public EmpleadoController(IConfiguration configuration) 
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            return View(EmpleadoDataResponse.GetEmployeeListResponse(this.httpClientHandler));
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View(EmpleadoDataResponse.GetEmployeeDetailResponse(this.httpClientHandler, id));
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
                EmployeeSaveResponse result;

                if (EmpleadoDataResponse.GetEmployeeSaveResponse(this.httpClientHandler, employeeAddDto, out result))
                {
                    if (!result.success)
                    {
                        ViewBag.Message = result.message;
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "Error creando el empleado";
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
            return View(EmpleadoDataResponse.GetEmployeeDetailResponse(this.httpClientHandler, id));
        }

        // POST: EmployeeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeUpdateDto employeeUpdate)
        {
            try
            {
                EmployeeUpdateResponse result;

                if (EmpleadoDataResponse.GetEmployeeUpdateResponse(this.httpClientHandler, employeeUpdate, out result))
                {
                    if (!result.success)
                    {
                        ViewBag.Message = result.message;
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "Error actualizando el empleado";
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
