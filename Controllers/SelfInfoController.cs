using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/SelfInfo")]
    public class SelfInfoController : Controller
    {
        private readonly LocationsDbContext _dbContext;

        public SelfInfoController(LocationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/SelfInfo
        [HttpGet]
        public IEnumerable<EmployeeSelfInfo> Get(string col)
        {
			IQueryable<EmployeeSelfInfo> employeeSelfInfos = _dbContext.HRDW_Employee_SelfInfo.Select(
				si => new EmployeeSelfInfo {
					//UniversalGUID = si.UniversalGUID,
					//EmployerID = si.EmployerID.Trim(),
					LocationID = si.LocationID.Trim()
				}).Distinct();

			return employeeSelfInfos.ToList();
			//if(col == "Locations")
			//return _dbContext.HRDW_Employee_SelfInfo.Select(item => new EmployeeSelfInfo { LocationID = item.LocationID.Replace("<","").Replace(">","") }).Distinct().ToList();
			//return _dbContext.HRDW_Employee_SelfInfo.Select(item => new EmployeeSelfInfo { EmployerID = item.EmployerID.Replace("<", "").Replace(">", "") }).Distinct().ToList();
		}

    }
}
