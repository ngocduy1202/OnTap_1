using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnTap_1
{
    public partial class ChiTiet : System.Web.UI.Page
    {
        private string strcon = ConfigurationManager.ConnectionStrings["strcon"].ConnectionString;
        private Tool tool = new Tool();
        private DataTable table;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string sql;

            if (Context.Items["msp"] == null)
            {
                sql = "select * from SanPham";
            }
            else
            {
                string masp = Context.Items["msp"].ToString();
                sql = "select * from SanPham where MaSP = '" + masp + "'";
            }
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, strcon);
                DataTable table = new DataTable();
                adapter.Fill(table);
                this.DataList1.DataSource = table;
                this.DataList1.DataBind();
            }
            catch (SqlException er)
            {
                Response.Write(er.Message);
            }
        }

        private void taoGioHang()
        {
            table = new DataTable();
            table.Rows.Clear();
            table.Columns.Add("TenDN", typeof(string));
            table.Columns.Add("MaSP", typeof(int));
            table.Columns.Add("TenSP", typeof(string));
            table.Columns.Add("SoLuong", typeof(int));
            table.Columns.Add("DonGia", typeof(int));
            table.Columns.Add("ThanhTien");
            Session["giohang"] = table;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("GioHang.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {   
            Button dh = (Button)sender;            
            //string tendn = Request.Cookies["TenDN"].ToString();
            string masp = dh.CommandArgument.ToString();
            DataListItem item = (DataListItem)dh.Parent;
            string sl = ((DropDownList)item.FindControl("DropDownList1")).SelectedItem.Text;
            string tensp = ((Label)item.FindControl("Label1")).Text;
            string dg = ((Label)item.FindControl("Label3")).Text;
            table = (DataTable)Session["giohang"];
            bool check = false;
            if (table == null) taoGioHang();
            foreach (DataRow dataRow in table.Rows)
            {
                if (dataRow["MaSP"].Equals(masp))
                {
                    if (dataRow["TenSP"].Equals(tensp))
                    {
                        dataRow["SoLuong"] = Convert.ToInt32(dataRow["SoLuong"]) + Convert.ToInt32(sl);
                        check = true; break;
                    }
                }
            }
            if (!check)
            {
                DataRow dataRow = table.NewRow();
                dataRow["TenDN"] = null;
                dataRow["MaSP"] = masp;
                dataRow["TenSP"] = tensp;
                dataRow["SoLuong"] = sl;
                dataRow["DonGia"] = dg;
                dataRow["ThanhTien"] = Convert.ToDouble(sl) * Convert.ToDouble(dg);
                table.Rows.Add(dataRow);
            }
            Session["giohang"] = table;
        }
    }
}