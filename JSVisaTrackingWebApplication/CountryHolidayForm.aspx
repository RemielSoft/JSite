<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CountryHolidayForm.aspx.cs" Inherits="JSVisaTrackingWebApplication.CountryHolidayForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Country Holiday Form</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Holiday /  Country Holiday Form</div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                <div class="form-inner-bg">
                    <div class="col-sm-12 col-xs-12">
                        <asp:ValidationSummary ID="summary" runat="server" ValidationGroup="a" ShowMessageBox="true"
                            ShowSummary="false" DisplayMode="List" />
                        <div class="row form-group">
                            <div class="col-sm-3 col-xs-12">
                                <label>Enter country name to search</label>
                                <asp:RadioButtonList ID="rbtnlstPurpose" runat="server" RepeatDirection="Horizontal"
                                    Width="254px">
                                    <asp:ListItem Text=" Mail" Value="Mail" ></asp:ListItem>
                                    <asp:ListItem Text="Website" Value="Website"></asp:ListItem>
                                </asp:RadioButtonList>

                            </div>

                            <div class="col-sm-3 col-xs-12">
                                <label>Month<span class="red">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_month"
                                    ErrorMessage="Please Select Month." Display="None" ValidationGroup="a" InitialValue="0"></asp:RequiredFieldValidator>
                                <asp:DropDownList ID="ddl_month" runat="server" AutoPostBack="True" CssClass="form-control">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="January">January</asp:ListItem>
                                    <asp:ListItem Value="Febraury">Febraury</asp:ListItem>
                                    <asp:ListItem Value="March">March</asp:ListItem>
                                    <asp:ListItem Value="April">April</asp:ListItem>
                                    <asp:ListItem Value="May">May</asp:ListItem>
                                    <asp:ListItem Value="June">June</asp:ListItem>
                                    <asp:ListItem Value="July">July</asp:ListItem>
                                    <asp:ListItem Value="August">August</asp:ListItem>
                                    <asp:ListItem Value="September">September</asp:ListItem>
                                    <asp:ListItem Value="October">October</asp:ListItem>
                                    <asp:ListItem Value="November">November</asp:ListItem>
                                    <asp:ListItem Value="December">December</asp:ListItem>
                                </asp:DropDownList>

                            </div>

                            <div class="col-sm-3 col-xs-12">
                                <label>Location <span class="red">*</span></label>
                                <asp:DropDownList ID="ddl_location" runat="server" AutoPostBack="True" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddl_location"
                                    ErrorMessage="Please Select Location." Display="None" ValidationGroup="a" InitialValue="0"></asp:RequiredFieldValidator>

                            </div>

                            <div class="col-sm-3 col-xs-12">
                                <label>Detail <span class="red">*</span></label>
                                <asp:TextBox ID="txt_detail" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_detail"
                                    ErrorMessage="Please Enter Detail." Display="None" ValidationGroup="a"></asp:RequiredFieldValidator>
                            </div>


                            <div class="col-sm-3 col-xs-12">
                                <label>Note  <span class="red">*</span></label>
                                <asp:TextBox ID="txt_notes" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_notes"
                                    ErrorMessage="Please Enter Note." Display="None" ValidationGroup="a"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="text-right">
                            <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" ValidationGroup="a" CssClass="button-1" />
                            <asp:Button ID="btn_update" runat="server" Text="Update" Visible="false"  ValidationGroup="a" OnClick="btn_update_Click" CssClass="button-1" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>




</asp:Content>
