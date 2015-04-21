<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RePrintInvoice.aspx.cs" Inherits="JSVisaTrackingWebApplication.printInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

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
        //    $('form').live("submit", function () {
        //        ShowProgress();
        //    });
    </script>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Reprint Invoice</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Utilities / Reprint Invoice</div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                <div class="form-inner-bg">
                    <div class="col-sm-12 col-xs-12">
                          <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Summery1"
        HeaderText="Following error occurs:" ShowMessageBox="true" DisplayMode="BulletList"
        ShowSummary="false" />
                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                             <asp:Label ID="lblInvTyp" runat="server" Text="Invoice Type"></asp:Label>
                                  <asp:RadioButtonList ID="rbtPrintInv" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                    OnSelectedIndexChanged="rbtPrintInv_SelectedIndexChanged">
                    <asp:ListItem Text="Normal" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Advance" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Additional" Value="3"></asp:ListItem>
                </asp:RadioButtonList>

                            </div>
                              <div class="col-sm-4 col-xs-12">
                                  <asp:Label ID="lblConsNo" runat="server" Text="Consignment No."></asp:Label>
                                   <asp:TextBox ID="txtConsignmentNo" runat="server"  CssClass="form-control"></asp:TextBox>
                                    <asp:CompareValidator ID="validator" runat="server" ControlToValidate="txtConsignmentNo"
                    Operator="DataTypeCheck" Type="Integer" ErrorMessage="Consignment must be a Integer"
                    ValidationGroup="Summery1" Display="None" />
                                  </div>
                             <div class="col-sm-4 col-xs-12">
                                   <asp:Label ID="lblAgentName" runat="server" Text="Agent Name"></asp:Label>
                                   <asp:DropDownList ID="ddlagentName" runat="server"  CssClass="form-control">
                    </asp:DropDownList>
                                 </div>
                        </div>
                           <div class="text-right">
        <asp:Button ID="btnSearch" runat="server" Text="Go" ValidationGroup="Summery1" OnClick="btnSearch_Click"
            OnClientClick="ShowProgress();" CssClass="button-1" />
    </div>
                    </div>
                </div>
           
  
 
    <div class="table-responsive">
        <asp:GridView runat="server" ID="gvPrintInvoice" AutoGenerateColumns="False" AllowPaging="True"
            Width="100%" CssClass="gridview table table-bordered table-striped table-condensed" PageSize="10" CellPadding="5" OnPageIndexChanging="gvPrintInvoice_PageIndexChanging"
            OnRowCommand="gvPrintInvoice_RowCommand" OnRowDataBound="gvPrintInvoice_RowDataBound">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="Bill No.">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Visa_City" runat="server" Text='<%#Eval("BillId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label ID="lbl_country" runat="server" Text='<%#Eval("BillDate" ,"{0:dd MMM yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Consignment No.">
                    <ItemTemplate>
                        <asp:Label ID="lbl_title" runat="server" Text='<%#Eval("ConsignmentId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bill Type">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Billtype" runat="server" Text='<%#Eval("BillType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Client Name">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Form" runat="server" Text='<%#Eval("AgentDetails.AgentName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--  <asp:TemplateField HeaderText="Versioning">
                    <ItemTemplate>
                        <asp:Label ID="lblVersion" runat="server" Text='<%#Eval("Version") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                --%>
                <asp:TemplateField HeaderText="Version">
                    <ItemTemplate>
                        <asp:DropDownList runat="server" ID="ddlVersion" AutoPostBack="true" OnSelectedIndexChanged="ddlVersion_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnPrint" runat="server" CommandName="lnkPrint" CommandArgument='<%#Eval("BillId")+","+Eval("Version")%>'
                            ToolTip="Print"><i class=" glyphicon glyphicon-print "></i></asp:LinkButton>
                        <asp:LinkButton ID="lbtnRePrint" runat="server" CommandName="lnkRePrint" CommandArgument='<%#Eval("BillId")+","+Eval("Version")%>'
                            ToolTip="RePrint"><i class="glyphicon glyphicon-print"></i></asp:LinkButton>
                       <%-- <asp:LinkButton ID="lbtnEdit" runat="server" CommandName="lnkEdit" CommandArgument='<%#Eval("BillId")+","+Eval("Version")%>'
                            ToolTip="Edit"><i class="glyphicon glyphicon-edit"></i></asp:LinkButton>--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle Font-Size="10pt" />
        </asp:GridView>
    </div>
    <div class="loading" align="center">
        Please wait...<br />
        <br />
        <img src="image/loader_circle.gif" width="50" height="50" />
        <%-- <img src="images/Loader.GIF" alt="" />--%>
    </div>
                 </div>
        </div>
    </div>

</asp:Content>
