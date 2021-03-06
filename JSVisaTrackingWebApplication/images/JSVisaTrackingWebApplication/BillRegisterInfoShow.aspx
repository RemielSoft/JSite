﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="BillRegisterInfoShow.aspx.cs" Inherits="JSVisaTrackingWebApplication.BillRegisterInfoShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
.CSSTableGenerator {
	margin:0px;padding:0px;
	width:100%;
	box-shadow: 10px 10px 5px #888888;
	border:1px solid #ffffff;
	
	-moz-border-radius-bottomleft:0px;
	-webkit-border-bottom-left-radius:0px;
	border-bottom-left-radius:0px;
	
	-moz-border-radius-bottomright:0px;
	-webkit-border-bottom-right-radius:0px;
	border-bottom-right-radius:0px;
	
	-moz-border-radius-topright:0px;
	-webkit-border-top-right-radius:0px;
	border-top-right-radius:0px;
	
	-moz-border-radius-topleft:0px;
	-webkit-border-top-left-radius:0px;
	border-top-left-radius:0px;
}.CSSTableGenerator table{
	width:100%;
	height:100%;
	margin:0px;padding:0px;
}.CSSTableGenerator tr:last-child td:last-child {
	-moz-border-radius-bottomright:0px;
	-webkit-border-bottom-right-radius:0px;
	border-bottom-right-radius:0px;
}
.CSSTableGenerator table tr:first-child td:first-child {
	-moz-border-radius-topleft:0px;
	-webkit-border-top-left-radius:0px;
	border-top-left-radius:0px;
}
.CSSTableGenerator table tr:first-child td:last-child {
	-moz-border-radius-topright:0px;
	-webkit-border-top-right-radius:0px;
	border-top-right-radius:0px;
}.CSSTableGenerator tr:last-child td:first-child{
	-moz-border-radius-bottomleft:0px;
	-webkit-border-bottom-left-radius:0px;
	border-bottom-left-radius:0px;
}.CSSTableGenerator tr:hover td{
	background-color:#e5e5e5;
		

}
.CSSTableGenerator td{
	vertical-align:middle;
		background:-o-linear-gradient(bottom, #ffffff 5%, #e5e5e5 100%);	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #ffffff), color-stop(1, #e5e5e5) ); 
	background:-moz-linear-gradient( center top, #ffffff 5%, #e5e5e5 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr="#ffffff", endColorstr="#e5e5e5");	background: -o-linear-gradient(top,#ffffff,e5e5e5);

	background-color:#ffffff;

	border:1px solid #ffffff;
	border-width:0px 1px 1px 0px;
	text-align:left;
	padding:7px;
	font-size:10px;
	font-family:Arial;
	font-weight:normal;
	color:#000000;
}.CSSTableGenerator tr:last-child td{
	border-width:0px 1px 0px 0px;
}.CSSTableGenerator tr td:last-child{
	border-width:0px 0px 1px 0px;
}.CSSTableGenerator tr:last-child td:last-child{
	border-width:0px 0px 0px 0px;
}
.CSSTableGenerator tr:first-child td{
		background:-o-linear-gradient(bottom, #cccccc 5%, #b2b2b2 100%);	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #cccccc), color-stop(1, #b2b2b2) );
	background:-moz-linear-gradient( center top, #cccccc 5%, #b2b2b2 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr="#cccccc", endColorstr="#b2b2b2");	background: -o-linear-gradient(top,#cccccc,b2b2b2);

	background-color:#cccccc;
	border:0px solid #ffffff;
	text-align:center;
	border-width:0px 0px 1px 1px;
	font-size:14px;
	font-family:Arial;
	font-weight:bold;
	color:#000000;
}
.CSSTableGenerator tr:first-child:hover td{
	background:-o-linear-gradient(bottom, #cccccc 5%, #b2b2b2 100%);	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #cccccc), color-stop(1, #b2b2b2) );
	background:-moz-linear-gradient( center top, #cccccc 5%, #b2b2b2 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr="#cccccc", endColorstr="#b2b2b2");	background: -o-linear-gradient(top,#cccccc,b2b2b2);

	background-color:#cccccc;
}
.CSSTableGenerator tr:first-child td:first-child{
	border-width:0px 0px 1px 0px;
}
.CSSTableGenerator tr:first-child td:last-child{
	border-width:0px 0px 1px 1px;
}


</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <i class="icon-keyboard fg-color-blue"></i>Bill Register Information</h2>
        <div>
        <asp:GridView ID="gv_billRegister" runat="server"></asp:GridView>
        </div>

        <%--<div class="CSS_Table_Example" style="width:600px;height:150px;">
			<div class="CSSTableGenerator" >
                <table >
                    <tr>
                        <td>
                            Date
                        </td>
                        <td >
                            BillNo
                        </td>
                        <td>
                            PartyName	
                        </td>
                        <td>
                           VisaCountry
                        </td>
                        <td >
                            Visa
                        </td>
                        <td>
                            Attestation	
                        </td>
                    </tr>
                    <tr>
                        <td >
                            Row 1
                        </td>
                        <td>
                            Row 1
                        </td>
                        <td>
                            Row 1
                        </td>
                        <td >
                            Row 1
                        </td>
                        <td>
                            Row 1
                        </td>
                        <td>
                            Row 1
                        </td>
                    </tr>
                    <tr>
                        <td >
                            Row 2
                        </td>
                        <td>
                            Row 2
                        </td>
                        <td>
                            Row 2
                        </td>
                        <td >
                            Row 1
                        </td>
                        <td>
                            Row 1
                        </td>
                        <td>
                            Row 1
                        </td>
                    </tr>
                    <tr>
                        <td >
                            Row 2
                        </td>
                        <td>
                            Row 2
                        </td>
                        <td>
                            Row 2
                        </td>
                        <td >
                            Row 1
                        </td>
                        <td>
                            Row 1
                        </td>
                        <td>
                            Row 1
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" >
                           <b>Total</b>
                        </td>
                       
                        <td>
                           <b> 1,202,00.00</b>
                        </td>
                        <td >
                            <b>  100,00</b>
                        </td>
                        <td>
                           <b>  100</b>
                        </td>
                        <td>
                           <b>  100.50</b>
                        </td>
                    </tr>
                </table>
            </div>
            
		</div>--%>
</asp:Content>
