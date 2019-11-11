﻿using System;
using System.Web;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace FooFoo
{
    /*
     - things that are related should be together 
     */
    public partial class Download : System.Web.UI.Page
    {
        private readonly DataTableToCsvMapper _dataTableToCsvMapper = new DataTableToCsvMapper();
        private readonly TableReader _tableReader = new TableReader();
        protected void Page_Load(object sender, EventArgs e)
        {
            ClearResponse();
            SetCacheability();

            WriteContentToResponse(GetCsv());
        }

        private byte[] GetCsv()
        {
            System.IO.MemoryStream ms = _dataTableToCsvMapper.Map(_tableReader.GetDataTable());

            byte[] byteArray = ms.ToArray();
            ms.Flush();
            ms.Close();
            return byteArray;
        }

        private void WriteContentToResponse(byte[] byteArray)
        {
            Response.Charset = System.Text.UTF8Encoding.UTF8.WebName;
            Response.ContentEncoding = System.Text.UTF8Encoding.UTF8;
            Response.ContentType = "text/comma-separated-values";
            Response.AddHeader("Content-Disposition", "attachment; filename=FooFoo.csv");
            Response.AddHeader("Content-Length", byteArray.Length.ToString());
            Response.BinaryWrite(byteArray);
        }

        private void SetCacheability()
        {
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.CacheControl = "private";
            Response.AppendHeader("Pragma", "cache");
            Response.AppendHeader("Expires", "60");
        }

        private void ClearResponse()
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Cookies.Clear();
        }
    }

    public class DataTableToCsvMapper
    {
        public MemoryStream Map(DataTable dataTable)
        {
            MemoryStream ReturnStream = new MemoryStream();
            
            StreamWriter sw = new StreamWriter(ReturnStream);
            WriteColumnNames(dataTable, sw);
            WriteRows(dataTable, sw);
            sw.Flush();
            sw.Close();
            
            return ReturnStream;
        }

        private static void WriteRows(DataTable dt, StreamWriter sw)
        {
            foreach (DataRow dr in dt.Rows)
            {
                WriteRow(dr, dt, sw);
            }
        }

        private static void WriteRow(DataRow dr, DataTable dt, StreamWriter sw)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                WriteCell(dr, i,sw);

                WriteSeparatorIfRequired(dt, i, sw);
            }
            sw.WriteLine();
        }

        private static void WriteSeparatorIfRequired(DataTable dt, int i, StreamWriter sw)
        {
            if (i < dt.Columns.Count - 1)
            {
                sw.Write(",");
            }
        }

        private static void WriteCell(DataRow dr, int i, StreamWriter sw)
        {
            if (!Convert.IsDBNull(dr[i]))
            {
                string str = String.Format("\"{0:c}\"", dr[i].ToString()).Replace("\r\n", " ");
                sw.Write(str);
            }
            else
            {
                sw.Write("");
            }
        }

        private static void WriteColumnNames(DataTable dt, StreamWriter sw)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < dt.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.WriteLine();
        }


    }
    public class TableReader
    {
        public DataTable GetDataTable()
        {
            string strConn = ConfigurationManager.ConnectionStrings["FooFooConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [FooFoo] ORDER BY id ASC", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "FooFoo");
            DataTable dt = ds.Tables["FooFoo"];
            return dt;
        }
    }
}