<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AgentList.aspx.cs" Inherits="JSVisaTrackingWebApplication.AgentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function LstAgent_DoubleClick() {
            document.forms[0].ListBox1Hidden.value = "doubleclicked";
            document.forms[0].submit();
        }
    </script>
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
    <script language="javascript" type="text/javascript">
        function UpdateListBox() {
            var updateListBox = document.getElementById('<%=btnsearch.ClientID %>');
            var filterText = document.getElementById('<%=txtname.ClientID %>');
            updateListBox.click();
        }


        function Clear(flag) {
            var filterText = document.getElementById('<%=txtname.ClientID %>');
            //            if (filterText.value == "Enter Search Text..." && flag == true) {
            //                filterText.value = "";
            //            }
            //            else if (flag == false) {
            //                filterText.value = "Enter Search Text...";
            //            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Agent List</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Agent / Agent List</div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                <div class="form-inner-bg">
                    <div class="col-sm-12 col-xs-12">
                        <div class="row form-group">
                            <div class="col-sm-3 col-xs-12">
                                <label>Agent Name</label>
                                  <asp:TextBox ID="txtname" runat="server" onkeyUp="UpdateListBox();" Width="194px"
                    onfocus="Clear(true);" onblur="Clear(false);"></asp:TextBox>
                <asp:LinkButton ID="btnsearch" runat="server" ValidationGroup="search"
                    OnClick="btnsearch_Click1"><i class="icon-search black"></i></asp:LinkButton>
                            </div>
                             <div class="col-sm-3 col-xs-12">
                             <asp:ListBox ID="LstAgent" runat="server" Width="100%" Height="305px" ondblclick="LstAgent_DoubleClick()"
                    AutoPostBack="true" OnSelectedIndexChanged="LstAgent_SelectedIndexChanged"></asp:ListBox>
                <input type="hidden" name="ListBox1Hidden" /></div>

                        </div>
                         <div class="text-right">
        <asp:Button ID="btnAddConsignment" runat="server" Text="Add Consignment" Width="160px" OnClick="btnAddConsignment_Click" />
    </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

   
   
</asp:Content>
