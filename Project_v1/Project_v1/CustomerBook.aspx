<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="CustomerBook.aspx.cs" Inherits="Project_v1.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <br />

     <asp:SqlDataSource ID="BusSource" runat="server" ConnectionString="<%$ConnectionStrings:database %>"

        SelectCommand="SELECT distinct Source FROM BusMasterRoute" />
    <asp:SqlDataSource ID="BusDest" runat="server" ConnectionString="<%$ConnectionStrings:database %>"

        SelectCommand="SELECT distinct Dest FROM BusMasterRoute" />
    

    Source: <asp:DropDownList DataSourceID="BusSource" DataTextField="Source" ID="DropDownList1" runat="server"></asp:DropDownList>&nbsp&nbsp&nbsp&nbsp&nbsp
    Destination:  <asp:DropDownList DataSourceID="BusDest" DataTextField="Dest" ID="DropDownList2" runat="server"></asp:DropDownList>&nbsp&nbsp&nbsp&nbsp&nbsp
    Date: <asp:TextBox ID="TextBox1" TextMode="Date" runat="server"></asp:TextBox><br /><br />
    <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click"  /><br /><br />






</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
