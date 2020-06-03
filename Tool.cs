using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OnTap_1
{
    
    
    public class Tool
    {
        string strcon = ConfigurationManager.ConnectionStrings["strcon"].ConnectionString;
        SqlConnection connection;

        private void getConnect() {
            connection = new SqlConnection(strcon);
            connection.Open();
        }
        private void closeConnect()
        {
            if(connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public DataTable laydata(string sql)
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, strcon);
                adapter.Fill(table);
            }
            catch
            {
                table = null;
            }
            return table;
        }
        public DataTable getData(string sql)
        {
            DataTable table = new DataTable();
            try
            {
                getConnect();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(table);
            }
            catch 
            {
                table = null;
            }
            finally { closeConnect(); }
            return table;
        }

        public int updateData(string sql)
        {
            int kq = 0;
            try
            {
                getConnect();
                SqlCommand command = new SqlCommand(sql, connection);
                kq = command.ExecuteNonQuery();
            }
            catch 
            {
                kq = 0;
            }
            finally { closeConnect(); }
            return kq;
        }
    }
}