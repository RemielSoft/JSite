<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Test.aspx.cs" Inherits="JSVisaTrackingWebApplication.Test" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <%-- <br /><br />
    <asp:LinkButton ID="LinkButton1" runat="server" ToolTip="Save"><span class="label info">Save <i class="icon-save fg-color-white"></i></span></asp:LinkButton> 
    <asp:LinkButton ID="LinkButton2" runat="server" ToolTip="Update"><span class="label success">Update <i class="icon-loading-2 fg-color-white"></i></span></asp:LinkButton>
    <asp:LinkButton ID="LinkButton3" runat="server" ToolTip="Cancel"><span class="label important">Cancel <i class="icon-cancel-2 fg-color-white"></i></span></asp:LinkButton>
    <asp:LinkButton ID="LinkButton4" runat="server" ToolTip="Download"><span class="label warning">Download <i class="icon-download-2 fg-color-white"></i></span></asp:LinkButton>
     <br /><br />--%>
      <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                                            <asp:TextBox ID="txtSubmDate" runat="server"></asp:TextBox>
                                            <i class="btn-date"></i>
                                        </div>
    <asp:Button ID="Button1" runat="server" Text="Button" />
</asp:Content>
