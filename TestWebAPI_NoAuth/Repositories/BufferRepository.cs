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
    public class BufferRepository : IBufferRepository
    {
        string _InCConnString;

        public BufferRepository()
        {
            _InCConnString = WebConfigurationManager.ConnectionStrings["InC"].ConnectionString;
        }
        public IEnumerable<BufferModel> GetAll()
        {
            SqlConnection conn = new SqlConnection(_InCConnString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = default(SqlDataReader);

            List<BufferModel> bList = new List<BufferModel>();

            using (conn)
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "API_BUFFER_LKU_proc_All";
                cmd.Connection = conn;

                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while(rdr.Read())
                {
                    BufferModel b = new BufferModel();

                    b.CoilNo = (string)rdr["CoilNo"];
                    b.Recv = (DateTime)rdr["Recv"];
                    b.Name = (string)rdr["CustomerName"];
                    b.Matl = (string)rdr["Material"];
                    b.PN = (string)rdr["PNParent"];
                    b.Alloy = (string)rdr["Alloy"];
                    b.Gauge = (decimal)rdr["Gauge"];
                    b.Width = (decimal)rdr["Width"];
                    b.Length = (decimal)rdr["Length"];
                    b.Net = (int)rdr["Net"];
                    b.Gross = (int)rdr["Gross"];
                    b.IMPGross = (int)rdr["IMPGross"];
                    b.Loc = (string)rdr["Location"];

                    bList.Add(b);
                }

            }
            return bList;
        } // GetAll()

        public BufferModel GetCoilNo(string coilNo)
        {
            SqlConnection conn = new SqlConnection(_InCConnString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = default(SqlDataReader);

            BufferModel b = new BufferModel();

            using (conn)
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "API_BUFFER_LKU_proc_ByCoilNumber";
                cmd.Connection = conn;

                HelpersMethods.AddParamToSQLCmd(cmd, "@coilno", SqlDbType.NVarChar, 25, ParameterDirection.Input, coilNo);

                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    b.CoilNo = (string)rdr["CoilNo"];
                    b.Recv = (DateTime)rdr["Recv"];
                    b.Name = (string)rdr["CustomerName"];
                    b.Matl = (string)rdr["Material"];
                    b.PN = (string)rdr["PNParent"];
                    b.Alloy = (string)rdr["Alloy"];
                    b.Gauge = (decimal)rdr["Gauge"];
                    b.Width = (decimal)rdr["Width"];
                    b.Length = (decimal)rdr["Length"];
                    b.Net = (int)rdr["Net"];
                    b.Gross = (int)rdr["Gross"];
                    b.IMPGross = (int)rdr["IMPGross"];
                    b.Loc = (string)rdr["Location"];
                }

            }
            return b;
        } // GetCoilNo()
    }
}