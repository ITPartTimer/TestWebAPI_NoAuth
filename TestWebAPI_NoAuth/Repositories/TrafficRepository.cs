using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Linq;
using System.Web;
using TestWebAPI_NoAuth.Interfaces;
using TestWebAPI_NoAuth.Models;
using TestWebAPI_NoAuth.Helpers;

namespace TestWebAPI_NoAuth.Repositories
{
    public class TrafficRepository : ITrafficRepository
    {
        string _InCConnString;

        public TrafficRepository()
        {
            _InCConnString = WebConfigurationManager.ConnectionStrings["InC"].ConnectionString;
        }
        public IEnumerable<ShipApptModel> GetShipAll()
        {
            SqlConnection conn = new SqlConnection(_InCConnString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = default(SqlDataReader);

            List<ShipApptModel> apptList = new List<ShipApptModel>();

            // finish code here

            return apptList;
        }

        public IEnumerable<RecvApptModel> GetRecvAll()
        {
            SqlConnection conn = new SqlConnection(_InCConnString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = default(SqlDataReader);

            List<RecvApptModel> apptList = new List<RecvApptModel>();

            // finish code here

            return apptList;
        }
    }