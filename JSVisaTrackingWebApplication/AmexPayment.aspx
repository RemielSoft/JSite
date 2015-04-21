<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="AmexPayment.aspx.cs" Inherits="JSVisaTrackingWebApplication.AmexPayment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <title></title>
    <style type="text/css">
        .auto-style1 {
            background: #f8f8f8;
            border: 1px solid #e2e2e2;
            box-shadow: 0px 1px 5px #333;
            position: relative;
            top: 10px;
            max-width: 500px;
            margin-bottom: 20px;
            padding: 20px;
        }

        .auto-style2 {
            max-width: 189px;
        }

        body {
            margin: 0px;
            padding: 0;
        }

        .auto-style1 input, select {
            width: 100%;
            display: block;
        }

            .auto-style1 input[type="submit"] {
                width: auto;
                float: right;
            }

        @media screen and (max-width:480px) {
            .auto-style1 {
                padding: 0;
            }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <section>
    <div class="container-fulid page-heading">
     <div class="container">
         <div class="row">
         <div class="col-xs-12 col-sm-6">Online Payment</div>
         <div class="col-xs-12 col-sm-6 caption text-right">Home / Online Payment</div>
             </div>
     </div>
    </div>
</section>

    <asp:ValidationSummary ID="PaymentValidationSummary" runat="server" ValidationGroup="PaymentValidationGroup" CssClass="failureNotification" 
         ShowMessageBox="true"  ShowSummary="false" EnableClientScript="true" Enabled="true" />

      <div class="container">
         <div class="row">
                <div class="col-xs-12 col-sm-6 center-block" style="float:none;">
    <div class="table-responsive">
        <table class="table table-bordered table-striped">
            <tr>
                <td class="auto-style2"colspan="2" style="  font-size: 25px; text-align: center; color: red;" >
                    Make Online Payment
                </td>
              
            </tr>
            <tr>
                <td class="auto-style2">Order Reference No. :<font color="RED"><span class="Apple-converted-space">&nbsp;</span>*</font></td>
                <td>
                    <asp:TextBox ID="txtOrderNo" runat="server" class="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="OrderNo" runat="server" ControlToValidate="txtOrderNo" display ="None" 
                                     ErrorMessage="Please Fill The Order No First" ForeColor="Red" ToolTip="Order No is required." 
                                     ValidationGroup="PaymentValidationGroup">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Amount (In INR). :<font color="RED">* #</font></td>
                <td>
                    <asp:TextBox ID="txtAmount" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="AmountValidate" runat="server" ControlToValidate="txtAmount" display ="Dynamic"
                                     ErrorMessage="Please Enter the Amount First" ForeColor="Red" ToolTip="Amount is required." 
                                     ValidationGroup="PaymentValidationGroup"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Name :<font color="RED"><span class="Apple-converted-space">&nbsp;</span>*</font></td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="NameValidate" runat="server" ControlToValidate="txtName" display ="Dynamic"
                                     ErrorMessage="Please Enter the Name First" ForeColor="Red" ToolTip="Name is required." 
                                     ValidationGroup="PaymentValidationGroup"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">E-Mail :<font color="RED"><span class="Apple-converted-space">&nbsp;</span>*</font></td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                      <asp:RegularExpressionValidator ID="REVEmail" runat="server" Display="Dynamic" ErrorMessage="Please Enter Correct Email."
                       ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                      </asp:RegularExpressionValidator>
                     <asp:RequiredFieldValidator ID="EmailValidate" runat="server" ControlToValidate="txtEmail" display ="Dynamic"
                                     ErrorMessage="Please Enter the Email First" ForeColor="Red" ToolTip="Email is required." 
                                     ValidationGroup="PaymentValidationGroup"></asp:RequiredFieldValidator>
                </td>
            </tr>

         
            <tr>
                <td class="auto-style2">Phone :<font color="RED"><span class="Apple-converted-space">&nbsp;</span>*</font></td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" class="form-control"></asp:TextBox>
                     <asp:RegularExpressionValidator runat="server" ID="rexNumber" Display="Dynamic" ForeColor="Red" ControlToValidate="txtPhone" 
                         ValidationExpression="^[7-9][0-9]{9}$" ErrorMessage="Please enter a valid mobile number" />
                    <asp:RequiredFieldValidator ID="PhoneValidate" runat="server" ControlToValidate="txtPhone" display ="Dynamic"
                                     ErrorMessage="Please Enter the Email First" ForeColor="Red" ToolTip="Email is required." 
                                     ValidationGroup="PaymentValidationGroup"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Country :</td>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server" class="form-control">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <%--<asp:ListItem>Afganistan</asp:ListItem>
                         <asp:ListItem>Argetina</asp:ListItem>
                         <asp:ListItem>Bahrain</asp:ListItem>
                         <asp:ListItem>Belarus</asp:ListItem>
                         <asp:ListItem>China</asp:ListItem>
                         <asp:ListItem>Colombia</asp:ListItem>
                         <asp:ListItem>Iceland</asp:ListItem>
                        <asp:ListItem>India</asp:ListItem>
                        <asp:ListItem>Indonesia</asp:ListItem>--%>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="ddlValidate" runat="server" ControlToValidate="ddlCountry" display ="Dynamic"
                                     ErrorMessage="Please Enter the Email First" ForeColor="Red" ToolTip="Email is required." 
                                     ValidationGroup="PaymentValidationGroup"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">City :<font color="RED"><span class="Apple-converted-space">&nbsp;</span>*</font></td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" class="form-control"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="CityValidate" runat="server" ControlToValidate="txtCity" display ="Dynamic"
                                     ErrorMessage="Please Enter the City First" ForeColor="Red" ToolTip="Email is required." 
                                     ValidationGroup="PaymentValidationGroup"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">State :<font color="RED"><span class="Apple-converted-space">&nbsp;</span>*</font></td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" class="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="StateValidate" runat="server" ControlToValidate="txtState" display ="Dynamic"
                                     ErrorMessage="Please Enter the State First" ForeColor="Red" ToolTip="Email is required." 
                                     ValidationGroup="PaymentValidationGroup"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Address :<font color="RED">*</font></td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" class="form-control"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="AddressValidate" runat="server" ControlToValidate="txtAddress" display ="Dynamic"
                                     ErrorMessage="Please Enter the Email First" ForeColor="Red" ToolTip="Email is required." 
                                     ValidationGroup="PaymentValidationGroup"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Zip/Pin Code :<font color="RED"><span class="Apple-converted-space">&nbsp;</span>*</font></td>
                <td>
                    <asp:TextBox ID="txtZipPin" MaxLength="6" runat="server" class="form-control"></asp:TextBox>
                  <%--  <asp:RegularExpressionValidator ID="regeZipCode" runat="server" ControlToValidate="txtZipPin"
                                                        ValidationGroup="PaymentValidationGroup" Display="Dynamic" ForeColor="Red" ErrorMessage="Should be 5 or 9 Digits"
                                                        ValidationExpression="\\d{5}(-\\d{4})?$"></asp:RegularExpressionValidator>--%>
                      <asp:RequiredFieldValidator ID="ZipPinValidate" runat="server" ControlToValidate="txtZipPin" display ="Dynamic"
                                     ErrorMessage="Please Enter the Address First" ForeColor="Red" ToolTip="Email is required." 
                                     ValidationGroup="PaymentValidationGroup"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style2">Order Details :<Font color="RED"><span class="Apple-converted-space">&nbsp;</span>*</Font></td>
                <td>
                   
                    
                    <asp:TextBox ID="txtOrderDetail" runat="server" TextMode="Multiline" class="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="OrderDetailValidate" runat="server" ControlToValidate="txtOrderDetail" display ="Dynamic"
                                     ErrorMessage="Please Enter the Email First" ForeColor="Red" ToolTip="Email is ." 
                                     ValidationGroup="PaymentValidationGroup"></asp:RequiredFieldValidator>

                </td>
            </tr>
          
            <tr>
                
                <td colspan="2">
                    <div class="col-sm-4 pull-right">
                    <asp:Button ID="Button1"   ValidationGroup="PaymentValidationGroup" runat="server" OnClick="Button1_Click" Text="Make Payment"  class="button"/>
                   </div>
                </td>
            </tr>
          
           <tr>   
           </tr>
        </table>
        </div>
             </div>
          </div>
    </div>

       
</asp:Content>
