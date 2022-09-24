using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7.DAL.Entities
{

    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public float Salary { get; set; }

        public string Address { get; set; }

        public DateTime HireDate { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public string Notes { get; set; }

        public int DepartmentId { get; set; }

        public int DistrictId { get; set; }

        public string PhotoName { get; set; }
        public string CvName { get; set; }


        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        [ForeignKey("DistrictId")]
        public District District { get; set; }

    }
}
