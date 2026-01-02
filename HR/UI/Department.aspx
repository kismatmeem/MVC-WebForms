<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPageHR.master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="HR.UI.Department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedContent" runat="server">
    <table style="width:100%;">
 
<tr>  <td style="width: 173px">
     <asp:Label ID="LabelDepartmentName" runat="server" Text="Department Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDepartmentName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 173px"></td>
            <td>
                <asp:Label ID="lblDepartmentName" runat="server" Visible="False"></asp:Label>
            </td>

</tr>
<tr>
    <td style="height: 26px; width: 173px">
        <asp:Label ID="label" runat="server" Text="Department Head"></asp:Label>
    </td>
    <td style="height: 26px">
        <asp:TextBox ID="txtDepartmentHead" runat="server"></asp:TextBox>
    </td>
    <td style="height: 26px"></td>
</tr>
<tr>
    <td style="height: 26px; width: 173px">&nbsp;</td>
    <td style="height: 26px">
        <asp:Label ID="lblDepartmentHead" runat="server"></asp:Label>
    </td>
    <td style="height: 26px">&nbsp;</td>
</tr>
<tr>
    <td style="height: 26px; width: 173px">
        Location</td>
    <td style="height: 26px">
        <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
    </td>
    <td style="height: 26px">&nbsp;</td>
</tr>
<tr>
    <td style="width: 173px; height: 26px"></td>
    <td style="height: 26px">
        <asp:Label ID="lblLocation" runat="server"></asp:Label>
    </td>
    <td style="height: 26px"></td>
</tr>
<tr>
    <td style="width: 173px; height: 26px">&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Dep_ID"></asp:Label>
    </td>
    <td style="height: 26px" id="txtDept_Id">
        <asp:TextBox ID="txtDep_ID" runat="server"></asp:TextBox>
    </td>
    <td style="height: 26px">&nbsp;</td>
</tr>
<tr>
    <td style="width: 173px; height: 26px">&nbsp;</td>
    <td style="height: 26px">
        <asp:Label ID="lblDep_ID" runat="server"></asp:Label>
    </td>
    <td style="height: 26px">&nbsp;</td>
</tr>
<tr>
    <td style="width: 173px; height: 26px">&nbsp;</td>
    <td style="height: 26px">
        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click"  />
        <asp:Button ID="btnSave" runat="server" Text="Save"  OnClick="btnSave_Click" />
&nbsp;
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"/>
&nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" Visible="False"/>
    </td>
    <td style="height: 26px">&nbsp;</td>
</tr>
<tr>
    <td style="height: 26px" colspan="2">
        <asp:GridView ID="grdDepartment" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="grdDepartment_RowCommand" OnRowDeleting="grdDepartment_RowDeleting" OnSelectedIndexChanged="grdDepartment_SelectedIndexChanged" Width="101%">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
               <asp:TemplateField HeaderText="DepartmentName">
    <ItemTemplate>
        <asp:Label ID="lblgrdDepartmentName" runat="server" Text='<%# Eval("DepartmentName") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="DepartmentHead">
    <ItemTemplate>
        <asp:Label ID="lblgrdDepartmentHead" runat="server" Text='<%# Eval("DepartmentHead") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Location">
    <ItemTemplate>
        <asp:Label ID="lblgrdLocation" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
                <asp:TemplateField HeaderText="Dep_ID">
    <ItemTemplate>
        <asp:Label ID="lblgrdDep_ID" runat="server" Text='<%# Eval("Dep_ID") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

                <%--<asp:TemplateField HeaderText="Dep_ID"></asp:TemplateField>--%>
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
