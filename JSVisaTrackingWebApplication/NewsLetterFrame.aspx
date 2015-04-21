<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsLetterFrame.aspx.cs"
    Inherits="JSVisaTrackingWebApplication.Test2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <h2>
        <i class="icon-user fg-color-blue"></i>News Letter
    </h2>
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
            background-color: #fff;
            -moz-box-shadow: 0px 3px 7px 0px #070101;
            -webkit-box-shadow: 0px 3px 7px 0px #070101;
            box-shadow: 0px 3px 7px 0px #070101;
            padding: 0px 0px 0px 0px;
            width: 50%;
            height: 300px;
        }
        .popup-close
        {
            position: absolute;
            top: 5px;
            right: 5px;
        }
        
        .message-dialog
        {
            position: relative;
            top: 0px;
            left: 0px;
            height: 20px;
            top: 0px;
            padding: 5px 10px;
            background: #3C86D7;
            color: #ffffff;
            font-family: Arial, Sans-Serif, Verdana;
            font-size: 13px;
            font-weight: bold;
        }
        .displaynone
        {
            display: none;
        }
        .MyTabStyle .ajax__tab_header
        {
            font-family: "Helvetica Neue" , Arial, Sans-Serif;
            font-size: 20px;
            font-weight: bold;
            display: block;
        }
        .MyTabStyle .ajax__tab_header .ajax__tab_outer
        {
            border-color: #222;
            color: #222;
            padding-left: 10px;
            margin-right: 3px;
            border: solid 1px #d7d7d7;
        }
        .MyTabStyle .ajax__tab_header .ajax__tab_inner
        {
            border-color: #666;
            color: #666;
            padding: 3px 10px 2px 0px;
        }
        .MyTabStyle .ajax__tab_hover .ajax__tab_outer
        {
            background-color: #9c3;
        }
        .MyTabStyle .ajax__tab_hover .ajax__tab_inner
        {
            color: #fff;
        }
        .MyTabStyle .ajax__tab_active .ajax__tab_outer
        {
            background-color: #507CD1;
            color: #ffffff;
        }
        .MyTabStyle .ajax__tab_active .ajax__tab_inner
        {
            color: #000;
            border-color: #333;
        }
        .MyTabStyle .ajax__tab_body
        {
            font-family: verdana,tahoma,helvetica;
            font-size: 20px;
            background-color: #fff;
            border-top-width: 0;
            border: solid 1px #d7d7d7;
            border-top-color: #ffffff;
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
            width: 504px;
            height: 265px;
            overflow: scroll;
            overflow-x: hidden;
            left: 7px;
        }
        .tpName
        {
            text-align: center;
        }
        .HLabel
        {
            position: relative;
            left: 10px;
        }
        h3
        {
            text-align: center;
        }
        
        .pbar .ui-progressbar-value
        {
            display: block !important;
        }
        .pbar
        {
            overflow: hidden;
            position: relative;
            float: right;
            right: 80px;
            top: 10px;
        }
        .percent
        {
            position: absolute;
            text-align: right;
            margin: 12px 0px 0px 330px;
            font-weight: normal;
            font-size: 12px;
            font-family: Verdana;
        }
        
        .ui-widget
        {
            font-family: Trebuchet MS, Tahoma, Verdana, Arial, sans-serif;
            font-size: 1.1em;
        }
        .ui-widget .ui-widget
        {
            font-size: 1em;
        }
        .ui-widget input, .ui-widget select, .ui-widget textarea, .ui-widget button
        {
            font-family: Trebuchet MS, Tahoma, Verdana, Arial, sans-serif;
            font-size: 1em;
        }
        .ui-widget-content
        {
            border: 1px solid #dddddd;
            background: #eeeeee url(images/ui-bg_highlight-soft_100_eeeeee_1x100.png) 50% top repeat-x;
            color: #333333;
        }
        .ui-widget-content a
        {
            color: #333333;
        }
        .ui-widget-header
        {
            border: 1px solid #e78f08;
            background: #f6a828 url(images/ui-bg_gloss-wave_35_f6a828_500x100.png) 50% 50% repeat-x;
            color: #ffffff;
            font-weight: bold;
        }
        .ui-widget-header a
        {
            color: #ffffff;
        }
        
        
        
        .ui-progressbar
        {
            height: 1em;
            text-align: left;
            width: 150px;
        }
        .ui-progressbar .ui-progressbar-value
        {
            margin: -1px;
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ValidationSummary ID="vs" runat="server" ValidationGroup="save" ShowMessageBox="true"
        ShowSummary="false" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:TabContainer ID="TabContainer1" ForeColor="black" BackColor="Blue" runat="server"
        ActiveTabIndex="0" VerticalStripWidth="200px">
        <asp:TabPanel runat="server" TabIndex="1" HeaderText="View News Letter" ID="TabPanel1">
            <ContentTemplate>
                <div style="position: relative; float: left; top: 0px; width: 50%;">
                    <table class="table table-bordered table-striped table-condensed">
                        <tr>
                            <td style="height: 26px; vertical-align: text-top;">
                                <asp:Label ID="lblTopic" runat="server" Text="Topic&lt;span style=&quot;color:Red;&quot;&gt;*&lt;/span&gt;"
                                    Font-Bold="True" Font-Size="14px"></asp:Label>
                            </td>
                            <td style="height: 26px">
                                <asp:TextBox ID="txtTopic" runat="server" Width="444px" Height="26px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqfv" ControlToValidate="txtTopic" runat="server"
                                    ValidationGroup="save" ErrorMessage="Please Insert Topic Name" Display="None"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="input-control text">
                                    <asp:TextBox ID="txtdes" runat="server" Width="500px" Height="300px"></asp:TextBox>
                                </div>
                                <asp:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" TargetControlID="txtdes"
                                    EnableSanitization="False" Enabled="True">
                                </asp:HtmlEditorExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 5px;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="save"
                                    CssClass="button" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click1"
                                    CssClass="button" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="position: relative; float: right; top: 0px; padding-left: 20px; width: 45%;">
                    <asp:Label ID="lbluploadFile" runat="server" Text="Upload Documents" Font-Bold="True"
                        Font-Underline="True"></asp:Label>
                    <asp:FileUpload ID="uploadimage" runat="server" OnLoad="uploadimage_Load" Width="200px" />
                    <asp:Button ID="btnUpload1" runat="server" Text="Upload" OnClick="btnUpload1_Click" />
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
                <asp:Label ID="lbldetails" runat="server" Text="News Details" Font-Bold="True" ForeColor="Blue"
                    Font-Underline="True"></asp:Label><br />
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="gvwNews" runat="server" AutoGenerateColumns="False" CellPadding="5"
                                CssClass="gridview" Width="100%" OnRowCommand="gvwNews_RowCommand">
                                <HeaderStyle CssClass="gridViewHeader" />
                                <RowStyle CssClass="gridViewRow" />
                                <AlternatingRowStyle CssClass="gridViewAltRow" />
                                <SelectedRowStyle CssClass="gridViewSelectedRow" />
                                <PagerStyle CssClass="gridViewPager" />
                                <Columns>
                                    <asp:TemplateField HeaderText="FileName">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblname" runat="server" Text='<%#Eval("TopicName")%>' CommandName="cmdDetails"
                                                CommandArgument='<%#Eval("TopicId") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="140px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkedit" runat="server" CommandName="cmdEdit" CommandArgument='<%#Eval("TopicId") %>'>Edit</asp:LinkButton>
                                            <asp:LinkButton ID="lnkdelete" runat="server" CommandName="cmdelete" CommandArgument='<%#Eval("TopicId") %>'
                                                OnClientClick="return confirmation();">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button1" runat="server" Text="Button" CssClass="displaynone" />
                <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Button1"
                    PopupControlID="Panel2" DynamicServicePath="" Enabled="True">
                </asp:ModalPopupExtender>
                <asp:Panel ID="Panel2" CssClass="div-popup" runat="server">
                    <div class="message-dialog">
                        View News Details
                        <asp:ImageButton ID="ImageButton2" CssClass="popup-close" ImageUrl="~/image/Close.png"
                            runat="server" />
                    </div>
                    <div class="ScrollPop">
                        <asp:Label ID="lblTopicname" runat="server" Text="Topic Name: " Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Literal ID="literal2" runat="server"></asp:Literal><br />
                        <br />
                        <asp:Label ID="lblDescription" runat="server" Text="Description: " Font-Bold="True"></asp:Label><br />
                        <br />
                        <asp:Literal ID="literal1" runat="server"></asp:Literal>
                        <br />
                        <br />
                        <asp:Label ID="lblFilename" runat="server" Text="Uploaded Document" Font-Bold="True"></asp:Label>
                        <asp:LinkButton ID="lnkbtn1" runat="server" Text='<%# Eval("ImageName") %>' CommandName="cmdimage"
                            CommandArgument='<%# Eval("ImageName") %>' OnClick="OpenDetails"></asp:LinkButton>
                        <asp:Image ID="image1" runat="server" Visible="False" />
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:TabPanel>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </asp:TabContainer>
    </form>
</body>
</html>
