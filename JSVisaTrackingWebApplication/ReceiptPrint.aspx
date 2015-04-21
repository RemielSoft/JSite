<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiptPrint.aspx.cs" Inherits="JSVisaTrackingWebApplication.ReceiptPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .maindiv
        {
            width: 950px;
            margin: 0px auto;
            font-family: Verdana;
            font-size: 12px;
            border: 2px solid #000;
        }
        .maindiv1
        {
            width: 950px;
            margin: 0px auto;
            font-family: Verdana;
            font-size: 12px;
        }
        
        .div1
        {
            position: relative;
            border-top: 2px solid #000;
            border-right: 2px solid #000;
            border-bottom: 2px solid #000;
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
            border-top: 2px solid #000;
            border-left: 2px solid #000;
            border-bottom: 2px solid #000;
            width: 350px;
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
            border-top: 2px solid #000;
            border-right: 1px solid #000;
            border-bottom: 2px solid #000;
            border-left: 2px solid #000;
            width: 600px;
            float: left;
            min-height: 100px;
        }
        
        .div6
        {
            position: relative;
            border-top: 2px solid #000;
            border-right: 2px solid #000;
            border-left: 1px solid #000;
            border-bottom: 2px solid #000;
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
        }
        
        .mainHeadersTagSemi
        {
            padding-left: 2px;
            padding-right: 2px;
            font-weight: bold;
        }
        
        .mainHeadersContent
        {
            padding: 3px;
        }
    </style>
    <script type="text/javascript">
        function PrintPage() {
            window.print();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="div-popup">
        <div style="text-align: center; width: 980px; height: 166px; font-family: Verdana;
            font-size: 13px; position: relative; margin: 0 auto">
            <%-- <b>JETSAVE INDIA TOURS PVT. LTD</b>--%>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/image/jetsave-logo.gif" />
            <p style="text-align: center; margin: 10px 0px 0px 0px; top: 0px;">
                30/28, IIIrd FLOOR, (OPP MUGHAL MAHAL RESTAURANT), EAST PATEL NAGAR , NEW DELHI
                - 110 008<br />
                INDIA HUNTING LINE NUMBER(30 LINES)<%--+91 011-45616161--%><asp:Label ID="lblPhoneNumber"
                    runat="server" Text=""></asp:Label><br />
                FAX:
                <%--+91 011-45616171/45616172--%><asp:Label ID="lblfaxNumber" runat="server" Text=""></asp:Label><br />
                Email:<%--jetsave@eth.net,viplav_2k@hotmail.com--%><asp:Label ID="lblemailAddress"
                    runat="server" Text=""></asp:Label><br />
                Service Tax Number : AAACJ0751ESD001</p>
        </div>
        <div style="text-align: right; height: 10px; width: 950px; font-family: Verdana;
            font-size: 12px; padding-bottom: 10px;">
            <asp:Label ID="lblDuplicate" runat="server" Text="Duplicate Copy" Visible="false"></asp:Label>
        </div>
        <div class="maindiv">
            <table style="width: 950px;">
                <tr>
                    <td style="width: 100%;">
                        <table style="width: 100%">
                            <tr>
                                <td class="mainHeadersTag">
                                    Account Code
                                </td>
                                <td class="mainHeadersTagSemi">
                                    :
                                </td>
                                <td class="mainHeadersContent">
                                    <asp:Label ID="lblAccountCode" runat="server"></asp:Label>
                                </td>
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
                                    Account Name
                                </td>
                                <td class="mainHeadersTagSemi">
                                    :
                                </td>
                                <td class="mainHeadersContent">
                                    <asp:Label ID="lblAccountName" runat="server"></asp:Label>
                                </td>
                                <td class="mainHeadersTag">
                                    Receipt No.
                                </td>
                                <td class="mainHeadersTagSemi">
                                    :
                                </td>
                                <td class="mainHeadersContent">
                                    <asp:Label ID="lblReceiptNo" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <br />
                        Recieved With Thanks From
                        <asp:Label ID="lblagntname" runat="server" Font-Bold="True"></asp:Label>
                        <br />
                        <br />
                        <strong>The Sum Of</strong><asp:Label ID="LbltotalAmt" runat="server" Text="Label"
                            Font-Bold="True"></asp:Label><strong>Only</strong><br />
                        <br />
                        By<asp:Label ID="lblPaymentMode" runat="server" Text=" Label"></asp:Label><br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="left">
                        <asp:GridView ID="gvPreviewReceipt" runat="server" Width="100%" AutoGenerateColumns="False"
                            ShowFooter="true" OnRowDataBound="gvPreviewReceipt_RowDataBound">
                            <HeaderStyle BackColor="#E5E5E5" ForeColor="Black" />
                            <FooterStyle BackColor="#E5E5E5" ForeColor="Black" HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="Bill No." ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("InvoiceNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="True" Text="Total Amount (IN INR.)" />&nbsp;
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblamt" runat="server" Text='<%# Eval("AdjustedAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalAmt" runat="server" Font-Bold="True" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <br />
        <div class="maindiv1">
            <table width="100%" style="width: 950px;">
                <tr>
                    <td colspan="2">
                        <asp:ImageButton ID="imgCurrency" runat="server" ImageUrl="~/images/currency_sign_rupee.png"
                            Height="18px" Width="18px" />
                        &nbsp;&nbsp;<strong>:</strong> &nbsp;&nbsp;
                        <asp:Label ID="lbltotalAdjustedAmt" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        (Cheques etc. Subjected To Realisation)<br />
                        <br />
                        FOR JETSAVE INDIA TOURS PVT. LTD.
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Reciever's Signature
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right" valign="middle">
                        Click Here for Print-------&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ImgbtnPrint" runat="server" Height="35px" ImageUrl="~/images/print.png"
                            OnClick="ImgbtnPrint_Click" Width="36px" OnClientClick="javascript:PrintPage();" />
                    </td>
                </tr>
            </table>
        </div>
        </div>
    </form>
</body>
</html>
