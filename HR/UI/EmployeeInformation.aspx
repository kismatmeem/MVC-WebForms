<%@ Page Title="" Language="C#" MasterPageFile="~/HRSite.Master" AutoEventWireup="true" CodeBehind="EmployeeInformation.aspx.cs" Inherits="HR.UI.EmployeeInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 98%; margin-left: 19px;">
        <tr>
            <td style="height: 34px; width: 602px;">
                <asp:Label ID="Label1" runat="server" Text="EmployeeName"></asp:Label>
                <asp:TextBox ID="txtEmployeeName" runat="server" Width="219px"></asp:TextBox>
            </td>
            <td style="height: 34px"></td>
            <td style="height: 34px"></td>
        </tr>
        <tr>
            <td style="height: 26px; width: 602px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
            </td>
            <td style="height: 26px"></td>
            <td style="height: 26px"></td>
        </tr>
        <tr>
            <td style="width: 602px">&nbsp;<asp:Label ID="Label2" runat="server" Text="MobileNo"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtMobileNo" runat="server" Width="221px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 26px; width: 602px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblMobileNo" runat="server"></asp:Label>
            </td>
            <td style="height: 26px"></td>
            <td style="height: 26px"></td>
        </tr>
        <tr>
            <td style="height: 26px; width: 602px">
                <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtEmail" runat="server" Width="261px"></asp:TextBox>
            </td>
            <td style="height: 26px">&nbsp;</td>
            <td style="height: 26px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 26px; width: 602px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;-
            </td>
            <td style="height: 26px"></td>
            <td style="height: 26px"></td>
        </tr>
        <tr>
            <td style="height: 26px; width: 602px">
                <asp:Label ID="Label4" runat="server" Text="ID"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
            </td>
            <td style="height: 26px">&nbsp;</td>
            <td style="height: 26px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 26px; width: 602px">&nbsp;</td>
            <td style="height: 26px">&nbsp;</td>
            <td style="height: 26px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 602px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" Visible="False" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 602px">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="grdEmployee" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" OnRowCommand="grdEmployee_RowCommand" OnRowDeleting="grdEmployee_RowDeleting" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Name">
    <ItemTemplate>
        <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Eval("Employee Name") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Mobile No">
    <ItemTemplate>
        <asp:Label ID="lblMobileNo" runat="server" Text='<%# Eval("Mobile No") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Email">
    <ItemTemplate>
        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="ID">
    <ItemTemplate>
        <asp:Label ID="lblEmployeeID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

                       <%-- <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile No">
                            <ItemTemplate>
                                <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeID" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
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
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
