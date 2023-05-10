using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagementAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmpDBContext _context;

        public EmployeeRepository(EmpDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.employeeId == employeeId);
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            var result = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(e => e.employeeId == employee.employeeId);

            if (emp != null)
            {
                emp.employeeId = employee.employeeId;
                emp.employeeName=employee.employeeName;
                emp.departmentId = employee.departmentId;
                emp.salary=employee.salary;
                emp.age=employee.age;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.employeeId == employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
