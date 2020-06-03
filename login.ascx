<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.ascx.cs" Inherits="OnTap_1.login" %>
<style type="text/css">
    .auto-style1 {
        height: 26px;
    }
</style>
<div id="login">
    <table style="width: 375px;">
        <tr>
            <td>Tên Đăng Nhập</td>
            <td>
                <asp:TextBox ID="tbuser" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td class="auto-style1">Mật Khẩu</td>
            <td class="auto-style1">
                <asp:TextBox ID="tbpass" TextMode="Password" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" /></td>
            
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="Label1" runat="server"></asp:Label></td>
        </tr>
    </table>
</div>
