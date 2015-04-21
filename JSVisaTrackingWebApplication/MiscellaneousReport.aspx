<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="MiscellaneousReport.aspx.cs" Inherits="JSVisaTrackingWebApplication.MiscellaneousReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modal
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: #fff;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
        .loading
        {
            font-family: Arial;
            font-size: 10pt;
            font-weight: bold;
            color: Blue;
            width: 180px;
            height: 80px;
            display: none;
            position: fixed;
            background-color: transparent;
            z-index: 999;
        }
    </style>
    <!--[if lt IE 9]>
<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
    <script type="text/javascript">
        document.createElement('header');
        document.createElement('section');
        document.createElement('article');
        document.createElement('aside');
        document.createElement('nav');
        document.createElement('footer');
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">

        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        
    </script>
    <h2>
        <i class="icon-list fg-color-blue"></i>Miscellaneous Report ...</h2>
    <h4>
        <i class="fg-color-blue"></i>Search By Following Criteria......</h4>
    <div>
        <table class="table table-bordered table-striped table-condensed">
            <tr>
                <td colspan="4">
                    <asp:RadioButtonList ID="radiobtnMiscllReport" runat="server" Font-Bold="True" OnSelectedIndexChanged="radiobtnMiscllReport_SelectedIndexChanged"
                        RepeatDirection="Horizontal" AutoPostBack="True">
                        <asp:ListItem Value="1" Selected="True"> Consolidated Search </asp:ListItem>
                        <asp:ListItem Value="2"> Individual Search </asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr id="trdate" runat="server">
                <td>
                    <asp:Label ID="lblfromdate" runat="server" Text="From Date"></asp:Label>
                </td>
                <td align="left">
                    <div class="input-control text datepicker  span4" data-param-year-buttons="1" data-param-lang="en">
                        <asp:TextBox ID="txtFromDate" runat="server" format="yyyy-MM-dd"></asp:TextBox>
                        <i class="btn-date"></i>
                    </div>
                    <asp:RequiredFieldValidator ID="rqfv" runat="server" ControlToValidate="txtFromDate"
                        ValidationGroup="serach" ErrorMessage="Please Select Both Dates"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="lbltodate" runat="server" Text="To Date"></asp:Label>
                </td>
                <td align="left">
                    <div class="input-control text datepicker  span4" data-param-year-buttons="1" data-param-lang="en">
                        <asp:TextBox ID="txtTodate" runat="server" format="yyyy-MM-dd"></asp:TextBox>
                        <i class="btn-date"></i>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTodate"
                        ValidationGroup="serach" ErrorMessage="Please Select Both Dates"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblcountryName" runat="server" Text="Country Name"></asp:Label>
                </td>
                <td>
                    <div class="input-control select">
                        <asp:DropDownList ID="ddlCountryName" runat="server">
                        </asp:DropDownList>
                    </div>
                </td>
                <td>
                    <asp:Label ID="lblAgentName" runat="server" Text="Agent Name"></asp:Label>
                </td>
                <td>
                    <div class="input-control select">
                        <asp:DropDownList ID="ddlagentName" runat="server" Width="247px">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <div align="right">
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                OnClientClick=" ShowProgress();" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
        <div class="loading" align="center">
            Please wait...<br />
            <br />
            <img src="images/Loader.GIF" alt="" />
        </div>
        <div align="center" id="lbldiv" runat="server">
            <asp:Label ID="lbldate1" runat="server" Text="Selected Date" Font-Bold="true"></asp:Label><br />
            (<asp:Label ID="lblDate" runat="server"></asp:Label>)
        </div>
        <br />
        <div align="left" id="divdate">
            <div style="width: 100%; height: auto; overflow: scroll; overflow-y: hidden;">
                <asp:GridView ID="grdAll" runat="server" CssClass="gridview" CellPadding="6" PageSize="5" AllowPaging="true"
                    AutoGenerateColumns="False" ShowFooter="True" OnRowDataBound="grdAll_RowDataBound"
                    OnPageIndexChanging="grdAll_PageIndexChanging">
                    <HeaderStyle CssClass="gridViewHeader" />
                    <RowStyle CssClass="gridViewRow" />
                    <AlternatingRowStyle CssClass="gridViewAltRow" />
                    <SelectedRowStyle CssClass="gridViewSelectedRow" />
                    <PagerStyle CssClass="gridViewPager" />
                    <Columns>
                        <asp:TemplateField HeaderText="Agent Name" FooterText="Total(INR)">
                            <ItemTemplate>
                                <asp:Label ID="lblAname" runat="server" Text='<%#Eval("AgentName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Country">
                            <ItemTemplate>
                                <asp:Label ID="lblcountry" runat="server" Text='<%#Eval("CountryName") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblfooterCountry" runat="server" Text="Total(INR)" Font-Bold="true"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Service Charge(INR)">
                            <ItemTemplate>
                                <asp:Label ID="lblServiceCharge" runat="server" Text='<%#Eval("ServiceCharge") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblCharge" runat="server" Font-Bold="true"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Service Tax(INR)">
                            <ItemTemplate>
                                <asp:Label ID="lblServiceTax" runat="server" Text='<%#Eval("ServiceTax") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTax" runat="server" Font-Bold="true"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Amount(INR)">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalamt" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblGrandtotl" runat="server" Font-Bold="true" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <div align="right">
                <asp:Button ID="btnExport" runat="server" Text="Export To Excel" Width="150" OnClick="btnExport_Click" />
            </div>
        </div>
    </div>
</asp:Content>
