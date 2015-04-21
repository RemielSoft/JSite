<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="JSVisaTrackingWebApplication.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


 <div id="login_panel" class="login_panel">
        
                        <div class="login_inner_container" style="display: inline-block;">
                            <div class="inner_container cred" style="height:0px;">
                                <div class="login_workload_logo_container">
                                    <img id="login_workload_logo_image" class="workload_img" src="../images/Jetsavelogo.png"
                                        alt="Sign in to Office 365" style="visibility: visible;"></div>
                                <div class="login_cta_container normaltext">
                                    <div id="login_cta_text" class="cta_message_text 1">
                                        Sign in with your organizational account</div>
                                </div>
                                <ul class="login_cred_container">
                                    <li class="login_cred_field_container">
                                        <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
                                            OnAuthenticate="LoginUser_Authenticate">
                                            <LayoutTemplate>
                                                <span class="failureNotification">
                                                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                                </span>
                                                <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                                                    ValidationGroup="LoginUserValidationGroup" ShowMessageBox="true" ShowSummary="false" />
                                                <div class="accountInfo">
                                                    <div id="cred_userid_container" class="login_textfield textfield">
                                                        <span class="input_field textfield">
                                                            <asp:TextBox ID="UserName" class="login_textfield textfield required email field normaltext"
                                                                placeholder="someone@example.com " runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                                CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                                        </span>
                                                    </div>
                                                    <div id="cred_password_container" class="login_textfield textfield" style="visibility: visible;
                                                        opacity: 1;">
                                                        <span class="input_field textfield">
                                                            <asp:TextBox ID="Password" class="login_textfield textfield required field normaltext"
                                                                placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                                CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                                        </span>
                                                    </div>
                                                    <%--<div id="cred_kmsi_container" class="subtext normaltext">
                                                        <span class="input_field">
                                                            <asp:checkbox id="rememberme" runat="server" />
                                                            <asp:label id="remembermelabel" runat="server" associatedcontrolid="rememberme" class="persist_text">
                                                    keep me signed in</asp:label></span>
                                                    </div>--%>
                                                    <asp:Button ID="LoginButton" runat="server" CssClass="button normaltext cred_sign_in_button disabled_button"
                                                        Text="Sign in" CommandName="Login" ValidationGroup="LoginUserValidationGroup"  />
                                                </div>
                                            </LayoutTemplate>
                                        </asp:Login>
                                    </li>
                                    <li class="login_cred_options_container">
                                        <div id="recover_container" class="subtext smalltext" style="visibility: visible;
                                            opacity: 1;">
                                            <%--<span>
                                                <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false"> Register Here</asp:HyperLink>
                                                if you don't have an account. </span>--%>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <div class="push">
                            </div>
                        </div>
                        <div id="footer_links_container" class="login_footer_container">
                            <div class="footer_inner_container">
                                <table id="footer_table">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <div class="footer_glyph">
                                                    <img src="https://secure.aadcdn.microsoftonline-p.com/~Live.SiteContent.MSOID/~17.1.31/~/~/~/~/images/AD_Glyph_Footer_30x30.png"
                                                        class="footer_glyph" alt="Organizational account">
                                                </div>
                                            </td>
                                            <td>
                                                <div class="footer tinytext">
                                                    <span class="corporate_footer"><span class="corp_link" id="footer_copyright_link">Jetsave
                                                        India Tours Pvt. Ltd, All Rights Reserved. </span>
                                                        <br />
                                                        <span class="corp_link"><a tabindex="40" id="footer_link_0" class="STRID_FOOTER_TEXT_LEGAL"
                                                            href="#">Legal</a></span><span class="corp_link"><a tabindex="41" id="footer_link_1"
                                                                class="STRID_FOOTER_TEXT_PRIVACY" href="#">Privacy</a></span></span>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    
    </div>


    
</asp:Content>
