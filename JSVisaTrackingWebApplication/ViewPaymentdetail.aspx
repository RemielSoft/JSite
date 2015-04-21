<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="ViewPaymentdetail.aspx.cs" Inherits="JSVisaTrackingWebApplication.ViewPaymentdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <title></title>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <section>
        <div class="container-fulid page-heading">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-sm-12">View Payment Detail</div>
                    
                </div>
            </div>
        </div>
    </section>
      <div class="container">
    <div class="row">
        <div class="middle">
            <div class="container">
                <div class="row">
                    
                    <div class="col-xs-12 col-sm-6 center-block" style="float:none;">
    <form id="form_EzeClick" method="post" action="https://payments.billdesk.com/amexezeclick/payment/paymentRequest">
        <input type="hidden" name="merchantRequest" id="merchantRequest" runat="server" value="" />
        <input type="hidden" name="MID" id="MID" runat="server" value="" />
        <script>
            function btnPayNow_Click() {

            }
        </script>
      
        <div class="table-responsive">
            <table class="table table-bordered table-striped">
                <tr>
                    <td class="auto-style2"><span><b>Customer Name :</b></span></td>
                    <td colspan="6">
                        <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><b>Amount:</b></td>
                    <td colspan="6">
                        <asp:Label ID="lblAmount" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><span><b>E- Mail Address :</b></span></td>
                    <td colspan="6">
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><span><b>Street Address :</b></span></td>
                    <td colspan="6">
                        <asp:Label ID="lblStreetAddress" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><span><b>City :</b></span></td>
                    <td>
                        <asp:Label ID="lblCountry" runat="server"><b>State :</b></asp:Label></td>
                    <td>
                        <asp:Label ID="lblStateName" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblCountry0" runat="server"><b>Country :</b></asp:Label></td>

                    <td>
                        <asp:Label ID="lblCountryName" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblZip" runat="server"><b>Zip :</b></asp:Label></td>
                    <td>
                        <asp:Label ID="lblZipCode" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td colspan="7" style="text-align: center; color: red;"><span>If the information above needs some correction then click the &quot;Go Back&quot; button otherwise click on &quot;Pay Now!&quot; button</span><br style="color: rgb(0, 0, 0); font-family: arial; font-size: small; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: -webkit-center; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;" />
                        <font color="red"> *<span class="Apple-converted-space">&nbsp;</span></font><span style="color: red; font-family: arial; font-size: small; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: -webkit-center; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">Convenience 
                        Charges of 2.8% is added on total amount.</span></td>
                </tr>
                <tr>
                    <td colspan="7">

                        <div class="col-sm-5 pull-right">
                            <input type="submit" name="btnPay" value="Pay Now!" id="btnPayNow" onclick="return btnPayNow_Click" class="button width-auto">
                       <asp:Button ID="btnBack" runat="server" PostBackUrl="~/AmexPayment.aspx" Text="GoBack" class="button width-auto"/></div>
                         
                    </td>
                </tr>
            </table>

        </div>
    </form>
                        </div> </div>
                 </div>
             </div>
         </div>
           </div>
        
</asp:Content>
