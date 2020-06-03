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
    public partial class SanPham : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["strcon"].ConnectionString;
        Tool tool = new Tool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string sql;            
            if (Context.Items["ml"] == null)
            {
                sql = "select * from SanPham";
            }
            else
            {
                string maloai = Context.Items["ml"].ToString();
                sql = "select * from SanPham where MaLoai = '" + maloai + "'";
            }
            try
            {
                this.DataList1.DataSource = tool.laydata(sql);
                this.DataList1.DataBind();
            }
            catch (SqlException er)
            {
                Response.Write(er.Message);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string masp = ((LinkButton)sender).CommandArgument;
            Context.Items["msp"] = masp;
            Server.Transfer("ChiTiet.aspx");
        }
    }
}