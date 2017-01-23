using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebAPI_NoAuth.Models;
using TestWebAPI_NoAuth.Interfaces;
using TestWebAPI_NoAuth.Helpers;
using System.Web.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace TestWebAPI_NoAuth.Repositories
{
    public class OPCRepository : IOPCRepository
    {
        string _InCConnString;

        public OPCRepository()
        {
            _InCConnString = WebConfigurationManager.ConnectionStrings["InC"].ConnectionString;
        }

        //  Add all modes except Tail
        public void Add(OPCBindingModel opc)
        {
            // Get Density
            SqlConnection conn = new SqlConnection(_InCConnString);
            SqlCommand cmd = new SqlCommand();

            int errcode = 1;
            string errmsg = "INSERT_Mode ERROR";
            int opcID = 0;

            using (conn)
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "API_OPC_INSERT_proc_Mode";
                cmd.Connection = conn;

                HelpersMethods.AddParamToSQLCmd(cmd, "@opcid", SqlDbType.Int, 8, ParameterDirection.Input, opc.OPCID);
                HelpersMethods.AddParamToSQLCmd(cmd, "@catid", SqlDbType.Int, 8, ParameterDirection.Input, opc.CatID);
                HelpersMethods.AddParamToSQLCmd(cmd, "@secs", SqlDbType.Int, 8, ParameterDirection.Input, opc.Secs);            

                HelpersMethods.AddParamToSQLCmd(cmd, "@errcode", SqlDbType.Int, 8, ParameterDirection.Output);
                HelpersMethods.AddParamToSQLCmd(cmd, "@errmsg", SqlDbType.NVarChar, 50, ParameterDirection.Output);

                HelpersMethods.AddParamToSQLCmd(cmd, "@opcid", SqlDbType.Int, 8, ParameterDirection.Output);

                cmd.ExecuteNonQuery();

                errcode = Convert.ToInt32(cmd.Parameters["@errcode"].Value);
                errmsg = Convert.ToString(cmd.Parameters["@errmsg"].Value);

                // Need to handle errors here

                conn.Close();

            }         
        } // Add

        // Add Tail mode.  This closes the current OPC Interval
        // and start a new one.
        public int AddTail(OPCBindingModel opc)
        {         
            SqlConnection conn = new SqlConnection(_InCConnString);
            SqlCommand cmd = new SqlCommand();

            int errcode = 1;
            string errmsg = "INSERT_Tail ERROR";
            int opcID = 0;

            using (conn)
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "API_OPC_INSERT_proc_Tail";
                cmd.Connection = conn;

                HelpersMethods.AddParamToSQLCmd(cmd, "@opcid", SqlDbType.Int, 8, ParameterDirection.Input, opc.OPCID);
                HelpersMethods.AddParamToSQLCmd(cmd, "@catid", SqlDbType.Int, 8, ParameterDirection.Input, opc.CatID);
                HelpersMethods.AddParamToSQLCmd(cmd, "@secs", SqlDbType.Int, 8, ParameterDirection.Input, opc.Secs);

                HelpersMethods.AddParamToSQLCmd(cmd, "@errcode", SqlDbType.Int, 8, ParameterDirection.Output);
                HelpersMethods.AddParamToSQLCmd(cmd, "@errmsg", SqlDbType.NVarChar, 50, ParameterDirection.Output);

                HelpersMethods.AddParamToSQLCmd(cmd, "@opcid", SqlDbType.Int, 8, ParameterDirection.Output);

                cmd.ExecuteNonQuery();

                errcode = Convert.ToInt32(cmd.Parameters["@errcode"].Value);
                errmsg = Convert.ToString(cmd.Parameters["@errmsg"].Value);

                conn.Close();

            }

            // ---------------------------------------------
            // Throw expection if errcode <> 0 OR ProRpt = 0
            // ---------------------------------------------
            if (errcode != 0)
                throw new Exception(errmsg);
            else if (opcID == 0)
                throw new Exception(errmsg);
            else
                return opcID;
        } // AddTail
    }
}