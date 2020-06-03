using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnTap_1
{
    public partial class login : System.Web.UI.UserControl
    {
        
        string strcon = ConfigurationManager.ConnectionStrings["strcon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string tendn = tbuser.Text;
            string mk = tbpass.Text;
            string sql = "select * from KhachHang where TenDN ='" + tendn + "' and MatKhau ='" + mk + "'";
            //string sql = "select * from KhachHang where TenDN = '{0}' and MatKhau ='{1}'";
            //sql = string.Format(sql, tbuser.Text, tbpass.Text);
            SqlConnection connection = new SqlConnection(strcon);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count !=0)
            {
                //Label1.Text = "Sai TenDN hoặc MatKhau";
                Label1.Text = "Success!";
                Response.Cookies["TenDN"].Value = tendn;
                Server.Transfer("GioHang.aspx");
            }
            else
            {
                Label1.Text = "error";
                //Label1.Text = "Chào user " + table.Rows[0]["TenKhach"];
            }
           
        }
    }
}