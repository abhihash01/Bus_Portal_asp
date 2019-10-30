<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" Theme="Skin1" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Project_v1.WebForm1" %>
<asp:Content ID="Content1"  ContentPlaceHolderID="head" runat="server">
    
<asp:Label ID="Label1" CssClass="title" Width="1000px" runat="server" Text="Login Page"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <asp:TextBox ID="TextBox1" runat="server">Username</asp:TextBox><br />
   <asp:TextBox TextMode="Password" ID="TextBox2" runat="server">Password</asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />&nbsp&nbsp&nbsp
    <asp:Button ID="Button2" runat="server" Text="Signup" OnClick="Button2_Click" /><br /><br />
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username required" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password required"  ControlToValidate="TextBox2"></asp:RequiredFieldValidator>

</asp:Content>
