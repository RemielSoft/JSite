<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test2.aspx.cs" Inherits="JSVisaTrackingWebApplication.Test2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
           display:none;
        }
        .MyTabStyle .ajax__tab_header
        {
            font-family: "Helvetica Neue" , Arial, Sans-Serif;
            font-size: 14px;
            font-weight:bold;
            display: block;

        }
        .MyTabStyle .ajax__tab_header .ajax__tab_outer
        {
            border-color: #222;
            color: #222;
            padding-left: 10px;
            margin-right: 3px;
            border:solid 1px #d7d7d7;
        }
        .MyTabStyle .ajax__tab_header .ajax__tab_inner
        {
            border-color: #666;
            color: #666;
            padding: 3px 10px 2px 0px;
        }
        .MyTabStyle .ajax__tab_hover .ajax__tab_outer
        {
            background-color:#9c3;
        }
        .MyTabStyle .ajax__tab_hover .ajax__tab_inner
        {
            color: #fff;
        }
        .MyTabStyle .ajax__tab_active .ajax__tab_outer
        {
           
            background-color: #507CD1;
            color:#ffffff;
        }
        .MyTabStyle .ajax__tab_active .ajax__tab_inner
        {
            color: #000;
            border-color: #333;
        }
        .MyTabStyle .ajax__tab_body
        {
            font-family: verdana,tahoma,helvetica;
            font-size: 10pt;
            background-color: #fff;
            border-top-width: 0;
            border: solid 1px #d7d7d7;
            border-top-color: #ffffff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:TabContainer ID="TabContainer1"   ForeColor="White" BackColor="Blue"   runat="server" ActiveTabIndex="0" VerticalStripWidth="200px">
        <asp:TabPanel runat="server" TabIndex="1" HeaderText="ViewNewsLetter" ID="TabPanel1">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="lblTopic" runat="server" Text="Topic"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTopic" runat="server" Width="300" Height="26px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="input-control text">
                                <asp:TextBox ID="txtdes" runat="server" Width="406px" Height="300"></asp:TextBox>
                            </div>
                            <asp:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" TargetControlID="txtdes"
                                EnableSanitization="false">
                            </asp:HtmlEditorExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="LinkButton1" runat="server">Upload</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn" runat="server" Text="Save" OnClick="btn_Click" Width="54px" />
                            <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click1" />
                        </td>
                    </tr>
                   
                </table>
                 <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton1"
                        PopupControlID="Panel1">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="Panel1" CssClass="div-popup" runat="server">
                        <div class="message-dialog">
                            Upload Files
                            <asp:ImageButton ID="ImageButton1" CssClass="popup-close" ImageUrl="~/image/Close.png"
                                runat="server" />
                        </div>
                        <asp:FileUpload ID="File1" runat="server" /><br />
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </asp:Panel>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" TabIndex="2" runat="server" HeaderText="ViewDetails">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="gvwNews" runat="server" AutoGenerateColumns="False" Width="100%"
                                GridLines="Horizontal" BackColor="White" CellPadding="4" 
                                ForeColor="#000FFF" OnRowCommand="gvwNews_RowCommand">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                      
                                            <asp:LinkButton ID="lblname" runat="server" Text='<%#Eval("TopicName") %>' CommandName="cmdDetails"
                                                CommandArgument='<%#Eval("TopicId") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkedit" runat="server" CommandName="cmdEdit" CommandArgument='<%#Eval("TopicId") %>'>Edit</asp:LinkButton>
                                            <asp:LinkButton ID="lnkdelete" runat="server" CommandName="cmdelete" CommandArgument='<%#Eval("TopicId") %>'>Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                              
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button1" runat="server" Text="Button" CssClass="displaynone"/>
                <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Button1"
                    PopupControlID="Panel2" DynamicServicePath="" Enabled="True">
                </asp:ModalPopupExtender>
                <asp:Panel ID="Panel2" CssClass="div-popup" runat="server">
                    <div class="message-dialog">
                        View News Details
                        <asp:ImageButton ID="ImageButton2" CssClass="popup-close" ImageUrl="~/image/Close.png"
                            runat="server" />
                    </div>
                    <asp:Label ID="lbldetailNews" runat="server" Text='<%# Eval("TopicName") %>'></asp:Label>
                </asp:Panel>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    </form>
</body>
</html>
