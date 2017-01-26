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
        public int Add(OPCBindingModel opc)
        {
            // Get Density
            SqlConnection conn = new SqlConnection(_InCConnString);
            SqlCommand cmd = new SqlCommand();

            int errcode = 1;
            string errmsg = "INSERT_Mode ERROR";
            int modeID = 0;

            using (conn)
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "API_OPC_INSERT_proc_Mode";
                cmd.Connection = conn;

                HelpersMethods.AddParamToSQLCmd(cmd, "@opcid", SqlDbType.Int, 8, ParameterDirection.Input, opc.OPCID);
                HelpersMethods.AddParamToSQLCmd(cmd, "@cat", SqlDbType.NVarChar, 15, ParameterDirection.Input, opc.Cat);
                HelpersMethods.AddParamToSQLCmd(cmd, "@secs", SqlDbType.Int, 8, ParameterDirection.Input, opc.Secs);            

                HelpersMethods.AddParamToSQLCmd(cmd, "@errcode", SqlDbType.Int, 8, ParameterDirection.Output);
                HelpersMethods.AddParamToSQLCmd(cmd, "@errmsg", SqlDbType.NVarChar, 50, ParameterDirection.Output);

                HelpersMethods.AddParamToSQLCmd(cmd, "@modeid", SqlDbType.Int, 8, ParameterDirection.Output);

                cmd.ExecuteNonQuery();

                // Assign output parameters to variables
                errcode = Convert.ToInt32(cmd.Parameters["@errcode"].Value);
                errmsg = Convert.ToString(cmd.Parameters["@errmsg"].Value);
                modeID = Convert.ToInt32(cmd.Parameters["@modeid"].Value);

                conn.Close();

            }

            // ---------------------------------------------
            // Throw expection if errcode <> 0 OR OPCModeID = 0
            // ---------------------------------------------
            if (errcode != 0)
                throw new Exception(errmsg);
            else if (modeID == 0)
                throw new Exception(errmsg);
            else
                return modeID;
        } // Add

        // Add Tail mode.  This closes the current OPC Interval
        // and start a new one.
        public int AddTail(OPCBindingModel opc)
        {         
            SqlConnection conn = new SqlConnection(_InCConnString);
            SqlCommand cmd = new SqlCommand();

            int errcode = 1;
            string errmsg = "INSERT_Tail ERROR";
            int newOPCID = 0;

            using (conn)
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "API_OPC_INSERT_proc_Tail";
                cmd.Connection = conn;

                HelpersMethods.AddParamToSQLCmd(cmd, "@opcid", SqlDbType.Int, 8, ParameterDirection.Input, opc.OPCID);
                HelpersMethods.AddParamToSQLCmd(cmd, "@cc", SqlDbType.Int, 8, ParameterDirection.Input, opc.CC);
                HelpersMethods.AddParamToSQLCmd(cmd, "@cat", SqlDbType.NVarChar, 15, ParameterDirection.Input, opc.Cat);
                HelpersMethods.AddParamToSQLCmd(cmd, "@secs", SqlDbType.Int, 8, ParameterDirection.Input, opc.Secs);

                HelpersMethods.AddParamToSQLCmd(cmd, "@errcode", SqlDbType.Int, 8, ParameterDirection.Output);
                HelpersMethods.AddParamToSQLCmd(cmd, "@errmsg", SqlDbType.NVarChar, 50, ParameterDirection.Output);

                HelpersMethods.AddParamToSQLCmd(cmd, "@newid", SqlDbType.Int, 8, ParameterDirection.Output);

                cmd.ExecuteNonQuery();

                // Assign output parameters to variables
                errcode = Convert.ToInt32(cmd.Parameters["@errcode"].Value);
                errmsg = Convert.ToString(cmd.Parameters["@errmsg"].Value);
                newOPCID = Convert.ToInt32(cmd.Parameters["@newid"].Value);

                conn.Close();

            }

            // ---------------------------------------------
            // Throw expection if errcode <> 0 OR ProRpt = 0
            // ---------------------------------------------
            if (errcode != 0)
                throw new Exception(errmsg);
            else if (newOPCID == 0)
                throw new Exception(errmsg);
            else
                return newOPCID;
        } // AddTail
    }
}