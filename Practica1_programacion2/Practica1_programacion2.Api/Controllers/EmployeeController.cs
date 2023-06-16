using Microsoft.AspNetCore.Mvc;
using Practica1_programacion2.Domain.Entities;
using Practica1_programacion2.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practica1_programacion2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeRepository employeeRepository { get; }
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("GetEmployees")]
        public IActionResult Get()
        {
            var employee = this.employeeRepository.GetEmployees();
            return Ok(employee);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = this.employeeRepository.GetEmployee(id);
            return Ok(employee);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] Employee employee)
        {
            this.employeeRepository.Add(employee);
            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            this.employeeRepository.Update(employee);
            return Ok();
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
