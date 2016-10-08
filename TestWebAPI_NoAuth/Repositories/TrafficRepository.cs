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
        public IEnumerable<ShipApptModel> GetShipAll(DateTime d)
        {
            SqlConnection conn = new SqlConnection(_InCConnString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = default(SqlDataReader);

            List<ShipApptModel> apptList = new List<ShipApptModel>();

            using (conn)
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "API_TRAF_LKU_proc_Ship_Appts_ByDate";
                cmd.Connection = conn;

                HelpersMethods.AddParamToSQLCmd(cmd, "@date", SqlDbType.DateTime, 8, ParameterDirection.Input, d);

                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    ShipApptModel appt = new ShipApptModel();

                    appt.ApptID = (int)rdr["ApptID"];
                    appt.ApptDate = (DateTime)rdr["ApptDate"];
                    appt.SlotTime = (string)rdr["SlotTime"];
                    appt.Customer = (string)rdr["CustName"];
                    appt.Carrier = (string)rdr["Carrier"];
                    appt.Notes = (string)rdr["Notes"];

                    apptList.Add(appt);
                }
            }
            return apptList;
        }

        public IEnumerable<RecvApptModel> GetRecvAll(DateTime d)
        {
            SqlConnection conn = new SqlConnection(_InCConnString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = default(SqlDataReader);

            List<RecvApptModel> apptList = new List<RecvApptModel>();

            using (conn)
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "API_TRAF_LKU_proc_Recv_Appts_ByDate";
                cmd.Connection = conn;

                HelpersMethods.AddParamToSQLCmd(cmd, "@date", SqlDbType.DateTime, 8, ParameterDirection.Input, d);

                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    RecvApptModel appt = new RecvApptModel();

                    appt.ApptID = (int)rdr["ApptID"];
                    appt.ApptDate = (DateTime)rdr["ApptDate"];
                    appt.SlotTime = (string)rdr["SlotTime"];
                    appt.Customer = (string)rdr["CustName"];
                    appt.Carrier = (string)rdr["Carrier"];
                    appt.Notes = (string)rdr["Notes"];

                    apptList.Add(appt);
                }
            }
            return apptList;
        }
    }
}