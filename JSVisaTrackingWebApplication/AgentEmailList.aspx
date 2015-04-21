<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AgentEmailList.aspx.cs" Inherits="JSVisaTrackingWebApplication.AgentEmailList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Agent E-Mail list</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Agent / Agent E-Mail list</div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                <div class="form-inner-bg">
                    <div class="col-sm-12 col-xs-12">
                        <div class="row form-group">
                            <div class="col-sm-3 col-xs-12">
                                <label>Enter City name to search</label>
                                <div class="input-group">
                                  <asp:TextBox ID="txt_city" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txt_city"
                        MinimumPrefixLength="1" EnableCaching="false" CompletionSetCount="1" CompletionInterval="100"
                        ServiceMethod="GetCityName" FirstRowSelected="false">
                    </asp:AutoCompleteExtender>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1" CssClass="input-group-addon">
                            <i class="glyphicon glyphicon-search"></i>
                    </asp:LinkButton>
                                    </div>
                            </div>
                        </div>
                    </div>
                </div>
         

    <div class="table table-responsive">
        <asp:GridView ID="grid_search" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            OnPageIndexChanging="grid_search_PageIndexChanging1" CssClass="gridview table table-bordered table-striped table-condensed" PageSize="15"
            CellPadding="5">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="Agent Name">
                    <ItemTemplate>
                        <asp:Label ID="lbl_agentname" runat="server" Text='<%# Eval("AgentName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Agent Email">
                    <ItemTemplate>
                        <asp:Label ID="lbl_email" runat="server" Text='<%# Eval("AgentEmail") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div class="text-right form-group">
        <asp:Button ID="btn_download" runat="server" Text="Download" OnClick="btn_download_Click"  CssClass="button-1"/>
    </div>
                   </div>
        </div>
    </div>

</asp:Content>
