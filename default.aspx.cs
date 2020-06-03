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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["strcon"].ConnectionString;
        Tool tool = new Tool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            try
            {
                this.DataList2.DataSource = tool.laydata("select * from SanPham");
                this.DataList2.DataBind();
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