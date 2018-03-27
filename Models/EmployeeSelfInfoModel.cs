using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class EmployeeSelfInfo
    {
        [Key]
        public string UniversalGUID { get; set; }
        public string EmployerID { get; set; }
        public string LocationID { get; set; }
        //public ICollection<Location> Locations { get; set; }
    }
}
