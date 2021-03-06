﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OnTap_1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:DataList ID="DataList2" runat="server" RepeatColumns="4" CellPadding ="5">
        <ItemTemplate>
            <div id="item" style="width:200px; border:1px solid blue; display:block; padding:10px ;text-align:center";>
                <div class ="img">
                    <asp:Image ID="Image1" ImageUrl='<%# "~/image/"+ Eval("Image") %>' Width="100px" runat="server" />
                </div>
                <div class ="msp">
                   Mã SP: <%# Eval("MaSP") %> <br />
                   Tên SP: <%# Eval("TenSP") %> <br />
                   Đơn Giá: <%# Eval("DonGia","{0:0,0}")%> <br />
                </div>
                <div class="chitiet">
                    <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("MaSP") %>' runat="server" OnClick="LinkButton1_Click" >Chi tiết</asp:LinkButton>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>