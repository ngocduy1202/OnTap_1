<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="OnTap_1.GioHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: inline-block">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="678px" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <%--<asp:BoundField HeaderText="TenDN"/>--%>
                <asp:BoundField HeaderText="Mã SP" DataField="MaSP" />
                <asp:BoundField HeaderText="Tên SP" DataField="TenSP" />
                <asp:TemplateField HeaderText="Số Lượng">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SoLuong") %>'></asp:TextBox>                        
                        <asp:Button ID="btedit" CommandName="btEdit" runat="server" Text="Sửa" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Đơn Giá">
                    <%--<EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DonGia") %>'></asp:TextBox>
                    </EditItemTemplate>--%>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("DonGia") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Thành Tiền">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ThanhTien") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btDel" runat="server" >Xoá</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lbtongtien" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("MaSP") %>' OnClick="Button1_Click" Text="Đặt Hàng" />
        <asp:Label ID="Label1" runat="server" ></asp:Label>
    </div>
</asp:Content>