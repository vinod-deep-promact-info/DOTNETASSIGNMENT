using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _repo;
        public DepartmentsController(IDepartmentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            try
            {
                return Ok(await _repo.GetDepartments());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddDepartment(Department department)
        {
            try
            {
                if (department == null)
                    return BadRequest("Empty department posted");

                if (!ModelState.IsValid)
                    return BadRequest("Department data validation issue");

                bool isAdded = await _repo.AddDepartment(department);

                if (isAdded)
                    return StatusCode(StatusCodes.Status201Created, "New department created");
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating new department record");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating new department record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> UpdateDepartment(int id, Department department)
        {
            try
            {
                if (id != department.departmentId)
                    return BadRequest("Department ID mismatch");

                if (!ModelState.IsValid)
                    return BadRequest("Department data validation issue");

                var depart = await _repo.GetDepartment(id);

                if (depart == null)
                    return NotFound($"Department with Id = {id} not found");

                bool isUpdated = await _repo.UpdateDepartment(department);
                if (isUpdated)
                    return Ok("Old department updated");
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating department data");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating department data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteDepartment(int id)
        {
            try
            {
                var depart = await _repo.GetDepartment(id);

                if (depart == null)
                {
                    return NotFound($"Department with Id = {id} not found");
                }

                bool isDeleted = await _repo.DeleteDepartment(id);
                if (isDeleted)
                    return Ok($"Department with Id={id} deleted");
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting department data");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting department data");
            }
        }
    }

}
