<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="ChiTiet.aspx.cs" Inherits="OnTap_1.ChiTiet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" Width="819px">
        <ItemTemplate>
            <div id="item" style="display:inline-block; width:700px; padding:20px">
                <div class="img" style="float:left">
                    <asp:Image ID="Image1" ImageUrl='<%#"~/image/" + Eval("Image") %>' Width="200px" runat="server" />
                </div>
                <div class="mota" style="display:block">
                   Tên SP: <asp:Label ID="Label1" runat="server" Text= '<%#Eval("TenSP") %>' ></asp:Label><br />

                   Mã SP: <asp:Label ID="Label2" runat="server" Text= '<%#Eval("MaSP") %>' ></asp:Label><br />

                    Mô Tả SP: <%#Eval("MoTa") %> <br />
                   Đơn Giá: <asp:Label ID="Label3" runat="server" ForeColor="Blue" Text='<%#Eval("DonGia","{0:0;0}") %>'></asp:Label> vnđ
                </div>
                <div class="control">
                    Số lượng    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                                </asp:DropDownList>
                    <asp:Button ID="Button1"  runat="server" CommandArgument='<%# Eval("MaSP") %>' Text="Đặt Hàng" OnClick="Button1_Click" /> <br />
                    <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("MaSP") %>' OnClick="LinkButton1_Click" runat="server">Giỏ Hàng</asp:LinkButton>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>