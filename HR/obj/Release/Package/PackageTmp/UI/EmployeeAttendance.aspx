<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPageHR.master" AutoEventWireup="true" CodeBehind="EmployeeAttendance.aspx.cs" Inherits="HR.UI.EmployeeAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedContent" runat="server">
   
    <table style="width:100%;">
        <tr>
            <td style="width: 163px">&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label6" runat="server" Text="AttendanceID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAttendanceID" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 163px">&nbsp;</td>
            <td>
                <asp:Label ID="lblAttendanceID" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 163px">&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Text=" EmployeeID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmployeeID" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 163px">&nbsp;</td>
            <td>
                <asp:Label ID="lblEmployeeID" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 163px; height: 29px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label3" runat="server" Text="Date"></asp:Label>
            </td>
            <td style="height: 29px">
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td style="height: 29px"></td>
        </tr>
        <tr>
            <td style="width: 163px">&nbsp;</td>
            <td>
                <asp:Label ID="lblDate" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 163px">&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label5" runat="server" Text="Status"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Value="present">present</asp:ListItem>
                    <asp:ListItem Value="Absent">Absent</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 163px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 163px; height: 26px">&nbsp;</td>
            <td style="height: 26px">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
&nbsp;
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
&nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" Visible="False" />
            </td>
            <td style="height: 26px"></td>
        </tr>
        <tr>
            <td style="height: 26px" colspan="2">
                <asp:GridView ID="grdAttendance" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="grdAttendance_RowCommand" OnRowDeleting="grdAttendance_RowDeleting" OnSelectedIndexChanged="grdAttendance_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="AttendanceID">
                            <ItemTemplate>
                                <asp:Label ID="lblgrdAttendanceId" runat="server" Text='<%# Eval("AttendanceID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EmployeeID">
                            <ItemTemplate>
                                <asp:Label ID="lblgrdEmployeeID" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="lblgrdDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblgrdStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
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
