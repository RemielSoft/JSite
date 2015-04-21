<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="NewsLetter.aspx.cs" Inherits="JSVisaTrackingWebApplication.NewsLetter" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function confirmation() {
            if (confirm('Are you sure you want to delete ?')) {
                return true;
            } else {
                return false;
            }
        }
    </script>
    
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
        

        .MyTabStyle .ajax__tab_header {
            font-family: "Helvetica Neue", Arial, Sans-Serif;
            font-size: 20px;
            font-weight: bold;
            display: block;
        }

            .MyTabStyle .ajax__tab_header .ajax__tab_outer {
                border-color: #222;
                color: #222;
                padding-left: 10px;
                margin-right: 3px;
                border: solid 1px #d7d7d7;
            }

            .MyTabStyle .ajax__tab_header .ajax__tab_inner {
                border-color: #666;
                color: #666;
                padding: 3px 10px 2px 0px;
            }

        .MyTabStyle .ajax__tab_hover .ajax__tab_outer {
            background-color: #9c3;
        }

        .MyTabStyle .ajax__tab_hover .ajax__tab_inner {
            color: #fff;
        }

        .MyTabStyle .ajax__tab_active .ajax__tab_outer {
            background-color: #507CD1;
            color: #ffffff;
        }

        .MyTabStyle .ajax__tab_active .ajax__tab_inner {
            color: #000;
            border-color: #333;
        }

        .MyTabStyle .ajax__tab_body {
            font-family: verdana,tahoma,helvetica;
            font-size: 20px;
            background-color: #fff;
            border-top-width: 0;
            border: solid 1px #d7d7d7;
            border-top-color: #ffffff;
        }

        .button {
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

            .button:hover {
                background: #D4E3FB;
            }

            .button:active {
                background: #212121;
            }

            .button:focus {
                outline: gold solid 1px;
            }
        /*Header and Pager styles*/
        .gridview {
            font-family: 'Segoe UI Semibold', 'Open Sans', Verdana, Arial, Helvetica, sans-serif;
            font-weight: normal;
            font-size: 10pt;
            letter-spacing: 0.01em;
            line-height: 9pt;
            font-smooth: always;
            background-color: #FFFFFF;
            border: solid 1px #CCCCCC;
        }

        .gridViewHeader {
            background-color: #2D89EF;
            color: #FFFFFF;
            height: 30px;
            padding: 0px 10px 0px 10px;
            text-align: center;
            border-width: 0px;
            border-collapse: collapse;
        }

        .gridViewRow {
            background-color: #EDEDED;
            color: #000000;
            border-collapse: collapse;
        }

        .gridViewAltRow {
            background-color: #FFFFFF;
            border-width: 0px;
            border-collapse: collapse;
        }

        .gridViewSelectedRow {
            background-color: #FFCC00;
            color: #666666;
            border-width: 0px;
            border-collapse: collapse;
        }



        .gridViewPager table {
            margin: 0px 0;
            width: 20px;
            background-color: #2D89EF;
        }

        .gridViewPager td {
            font-weight: bold;
            color: #000000;
            font-size: 12px;
            border: none;
        }

        .gridViewPager a {
            color: #fff;
            text-decoration: underline;
        }

            .gridViewPager a:hover {
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

        .tpName {
            text-align: center;
        }

        .HLabel {
            position: relative;
            left: 10px;
        }

        h3 {
            text-align: center;
        }

        .pbar .ui-progressbar-value {
            display: block !important;
        }

        .pbar {
            overflow: hidden;
            position: relative;
            float: right;
            right: 80px;
            top: 10px;
        }

        .percent {
            position: absolute;
            text-align: right;
            margin: 12px 0px 0px 330px;
            font-weight: normal;
            font-size: 12px;
            font-family: Verdana;
        }

        .ui-widget {
            font-family: Trebuchet MS, Tahoma, Verdana, Arial, sans-serif;
            font-size: 1.1em;
        }

            .ui-widget .ui-widget {
                font-size: 1em;
            }

            .ui-widget input, .ui-widget select, .ui-widget textarea, .ui-widget button {
                font-family: Trebuchet MS, Tahoma, Verdana, Arial, sans-serif;
                font-size: 1em;
            }

        .ui-widget-content {
            border: 1px solid #dddddd;
            background: #eeeeee url(images/ui-bg_highlight-soft_100_eeeeee_1x100.png) 50% top repeat-x;
            color: #333333;
        }

            .ui-widget-content a {
                color: #333333;
            }

        .ui-widget-header {
            border: 1px solid #e78f08;
            background: #f6a828 url(images/ui-bg_gloss-wave_35_f6a828_500x100.png) 50% 50% repeat-x;
            color: #ffffff;
            font-weight: bold;
        }

            .ui-widget-header a {
                color: #ffffff;
            }



        .ui-progressbar {
            height: 1em;
            text-align: left;
            width: 150px;
        }

            .ui-progressbar .ui-progressbar-value {
                margin: -1px;
                height: 100%;
            }
        .ajax__tab_xp .ajax__tab_body {
          border: 1px solid #CCCCCC !important;
          border-top:none !important;
        }
        .tab-active {
     background: #f7f7f7;
border-top: 3px solid red;
padding: 10px;
position: relative;
top: -1px;
font-size: 15px;
        }
        .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
            height:auto !important;
           
        }
        .ajax__tab_xp .ajax__tab_header {
            background:none !important;
        }
        .ajax__tab_header {
             border-bottom: 1px solid #CCCCCC !important;
        }

        .ajax__tab_inner {
            border: 1px solid #CCCCCC !important;
border-bottom: none !important;
background: #fff !important;
position: relative;
top: 1px;
        }

        .ajax__tab_body ajax__scroll_none {
            border: 1px solid #CCCCCC!important;
border-top: none!important;
        }
        .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_tab {
            background:none !important;
            outline:none !important;
        }
        .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
        background:none !important;
        }

        .ajax__tab_xp .ajax__tab_header .ajax__tab_inner {
            padding-left:0px !important;
        }

        #MainContent_TabContainer1_TabPanel2_tab span span {
            margin-left: 5px !important;
        }
        .ajax__tab_xp .ajax__tab_header .ajax__tab_outer {
            background:none !important;
        }

        .newDetails {
            margin-bottom: 10px !important;
            font-size:15px !important;
            display:inline-block !important;
        }
        #MainContent_TabContainer1_TabPanel2 {
            outline:none !important;
            padding-left: 15px !important;
        }
        #MainContent_TabContainer1 {
            outline:none !important;
        }
        .ajax__html_editor_extender_container {
            width:100% !important;
        }
    </style>
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">News Letter</div>
                <div class="col-xs-12 col-sm-6 caption text-right">News Letter / Add News Letter</div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                 <div class="form-inner-bg">

    <div class="col-sm-12 col-xs-12">
                <asp:ValidationSummary ID="vs" runat="server" ValidationGroup="save" ShowMessageBox="true"
                    ShowSummary="false" />
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                <asp:TabContainer ID="TabContainer1" ForeColor="black" runat="server"
                    ActiveTabIndex="0" VerticalStripWidth="200px">
                    <asp:TabPanel runat="server" TabIndex="1" HeaderText="View News Letter" ID="TabPanel1">
                        <ContentTemplate>
                            <div class="col-xs-12 col-sm-8 no-padding">
                                <div class="row">
                                     <div class="col-sm-12 col-xs-12 form-group ">
                                     <asp:Label ID="lblTopic" runat="server" Text="Topic"
                                      Font-Bold="True" Font-Size="14px"></asp:Label>
                                    <asp:TextBox ID="txtTopic" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqfv" ControlToValidate="txtTopic" runat="server"
                                                ValidationGroup="save" ErrorMessage="Please Insert Topic Name" Display="None"></asp:RequiredFieldValidator>
                                </div> </div>
                                  <div class="row">
                                       <div class="col-sm-12 col-xs-12 form-group ">
                                  <div class="input-control text">
                                                <asp:TextBox ID="txtdes" runat="server" Height="300px"></asp:TextBox>
                                            </div>
                                            <asp:HtmlEditorExtender  ID="HtmlEditorExtender1"  runat="server" TargetControlID="txtdes"
                                                EnableSanitization="false" Enabled="True">
                                            </asp:HtmlEditorExtender>
                                      </div>
                                      </div>
                                 <div class="row">
                                      <div class="col-sm-12 col-xs-12 form-group text-right">
                                  <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="save"
                                                CssClass="button-1" />
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click1"
                                                CssClass="button-1" />
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="cancel-btn" OnClick="btnCancel_Click" />
                                     </div>
                                     </div>
                                
                            </div>
                            <div  class="col-xs-12 col-sm-4">
                                <asp:Label ID="lbluploadFile" runat="server" Text="Upload Documents" CssClass="form-group"></asp:Label>
                                <asp:FileUpload ID="uploadimage" runat="server" OnLoad="uploadimage_Load"   CssClass="form-control form-group"/>
                                <asp:Button ID="btnUpload1" runat="server" Text="Upload" OnClick="btnUpload1_Click"   CssClass="button-1 pull-right"/>
                                <asp:GridView ID="grvw_image" AutoGenerateColumns="False" runat="server" Width="100%"
                                    OnRowCommand="grvw_image_RowCommand" CellPadding="5" CssClass="gridview" OnRowDataBound="grvw_image_RowDataBound">
                                    <HeaderStyle CssClass="gridViewHeader" />
                                    <RowStyle CssClass="gridViewRow" />
                                    <AlternatingRowStyle CssClass="gridViewAltRow" />
                                    <SelectedRowStyle CssClass="gridViewSelectedRow" />
                                    <PagerStyle CssClass="gridViewPager" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="FileName">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkimage" runat="server" CommandName="cmdimage" Text='<%#Eval("ImageName") %>'
                                                    CommandArgument='<%#Eval("TopicId") %>' OnClick="OpenImage"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="cmddelete" CommandArgument='<%#Eval("TopicId") %>'
                                                    OnClientClick="return confirmation();" ForeColor="Red">Delete</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <asp:Label ID="lblfile" runat="server"></asp:Label>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel2" TabIndex="2" runat="server" HeaderText="View Details">
                        <ContentTemplate>
                            <asp:Label ID="lbldetails" runat="server" Text="News Details"  CssClass="newDetails"
                                ></asp:Label><br />
                            <div class="table-responsive">
                               
                                        <asp:GridView ID="gvwNews" runat="server" AutoGenerateColumns="False" CellPadding="5"
                                            CssClass="gridview table table-bodered table-striped" Width="100%" OnRowCommand="gvwNews_RowCommand">
                                            <HeaderStyle CssClass="gridViewHeader" />
                                            <RowStyle CssClass="gridViewRow" />
                                            <AlternatingRowStyle CssClass="gridViewAltRow" />
                                            <SelectedRowStyle CssClass="gridViewSelectedRow" />
                                            <PagerStyle CssClass="gridViewPager" />
                                            <Columns>

                                                 <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbldate" runat="server" Text='<%#Eval("NewsDate")%>' CommandName="cmdDetails"
                                                            CommandArgument='<%#Eval("TopicId") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Topic">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lblname" runat="server" Text='<%#Eval("TopicName")%>' CommandName="cmdDetails"
                                                            CommandArgument='<%#Eval("TopicId") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="140px">
                                                    <ItemTemplate>
                                                        <%--<asp:LinkButton ID="lnkedit" runat="server" CommandName="cmdEdit" CommandArgument='<%#Eval("TopicId") %>'><i class="glyphicon glyphicon-edit"></i></asp:LinkButton>--%>
                                                        <asp:LinkButton ID="lnkdelete" runat="server" CommandName="cmdelete" CommandArgument='<%#Eval("TopicId") %>'
                                                            OnClientClick="return confirmation();"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    
                            </div>
                            <asp:Button ID="Button1" runat="server" Text="Button" CssClass="displaynone" />
                            <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Button1"
                                PopupControlID="Panel2" DynamicServicePath="" Enabled="True">
                            </asp:ModalPopupExtender>
                            <asp:Panel ID="Panel2" CssClass="div-popup" runat="server">
                               <div class="div-popup-inner">
                                 <div class="message-dialog">
                                    View News Details
                                     <asp:ImageButton ID="ImageButton" CssClass="pull-right" ImageUrl="Imagess/close-icon.png"
                            runat="server" PostBackUrl="#" />
                      <%--  <asp:ImageButton ID="ImageButton2" CssClass="popup-close" ImageUrl="~/image/Close.png"
                            runat="server" />--%>
                                </div>
                                <div class="ScrollPop">

                                    <asp:Label ID="lbldate" runat="server" Text="Date: " Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Literal ID="literal4" runat="server"></asp:Literal>
                                     <br /> 
                                     <br />
                                    <asp:Label ID="lblTopicname" runat="server" Text="Topic Name: " Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Literal ID="literal2" runat="server"></asp:Literal><br />
                                    <br />
                                    <asp:Label ID="lblDescription" runat="server" Text="Description: " Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  
                                    <asp:Literal ID="literal1" runat="server"></asp:Literal>
                                          
                                      
                                    <br />
                                    <br />
                                    <asp:Label ID="lblFilename" runat="server" Text="Uploaded Document:" Font-Bold="True"></asp:Label>
                                    <%-- <a href="'<%# Eval("literal3") %>'" id="atag" runat="server"> --%>
                                     <asp:HyperLink ID="VisaFormLink" runat="server"></asp:HyperLink>
                                        <asp:Literal ID="literal3" runat="server"></asp:Literal>
                                         <%--</a>--%>
                                    <asp:LinkButton ID="lnkbtn1" runat="server" Text='<%# Eval("ImageName") %>' CommandName="cmdimage"
                                        CommandArgument='<%# Eval("ImageName") %>' OnClick="OpenDetails"></asp:LinkButton>
                                    <asp:Image ID="image1" runat="server" Visible="False" />
                                </div>
                                   </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:TabPanel>

                </asp:TabContainer>
            </div>
        </div>
    </div>
    </div></div>
    <script>
        $(document).ready(function () {


            var id = document.getElementById("__tab_MainContent_TabContainer1_TabPanel1");
            var id1 = document.getElementById("__tab_MainContent_TabContainer1_TabPanel2");
            $(id).addClass("tab-active");

            $("#__tab_MainContent_TabContainer1_TabPanel2").click(function () {
                $(id1).addClass("tab-active");
                $(id).removeClass("tab-active");
            });
            $("#__tab_MainContent_TabContainer1_TabPanel1").click(function () {
                $(id).addClass("tab-active");
                $(id1).removeClass("tab-active");
            });

        });

    </script>
</asp:Content>
