using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Security.Claims;

/// <summary>
/// Functions that are used in many pages of this project
/// </summary>
namespace TestWebAPI_NoAuth.Helpers
{
    public static class HelpersMethods
    {
        #region SQLHelpers
        private static string _InCConnString;

        // --------------------------------------------
        // InControl connection string
        // --------------------------------------------
        public static string InCConnString
        {
            get
            {
                string strName;

                // strName is the connectionstring Name in web.config
                strName = "InC";

                _InCConnString = WebConfigurationManager.ConnectionStrings[strName].ConnectionString;

                if (string.IsNullOrEmpty(_InCConnString))
                {
                    throw new NullReferenceException("InC Conn String is missing from web.config");
                }
                else
                {
                    return _InCConnString;
                }
            }

        } //InCConnString

        // ---------------------------------------------------------
        // Add input parameters to a SQL command object.  Overloaded
        // to accept a param value for input parameters
        // ---------------------------------------------------------
        public static void AddParamToSQLCmd(SqlCommand sqlCmd, string paramID,
                                        SqlDbType sqlType, int paramSize,
                                        ParameterDirection paramDirection, object paramValue)
        {
            //See VB code for some error checking to insert here

            SqlParameter newSqlParam = new SqlParameter();

            newSqlParam.ParameterName = paramID;
            newSqlParam.SqlDbType = sqlType;
            newSqlParam.Size = paramSize;
            newSqlParam.Direction = paramDirection;
            newSqlParam.Value = paramValue;

            sqlCmd.Parameters.Add(newSqlParam);
        }

        // ------------------------------------------------------
        // Overload for input parameter to allow proper config
        // of a Decimal SqlDbType paramSize=Precision, scale=Scale
        // -------------------------------------------------------
        public static void AddParamToSQLCmd(SqlCommand sqlCmd, string paramID,
                                        SqlDbType sqlType, int paramSize, int scale,
                                        ParameterDirection paramDirection, object paramValue)
        {
            //See VB code for some error checking to insert here

            SqlParameter newSqlParam = new SqlParameter();

            newSqlParam.ParameterName = paramID;
            newSqlParam.SqlDbType = sqlType;
            newSqlParam.Precision = (byte)paramSize;
            newSqlParam.Scale = (byte)scale;
            newSqlParam.Direction = paramDirection;
            newSqlParam.Value = paramValue;

            sqlCmd.Parameters.Add(newSqlParam);
        }

        // ---------------------------------------------------
        // Add output parameters to SQL comment object
        // ---------------------------------------------------
        public static void AddParamToSQLCmd(SqlCommand sqlCmd, string paramID,
                                        SqlDbType sqlType, int paramSize,
                                        ParameterDirection paramDirection)
        {
            //See VB code for some error checking to insert here

            SqlParameter newSqlParam = new SqlParameter();

            newSqlParam.ParameterName = paramID;
            newSqlParam.SqlDbType = sqlType;
            newSqlParam.Size = paramSize;
            newSqlParam.Direction = paramDirection;

            sqlCmd.Parameters.Add(newSqlParam);
        }

        #endregion

        #region OtherHelpers

        // Test for a decimal value. Will also work when
        // an integer value is entered in a field
        public static bool IsDecimal(string theValue)
        {
            try
            {
                Convert.ToDouble(theValue);
                return true;
            } 
            catch 
            {
                return false;
            }
        } //IsDecimal

        // Test for integer value.  Will return false,
        // if decimal value entered into a field
        public static bool IsInteger(string theValue)
        {
            try
            {
                Convert.ToInt32(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        } //IsInteger   

        #endregion
    }
}
