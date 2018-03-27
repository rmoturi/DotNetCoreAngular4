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
    [Route("api/Locations")]
    public class LocationsController : Controller
    {

        //https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings
        //https://msdn.microsoft.com/magazine/mt703433.aspx

        private readonly LocationsDbContext _dbContext;

        public LocationsController(LocationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Locations
        [HttpGet]
        public IEnumerable<Location> Get()
        {
            //return new string[] { "value1", "value2" };
            //Location locationModel1 = new Location { LocationID = "location 1" };
            //Location locationModel2 = new Location { LocationID = "location 2" };

            //List<Location> LocationsList = new List<Location>();
            //LocationsList.Add(locationModel1);
            //LocationsList.Add(locationModel2);

            //return LocationsList.AsEnumerable();

            return _dbContext.HRDW_Locations.ToList();

            //try
            //{
            //    LocationsDataAccessLayer LocDAL = new LocationsDataAccessLayer(_dbContext);
            //    return LocDAL.GetAllLocations();
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}   

        }

        // GET: api/Locations/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Locations
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Locations/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
