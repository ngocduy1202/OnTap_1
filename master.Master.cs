using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OnTap_1
{
    public partial class master : System.Web.UI.MasterPage
    {
        string strcon = ConfigurationManager.ConnectionStrings["strcon"].ConnectionString;
        Tool tool = new Tool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            try
            {
                //string sql = "select * from LoaiHang";
                //SqlDataAdapter adapter = new SqlDataAdapter(sql, strcon);
                //DataTable table = new DataTable();
                //adapter.Fill(table);
                this.DataList1.DataSource = tool.laydata("select * from LoaiHang");
                this.DataList1.DataBind();
            }
            catch (SqlException er)
            {
                Response.Write(er.Message);
                throw;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string maloai = ((LinkButton)sender).CommandArgument;
            Context.Items["ml"] = maloai;
            Server.Transfer("SanPham.aspx");
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string tendn = this.Login1.UserName;
            string mk = this.Login1.Password;
            string sql = "select * from KhachHang where TenDN = '" + tendn + "' and MatKhau = '" + mk + "'";
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, strcon);
                adapter.Fill(table);
            }
            catch (SqlException er)
            {
                Response.Write("<b>Error</b>" + er.Message + "<p/>");

            }
           
            if (table.Rows.Count != 0)
            {                               
                Response.Cookies["TenDN"].Value = tendn;
                Server.Transfer("GioHang.aspx");
            }
            else
            {
                this.Login1.FailureText = "wrong"; 
            }
        }
    }
}