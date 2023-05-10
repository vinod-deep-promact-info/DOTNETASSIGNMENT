using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementAPI.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int employeeId { get; set; }
        [Required]
        [StringLength(30)]
        public string employeeName { get; set; }
        [Required]
        [Range(21, 100)]
        public int age { get; set; }
        [Required]
        public int departmentId { get; set; }
        [Required]
        public double salary { get; set; }
    }
}
