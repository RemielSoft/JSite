<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Misla_charges.aspx.cs"
    Inherits="JSVisaTrackingWebApplication.Misla_charges" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2 style="background-color: #FF6A6A">
            Miscellaneous Charges
        </h2>
    </div>
    <div>
        <table style="font-family: Arial, Helvetica, sans-serif" width="100%">
            <tr align="center">
                <td align="justify">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Description
                </td>
                <td align="justify">
                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                </td>
                <td align="justify">
                    Amount(INR)
                </td>
                <td align="justify">
                    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr align="center">
                <td align="justify">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Per Consignmend/Visa
                </td>
                <td colspan="1" align="justify">
                    <asp:DropDownList ID="drpvisa" runat="server" Width="50%">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="c" Text="Per Consignmend"></asp:ListItem>
                        <asp:ListItem Value="v" Text="Per Visa"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr align="center">
                <td align="justify">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Mandatory
                </td>
                <td align="justify">
                    <asp:CheckBox ID="CheckMandatory" runat="server" Text="Mandatory" />
                </td>
                <td align="justify">
                    ServiceTax
                </td>
                <td align="justify">
                    <asp:CheckBox ID="CheckService" runat="server" Text="ServicceTax" />
                </td>
            </tr>
            <tr align="center">
            <td align="justify">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Search</td>
            <td align="justify"><asp:TextBox ID ="txtsearch" runat ="server" ></asp:TextBox></td>
            </tr>
            <tr align="right">
                <td colspan="4">
                 <asp:Button ID="btns" runat="server" Text="search" Width="10%" Visible="false" 
                        onclick="btns_Click"/>
                <asp:Button ID="btnupdate" runat="server" Text="UPDATE" Width="10%" Visible="false"
                        onclick="btnupdate_Click" />
                    <asp:Button ID="BtnAdd" runat="server" Text="Add" Width="10%" OnClick="BtnAdd_Click" />
                </td>
            </tr>
            <tr align="right">
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:GridView ID="Grdm" runat="server" AutoGenerateColumns="False" 
                        AllowPaging="True" PageSize="7" 
                        onpageindexchanging="Grdm_PageIndexChanging" 
                        OnRowCommand="Grdm_RowCommand" CellPadding="4" ForeColor="#333333" 
                        GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lbldes" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblamount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="per_consignment/visa">
                                <ItemTemplate>
                                    <asp:Label ID="lblper" runat="server" Text='<%# Eval("Per_consignment") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ServiceTax">
                                <ItemTemplate>
                                    <asp:Label ID="lbltax" runat="server" Text='<%# Eval("ServiceTax") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mandatory">
                                <ItemTemplate>
                                    <asp:Label ID="lblmandatory" runat="server" Text='<%# Eval("Mandatory") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="lnkedit" runat="server" CommandName="cmdedit" CommandArgument='<%#Eval("MISC_ID") %>'
                                        Text="Edit"></asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton ID="lnkdelete" runat="server" CommandName="cmddelete" CommandArgument='<%#Eval("MISC_ID") %>'
                                        Text="Delete"></asp:LinkButton>--%> 
                                        <asp:ImageButton ID="imgedit" runat="server" ImageUrl="~/images/1372698761_pen.png" Height="25px" Width="25px" CommandName="cmdedit" CommandArgument='<%#Eval("Id") %>' />
                                        <asp:ImageButton ID ="imgdelete" runat="server" ImageUrl="~/images/1372698821_edit-delete.png" Height="25px" Width="25px" CommandName ="cmddelete" CommandArgument ='<%#Eval("Id") %>' />

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
