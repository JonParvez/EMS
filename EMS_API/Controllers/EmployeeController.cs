using EMS_BusinessLayer.Service;
using EMS_DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _EmployeeService;

        public EmployeeController(EmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;

        }
        //Add Employee  
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee Employee)
        {
            try
            {
                var employee = await _EmployeeService.AddEmployee(Employee);
                return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //Delete Employee  
        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(int Id)
        {
            try
            {
                if (_EmployeeService.DeleteEmployee(Id))
                    return Ok("Deleted Successfully!");
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //Delete Employee  
        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                if (_EmployeeService.UpdateEmployee(employee))
                    return Ok("Updated Successfully!");
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //GET All Employee by Name  
        [HttpGet("GetAllEmployeeById")]
        public IActionResult GetAllEmployeeById(int Id)
        {
            try
            {
                Employee employee = _EmployeeService.GetEmployeeById(Id);
                return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //GET All Employee  
        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employeeList = _EmployeeService.GetAllEmployees();
                return Ok(employeeList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
