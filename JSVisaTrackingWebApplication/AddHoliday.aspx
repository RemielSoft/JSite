<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddHoliday.aspx.cs" Inherits="JSVisaTrackingWebApplication.AddHoliday" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link type="text/css" href="css/jquery-ui.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {
           
            $("#" + "<%=chkMostEmbsy.ClientID%>").change(function (e) {
                //  $(".checkboxlistread").change(function (e) {
                debugger;
                if (this.checked) {
                    $("#" + "<%=ChkBoxList.ClientID%>" + " :input").attr("disabled", true);
                }
                else {
                    $("#" + "<%=ChkBoxList.ClientID%>" + " :input").attr("disabled", false);
                }
               

            });
        });
    </script>

  
     <script type="text/javascript">
         $(document).ready(function () {

             $("#" + "<%=chkMostEmbsy.ClientID%>").change(function (e) {
                //  $(".checkboxlistread").change(function (e) {
                debugger;
                if (this.checked) {
                    $(".hides").hide();;
                }
                else {
                    $(".hides").show();
                }


            });
        });
    </script>
    
    <script type="text/javascript">
        $(document).ready(function () {

            $("#" + "<%=chkAllEmbsy.ClientID%>").change(function (e) {
                 //  $(".checkboxlistread").change(function (e) {
                 debugger;
                 if (this.checked) {
                     $(".hides").hide();;
                 }
                 else {
                     $(".hides").show();
                 }


             });
         });
    </script>
   
    <script type="text/javascript">
        $(document).ready(function () {

            $("#" + "<%=chkSchenembsy.ClientID%>").change(function (e) {
                 //  $(".checkboxlistread").change(function (e) {
                 debugger;
                 if (this.checked) {
                     $(".hides").hide();;
                 }
                 else {
                     $(".hides").show();
                 }


             });
         });
    </script>
   
    <script type="text/javascript">
        $(document).ready(function () {

            $("#" + "<%=chkafrican.ClientID%>").change(function (e) {
                 //  $(".checkboxlistread").change(function (e) {
                 debugger;
                 if (this.checked) {
                     $(".hides").hide();;
                 }
                 else {
                     $(".hides").show();
                 }


             });
         });
    </script>


    <script type="text/javascript">
        $(document).ready(function () {

            $("#" + "<%=chkAllEmbsy.ClientID%>").change(function (e) {
                //  $(".checkboxlistread").change(function (e) {
                debugger;
                if (this.checked) {
                    $("#" + "<%=ChkBoxList.ClientID%>" + " :input").attr("disabled", true);
                }
                else {
                    $("#" + "<%=ChkBoxList.ClientID%>" + " :input").attr("disabled", false);
                }


            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#" + "<%=chkSchenembsy.ClientID%>").change(function (e) {
                //  $(".checkboxlistread").change(function (e) {
                debugger;
                if (this.checked) {
                    $("#" + "<%=ChkBoxList.ClientID%>" + " :input").attr("disabled", true);
                }
                else {
                    $("#" + "<%=ChkBoxList.ClientID%>" + " :input").attr("disabled", false);
                }


            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#" + "<%=chkafrican.ClientID%>").change(function (e) {
                //  $(".checkboxlistread").change(function (e) {
               
                if (this.checked) {
                    $("#" + "<%=ChkBoxList.ClientID%>" + " :input").attr("disabled", true);
                }
                else {
                    $("#" + "<%=ChkBoxList.ClientID%>" + " :input").attr("disabled", false);
                }


            });
        });
    </script>

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
                                <asp:Label ID="lblDate" runat="server" Text="Holiday Date"></asp:Label>
                                <div class="input-group text datepicker" data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="txtholidaydate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <i class="input-group-addon glyphicon glyphicon-calendar"></i>
                                    <i class="btn-date"></i>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Go" ControlToValidate="txtfrmdate"
                                        ErrorMessage="Please Select Your Required Date" Display="None"></asp:RequiredFieldValidator>--%>
                                </div>

                            </div>

                            <div class="col-sm-3 col-xs-12">
                                <label>Holiday Name <span class="red">*</span></label>
                                <asp:TextBox ID="txt_holidayname" runat="server" CssClass="form-control"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_detail"
                                    ErrorMessage="Please Enter Detail." Display="None" ValidationGroup="a"></asp:RequiredFieldValidator>--%>
                            </div>

                            <div class="hides">
                            <div class="col-sm-3 col-xs-12">
                                <label>Description  <span class="red">*</span></label>
                                <asp:TextBox ID="txt_holidesc" runat="server" CssClass="form-control" ></asp:TextBox>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_notes"
                                    ErrorMessage="Please Enter Note." Display="None" ValidationGroup="a"></asp:RequiredFieldValidator>--%>
                            </div>
                                </div>

                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblcountryname" runat="server" Text="Country Name"></asp:Label>
                                <div style="height: 80px; padding: 2px; overflow: auto; border: 1px solid #ccc;">
                                    <asp:CheckBoxList ID="ChkBoxList" runat="server"></asp:CheckBoxList>
                                </div>
                            </div>

                            <div class="col-sm-12 col-xs-12">
                                <asp:CheckBox ID="chkMostEmbsy" runat="server" CssClass="checkboxlistread" />
                                <asp:Label ID="lblMost" runat="server" Text="Most of the Embassies"></asp:Label>
                               
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            
                                <asp:CheckBox ID="chkAllEmbsy" runat="server" CssClass="checkboxlistread" />
                             
                                 <asp:Label ID="lblAllEm" runat="server" Text="All Embassies"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           
                                <asp:CheckBox ID="chkSchenembsy" runat="server" CssClass="checkboxlistread" />
                                <asp:Label ID="lblSchengen" runat="server" Text="Most Schengen Embassies"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           
                                <asp:CheckBox ID="chkafrican" runat="server" CssClass="checkboxlistread" />
                                 <asp:Label ID="lblAfricanEmbsy" runat="server" Text="Most African Embassies"></asp:Label>
                               
                            </div>

                            <%-----------------------------------------------------------------------------------------------------------------------------
                            -------------------------------------------------------%>
                            <%--For Embussy Country hard Code--%>
                            <%--<div class="col-sm-3 col-xs-12">
                                <asp:CheckBox ID="chkAllEmbassy" runat="server" />
                                <label>All Embassy<span class="red"></label>
                            </div>

                            <div class="col-sm-3 col-xs-12">
                                <asp:CheckBox ID="chkMostOfEmbassy" runat="server" />
                                <label>Most Of Embassy<span class="red"></label>
                            </div>--%>
                        </div>
                        <div class="text-right form-group">
                            <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click1" ValidationGroup="a" CssClass="button-1" />
                            <%--<asp:Button ID="btn_update" runat="server" Text="Update" Visible="false"  ValidationGroup="a" OnClick="btn_update_Click" CssClass="button-1" />--%>
                        </div>



                        <div class="table table-responsive">
                            <asp:GridView ID="GrdHoliday" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                CellPadding="5" CssClass="gridview table table-bordered table-striped table-condensed" PageSize="10"
                                OnPageIndexChanging="GrdHoliday_PageIndexChanging"
                                OnRowCommand="GrdHoliday_RowCommand">
                                <HeaderStyle CssClass="gridViewHeader" />
                                <RowStyle CssClass="gridViewRow" />
                                <AlternatingRowStyle CssClass="gridViewAltRow" />
                                <SelectedRowStyle CssClass="gridViewSelectedRow" />
                                <PagerStyle CssClass="gridViewPager" />
                                <Columns>
                                    <%-- <asp:TemplateField HeaderText="Id">
                    <ItemTemplate>
                        <asp:Label ID="lblCityId" runat="server" Text='<%# Eval("CityId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="DATE">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHolidayDate" runat="server" Text='<%# Eval("Holiday_Date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DAY">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHolidayDay" runat="server" Text='<%# Eval("Holiday_Day") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Holiday Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHolidayName" runat="server" Text='<%# Eval("Holiday_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="COUNTRY">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCountries" runat="server" Text='<%# Eval("Country_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="REMARKS">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Holiday_Detail") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%-- <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" CommandName="cmdedit"
                            CommandArgument='<%#Eval("CityId") %>'><i class="glyphicon glyphicon-edit" ></i></asp:LinkButton>
                        <asp:LinkButton ID="lnkdelete" runat="server" ToolTip="Delete" CommandName="cmddelete"
                            CommandArgument='<%#Eval("CityId") %>' OnClientClick="return confirm ('Are you Sure to Delete?')"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>



                    </div>
                </div>
            </div>
        </div>
    </div>




</asp:Content>

