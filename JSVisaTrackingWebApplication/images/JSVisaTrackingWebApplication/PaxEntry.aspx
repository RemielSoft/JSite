<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="PaxEntry.aspx.cs" Inherits="JSVisaTrackingWebApplication.PaxEntry" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <div id="divPax" runat="server">
            <table class="bordered">
                <tr>
                    <td class="left">
                        Agent
                    </td>
                    <td class="left" colspan="2">
                        <div class="input-control select">
                            <asp:Label ID="Lblagentname" runat="server" Text=""></asp:Label>
                        </div>
                    </td>
                    <td class="left" colspan="2">
                        PAX Name
                    </td>
                    <td class="left">
                        <div class="input-control text">
                            <asp:TextBox ID="txt_paxname" runat="server"></asp:TextBox>
                            <button class="btn-clear" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        Date of Birth
                    </td>
                    <td class="left" colspan="2">
                        <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                            <asp:TextBox ID="txt_dob" runat="server"></asp:TextBox>
                            <i class="btn-date"></i>
                        </div>
                    </td>
                    <td class="left" colspan="2">
                        Passport No.
                    </td>
                    <td class="left">
                        <div class="input-control text">
                            <asp:TextBox ID="txt_PassportNo" runat="server"></asp:TextBox>
                            <button class="btn-clear" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="left" colspan="6">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="left" colspan="6">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="DodgerBlue" Text="Documents"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="left" colspan="6">
                        <label class="input-control checkbox" onclick="">
                            <asp:CheckBox ID="chktickets" runat="server" />
                            <span class="helper">Tickets</span>
                        </label>
                        <label class="input-control checkbox" onclick="">
                            <asp:CheckBox ID="chkMedIns" runat="server" />
                            <span class="helper">Med. Insurance</span>
                        </label>
                        <label class="input-control checkbox" onclick="">
                            <asp:CheckBox ID="chkCreditCard" runat="server" />
                            <span class="helper">Credit Cards</span>
                        </label>
                        <label class="input-control checkbox" onclick="">
                            <asp:CheckBox ID="chkcertificate" runat="server" />
                            <span class="helper">Certificates</span>
                        </label>
                        <label class="input-control checkbox" onclick="">
                            <asp:CheckBox ID="chkItPaper" runat="server" />
                            <span class="helper">IT Papers</span>
                        </label>
                        <label class="input-control checkbox" onclick="">
                            <asp:CheckBox ID="chkDraft" runat="server" />
                            <span class="helper">Draft</span>
                        </label>
                    </td>
                </tr>
                <tr>
                    <td class="left" colspan="2">
                        Other
                    </td>
                    <td class="left" colspan="2">
                        <div class="input-control text">
                            <asp:TextBox ID="Txt_Others" runat="server"></asp:TextBox>
                            <button class="btn-clear" />
                        </div>
                    </td>
                    <td class="left" colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="left" colspan="6">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="left" colspan="1">
                        Remark
                    </td>
                    <td class="left" colspan="5">
                        <div class="input-control text">
                            <asp:TextBox ID="txtPaxRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="right">
                        <asp:Button ID="btnPaxEntry" runat="server" Text="Save" OnClick="btnPaxEntry_Click" />
                    </td>
                </tr>
            </table>
            </div>
            <div id="DivAdditional" runat="server" visible="False">
            <table>
                <tr>
                    <td class="left" colspan="4">
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="DodgerBlue" Text="Fill Additional Details"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        <span>Embassy</span>
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlCountry" runat="server" CssClass="dropdown" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td class="left">
                        Visa Type
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlVisaType" runat="server" AutoPostBack="True" CssClass="dropdown"
                                OnSelectedIndexChanged="ddlVisaType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        Number of Visit
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlnoofvisit" runat="server" AutoPostBack="True" CssClass="dropdown"
                                OnSelectedIndexChanged="ddlnoofvisit_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td class="left">
                        Duration
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlVisaDuration" runat="server" AutoPostBack="True" CssClass="dropdown"
                                OnSelectedIndexChanged="ddlVisaDuration_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="left" colspan="1">
                        Process Time
                    </td>
                    <td class="left" colspan="3">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlprocesstime" runat="server" CssClass="dropdown" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="addpax" runat="server" Text="Save" OnClick="addpax_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView runat="server" ID="gridview_Pax" AutoGenerateColumns="False" AllowPaging="True"
                            EmptyDataText="No Record Found" CssClass="gridview" PageSize="10" CellPadding="5">
                            <HeaderStyle CssClass="gridViewHeader" />
                            <RowStyle CssClass="gridViewRow" />
                            <AlternatingRowStyle CssClass="gridViewAltRow" />
                            <SelectedRowStyle CssClass="gridViewSelectedRow" />
                            <PagerStyle CssClass="gridViewPager" />
                            <Columns>
                                <asp:TemplateField HeaderText="Fee ID">
                                    <ItemTemplate>
                                        <asp:Label ID="LblInfo" runat="server" Text='<%#Eval("INFO_ID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Embassy">
                                    <ItemTemplate>
                                        <asp:Label ID="LblCountyName" runat="server" Text='<%#Eval("Country_name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Visa Type">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("DESCRIPTION_ONE")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="No of Entry">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("DESCRIPTION_Two")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Visa Duration">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("Expr1")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Process Time">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PROCESS_TIME">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPROCESS_TIME" runat="server" Text='<%#Eval("PROCESS_TIME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
