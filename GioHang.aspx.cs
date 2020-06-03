using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnTap_1
{
    public partial class GioHang : System.Web.UI.Page
    {
        private string strcon = ConfigurationManager.ConnectionStrings["strcon"].ConnectionString;
        private Tool tool = new Tool();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            this.docData();           

        }

        private void docDataDB()
        {
            try
            {
                string sql = "select TenDN, DonHang.MaSP, TenSP, DonGia, SoLuong, SoLuong * DonGia as ThanhTien" +
                    " from DonHang, SanPham where SanPham.Masp = DonHang.MaSP";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, strcon);
                DataTable table = new DataTable();
                adapter.Fill(table);
                this.GridView1.DataSource = table;
                this.GridView1.DataBind();
                double tong = 0;
                foreach (DataRow row in table.Rows)
                {
                    double thanhtien = Convert.ToDouble(row["ThanhTien"]);
                    tong = tong + thanhtien;
                }
                this.lbtongtien.Text = tong + "vnd";
            }
            catch (SqlException er)
            {
                Response.Write(er.Message);
                throw;
            }
        }

        private void docData()
        {
            DataTable table = (DataTable)Session["giohang"];

            GridView1.DataSource = table;
            GridView1.DataBind();
            double tong = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                double thanhtien = Convert.ToDouble(table.Rows[i]["SoLuong"])
                    * Convert.ToDouble(table.Rows[i]["DonGia"]);
                tong = tong + thanhtien;
            }

            this.lbtongtien.Text = " Tổng thành tiền " + tong + " vnd";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["TenDN"] == null)
            {
                Response.Write("<script>alert('Dang Nhap'); </script>");
                return;
            }
            else
            {

                DataTable table = (DataTable)Session["giohang"];
                SqlCommand command;
                SqlConnection connection = new SqlConnection(strcon);
                connection.Open();

                foreach (DataRow row in table.Rows)
                {
                    string tendn = Request.Cookies["TenDN"].Value.ToString();
                    string masp = row["MaSP"].ToString();
                    string sl = row["SoLuong"].ToString();
                    this.Label1.Text = "Insert to table DonHang success !";
                    string sql = "select * from DonHang where TenDN ='" + tendn + "' and MaSP = '" + masp + "'";
                    command = new SqlCommand(sql, connection);


                    command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        command = new SqlCommand("update DonHang set SoLuong = SoLuong + " + sl + " where TenDN = '" + tendn + "' and MaSP = '" + masp + "'", connection);
                    }
                    else
                    {
                        reader.Close();
                        command = new SqlCommand("insert into donhang values('" + tendn + "','" + masp + "','" + sl + "')", connection);
                    }
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable dt = (DataTable)Session["giohang"];
            if (e.CommandName == "btEdit")
            {
                GridViewRow row = (GridViewRow)((Button)e.CommandSource).Parent.Parent;
                //string masp = ((Button)e.CommandSource).CommandArgument;
                string soluong = ((TextBox)row.FindControl("TextBox1")).Text;                
                dt.Rows[row.DataItemIndex]["SoLuong"] = soluong;
                string dongia = ((Label)row.FindControl("Label2")).Text;
                dt.Rows[row.DataItemIndex]["ThanhTien"] = Convert.ToDouble(soluong) * Convert.ToDouble(dongia);
                Session["giohang"] = dt;
            }
            else
            {
                GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).Parent.Parent;
                //string masp = ((LinkButton)e.CommandSource).CommandArgument;
                dt.Rows[row.DataItemIndex].Delete();
                Session["giohang"] = dt;
            }
            this.docData();
        }
    }
}


