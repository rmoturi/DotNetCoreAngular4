using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Models
{
    public class LocationsDataAccessLayer
    {
        private readonly LocationsDbContext _dbContext;

        public LocationsDataAccessLayer(LocationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //To View all employees details
        public IEnumerable<Location> GetAllLocations()
        {
            try
            {
                List<Location> lstLocations = new List<Location>();
                using (SqlConnection con = new SqlConnection(_dbContext.ConnStr))
                {
                    SqlCommand cmd = new SqlCommand("select top 10 * from HRDW_Locations", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())

                    {
                        Location location = new Location();
                        location.LocationID = rdr["LocationID"].ToString() ?? String.Empty;
                        location.ERPEmployerID = rdr["ERPEmployerID"].ToString() ?? String.Empty;
                        location.Name = rdr["Name"].ToString() ?? String.Empty;
                        location.Address1 = ""; //rdr["Address1"].ToString() ?? String.Empty;
                        location.City = ""; //rdr["City"].ToString() ?? String.Empty;
                        location.State = ""; //rdr["State"].ToString() ?? String.Empty;
                        location.ZIP = ""; // rdr["ZIP"].ToString() ?? String.Empty;
                        location.Country = ""; //rdr["Country"].ToString() ?? String.Empty;
                        location.Active = true; //Boolean.TryParse(rdr["Active"].ToString(), out bool failed);
                        location.ADCountryCode = 0; //Convert.ToInt32(rdr["ADCountryCode"] ?? 0) ;
                        location.ADCountryAbrv = ""; //rdr["ADCountryAbrv"].ToString() ?? String.Empty;
                        lstLocations.Add(location);
                    }

                    con.Close();
                }

                return lstLocations;

            }
            catch
            {
                throw;
            }

        }

        public IEnumerable<EmployeeSelfInfo> GetSelfInfoLocations()
        {
            try
            {
                List<EmployeeSelfInfo> lstSILocations = new List<EmployeeSelfInfo>();
                using (SqlConnection con = new SqlConnection(_dbContext.ConnStr))
                {
                    SqlCommand cmd = new SqlCommand("select distinct LocationID FROM HRDW_Employee_SelfInfo", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())

                    {
                        EmployeeSelfInfo selfInfoModel = new EmployeeSelfInfo();
                        selfInfoModel.LocationID = rdr["LocationID"].ToString() ?? String.Empty;
                        lstSILocations.Add(selfInfoModel);
                    }

                    con.Close();
                }

                return lstSILocations;

            }
            catch
            {
                throw;
            }

        }

        public IEnumerable<EmployeeSelfInfo> GetSelfInfoEmployerIDs()
        {
            try
            {
                List<EmployeeSelfInfo> lstSIEmployerIDs = new List<EmployeeSelfInfo>();
                using (SqlConnection con = new SqlConnection(_dbContext.ConnStr))
                {
                    SqlCommand cmd = new SqlCommand("select distinct ERPEmployerID FROM HRDW_Employee_SelfInfo", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())

                    {
                        EmployeeSelfInfo selfInfoModel = new EmployeeSelfInfo();
                        selfInfoModel.EmployerID = rdr["ERPEmployerID"].ToString() ?? String.Empty;
                        lstSIEmployerIDs.Add(selfInfoModel);
                    }

                    con.Close();
                }

                return lstSIEmployerIDs;

            }
            catch
            {
                throw;
            }

        }

    }
}
