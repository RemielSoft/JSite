<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="SearchEmbassyFee.aspx.cs" Inherits="JSVisaTrackingWebApplication.SearchEmbassyFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="Summary" runat="server" ValidationGroup="a" ShowMessageBox="true" DisplayMode="List"
        ShowSummary="false" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h2>
        <i class="fg-color-blue icon-search"></i>Search Embassy Fee
    </h2>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table table-bordered table-striped table-condensed">
                <tr>
                    <td class="left">
                        Search Criteria <span class="red">*</span>
                    </td>
                    <td class="left">
                        <asp:RadioButtonList ID="rbtnlstSearch" runat="server" RepeatDirection="Horizontal"
                            AutoPostBack="True" OnSelectedIndexChanged="rbtnlstSearch_SelectedIndexChanged">
                            <asp:ListItem Text=" All" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text=" Country Base" Value="1"></asp:ListItem>
                            <asp:ListItem Text=" VisaType Base" Value="2"></asp:ListItem>
                            <asp:ListItem Text=" VisaDuration Base" Value="3"></asp:ListItem>
                            <asp:ListItem Text=" No.Of Visit Base" Value="4"></asp:ListItem>
                            <asp:ListItem Text=" ProcessTime Base" Value="5"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
            <table class="table table-bordered table-striped table-condensed" id="tblAll" runat="server">
                <tr>
                    <td class="left" width="250px">
                        Embassy Country <span class="red">*</span>
                        <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="ddlCountryAll"
                            Display="None" ErrorMessage="Select Country." ForeColor="Red" InitialValue="0"
                            ValidationGroup="a"></asp:RequiredFieldValidator>
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlCountryAll" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="left" width="250px">
                        Visa Type <span class="red">*</span>
                        <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlVisaTypeAll"
                            Display="None" ErrorMessage="Select Visa Type." ForeColor="Red" InitialValue="0"
                            ValidationGroup="a"></asp:RequiredFieldValidator>
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlVisaTypeAll" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="left" width="250px">
                        Visa Duration <span class="red">*</span>
                        <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="ddlVisaDurationAll"
                            Display="None" ErrorMessage="Select Visa Duration." ForeColor="Red" InitialValue="0"
                            ValidationGroup="a"></asp:RequiredFieldValidator>
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlVisaDurationAll" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="left" width="250px">
                        No. Of Visit <span class="red">*</span>
                        <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="ddlNoOfVisitAll"
                            Display="None" ErrorMessage="Select No. of Visit." ForeColor="Red" InitialValue="0"
                            ValidationGroup="a"></asp:RequiredFieldValidator>
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlNoOfVisitAll" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="left" width="250px">
                        Process Time <span class="red">*</span>
                        <asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="ddlProcessTimeAll"
                            Display="None" ErrorMessage="Select Process Time." ForeColor="Red" InitialValue="0"
                            ValidationGroup="a"></asp:RequiredFieldValidator>
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlProcessTimeAll" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
            </table>
            <table class="table table-bordered table-striped table-condensed" id="tblCountryBase"
                runat="server">
                <tr>
                    <td class="left" width="250px">
                        Embassy Country <span class="red">*</span>
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" ValidationGroup="b">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFV6" runat="server" ControlToValidate="ddlCountry"
                                ErrorMessage="Please Select Country." ForeColor="Red" InitialValue="0" ValidationGroup="b"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
            </table>
            <table class="table table-bordered table-striped table-condensed" id="tblVisaTypeBase"
                runat="server">
                <tr>
                    <td class="left" width="250px">
                        Visa Type <span class="red">*</span>
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlVisaType" runat="server" AutoPostBack="true" ValidationGroup="c">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFV7" runat="server" ControlToValidate="ddlVisaType"
                                ErrorMessage="Please Select Visa Type." ForeColor="Red" InitialValue="0" ValidationGroup="c"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
            </table>
            <table class="table table-bordered table-striped table-condensed" id="tblVisaDurationBase"
                runat="server">
                <tr>
                    <td class="left" width="250px">
                        Visa Duration <span class="red">*</span>
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlVisaDuration" runat="server" AutoPostBack="true" ValidationGroup="d">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFV8" runat="server" ControlToValidate="ddlVisaDuration"
                                ErrorMessage="Please Select Visa Duration." ForeColor="Red" InitialValue="0"
                                ValidationGroup="d"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
            </table>
            <table class="table table-bordered table-striped table-condensed" id="tblNoOfVisitBase"
                runat="server">
                <tr>
                    <td class="left" width="250px">
                        No. Of Visit <span class="red">*</span>
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlNoOfVisit" runat="server" AutoPostBack="true" ValidationGroup="e">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFV9" runat="server" ControlToValidate="ddlNoOfVisit"
                                ErrorMessage="Please Select No. of Visit." ForeColor="Red" InitialValue="0" ValidationGroup="e"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
            </table>
            <table class="table table-bordered table-striped table-condensed" id="tblProcessTime"
                runat="server">
                <tr>
                    <td class="left" width="250px">
                        Process Time <span class="red">*</span>
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlProcessTime" runat="server" AutoPostBack="true" ValidationGroup="f">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFV10" runat="server" ControlToValidate="ddlProcessTime"
                                ErrorMessage="Please Select Process Time." ForeColor="Red" InitialValue="0" ValidationGroup="f"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
            </table>
            <br />
            <div align="right">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                <asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click" />
            </div>
            <div style="width: 100%; height: auto;">
                <asp:GridView ID="GVEmbassyFeesSearch" runat="server" DataKeyNames="EmbsyMasterId"
                    AutoGenerateColumns="False" AllowPaging="true" CssClass="gridview" PageSize="10"
                    CellPadding="5" OnPageIndexChanging="GVEmbassyFeesSearch_PageIndexChanging" OnRowUpdating="GVEmbassyFeesSearch_RowUpdating"
                    OnRowEditing="GVEmbassyFeesSearch_RowEditing" OnRowCancelingEdit="GVEmbassyFeesSearch_RowCancelingEdit">
                    <HeaderStyle CssClass="gridViewHeader" />
                    <RowStyle CssClass="gridViewRow" />
                    <AlternatingRowStyle CssClass="gridViewAltRow" />
                    <SelectedRowStyle CssClass="gridViewSelectedRow" />
                    <PagerStyle CssClass="gridViewPager" />
                    <Columns>
                        <asp:TemplateField HeaderText="Id">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%# Eval("EmbsyMasterId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Country">
                            <ItemTemplate>
                                <asp:Label ID="lblcontry" runat="server" Text='<%# Eval("country") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Visa Type">
                            <ItemTemplate>
                                <asp:Label ID="lblvisatype" runat="server" Text='<%# Eval("visatype") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Visa Duration">
                            <ItemTemplate>
                                <asp:Label ID="lblvisaduration" runat="server" Text='<%# Eval("DurationDescription") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="No. of Visit">
                            <ItemTemplate>
                                <asp:Label ID="lblno_ofvisit" runat="server" Text='<%# Eval("NoOfVisit") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Process Time">
                            <ItemTemplate>
                                <asp:Label ID="lblprocesstime" runat="server" Text='<%# Eval("ProcessTimeDesc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fee">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFees" runat="server" Text='<%# Eval("fees") %>' Width="120px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblfees" runat="server" Text='<%# Eval("fees") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ControlStyle-CssClass="black" HeaderText="Action" ShowCancelButton="true"
                            ShowEditButton="true" />
                        <%--<asp:TemplateField HeaderText="Action">
                    <EditItemTemplate>
                        <asp:LinkButton ID="btnUpdate" Text="Update" runat="server" CommandName="Update" ToolTip="Update"/>                        
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lknbtnEdit" runat="server" CommandName="cmdedit" CommandArgument='<%# Eval("EmbsyMasterId") %>' ToolTip="Edit"><i class="icon-pencil black"></i></asp:LinkButton>                        
                    </ItemTemplate>                    
                </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
            <asp:PostBackTrigger ControlID="GVEmbassyFeesSearch" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
