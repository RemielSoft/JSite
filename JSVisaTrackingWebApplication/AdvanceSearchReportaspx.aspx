<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="AdvanceSearchReportaspx.aspx.cs" Inherits="JSVisaTrackingWebApplication.AdvanceSearchaspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .DefMain {
            width: 100%;
            height: 583px;
            background-color: Green;
        }

        .TableMain {
            position: relative;
            float: left;
            top: 0px;
            width: 50%;
            height: 100px;
            background-color: #fff;
        }

        .TableMain1 {
            position: absolute;
            top: 200px;
            left: 0px;
            width: 100%;
            height: 100px;
            background-color: #fff;
        }

        .TableMain2 {
            position: absolute;
            top: 100px;
            left: 0px;
            width: 100%;
            height: 100px;
            background-color: #fff;
        }


        .Footer {
            position: relative;
            width: 100%;
            height: 84px;
            background-color: Red;
        }

        .DrpDown {
            width: 50%;
        }

        .RBlist {
            width: 320px;
        }

        .RBlist1 {
            width: 500px;
        }

        .TRHeading {
            font-weight: bold;
            font-size: 14px;
            background-color: Green;
            color: #fff;
        }

        table {
            max-width: 100%;
            background-color: transparent;
            border-collapse: collapse;
            border-spacing: 0;
        }

        .table {
            width: 100%;
            margin-bottom: 0px;
        }

            .table .bold {
                font-weight: bold;
            }

            .table th, .table td {
                padding: 8px;
                line-height: 18px;
                text-align: left;
                vertical-align: top;
                border-top: 1px solid #dddddd;
            }

            .table th {
                font-weight: bold;
            }

            .table thead th {
                vertical-align: bottom;
            }

            .table caption + thead tr:first-child th, .table caption + thead tr:first-child td, .table colgroup + thead tr:first-child th, .table colgroup + thead tr:first-child td, .table thead:first-child tr:first-child th, .table thead:first-child tr:first-child td {
                border-top: 0;
            }

            .table tbody + tbody {
                border-top: 2px solid #dddddd;
            }

        .table-condensed th, .table-condensed td {
            padding: 4px 5px;
        }

        .table-bordered {
            border: 1px solid #dddddd;
            border-collapse: separate;
            border-collapse: collapsed;
            border-left: 0;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
        }

            .table-bordered th, .table-bordered td {
                border-left: 1px solid #dddddd;
            }

            .table-bordered caption + thead tr:first-child th, .table-bordered caption + tbody tr:first-child th, .table-bordered caption + tbody tr:first-child td, .table-bordered colgroup + thead tr:first-child th, .table-bordered colgroup + tbody tr:first-child th, .table-bordered colgroup + tbody tr:first-child td, .table-bordered thead:first-child tr:first-child th, .table-bordered tbody:first-child tr:first-child th, .table-bordered tbody:first-child tr:first-child td {
                border-top: 0;
            }

                .table-bordered thead:first-child tr:first-child th:first-child, .table-bordered tbody:first-child tr:first-child td:first-child {
                    -webkit-border-top-left-radius: 4px;
                    border-top-left-radius: 4px;
                    -moz-border-radius-topleft: 4px;
                }

                .table-bordered thead:first-child tr:first-child th:last-child, .table-bordered tbody:first-child tr:first-child td:last-child {
                    -webkit-border-top-right-radius: 4px;
                    border-top-right-radius: 4px;
                    -moz-border-radius-topright: 4px;
                }

            .table-bordered thead:last-child tr:last-child th:first-child, .table-bordered tbody:last-child tr:last-child td:first-child {
                -webkit-border-radius: 0 0 0 4px;
                -moz-border-radius: 0 0 0 4px;
                border-radius: 0 0 0 4px;
                -webkit-border-bottom-left-radius: 4px;
                border-bottom-left-radius: 4px;
                -moz-border-radius-bottomleft: 4px;
            }

            .table-bordered thead:last-child tr:last-child th:last-child, .table-bordered tbody:last-child tr:last-child td:last-child {
                -webkit-border-bottom-right-radius: 4px;
                border-bottom-right-radius: 4px;
                -moz-border-radius-bottomright: 4px;
            }

        .table-striped tbody tr:nth-child(odd) td, .table-striped tbody tr:nth-child(odd) th {
            background-color: #f9f9f9;
        }



        .table tbody tr:hover td, .table tbody tr:hover th {
            background-color: #f5f5f5;
        }

        .MainInner {
            position: relative;
            top: 85px;
            width: 100%;
            height: 520px;
            background-color: #fff;
        }

        .Inner {
            position: relative;
            width: 100%;
        }

        .Inner1 {
            position: relative;
            width: 100%;
            top: 2px;
        }

        .BTNCss {
            position: relative;
            float: left;
            left: 10px;
        }
        
        
   
        .style1
        {
            width: 39px;
        }
        
        
   
    </style>
    <!--[if lt IE 9]>
<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
    <script type="text/javascript">
        document.createElement('header');
        document.createElement('section');
        document.createElement('article');
        document.createElement('aside');
        document.createElement('nav');
        document.createElement('footer');
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h2>
        <i class="icon-list fg-color-blue"></i>Advance Search Report ...</h2
<div class="MainInner">
<table class="table table-bordered table-striped table-condensed">
 <tr>
                <td  >
                    
                 Select Agent 
                 
                 </td>
                 <td>
                  <div class="input-control select">
                   <asp:DropDownList ID="ddlAgentName" CssClass="DrpDown" runat="server">                   
                    </asp:DropDownList>
                    </div>
                    </td>
                
                <td >
                Select Country
                </td>
                <td>
                 <div class="input-control select">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                    </div>
                </td>
                </tr>
                <tr>
                <td > From Date</td>
                <td align="left" class="style1">
                <div class="input-control text datepicker  span4" data-param-year-buttons="1" data-param-lang="en">
                    <asp:TextBox ID="txtFromDate" runat="server" format="yyyy-MM-dd" ></asp:TextBox>
                    <i class="btn-date"></i>
                </div>
                </td>
                <td >To Date</td>
               <td align="left">
                <div class="input-control text datepicker  span4" data-param-year-buttons="1" data-param-lang="en">
                    <asp:TextBox ID="txtToDate" runat="server" format="yyyy-MM-dd" ></asp:TextBox>
                    <i class="btn-date"></i>
                </div>
                </td>
                </tr>
                <tr>
                <td >Consignment No</td>
                <td class="style1" colspan="3">
                <div class="input-control text">
                <asp:TextBox ID="txtConsignment" runat="server"></asp:TextBox>
                </div>
                </td>
               <%-- <td >Pax's Name</td>
                <td>
                <div class="input-control text">
                <asp:TextBox ID="txtPaxName" runat="server"></asp:TextBox>
                </div>
                </td>--%>
                </tr>
</table>             
         <br />         
            <div style=" position:relative; width:100%; top:0px;">
        <div style=" position:relative; float:right; width:300px;">
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
           <asp:Button ID="btnPrint" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
           </div>
    </div>
    <div style="position:relative; float:left; width:250px; text-align:left; height:auto; top:50px;">
    <asp:Label ID="lblTotalPass" runat="server" Text="Total No. Of Passport" 
            Font-Bold="True"></asp:Label>
    </div>
    <div style="position:relative; float:left; width:50px; text-align:left; height:auto; top:50px;">
  
  <asp:Label ID="lblTotalVisa" runat="server" Font-Bold="True"></asp:Label>
    </div>    
    <div style="width:100%; height:auto; top:50px; position:relative; ">
        <asp:GridView ID="grdViewSearch" CssClass="gridview" runat="server" AutoGenerateColumns="False" 
            OnRowCommand="grdViewSearch_RowCommand" CellPadding="4" AllowPaging="true" PageSize="5" OnPageIndexChanging="grdViewSearch_PageIndexChanging">
            <AlternatingRowStyle CssClass="gridViewAltRow" BackColor="White" />
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="ConsignmentId">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnConsignmentId" runat="server" Text='<%#Eval("ConsignmentId") %>' CommandName="cmdConsgmntId"
                             CommandArgument='<%#Eval("ConsignmentId") %>'></asp:LinkButton>                       
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AgentName">
                    <ItemTemplate>
                        <asp:Label ID="lblAgentName" runat="server" Text='<%#Eval("AgentName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VisaCountry">
                    <ItemTemplate>
                        <asp:Label ID="lblVisaCountry" runat="server" Text='<%#Eval("VisaCountry") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:TemplateField HeaderText="PaxName">
                    <ItemTemplate>
                        <asp:Label ID="lblPaxName" runat="server" Text='<%#Eval("PaxName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PPTNo">
                    <ItemTemplate>
                        <asp:Label ID="lblPPTNo" runat="server" Text='<%#Eval("PPTNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="AreaCode">
                    <ItemTemplate>
                        <asp:Label ID="lblAreaCode" runat="server" Text='<%#Eval("AreaCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SubDate">
                    <ItemTemplate>
                        <asp:Label ID="lblSubdate" runat="server" Text='<%#Eval("SubmissionDate","{0:M-dd-yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DeliveryDate">
                    <ItemTemplate>
                        <asp:Label ID="lblDeliveryDate" runat="server" Text='<%#Eval("DeliveryDate","{0:M-dd-yyyy}") %>' format="yyyy-MM-dd"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DeliveryStatus">
                    <ItemTemplate>
                        <asp:Label ID="lblDeliveryStatus" runat="server" Text='<%#Eval("DeliveryStatus") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
