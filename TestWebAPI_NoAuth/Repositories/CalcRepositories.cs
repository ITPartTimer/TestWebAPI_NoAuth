using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using TestWebAPI_NoAuth.Interfaces;
using TestWebAPI_NoAuth.Models;
using TestWebAPI_NoAuth.Helpers;

namespace TestWebAPI_NoAuth.Repositories
{
    public class CoilCalcRepository : ICoilCalcRepository
    {
        string _InCConnString;

        public CoilCalcRepository()
        {
            _InCConnString = WebConfigurationManager.ConnectionStrings["InC"].ConnectionString;
        }

        public IEnumerable<CoilCalcModel> Get(CoilCalcBindingModel calcInput)
        {
            // Get Density
            SqlConnection conn = new SqlConnection(_InCConnString);
            SqlCommand cmd = new SqlCommand();

            double density;

            using (conn)
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "API_CALC_LKU_proc_Density_ByMatl";
                cmd.Connection = conn;

                HelpersMethods.AddParamToSQLCmd(cmd, "@matl", SqlDbType.NVarChar, 12, ParameterDirection.Input, calcInput.Matl);

                // Only returns one value
                density = Convert.ToDouble(cmd.ExecuteScalar());
            }

            //Figure coil calc output
            List<CoilCalcModel> brkList = new List<CoilCalcModel>();

            //Base values used for all calculations
            double piw = calcInput.Net / calcInput.Width;
            double cutID = calcInput.CutID + (2 * calcInput.CutCore);

            double X, Y;

            for (int b = 0; b < 5; b++)
            {
                // Figure data for each break
                CoilCalcModel brk = new CoilCalcModel();

                brk.BrkNo = b;

                //Cut Lbs.  0 brk = piw/1, 1 brk = piw/2 and so on
                brk.CutLbs = Convert.ToInt16(calcInput.CutWidth * piw / (b + 1));
                brk.CutFt = Convert.ToInt16((brk.CutLbs / (calcInput.Gauge * calcInput.CutWidth * density))/12);

                //Break up components of OD calculation.  Easier to read.
                X = brk.CutLbs / (density * calcInput.CutWidth * Math.PI);
                Y = Math.Pow(cutID / 2, 2);
                brk.CutOD = Math.Sqrt(X + Y) * 2;
                brk.CutRise = (brk.CutOD - cutID) / 2;

                //Add to List<>
                brkList.Add(brk);
            }

            return brkList;
        }        
    }
}