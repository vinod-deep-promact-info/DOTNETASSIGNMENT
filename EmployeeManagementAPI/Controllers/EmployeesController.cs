using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;
        public EmployeesController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            try
            {
                return Ok(await _repo.GetEmployees());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var employee = await _repo.GetEmployee(id);

                if (employee == null) return NotFound();

                return employee;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest("Empty employee posted");

                if (!ModelState.IsValid)
                    return BadRequest("Employee data validation issue");

                bool isAdded = await _repo.AddEmployee(employee);

                if (isAdded)
                    return StatusCode(StatusCodes.Status201Created, "New employee created");
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating new employee record");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.employeeId)
                    return BadRequest("Employee ID mismatch");

                if (!ModelState.IsValid)
                    return BadRequest("Employee data validation issue");

                var emp = await _repo.GetEmployee(id);

                if (emp == null)
                    return NotFound($"Employee with Id = {id} not found");

                bool isUpdated = await _repo.UpdateEmployee(employee);
                if (isUpdated)
                    return Ok("Old employee updated");
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating employee data");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating employee data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteEmployee(int id)
        {
            try
            {
                var emp = await _repo.GetEmployee(id);

                if (emp == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                bool isDeleted = await _repo.DeleteEmployee(id);
                if (isDeleted)
                    return Ok($"Employee with Id={id} deleted");
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting employee data");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting employee data");
            }
        }
    }
}
