<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="StatementOfAccount.aspx.cs" Inherits="JSVisaTrackingWebApplication.StatementOfAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    .modal
    {
        position: fixed;
        top: 0;
        left: 0;
        background-color:#fff;
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
        font-weight:bold;
        color:Blue;
       
        width: 180px;
        height: 80px;
        display: none;
        position: fixed;
        background-color:transparent;
        
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
    <style type="text/css">
    .HeaderAlign
    {
        text-align:left;
    }
    .HeaderAlign1
    {
        text-align:right;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <h2>
        <i class="icon-list fg-color-blue"></i>Statement Of Account</h2>
    <asp:ValidationSummary ID="vdsAdate" runat="server" ValidationGroup="submit" ShowMessageBox="true" DisplayMode="List"
        ShowSummary="false" />
    <table class="table table-bordered table-striped table-condensed" id="tblFirst" runat="server">
        <tr>
            <td>
                <asp:Label ID="lblfromDate" runat="server" Text="From Date"></asp:Label>
            </td>
            <td>
                <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                    <asp:TextBox ID="txtfrmdate" runat="server"></asp:TextBox>
                    <i class="btn-date"></i>
                </div>
            </td>
            <td>
                <asp:Label ID="lbltodate" runat="server" Text="ToDate"></asp:Label>
            </td>
            <td>
                <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                    <asp:TextBox ID="txttodate" runat="server"></asp:TextBox>
                    <i class="btn-date"></i>
                </div>
            </td>
        </tr>
        <tr>
            <td>
            Select Party Name<span style="color:Red">*</span>
                
            </td>
            <td colspan="3" align="left">
             <div class="input-control select">
               <asp:DropDownList ID="ddlagentList" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rquItems" runat="server" ValidationGroup="submit" InitialValue="0"
                    ControlToValidate="ddlagentList" ErrorMessage="Please Select Party Name" Display="None"></asp:RequiredFieldValidator>
            </div>
            </td>
        </tr>
    </table>
    <br />
    <div align="right">
        <asp:Button ID="btndisplay" runat="server" Text="Search" OnClick="btndisplay_Click"
            ValidationGroup="submit"  />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
    <table class="table table-bordered table-striped table-condensed" id="tblSecond" runat="server">
        <tr>
            <td class="center" colspan="4" style="font-family: Arial;">
                <h3 style="font-weight: bold">
                    <strong>Statement Of Account</strong>
                </h3>
            </td>
        </tr>
        <tr>
            <td class="center" colspan="4">
                (
                <asp:Label ID="lblStatDate" runat="server"></asp:Label>
                &nbsp;)
            </td>
        </tr>
        <tr>
            <td class="left">
                Party Name
            </td>

            <td class="left">
           
                <asp:Label ID="lblPartyName" runat="server"></asp:Label>

                
            </td>
            <td class="right">
                Opening Balance
            </td>
            <td class="left">
                <asp:Label ID="lblOpenBalance" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="left">
                Party Address
            </td>
            <td class="left" colspan="3">
                <asp:Label ID="lblPartyAddress" runat="server" Text='<%#Eval("AgentId") %>'></asp:Label>
            </td>
        </tr>
    </table>
  <div class="loading" align="center">
        Please wait...<br />
        <br />
        <img src="images/Loader.GIF" alt="" />
    </div>
    <div style=" height: auto; overflow: scroll; overflow-y:hidden;">
        <asp:GridView ID="grdStatement" CssClass="gridview" runat="server" AutoGenerateColumns="False" 
            ShowFooter="True" AllowPaging="true" PageSize="5"
            onrowdatabound="grdStatement_RowDataBound" 
            onpageindexchanging="grdStatement_PageIndexChanging"> 
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <FooterStyle BackColor="#2D89EF" ForeColor="White" HorizontalAlign="Left" Height="25px" />
            <Columns>
                <asp:TemplateField HeaderText="DATE">
                    <ItemTemplate>
                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("DocDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PARTICULARS" FooterText="TOTAL(INR)">
                    <ItemTemplate>
                        <asp:Label ID="lblparticulars" runat="server" Text='<%#Eval("Particular") %>'></asp:Label><br />
                        <asp:Label ID="lblnaration" runat="server" Text='<%#Eval("Narration") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DEBIT">
                    <ItemTemplate>
                        <asp:Label ID="lbldebit" runat="server" Text='<%#Eval("DrAmount") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    <asp:Label ID="lblDrAmt" runat="server" Font-Bold="true"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CREDIT">
                    <ItemTemplate>
                        <asp:Label ID="lblcredit" runat="server" Text='<%#Eval("CrAmount") %>'></asp:Label>
                    </ItemTemplate>
                     <FooterTemplate>
                    <asp:Label ID="lblCrAmt" runat="server" Font-Bold="true"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BALANCE">
                    <ItemTemplate>
                        <asp:Label ID="lblbalance" runat="server" Text='<%#Eval("Balance") %>'></asp:Label>
                    </ItemTemplate>
                     <FooterTemplate>
                    <asp:Label ID="lblBALANCE" runat="server" Font-Bold="true"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            
        </asp:GridView>
    </div>
    <br />
    <div align="right">
        <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" />
    </div>
</asp:Content>
