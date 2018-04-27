<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="SearchApp._Default" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%--    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>--%>

      <div>  

   <table>

    <tr>

    <td> 

       Search Employee

        </td>

        <td>

        <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox>

        </td>

        <td> 

        <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" />

        </td>

        

        </tr>
 

</table>

<table><tr><td><p><asp:Label ID="lblText" runat="server"></asp:Label>  </p></td></tr></table>

 

          <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

 

<asp:GridView ID="gvEmpDetails" runat="server"  Width="95%" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
              onpageindexchanging="gvEmpDetails_PageIndexChanging" AllowPaging="True" HeaderStyle-HorizontalAlign="Left"  AllowSorting="true"
              CellPadding="4" ForeColor="#333333" GridLines="None" 
              onsorting="gvEmpDetails_Sorting" >
    <AlternatingRowStyle BackColor="White" />
    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#990000" HorizontalAlign="Left" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    <SortedAscendingCellStyle BackColor="#FDF5AC" />
    <SortedAscendingHeaderStyle BackColor="#4D0000" />
    <SortedDescendingCellStyle BackColor="#FCF6C0" />
    <SortedDescendingHeaderStyle BackColor="#820000" />

    </asp:GridView> 

    </div>








</asp:Content>
