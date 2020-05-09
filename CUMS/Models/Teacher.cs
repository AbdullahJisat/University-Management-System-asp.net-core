using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CUMS.Models
{
    public class Teacher : ActionDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Image { get; set; }
        [ForeignKey("Designation")]
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public decimal CreditTaken { get; set; }
    }
}
