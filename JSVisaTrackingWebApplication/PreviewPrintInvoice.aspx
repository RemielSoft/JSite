<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreviewPrintInvoice.aspx.cs"
    Inherits="JSVisaTrackingWebApplication.PreviewPrintInvoice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<title></title>
<!--[if lt IE 9]>
<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
    
<style type="text/css">
    .maindiv
    {
        position: relative;
        width: 100%;
        margin: 0px auto;
        font-family: Verdana;
        font-size: 12px;
        top: 0px;
        left: 0px;
        height: auto;
    }
    .div1
    {
        position: relative;
        width: 250px;
        float: left;
        height: 100px;
    }
    .div2
    {
        position: relative;
        width: 300px;
        float: left;
        height: 100px;
        padding: 5px;
        text-align: center;
    }
    .div3
    {
        position: relative;
        float: left;
        height: 100px;
    }
    .div4
    {
        width: 900px;
        margin: 0px auto;
    }
    .div5
    {
        position: relative;
        width: 600px;
        float: left;
        min-height: 100px;
    }
    .div6
    {
        position: relative;
        width: 308px;
        float: left;
        min-height: 100px;
    }
    .logo
    {
        width: 118px;
        height: 70px;
        margin-bottom: 5px;
        padding-top: 5px;
        padding-left: 5px;
    }
    .dotted
    {
        border-bottom: 1px dotted #999;
        padding-bottom: 1px;
    }
    .tableHeader
    {
        font-size: 11px;
        font-weight: bold;
        border: 1px solid black;
        padding-left: 4px;
        padding-right: 4px;
        vertical-align: bottom;
        padding-bottom: 2px;
    }
    .tableStringData
    {
        font-size: 12px;
        padding-left: 5px;
        padding-bottom: 4px;
        text-align: left;
    }
    .tableNumericData
    {
        font-size: 12px;
        padding-right: 2px;
        padding-left: 2px;
        padding-bottom: 4px;
        text-align: right;
    }
    .columnBorder
    {
        border: 1px solid black;
        vertical-align: top;
    }
    .mainHeadersTag
    {
        padding-left: 5px;
        font-weight: bold;
        width: 45%;
    }
    .mainHeadersTagSemi
    {
        padding-left: 2px;
        padding-right: 2px;
        font-weight: bold;
        width: 5%;
    }
    .mainHeadersContent
    {
        padding: 3px;
        width: 50%;
    }
    .mainHeadersTag1
    {
        padding-left: 5px;
        font-weight: bold;
      width:84%;
    }
    .mainHeadersTagSemi1
    {
        padding-left: 2px;
        padding-right: 2px;
        font-weight: bold;
        width: 20px;
    }
    .mainHeadersContent1
    {
        padding: 3px;
        width: 150px;
    }
    .lbltext
    {
        position: relative;
        margin: 0px 0px 0px 0px;
    }
    .BlnkDiv
    {
        width: 100%;
        height: 30px;
        position: relative;
        margin: 30px 0px 0px 0px;
    }
    .RupSymbol
    {
        position: relative;
        float: right;
        right: 0px;
    }
    .GridHeaderInvoice
    {
        text-align: left;
        position: relative;
        border-bottom: 1px dashed #000;
        border-top: 1px dashed #000;
    }
    .TableBottob
    {
        position: relative;
        width: 100%;
        float: left;
        text-align: left;
        font-family: Arial;
        font-size: 14px;
        /*border-top: 1px dashed #000;*/
    }
    .Tablecss
    {
        font-family: Arial;
        font-size: 14px;
        width: 100%;
        padding-bottom:40px;
         /*border-bottom: 1px dashed #000;*/
    }
</style>
<script type="text/javascript">
    function PrintPage() {
        var printButton = document.getElementById("ImgbtnPrint");
        var printLavel = document.getElementById("Label1");
        printButton.style.visibility = 'hidden';
        printLavel.style.visibility = 'hidden';
        var winFeature =
        'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes';
        window.print(winFeature)
        printButton.style.visibility = 'visible';
        printLavel.style.visibility = 'visible';
        Label1.visibility = false;
    }
   
</script>

<body>
    <form id="form1" runat="server">
    <div class="div-popup">
        <div style="text-align: center; width: 980px;  font-family: Verdana;
            font-size: 14px; position: relative; margin: 0 auto">
             <b>JETSAVE INDIA TOURS PVT. LTD</b>
         <%--   <asp:Image ID="Image1" runat="server" ImageUrl="~/imagess/logo.gif" />--%>
            <p style="text-align: center; margin: 10px 0px 0px 0px; top: 0px; font-size: 14px;">
                <asp:Label ID="lblAddressInvoice" runat="server" Text=""></asp:Label>
              30/28, IIIrd FLOOR, (OPP MUGHAL MAHAL RESTAURANT), EAST PATEL NAGAR , NEW DELH - 110 008
                <%--INDIA HUNTING LINE NUMBER(30 LINES)--%><%--+91 011-45616161--%>
                <br />
                INDIA HUNTING LINE NUMBER: &nbsp;<asp:Label ID="lblPhoneNumber" runat="server" Text=""></asp:Label><br />
                FAX NO:&nbsp;
                <%--+91 011-45616171/45616172--%><asp:Label ID="lblfaxNumber" runat="server" Text=""></asp:Label><br />
                Email:visas@jetsavetours.com<asp:Label ID="lblemailAddress"
                    runat="server" Text=""></asp:Label><br />

                <b>Company Reg. No : U74899DL1990 PTC040717</b><br />
                <b>Service Tax Number : AAACJ0751ESD001</b></p>
        </div>
        <div style="text-align: center; width: 100%; font-family: Verdana;
            font-size: 14px; padding-bottom: 10px; padding-top: 10px; font-weight:bold" align="center">
            <asp:Label ID="lblCopy" runat="server" Text="Original Copy"  align="center"></asp:Label>
        </div>

        <div style="text-align: left; left: 10px; width: 100%; padding-top: 10px; border-top:1px dashed  #000;
            margin: 15px 0px 0px 0px; position: relative; height: auto; font-family: Verdana;
            font-size: 14px; top: 0px;"></div>



        <br />
        <br />
        <div class="maindiv">
            <div style="width: 50%; position: relative; float: left;">
                <table style="width: 100%" class="Tablecss">
                    
                    <tr>
                        <td class="mainHeadersTag">
                            Client Name
                        </td>
                        <td class="mainHeadersTagSemi">
                            :
                        </td>
                        <td class="mainHeadersContent">
                            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td class="mainHeadersTag">
                            Client Address
                        </td>
                        <td class="mainHeadersTagSemi">
                            :
                        </td>
                        <td class="mainHeadersContent">
                            <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                   <tr>
                        <td class="mainHeadersTag">
                            Corporate
                        </td>
                        <td class="mainHeadersTagSemi">
                            :
                        </td>
                        <td class="mainHeadersContent">
                            <asp:Label ID="lblCorpName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td class="mainHeadersTag">
                            Pax Name
                        </td>
                        <td class="mainHeadersTagSemi">
                            :
                        </td>
                        <td class="mainHeadersContent">
                           <%-- <asp:Label ID="lblCorporatepax" runat="server" Text=""></asp:Label>--%>
                            <asp:Label ID="lblpax" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="mainHeadersTag">
                            Phone No.
                        </td>
                        <td class="mainHeadersTagSemi">
                            :
                        </td>
                        <td class="mainHeadersContent">
                            <asp:Label ID="lblPhone" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 50%; position: relative; float: left;">
                <table style="width: 100%;" class="Tablecss">
                    
                    
                    <tr>
                        <td class="mainHeadersTag">
                            Invoice No.
                        </td>
                        <td class="mainHeadersTagSemi">
                            :
                        </td>
                        <td class="mainHeadersContent">
                            <asp:Label ID="lblInvoiceNo" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="mainHeadersTag">
                            Date
                        </td>
                        <td class="mainHeadersTagSemi">
                            :
                        </td>
                        <td class="mainHeadersContent">
                            <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="mainHeadersTag">
                            Ref. No.
                        </td>
                        <td class="mainHeadersTagSemi">
                            :
                        </td>
                        <td class="mainHeadersContent">
                            <asp:Label ID="lblRef" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div style="width: 100%; padding: 10px 0px; 
            margin: 0px 0px 0px 0px; position: relative; height: auto; font-family: Verdana;
            font-size: 14px; top: 20px; font-weight:bold;">
               <asp:Label ID="Label2" runat="server" Text="Invoice"  align="center"></asp:Label>
            </div>
         
            <%--<asp:GridView id="grdInvoice" runat="server" BorderStyle="None" GridLines="None" Width="864px" AutoGenerateColumns="false">
                 <Columns>
                     <asp:TemplateField HeaderText="Description">
                         <ItemTemplate><asp:Label ID="lblDesc" runat="server" Text='<%# Eval("Description") %>'></asp:Label></ItemTemplate>
                     </asp:TemplateField>
                      <asp:TemplateField HeaderText="Charge/Unit">
                         <ItemTemplate><asp:Label ID="lblDesc" runat="server" Text='<%# Eval("Charge/Unit") %>'></asp:Label></ItemTemplate>
                     </asp:TemplateField>
                      <asp:TemplateField HeaderText="Units">
                         <ItemTemplate><asp:Label ID="lblDesc" runat="server" Text='<%# Eval("Units") %>'></asp:Label></ItemTemplate>
                     </asp:TemplateField>
                      <asp:TemplateField HeaderText="Amount">
                         <ItemTemplate><asp:Label ID="lblDesc" runat="server" Text='<%# Eval("Amount") %>'></asp:Label></ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
             </asp:GridView>--%>
           
            <div style="height: auto; width: 100%; padding-bottom:100px; border-bottom:1px dashed #000;">
                <asp:GridView ID="gvPreviewInvoice" CssClass="Tablecss" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" Font-Names="Arial" Font-Size="14px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="GridHeaderInvoice">
                            <ItemTemplate>
                                <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("BillItemDescription") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="GridHeaderInvoice"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Charge" HeaderStyle-CssClass="GridHeaderInvoice">
                            <ItemTemplate>
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/image/Rupees-symbol.png" Height="16px"
                                    Width="16px" />
                                <asp:Label ID="lblRate" runat="server" Text='<%# Eval("ItemCharge") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="GridHeaderInvoice"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity" HeaderStyle-CssClass="GridHeaderInvoice">
                            <ItemTemplate>
                                <asp:Label ID="lblqty" runat="server" Text='<%# Eval("ItemQuantity") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="GridHeaderInvoice"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="GridHeaderInvoice">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/image/Rupees-symbol.png" Height="16px"
                                    Width="16px" />
                                <asp:Label ID="lblamt" runat="server" Text='<%# Eval("ItemAmount") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="GridHeaderInvoice"></HeaderStyle>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle Font-Bold="True" ForeColor="Black" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle  />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
            <br />
            <table class="TableBottob">
                <tr>
                    <td class="mainHeadersTag1">
                        <b>Total Amount </b>
                    </td>
                 
                    <td class="mainHeadersTagSemi1">
                        <asp:Image ID="Image3" CssClass="RupSymbol" runat="server" ImageUrl="~/image/Rupees-symbol.png"
                            Height="16px" Width="16px" />
                    </td>
                    <td class="mainHeadersContent1">
                        <asp:Label ID="lbltotalAmt" CssClass="lbltext" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="mainHeadersTag1">
                        <b>Service Charge </b>
                    </td>
                   
                    <td class="mainHeadersTagSemi1">
                        <asp:Image ID="Image5" CssClass="RupSymbol" runat="server" ImageUrl="~/image/Rupees-symbol.png"
                            Height="16px" Width="15px" />
                    </td>
                    <td class="mainHeadersContent1">
                        <asp:Label ID="lblserviceCharge" CssClass="lbltext" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                </table>
            <table class="TableBottob">
                <tr>
                    <td class="mainHeadersTag1">
                        <b>Service Tax </b>
                        <asp:Label ID="lblServicetaxCharge" runat="server" Text="" ForeColor="Black"></asp:Label>
                    </td>
                   
                    <td class="mainHeadersTagSemi1">
                        <asp:Image ID="Image6" CssClass="RupSymbol" runat="server" ImageUrl="~/image/Rupees-symbol.png"
                            Height="16px" Width="15px" />
                    </td>
                    <td class="mainHeadersContent1">
                        <asp:Label ID="lblserviceTax" CssClass="lbltext" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                 
                <tr>
                  
                    <td class="mainHeadersTag1" style="border-top: 1px dashed #000; border-bottom: 1px dashed #000;">
                        <b>Net Amount </b>
                    </td>
                   
                    <td class="mainHeadersTagSemi1" style="border-top: 1px dashed #000; border-bottom: 1px dashed #000;">
                        <asp:Image ID="Image7" CssClass="RupSymbol" runat="server" ImageUrl="~/image/Rupees-symbol.png"
                            Height="16px" Width="15px" />
                    </td>
                    <td class="mainHeadersContent1" style="border-top: 1px dashed #000; border-bottom: 1px dashed #000;">
                        <asp:Label ID="lblNetAmt" CssClass="lbltext" runat="server" Text=""></asp:Label>
                    </td>
                       
                </tr>
                       
            </table>
        </div>
        <div style="text-align: left; left: 10px; width: 100%; padding-top: 10px;
            margin: 0px; position: relative; height: auto; font-family: Verdana;
            font-size: 14px; top: 0px;">
            <asp:Label ID="lbltna" runat="server" Text="Total Net Amount: " 
                Font-Bold="True"></asp:Label>
            <asp:Label ID="lblAmountNet" runat="server" Text=""></asp:Label>
            Only.</div>
        <div style="position: relative; top: 0px; height: auto;">
            <div style="text-align: left; left: 10px;  margin: 20px 0px 0px 0px;
                position: relative; height: auto; font-family: Verdana; font-size: 14px; top: 0px;">
                <b>E. & O. E.<br />
                    TERMS & CONDITIONS </b>
                <br />
                <br />
                <p style="text-align: left; left: 10px; padding: 0px; margin: 0px; top: 0px;">
                    <b>CHEQUE :</b>Payments should be made by Cheques/Drafts in favour of JETSAVE INDIA
                    TOURS PVT. LTD.<br />
                    and should crossed "A/C PAYEE ONLY" or &quot;IN CASH&quot;.
                </p>
                <p style="text-align: left; left: 10px; top: 0px; padding: 0px; margin: 0px;">
                    <b>CASH :</b>Payment to be made to the cashier & printed official Receipt must be
                    obtained
                </p>
                <p style="text-align: left; left: 10px; top: 0px; padding: 0px; margin: 0px;">
                    <b>OUTSTANDING :</b>Interest @ 24% per annum will be charged on bills if not paid
                    within 7 days
                    <br />
                    and should crossed &quot;A/C PAYEE ONLY&quot; or &quot;IN CASH&quot;.
                </p>
            </div>
            <div style="text-align: center;

font-family: Verdana;
font-size: 14px;
top: 0px;
left: 0px;
margin: 0 auto;">
               

                
                 <p style="text-align: center; position: relative; float: right; padding: 0px; margin: 0px;
                    top: 2px; left: 0px;">
                    Authorised Signatory<br />
                    For JETSAVE INDIA TOURS PVT. LTD.
                    <br />
                    No Signatures Required as Invoice is Electronically Generated</p>
            </div>

            <div id="printOption" runat="server" style="float: right; width: 100%;">
                     <asp:Label ID="Label1" runat="server" Text="Click Here To Print--->"></asp:Label>
                <input type="button" value="Print" onclick="window.print()" />
               
                <asp:ImageButton ID="ImgbtnPrint" runat="server" Height="28px" ImageUrl="~/images/print.jpg"
                    OnClick="ImgbtnPrint_Click" Width="29px" OnClientClick="javascript:PrintPage();" />
            </div>
            
            <div class="BlnkDiv">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
