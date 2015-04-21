<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="HolidayList.aspx.cs" Inherits="JSVisaTrackingWebApplication.HolidayList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
       <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>
        <link  type="text/css" href="css/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript">
     

        function confirmation() {
            if (confirm('Are you sure you want to Delete ?')) {
                return true;
            }
            else {
                return false;
            }
        }

      
    </script>

    <script>
        $(function () {
            $("#datepicker").datepicker({
                changeMonth: true,
                changeYear: true
            });
        });
        $(function () {
            $('.date-picker').datepicker({
                changeMonth: true,
                changeYear: true,
                showButtonPanel: true,
                dateFormat: 'MM / yy',
                monthNames: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12'],
                onClose: function (dateText, inst) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    $(this).datepicker('setDate', new Date(year, month, 1));
                }
            });
        });

</script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   

    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Holiday List</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Holiday /  Holiday List</div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                <div class="form-inner-bg">
                    <div class="col-sm-12 col-xs-12">


                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_location"
                            ErrorMessage="Please Select Location." ForeColor="Red" ValidationGroup="a" InitialValue="0"></asp:RequiredFieldValidator>--%>
                       
                       <%-- <div class="text-right">
                            <asp:Button ID="btn_go" runat="server" Text="Go" OnClick="btn_go_Click" ValidationGroup="a" CssClass="button-1" />
                        </div>--%>
                      <div class="row form-group">

                        <div class="col-sm-4 col-xs-12">
                            <label>Year<span class="red">*</span></label>
                        <asp:DropDownList id="ddlyear" runat="server" class="form-control"> 
                           
                            <asp:ListItem>2000</asp:ListItem>
                            <asp:ListItem>2001</asp:ListItem>
                            <asp:ListItem>2002</asp:ListItem>
                            <asp:ListItem>2003</asp:ListItem>
                            <asp:ListItem>2004</asp:ListItem>
                            <asp:ListItem>2005</asp:ListItem>
                            <asp:ListItem>2006</asp:ListItem>
                            <asp:ListItem>2007</asp:ListItem>
                            <asp:ListItem>2008</asp:ListItem>
                            <asp:ListItem>2009</asp:ListItem>
                            <asp:ListItem>2010</asp:ListItem>
                            <asp:ListItem>2011</asp:ListItem>
                            <asp:ListItem>2012</asp:ListItem>
                            <asp:ListItem>2013</asp:ListItem>
                            <asp:ListItem>2014</asp:ListItem>
                            <asp:ListItem>2015</asp:ListItem>
                            <asp:ListItem>2016</asp:ListItem>
                            <asp:ListItem>2017</asp:ListItem>
                            <asp:ListItem>2018</asp:ListItem>
                            <asp:ListItem>2019</asp:ListItem>
                            <asp:ListItem>2020</asp:ListItem>
                            <asp:ListItem>2021</asp:ListItem>
                            <asp:ListItem>2022</asp:ListItem>
                            <asp:ListItem>2023</asp:ListItem>
                            <asp:ListItem>2024</asp:ListItem>
                            <asp:ListItem>2025</asp:ListItem>
                            <asp:ListItem>2026</asp:ListItem>
                            <asp:ListItem>2027</asp:ListItem>
                            <asp:ListItem>2028</asp:ListItem>
                            <asp:ListItem>2029</asp:ListItem>
                            <asp:ListItem>2030</asp:ListItem>
                            <asp:ListItem>2031</asp:ListItem>
                        </asp:DropDownList>
                            
                       </div>
                        <div class="col-sm-4 col-xs-12">
                            <label>Month<span class="red">*</span></label>
                         <asp:DropDownList id="ddlmonth" runat="server" class="form-control">
                            
                            <asp:ListItem>January</asp:ListItem>
                            <asp:ListItem>February</asp:ListItem>
                            <asp:ListItem>March</asp:ListItem>
                            <asp:ListItem>April</asp:ListItem>
                            <asp:ListItem>May</asp:ListItem>
                            <asp:ListItem>June</asp:ListItem>
                            <asp:ListItem>July</asp:ListItem>
                            <asp:ListItem>August</asp:ListItem>
                            <asp:ListItem>September</asp:ListItem>
                            <asp:ListItem>October</asp:ListItem>
                            <asp:ListItem>November</asp:ListItem>
                            <asp:ListItem>December</asp:ListItem>
                        </asp:DropDownList>
                          
                            </div>
                        
                       
                         <div class="col-sm-2 col-xs-12 text-right">
                             <label>&nbsp;</label><br/>
                             <asp:Button id="btnshowholiday" runat="server" Text="Show Holiday" OnClick="btnshowholiday_Click" class="button-1" />
                        </div>
                  
                               </div>


                        </div>
                </div>
      <%--          <div class="table-responsive">
                    <asp:GridView ID="grid_holiday" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        CssClass="gridview table table-bordered table-striped table-condensed" PageSize="10" CellPadding="5" OnRowCommand="grid_holiday_RowCommand"
                        OnRowDataBound="grid_holiday_RowDataBound" OnPageIndexChanging="grid_holiday_PageIndexChanging">
                        <HeaderStyle CssClass="gridViewHeader" />
                        <RowStyle CssClass="gridViewRow" />
                        <AlternatingRowStyle CssClass="gridViewAltRow" />
                        <SelectedRowStyle CssClass="gridViewSelectedRow" />
                        <PagerStyle CssClass="gridViewPager" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("HoliId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Month">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_month" runat="server" Text='<%# Eval("HoliMonth") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Holiday Details">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_detail" runat="server" Text='<%# Eval("HoliDetails") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Holiday Notes">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_notes" runat="server" Text='<%# Eval("HoliNotes") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="70px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="cmdedit" CommandArgument='<%# Eval("HoliId") %>'
                                        ToolTip="Edit"><i class="glyphicon glyphicon-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton5" runat="server" CommandName="cmddel" CommandArgument='<%# Eval("HoliId") %>'
                                        ToolTip="Delete" OnClientClick="return confirmation();"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>--%>


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
                        <asp:Label ID="lblCountries" runat="server" Text='<%# string.Join("<br />",Eval("Country_Name").ToString().Split(new []{","},StringSplitOptions.None)) %>'></asp:Label>
                            
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
</asp:Content>
