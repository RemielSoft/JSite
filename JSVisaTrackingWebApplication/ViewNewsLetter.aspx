<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ViewNewsLetter.aspx.cs" Inherits="JSVisaTrackingWebApplication.ViewNewsLetter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<script type="text/javascript">
        document.createElement('header');
        document.createElement('section');
        document.createElement('article');
        document.createElement('aside');
        document.createElement('nav');
        document.createElement('footer');
    </script>--%>
    <style type="text/css">
        /* Popup box css */
        .div-popup
        {
             position:fixed;
            width:100%;
            height:100%;
            background:rgba(0,0,0,0.7);
            top:0;
            right:0;
            left:0;
            bottom:0;
        }
        .div-popup-inner {
            width:auto;
            background: #fff;
            margin:50px;
            padding-bottom: 20px;
        }
     
        .message-dialog
        {
            
            padding: 5px 10px;
            background:#e70012;
            color: #ffffff;
            font-weight: bold;
        }
        .displaynone
        {
            display: none;
            width:1px;
            height:1px;
            margin-left:5px;
            background-color:White;
            position:absolute;
            z-index:-10001;
        }
        
        .button
        {
            background: #2672EC;
            border: 1px solid #FFFFFF;
            padding: 6px 12px 6px 12px;
            color: #FFFFFF;
            width: auto;
            cursor: pointer;
            transition: background 1s;
            -moz-transition: background 1s;
            -webkit-transition: background 1s;
            -o-transition: background 1s;
            transition-property: background;
            transition-duration: 1s;
            -webkit-touch-callout: none;
            -webkit-user-select: none;
            -khtml-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            -o-user-select: none;
            user-select: none;
        }
        
        .button:hover
        {
            background: #D4E3FB;
        }
        
        .button:active
        {
            background: #212121;
        }
        
        .button:focus
        {
            outline: gold solid 1px;
        }
        /*Header and Pager styles*/
        .gridview
        {
            font-family: 'Segoe UI Semibold' , 'Open Sans' , Verdana, Arial, Helvetica, sans-serif;
            font-weight: normal;
            font-size: 10pt;
            letter-spacing: 0.01em;
            line-height: 9pt;
            font-smooth: always;
            background-color: #FFFFFF;
            border: solid 1px #CCCCCC;
        }
        
        .gridViewHeader
        {
            background-color: #2D89EF;
            color: #FFFFFF;
            height: 30px;
            padding: 0px 10px 0px 10px;
            text-align: center;
            border-width: 0px;
            border-collapse: collapse;
        }
        
        .gridViewRow
        {
            background-color: #EDEDED;
            color: #000000;
            border-collapse: collapse;
        }
        
        .gridViewAltRow
        {
            background-color: #FFFFFF;
            border-width: 0px;
            border-collapse: collapse;
        }
        
        .gridViewSelectedRow
        {
            background-color: #FFCC00;
            color: #666666;
            border-width: 0px;
            border-collapse: collapse;
        }
        
        
        
        .gridViewPager table
        {
            margin: 0px 0;
            width: 20px;
            background-color: #2D89EF;
        }
        .gridViewPager td
        {
            font-weight: bold;
            color: #000000;
            font-size: 12px;
            border: none;
        }
        .gridViewPager a
        {
            color: #fff;
            text-decoration: underline;
        }
        .gridViewPager a:hover
        {
            color: #ccc;
            text-decoration: none;
        }

      

        .ScrollPop
        {
            position: relative;
            top:0px;
            width: 100%;
            margin-top:10px;
            padding:0px 10px 10px 10px;
            overflow-y:scroll;
            overflow-x:hidden;
            height:500px;
          
        }
           
        .tpName
        {
            text-align: center;
        }
        .table-width table {
            width:100% !important;
        }
        .box-heading {
            font-size:15px;
            font-weight:bold;
        }
        .box-text {
            font-weight:bold;
            font-size:20pt;
        }
        .box-Destext {
            font-weight:bold;
            font-size:20pt;
        }
        
    </style>
</asp:Content>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">View News Letter</div>
                <div class="col-xs-12 col-sm-6 caption text-right">News Letter / View News Letter</div>
            </div>
        </div>
    </div>


     <div class="container" style="margin-top:20px;">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
           
     <div class="table table-responsive">
 
                <asp:GridView ID="grdViewNewsletter" runat="server" AutoGenerateColumns="False" CellPadding="5"
                    CssClass="gridview table table-bordered table-striped table-condensed" Width="100%" OnRowCommand="grdViewNewsletter_RowCommand">
                    <HeaderStyle CssClass="gridViewHeader" />
                    <RowStyle CssClass="gridViewRow" />
                    <AlternatingRowStyle CssClass="gridViewAltRow" />
                    <SelectedRowStyle CssClass="gridViewSelectedRow" />
                    <PagerStyle CssClass="gridViewPager" />
                    <Columns>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblname" runat="server" Text='<%#Eval("NewsDate")%>' CommandName="cmdDetails"
                                    CommandArgument='<%#Eval("TopicId") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Topic">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbldate" runat="server"  Text='<%#Eval("TopicName")%>' CommandName="cmdDetails"
                                    CommandArgument='<%#Eval("TopicId") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

    

    <asp:Button ID="Button1" runat="server" CssClass="displaynone" />
    <div>
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Button1"
            PopupControlID="Panel2" DynamicServicePath="" Enabled="True">
        </asp:ModalPopupExtender>
         <div class="ScrollPop-Outer">
        <asp:Panel ID="Panel2" CssClass="div-popup" runat="server">
            <div class="div-popup-inner">
            <div class="message-dialog">
                View News Details
                <asp:ImageButton ID="ImageButton" CssClass="pull-right" ImageUrl="Imagess/close-icon.png"
                            runat="server" PostBackUrl="#" />
            </div>
           
            <div class="ScrollPop">
                <div class="row">
                    <div class="col-sm-3" style="margin-bottom:5px;">
                <asp:Label ID="lblDate" runat="server" Text="Date:" Font-Bold="True" CssClass="box-heading"></asp:Label>
                 </div>
                    <div class="col-sm-9 table-width box-text">
                <asp:Literal ID="literal3" runat="server"></asp:Literal>
                  </div>
                    </div>
                     <div class="row">
                <div class="col-sm-3">
                <asp:Label ID="lblTopicname" runat="server" Text="TopicName:" Font-Bold="True" CssClass="box-heading"></asp:Label>
                 </div>
                <div class="col-sm-9 table-width box-text">
                <asp:Literal ID="literal2" runat="server"></asp:Literal>
                  </div>
                         </div>
 <div class="row">
                    <div class="col-sm-3">
                <asp:Label ID="lblDescription" runat="server" Text="Description:" Font-Bold="True" CssClass="box-heading"></asp:Label>
                        
                 </div>
                <div class="col-sm-9 table-width box-text">
                <asp:Literal ID="literal4" runat="server"></asp:Literal>
                  </div>
                   
                    </div>
                 <%-- <div class="row">
                   <div class="col-sm-4">
                <asp:Label ID="lblDescription" runat="server" Text="Description: " Font-Bold="True"></asp:Label>
               </div>
                 <div class="col-sm-8">
                <asp:Literal ID="literal1" runat="server"></asp:Literal>
                     </div>
                      </div>--%>
                  <div class="row">
                  <div class="col-sm-4">
                      <asp:Label ID="lblFilename" runat="server" Text="Uploaded Document: " Font-Bold="True">
                          
                      </asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:HyperLink ID="VisaFormLink" runat="server"></asp:HyperLink>
                      <asp:Literal ID="literal5" runat="server"></asp:Literal>
                       <div class="col-sm-10 table-width">
              <%--  <asp:Literal ID="literal5" runat="server"></asp:Literal>--%>
                  </div>
                  </div>
                <div class="col-sm-8"> <asp:LinkButton ID="lnkbtn1" runat="server" Text='<%# Eval("ImageName") %>' CommandName="cmdimage"
                    CommandArgument='<%# Eval("ImageName") %>' OnClick="OpenDetails"></asp:LinkButton></div>
                      </div>
                <asp:Image ID="image1" runat="server" Visible="False" />
            </div>
          </div>
        </asp:Panel>
             </div>
    </div>
     </div></div>
         </div>
</asp:Content>
