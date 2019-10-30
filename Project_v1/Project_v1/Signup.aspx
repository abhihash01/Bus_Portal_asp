<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Project_v1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Label ID="Label1" CssClass="title" Width="1000px" runat="server" Text="Signup Page"></asp:Label>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server">Username</asp:TextBox><br />
   <asp:TextBox ID="TextBox2" runat="server">Password</asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click"  /><br />
    <asp:Label ID="Label2" runat="server"></asp:Label>
</asp:Content>
