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

			IQueryable<Location> locations = _dbContext.HRDW_Locations.Select(
					l => new Location
					{
						LocationID = l.LocationID.Trim(),
						ERPEmployerID = l.ERPEmployerID.Trim(),
						Name = l.Name.Trim(),
						Address1 = l.Address1,
						Address2 = l.Address2,
						City = l.City,
						State = l.State,
						ZIP = l.ZIP,
						Country = l.Country,
						Active = l.Active,
						ADCountryAbrv = l.ADCountryAbrv,
						ADCountryCode = l.ADCountryCode
					});
			return locations.ToList();

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
        public bool Put(string id, [FromBody]Location location)
        {
			location.LocationID = id;
			if (location == null)
			{
				throw new ArgumentNullException("location");
			}

			using (_dbContext)
			{
				var currLocation = _dbContext.HRDW_Locations.Single(l => l.LocationID == location.LocationID);

				if (currLocation != null)
				{
					currLocation.LocationID = location.LocationID;
					currLocation.ERPEmployerID = location.ERPEmployerID;

					int rowsAffected = _dbContext.SaveChanges();

					return rowsAffected > 0 ? true : false;
				}
				else
				{
					return false;
				}

			}
		}
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
