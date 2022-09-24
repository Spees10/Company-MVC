using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WebApplication7.DAL.Entities
{

    [Table("District")]
    public class District
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string DistrictName { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }


        public virtual ICollection<Employee> Employee { get; set; }

    }
}
