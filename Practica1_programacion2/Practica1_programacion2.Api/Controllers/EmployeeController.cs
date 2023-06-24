using Microsoft.AspNetCore.Mvc;
using Practica1_programacion2.Application.Contract;
using Practica1_programacion2.Application.Dtos.Employee;
using Practica1_programacion2.Domain.Entities;
using Practica1_programacion2.Infrastructure.Interfaces;
using Practica1_programacion2.Infrastructure.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practica1_programacion2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("GetEmployees")]
        public IActionResult Get()
        {
            var result = this.employeeService.Get();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetEmployee")]
        public IActionResult Get([FromQuery] int id)
        {
            var result = this.employeeService.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] EmployeeAddDto employeeAddDto)
        {
            var result = this.employeeService.Save(employeeAddDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] EmployeeUpdateDto employeeUpdateDto)
        {
            var result = this.employeeService.Update(employeeUpdateDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        /*
        [HttpPost("Remove")]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            this.employeeRepository.Update(employee);
            return Ok();
        }*/


    }
}
