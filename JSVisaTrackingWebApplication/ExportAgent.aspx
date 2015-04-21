<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExportAgent.aspx.cs" Inherits="JSVisaTrackingWebApplication.ExportAgent" %>
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
                <div class="col-xs-12 col-sm-6">Export Agent</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Agent / Export Agent</div>
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
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" CssClass="input-group-addon">
                            <i class="glyphicon glyphicon-search"></i>
                    </asp:LinkButton>
                                    </div>
                            </div>
                         

                        </div>
                        

                    </div>
                </div>
           

   
    <div class="table table-responsive">
        <asp:GridView ID="grid_search" runat="server" AutoGenerateColumns="False" AllowPaging="True"
             CssClass="gridview table table-bordered table-striped table-condensed" PageSize="15"
            CellPadding="5" onpageindexchanging="grid_search_PageIndexChanging" >
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="Agent Id">
                    <ItemTemplate>
                        <asp:Label ID="lbl_agentname" runat="server" Text='<%# Eval("AgentId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Agent Name">
                    <ItemTemplate>
                        <asp:Label ID="lbl_agentname" runat="server" Text='<%# Eval("AgentName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT CPERSON">
                    <ItemTemplate>
                        <asp:Label ID="lblcper" runat="server" Text='<%#Eval("AgentCPerson") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT ADDRESS">
                    <ItemTemplate>
                        <asp:Label ID="lbladd" runat="server" Text='<%#Eval("AgentAddress") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT CITY">
                    <ItemTemplate>
                        <asp:Label ID="lblcity" runat="server" Text='<%#Eval("AgentCity") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT PIN">
                    <ItemTemplate>
                        <asp:Label ID="lblpin" runat="server" Text='<%#Eval("AgentPin") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT EMAIL">
                    <ItemTemplate>
                        <asp:Label ID="lblemail" runat="server" Text='<%#Eval("AgentEmail") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT PHONE">
                    <ItemTemplate>
                        <asp:Label ID="lblphone" runat="server" Text='<%#Eval("AgentPhone") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT FAX">
                    <ItemTemplate>
                        <asp:Label ID="lblfax" runat="server" Text='<%#Eval("AgentFax") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
        </asp:GridView>
    </div>
   
    <div class="text-right form-group">
        <asp:Button ID="btn_download" runat="server" Text="Download" 
            onclick="btn_download_Click"  CssClass="button-1"/></div>

                 </div>
        </div>

    </div>
</asp:Content>
