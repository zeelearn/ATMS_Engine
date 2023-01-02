using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using ShoppingCart.DAL;
using System.Data.SqlClient;
using ShoppingCart.BL;
using System.Configuration;
////using Encryption.BL;
namespace ShoppingCart.BL
{
    public class Report
    {
        //All Functions for MT College Project

        //'Function to get Menu
        public static DataSet Get_Report_OpeningStock(int Flag, string Inward_Code, string Location_Type, string Div_Code, string Location, string materialcode, string Created_By)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            SqlParameter p2 = new SqlParameter("@InwardCode", Inward_Code);
            SqlParameter p3 = new SqlParameter("@Location_Type", Location_Type);
            SqlParameter p4 = new SqlParameter("@Div_Code", Div_Code);
            SqlParameter p5 = new SqlParameter("@Location", Location);
            SqlParameter p6 = new SqlParameter("@matrialcode", materialcode);
            SqlParameter p7 = new SqlParameter("@Created_By", Created_By);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Report_Opening_Stock", p1, p2, p3, p4, p5, p6,p7));
        }

        public static DataSet Get_Report_OpeningStock1(int Flag, string Inward_Code, string Location_Type, string Div_Code, string Location, string materialcode, string Created_By)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            SqlParameter p2 = new SqlParameter("@InwardCode", Inward_Code);
            SqlParameter p3 = new SqlParameter("@Location_Type", Location_Type);
            SqlParameter p4 = new SqlParameter("@Div_Code", Div_Code);
            SqlParameter p5 = new SqlParameter("@Location", Location);
            SqlParameter p6 = new SqlParameter("@matrialcode", materialcode);
            SqlParameter p7 = new SqlParameter("@Created_By", Created_By);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Report_Opening_Stock", p1, p2, p3, p4, p5, p6, p7));
        }

    }
}
