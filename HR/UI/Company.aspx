<%@ Page Title="" Language="C#" MasterPageFile="~/HRSite.Master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="HR.UI.Company" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
     <td style="width: 173px">
         <asp:Label ID="jhjh" runat="server" Text="CompanyID"></asp:Label>
     </td>
     <td>
         <asp:TextBox ID="txtCompanyID" runat="server"></asp:TextBox>
     </td>
     <td>&nbsp;</td>
 </tr>
        <tr>
     <td style="width: 173px">
         &nbsp;</td>
     <td>
         <asp:Label ID="lblCompanyID" runat="server"></asp:Label>
     </td>
     <td>&nbsp;</td>
 </tr>
        <tr>
     <td style="width: 173px">
         <asp:Label ID="Label1" runat="server" Text="Company Name"></asp:Label>
     </td>
     <td>
         <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
     </td>
     <td>&nbsp;</td>
 </tr>
 <tr>
     <td style="width: 173px">&nbsp;</td>
     <td>
         <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
     </td>
     <td>&nbsp;</td>
 </tr>
 <tr>
     <td style="height: 26px; width: 173px">
         <asp:Label ID="Label2" runat="server" Text="Adreess"></asp:Label>
     </td>
     <td style="height: 26px">
         <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
     </td>
     <td style="height: 26px"></td>
 </tr>
 <tr>
     <td style="height: 26px; width: 173px">&nbsp;</td>
     <td style="height: 26px">
         <asp:Label ID="lblAddress" runat="server"></asp:Label>
     </td>
     <td style="height: 26px">&nbsp;</td>
 </tr>
 <tr>
     <td style="height: 26px; width: 173px">
         <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
     </td>
     <td style="height: 26px">
         <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
     </td>
     <td style="height: 26px">&nbsp;</td>
 </tr>
 <tr>
     <td style="width: 173px; height: 26px"></td>
     <td style="height: 26px">
         <asp:Label ID="lblEmail" runat="server"></asp:Label>
     </td>
     <td style="height: 26px"></td>
 </tr>
 <tr>
     <td style="width: 173px; height: 26px">&nbsp;</td>
     <td style="height: 26px">
         <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
         <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
         <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" Visible="False" />
     </td>
     <td style="height: 26px">&nbsp;</td>
 </tr>
 <tr>
     <td style="height: 26px" colspan="2">
         <asp:GridView ID="grdCompany" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="grdCompany_RowCommand" OnRowDeleting="grdCompany_RowDeleting" OnSelectedIndexChanging="grdCompany_SelectedIndexChanging">
             <AlternatingRowStyle BackColor="White" />
             <Columns>
                 <asp:TemplateField HeaderText="CompanyID">
                     <ItemTemplate>
                         <asp:Label ID="lblCompanyID" runat="server" Text='<%# Eval("CompanyID") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="CompanyName">
                     <ItemTemplate>
                         <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Address">
                     <ItemTemplate>
                         <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Email">
                     <ItemTemplate>
                         <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:CommandField ShowSelectButton="True" />
                 <asp:CommandField ShowDeleteButton="True" />
             </Columns>
             <EditRowStyle BackColor="#2461BF" />
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
             <RowStyle BackColor="#EFF3FB" />
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             <SortedAscendingCellStyle BackColor="#F5F7FB" />
             <SortedAscendingHeaderStyle BackColor="#6D95E1" />
             <SortedDescendingCellStyle BackColor="#E9EBEF" />
             <SortedDescendingHeaderStyle BackColor="#4870BE" />
         </asp:GridView>
     </td>
     <td style="height: 26px">&nbsp;</td>
 </tr>
    </table>
</asp:Content>
