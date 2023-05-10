using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmpDBContext _context;

        public DepartmentRepository(EmpDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            return await _context.Departments.FirstOrDefaultAsync(e => e.departmentId == departmentId);
        }

        public async Task<bool> AddDepartment(Department Department)
        {
            var result = await _context.Departments.AddAsync(Department);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDepartment(Department department)
        {
            var depart = await _context.Departments.FirstOrDefaultAsync(e => e.departmentId == department.departmentId);

            if (depart != null)
            {
                depart.departmentId = department.departmentId;
                depart.departmentName = department.departmentName;

                _context.Departments.Update(depart);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteDepartment(int departmentId)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(e => e.departmentId == departmentId);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
