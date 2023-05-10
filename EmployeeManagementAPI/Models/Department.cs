using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementAPI.Models
{
    [Table("department")]
    public class Department
    {
        [Key]
        public int departmentId { get; set; }
        [Required]
        [StringLength(50)]
        public string departmentName { get; set; }
    }
}
