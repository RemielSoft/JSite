<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UpdateConsignmentStatus.aspx.cs" Inherits="JSVisaTrackingWebApplication.UpdateConsignmentStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Update Consignment Status</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Consignment /  Update Consignment Status</div>
            </div>
        </div>
    </div>
     <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                 <div class="form-inner-bg">

    <div class="col-sm-12 col-xs-12">
         <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Following error occurs:"
        ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="false" ValidationGroup="Go" />
        
            <div class="row form-group">
        <div class="col-sm-4 col-xs-12">
               <label>From Date<span class="red">*</span></label>
            <div class="input-group text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                    <asp:TextBox ID="txtfrmdate" runat="server" CssClass="form-control"></asp:TextBox>
                    <i class="input-group-addon glyphicon glyphicon-calendar"></i>
                    <asp:RequiredFieldValidator ID="rqvDate" runat="server" ValidationGroup="Go" ControlToValidate="txtfrmdate"
                        ErrorMessage="Please Enter From Date" Display="None"></asp:RequiredFieldValidator>
                </div>

        </div>
                <div class="col-sm-4 col-xs-12">
                      <label>To Date<span class="red">*</span></label>
                    <div class="input-group text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                    <asp:TextBox ID="txttodate" runat="server" CssClass="form-control"></asp:TextBox>
                    <i class="input-group-addon glyphicon glyphicon-calendar"></i>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Go"
                    ControlToValidate="txttodate" ErrorMessage="Please Enter To Date" Display="None"></asp:RequiredFieldValidator>
                </div>

            </div>
     <div class="text-right">
        <asp:Button ID="btnGo" runat="server"  Text="Go" ValidationGroup="Go" OnClientClick="ShowProgress();" onclick="btnGo_Click" CssClass="button-1"/>
    </div>

    </div>

                 </div>

         
  
   
    
    <div class="table-responsive">
        <asp:GridView runat="server" ID="gridViewConsignment" AutoGenerateColumns="False" Width="100%"
            AllowPaging="True" CssClass="gridview table table-bordered table-striped" PageSize="10" CellPadding="5" OnPageIndexChanging="gridViewConsignment_PageIndexChanging"
            OnRowCommand="gridViewConsignment_RowCommand" OnRowEditing="gridViewConsignment_RowEditing"
            OnRowUpdating="gridViewConsignment_RowUpdating" OnRowDataBound="gridViewConsignment_RowDataBound"
            OnRowCancelingEdit="gridViewConsignment_RowCancelingEdit">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="Visa Country">
                    <ItemTemplate>
                        <asp:Label ID="lblvisaCountry" runat="server" Text='<%#Eval("CountryName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Consignment No.">
                    <ItemTemplate>
                        <asp:Label ID="lblConsignmentId" runat="server" Text='<%#Eval("ConsignmentId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Agent Name">
                    <ItemTemplate>
                        <asp:Label ID="lblCgAgntname" runat="server" Text='<%#Eval("ConsignmentAgent.AgentName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Consignment Status">
                    <ItemTemplate>
                        <asp:Label ID="lblConsignVisaStatus" runat="server" Text='<%#Eval("ConsignmentVisaStatus")+"," %>'></asp:Label>
                        <asp:Label ID="lblConsignDocumentStatus" runat="server" Text='<%#Eval("ConsignmentDocumentStatus") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="DrpdnConsignStatus" runat="server">
                            <asp:ListItem Text="--Select--" Value="-1" />
                            <asp:ListItem Text="Visa Not-Done" Value="0" />
                            <asp:ListItem Text="Visa Done" Value="1" />
                        </asp:DropDownList>
                        <asp:DropDownList ID="DDlConsignDocumntStatus" runat="server">
                            <asp:ListItem Text="--Select--" Value="-1" />
                            <asp:ListItem Text="Document Not-Send" Value="0" />
                            <asp:ListItem Text="Document Send" Value="1" />
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="linbtn_edit" runat="server" CommandName="Edit" ToolTip="Edit"
                            CommandArgument='<%#Eval("ConsignmentId") %>'><i class="glyphicon glyphicon-edit"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinbtnViewConsign" runat="server" ToolTip="ConsignmentView" CommandName="cmdViewCon"
                            CommandArgument='<%#Eval("ConsignmentId") %>'><i class="glyphicon glyphicon-zoom-in"></i></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="linbtn_update" runat="server" CommandName="Update" ToolTip="Update"
                            CommandArgument='<%#Eval("ConsignmentId") %>'><i class=" icon-loading-2 fg-color-greenDark"></i></asp:LinkButton>
                        <asp:LinkButton ID="linbtn_cancel" runat="server" CommandName="Cancel" ToolTip="Cancel"
                            CommandArgument='<%#Eval("ConsignmentId") %>'><i class="icon-cancel-2 red"></i></asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="loading" align="center">
        Please wait...<br />
        <br />
        <img src="images/Loader.GIF" alt="" />
    </div>
                   </div>

        </div>
         </div>
</asp:Content>
