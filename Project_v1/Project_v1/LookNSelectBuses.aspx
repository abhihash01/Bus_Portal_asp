<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="LookNSelectBuses.aspx.cs" Inherits="Project_v1.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Source:<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp
    Destination: <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>&nbsp&nbsp&nbsp&nbsp
    Date: <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>&nbsp&nbsp&nbsp&nbsp


    <asp:SqlDataSource ID="BusDataSource2" runat="server" ConnectionString="<%$ConnectionStrings:database %>"

        SelectCommand="SELECT * FROM BusMasterRoute WHERE (Source=@Source) AND (Dest=@Dest) AND (Date=@Date)">
        <SelectParameters>
            <asp:ControlParameter Name="Source" ControlID="Label1" PropertyName="Text"  />
            <asp:ControlParameter Name="Dest" ControlID="Label2" PropertyName="Text"  />
            <asp:ControlParameter Name="Date" ControlID="Label3" PropertyName="Text"  />
           
        </SelectParameters>
        
        </asp:SqlDataSource>
    <asp:GridView OnSelectedIndexChanging="GridView2_SelectedIndexChanged1" DataKeyNames="BusNo" AllowSorting="true" AllowPaging="true" PageSize="3" DataSourceID="BusDataSource2" ID="GridView2" runat="server" Height="145px" Width="184px" AutoGenerateColumns="false" CellPadding="5" CellSpacing="5" AutoGenerateSelectButton="true">
        <Columns>
            <asp:BoundField DataField="BusNo" HeaderText="Route No" />
            <asp:BoundField DataField="Operator" SortExpression="Operator" HeaderText="Operator" />
            <asp:BoundField DataField="Source" HeaderText="Source" />
            <asp:BoundField DataField="Dest" HeaderText="Destination" />
            <asp:BoundField DataField="Date" HeaderText="Date" />
            <asp:BoundField DataField="Cost" SortExpression="Cost" HeaderText="Ticket Price" />
            <asp:BoundField DataField="RemainSeats" HeaderText="RemainSeats" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
