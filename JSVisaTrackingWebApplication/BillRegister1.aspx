<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BillRegister1.aspx.cs" Inherits="JSVisaTrackingWebApplication.BillRegister1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .modal {
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

        .loading {
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary ID="BillRegisterSummry" runat="server" ShowMessageBox="true" DisplayMode="List"
        ShowSummary="false" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">

        function ShowProgress() {
            if (Page_ClientValidate()) {
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
        }
        //    $('form').live("submit", function () {
        //        ShowProgress();
        //    });
    </script>

    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Bill Summary</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Accounting / Bill Summary</div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                <div class="form-inner-bg">
                    <div class="col-sm-12 col-xs-12">
                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                                <label>Search Criteria <span class="red"></span></label>
                                <asp:RadioButtonList ID="rbtnlstSearch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbtnlstSearch_SelectedIndexChanged"
                                    RepeatDirection="Horizontal" Width="254px" CausesValidation="True">
                                    <asp:ListItem Selected="True" Text=" Period" Value="1"></asp:ListItem>
                                    <asp:ListItem Text=" Bill" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                                <%--<asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="ddlAgentName"
                            ErrorMessage="Please Select Agent Name." Display="None" Font-Size="Smaller" ForeColor="#FF3300"
                            InitialValue="0"></asp:RequiredFieldValidator>--%>
                            </div>


                            <div class="col-sm-4 col-xs-12">
                                <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label><span id="FromDateSpan"
                                    runat="server" class="red"></span>
                                <div id="divfromdate" runat="server" class="input-group text datepicker span4"
                                    data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="txt_fromDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <i class="input-group-addon glyphicon glyphicon-calendar"></i>
                                </div>
                                <%-- <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="txt_fromDate"
                            ErrorMessage="Please Fill From Date." Font-Size="Smaller" ForeColor="#FF3300"
                            ValidationGroup="a"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <asp:Label ID="lblToDate" runat="server" Text="To Date"></asp:Label>
                                <span id="ToDateSpan" runat="server" class="red"></span>

                                <div id="divtodate" runat="server" class="input-group text datepicker span4" data-param-year-buttons="1"
                                    data-param-lang="en">
                                    <asp:TextBox ID="txt_toDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <i class="input-group-addon glyphicon glyphicon-calendar"></i>
                                </div>
                                <%-- <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="txt_toDate"
                            ErrorMessage="Please Fill To Date." Font-Size="Smaller" ForeColor="#FF3300"
                            ValidationGroup="a"></asp:RequiredFieldValidator>--%>
                            </div>

                        </div>
                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                                <label>Agent Name <span class="red"></span></label>
                                <asp:DropDownList ID="ddlAgentName" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <asp:Label ID="lblbillnofrom" runat="server" Text="Bill No. From"></asp:Label>
                                <%--<label>Bill No. From <span class="red"></span></label>--%>
                                <asp:TextBox ID="txt_fromBill" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txt_fromBill"
                                    ErrorMessage="Please Fill From Bill." Display="None" Font-Size="Smaller" ForeColor="#FF3300"
                                    ValidationGroup="b"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CV1" runat="server" ControlToValidate="txt_fromBill" Display="None"
                                    ErrorMessage="Please Fill From Bill No. With Only Numeric Value." ForeColor="Red"
                                    Operator="DataTypeCheck" Type="Integer" ValidationGroup="b"></asp:CompareValidator>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <asp:Label ID="lblbillnoTo" runat="server" Text="Bill No. To"></asp:Label>
                                <%--<label>Bill No. To<span class="red"></span></label>--%>
                                <asp:TextBox ID="txt_toBill" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="txt_toBill"
                                    ErrorMessage="Please Fill To Bill." Display="None" Font-Size="Smaller" ForeColor="#FF3300"
                                    ValidationGroup="b"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CV2" runat="server" ControlToValidate="txt_toBill" Display="None"
                                    ErrorMessage="Please Fill To Bill No. With Only Numeric Value." ForeColor="Red"
                                    Operator="DataTypeCheck" Type="Integer" ValidationGroup="b"></asp:CompareValidator>

                            </div>
                        </div>
                        <div class="text-right">
                            <asp:Button ID="btnGo" runat="server" Text="Search" OnClick="btnGo_Click" CssClass="button-1" />
                            <asp:Button ID="btnCnacel" runat="server" Text="Cancel" OnClick="btnCnacel_Click" CssClass="cancel-btn" />
                        </div>

                    </div>
                </div>


                <%-- -------- Put Table Here ---------%>


                <asp:UpdatePanel ID="updatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblbri" runat="server"></asp:Label>
                        <div style="width: 100%; height: auto; overflow: scroll; overflow-y: hidden;">
                            <asp:GridView ID="gv_billRegister" runat="server" AutoGenerateColumns="False" CssClass="gridview"
                                PageSize="10" CellPadding="5" ShowFooter="true" OnRowDataBound="gv_billRegister_RowDataBound" OnRowCreated="gv_billRegister_RowCreated">
                                <HeaderStyle CssClass="gridViewHeader" />
                                <RowStyle CssClass="gridViewRow" />
                                <AlternatingRowStyle CssClass="gridViewAltRow" />
                                <SelectedRowStyle CssClass="gridViewSelectedRow" />
                                <PagerStyle CssClass="gridViewPager" />
                                <FooterStyle BackColor="#2D89EF" ForeColor="White" HorizontalAlign="Left" />
                                         <Columns>
                                                  <asp:TemplateField HeaderText="Doc Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocDate" runat="server" Text='<%#Eval("BillConsignment.CgDate","{0:MM/dd/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDocdate" runat="server" Text='<%#Eval("BillConsignment.CgDate","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invoice Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocNo" runat="server" Text='<%#Eval("BillId") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtBillId" runat="server" Text='<%#Eval("BillId") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Consignment Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblRefNo" runat="server" Text='<%#Eval("ConsignmentId") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRefNo" runat="server" Text='<%#Eval("ConsignmentId") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                       
                            <asp:TemplateField HeaderText="Applicant Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocType" runat="server" Text='<%#Eval("Paxs") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDocType" runat="server" Text='<%#Eval("Paxs") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Corporate Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblClientName" runat="server" Text='<%#Eval("BillConsignment.CgCorporate") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtClient" runat="server" Text='<%#Eval("BillConsignment.CgCorporate") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Visa Country">
                                <ItemTemplate>
                                    <asp:Label ID="lblRefNo" runat="server" Text='<%#Eval("PaxDetails.CountryName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRefNo" runat="server" Text='<%#Eval("PaxDetails.CountryName") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No. of Passports">
                                <ItemTemplate>
                                    <asp:Label ID="lblRefNo" runat="server" Text='<%#Eval("BillConsignment.CgNoOfPass") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRefNo" runat="server" Text='<%#Eval("BillConsignment.CgNoOfPass") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>


                            <%--<asp:CommandField HeaderText="Action" ShowCancelButton="true" ShowEditButton="true" ShowDeleteButton="true" />--%>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="linbtnPrint" runat="server" CommandName="Print" CommandArgument='<%#Eval("BillId")+","+Eval("Version")%>'
                                        ToolTip="Print"><i class="glyphicon glyphicon-print"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                            </asp:GridView>
                        </div>
                        <br />
                        <div class="text-right">
                            <asp:Button ID="btnBack" CssClass="form-group button-1" runat="server" Text="Back" OnClick="btnBack_Click" />
                            <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" CssClass="form-group button-1" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnExport" />
                    </Triggers>
                </asp:UpdatePanel>
</asp:Content>
