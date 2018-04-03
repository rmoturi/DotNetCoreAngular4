using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Location
    {
        public string ERPEmployerID { get; set; }
        public string LocationID { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public bool? Active { get; set; }
        public int? ADCountryCode { get; set; }
        public string ADCountryAbrv { get; set; }

        
        //[ERPEmployerID] [nvarchar] (50) NOT NULL,
        //[LocationID] [nvarchar] (50) NOT NULL,
        //[Name] [nvarchar] (50) NOT NULL,
        //[Address1] [nvarchar] (256) NULL,
        //[Address2] [nvarchar] (256) NULL,
        //[City] [nvarchar] (50) NULL,
        //[State] [nvarchar] (50) NULL,
        //[ZIP] [nvarchar] (50) NULL,
        //[Country] [nvarchar] (50) NULL,
        //[Active] [bit] NULL,
        //[ADCountryCode] [int] NULL,
        //[ADCountryAbrv] [varchar] (2) NULL,
    }

}
