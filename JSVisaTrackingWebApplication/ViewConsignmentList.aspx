<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ViewConsignmentList.aspx.cs" Inherits="JSVisaTrackingWebApplication.ViewConsignmentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!--[if lt IE 9]>
<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
    <script type="text/javascript">
        function confirmationSave() {
            if (confirm('Are you sure you want to Delete ?')) {
                return true;
            } else {
                return false;
            }
        }

        $(".btnExport").click(function (e) {
            window.open('data:application/vnd.ms-excel,' + $('.Div1').html());
            e.preventDefault();
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">View Consignment List</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Consignment / View Consignment List</div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                <div class="form-inner-bg">

                    <div class="col-sm-12 col-xs-12">

                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following error occurs:"
                            ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="false" ValidationGroup="Go" />

                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                                <asp:Label ID="lblfromDate" runat="server" Text="From Date"></asp:Label>
                                <div class="input-group text datepicker" data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="txtfrmdate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <i class="input-group-addon glyphicon glyphicon-calendar"></i>
                                    <i class="btn-date"></i>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Go" ControlToValidate="txtfrmdate"
                                        ErrorMessage="Please Select Your Required Date" Display="None"></asp:RequiredFieldValidator>--%>
                                </div>

                            </div>

                            <div class="col-sm-4 col-xs-12">
                                <asp:Label ID="lbltodate" runat="server" Text="To Date"></asp:Label>
                                <div class="input-group text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="txttodate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <i class="input-group-addon glyphicon glyphicon-calendar"></i>
                                </div>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Go"
                                    ControlToValidate="txttodate" ErrorMessage="Please Select Your Required Date"
                                    Display="None"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <%-- <label>Country Name</label>--%>
                                <asp:Label runat="server" Text="Country Name"></asp:Label>
                                <asp:DropDownList ID="ddlcountry" runat="server" CausesValidation="true" AutoPostBack="false" CssClass="form-control">
                                </asp:DropDownList>
                            </div>


                        </div>
                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                                <label>Agent Name</label>
                                <asp:DropDownList ID="ddlAgent" runat="server" CausesValidation="true" AutoPostBack="false" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Consignment No.</label>
                                <asp:TextBox ID="txtConsignmentNosearch" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>

                            <div class="col-sm-4 col-xs-12">
                                <label>Consignment Status</label>
                                <asp:DropDownList ID="drpdwnStatus" runat="server" CausesValidation="true" AutoPostBack="false" CssClass="form-control">
                                    <asp:ListItem Text="--Select--" Value="0" />
                                    <asp:ListItem Text="Close" Value="1" />
                                    <asp:ListItem Text="Open" Value="2" />
                                </asp:DropDownList>
                            </div>

                        </div>

                    </div>

                    <div class="text-right">

                        <asp:Button ID="btnGo" align="right" runat="server" ValidationGroup="Go" Text="Search" OnClick="btnGo_Click" CssClass="button-1" />
                        <%-- <asp:Button ID="BtnExportToExcel" align="right" runat="server" Text="Export To Excel"
            Visible="false" OnClick="BtnExportToExcel_Click" />
                        --%>
                    </div>
                </div>



                <div id="Div1" runat="server" class="table-responsive" style="overflow: auto;">

                    <asp:GridView runat="server" ID="gridViewConsignment" AutoGenerateColumns="False" AllowPaging="true" PageSize="50"
                        CssClass="gridview table table-striped table-bordered" OnRowCommand="gridViewConsignment_RowCommand"
                        CellPadding="5" OnPageIndexChanging="gridViewConsignment_PageIndexChanging" OnRowDataBound="gridViewConsignment_RowDataBound"
                        OnSelectedIndexChanged="gridViewConsignment_SelectedIndexChanged">
                        <HeaderStyle />
                        <RowStyle CssClass="gridViewRow" />
                        <AlternatingRowStyle CssClass="gridViewAltRow" />
                        <SelectedRowStyle CssClass="gridViewSelectedRow" />
                        <PagerStyle CssClass="gridViewPager" />

                        <Columns>
                            <asp:TemplateField HeaderText="Visa Country" SortExpression="CountryName">

                                <%--<HeaderTemplate>
                                    <table>
                                        <tr>
                                            <td colspan="2">CountryName
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtCountryName" runat="server"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnUserNameSubmit" runat="server" Text="Find" OnClick="btnUserNameSubmit_Click"  CssClass="button-1"/>
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblvisaCountry" runat="server" Text='<%#Eval("CountryName") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Consignment No">
                                <ItemTemplate>
                                    <asp:Label ID="lblConsignmentId" runat="server" Text='<%#Eval("ConsignmentId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Consignment Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblCgDate" runat="server" Text='<%#Eval("CgDate","{0:MM/dd/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Pax Name">


                                <%--                                 <HeaderTemplate>
                                    <table>
                                        <tr>
                                            <td colspan="2">PaxName
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtPaxName" runat="server"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnPaxNameSubmit" runat="server" Text="Find" OnClick="btnPaxNameSubmit_Click"  CssClass="button-1"/>
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>--%>


                                <ItemTemplate>
                                    <asp:GridView ID="gvChildGrid" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                        GridLines="None">
                                        <Columns>
                                            <asp:BoundField DataField="paxname" HeaderStyle-HorizontalAlign="left" />
                                        </Columns>
                                    </asp:GridView>




                                    <asp:Label ID="lblpaxname" runat="server" Text='<%# string.Join("<br />",Eval("PaxPaxName").ToString().Split(new []{"/"},StringSplitOptions.None)) %>'>></asp:Label>
                                    (<asp:Label ID="Label1" runat="server" Text='<%# string.Join("<br />", Eval("pax.PaxPassportNo").ToString().Split(new []{"/"},StringSplitOptions.None)) %>'>></asp:Label>)
                                

                                </ItemTemplate>
                            </asp:TemplateField>





                            <asp:TemplateField HeaderText="Passport No.">

                                <HeaderTemplate>
                                    <table>
                                        <tr>
                                            <td colspan="2">No Of Passport
                                            </td>
                                        </tr>
                                        <%-- <tr>
                                            <td>
                                                <asp:TextBox ID="txtNoOfPassport" runat="server" ForeColor="black"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnNoOfPassport" runat="server" Text="Find" OnClick="btnNoOfPassport_Click"  CssClass="button-1"/>
                                            </td>
                                        </tr>--%>
                                    </table>
                                </HeaderTemplate>


                                <ItemTemplate>
                                    <asp:Label ID="lblCgNoOfPass" runat="server" Text='<%#Eval("CgNoOfPass") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>



                            <%--  <asp:TemplateField HeaderText="Passport No.">

                                <HeaderTemplate>
                                    <table>
                                        <tr>
                                            <td colspan="2">Passport No.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtPassportNo" runat="server" ForeColor="black" Width="74px"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                 <%--<asp:LinkButton ID="lbLine" runat="server" Text="Find" CommandName="Find" CommandArgument='<%# Eval("pax.PaxPassportNo") %>' CssClass="RightAlign">Find</asp:LinkButton>--%>
                            <%-- <asp:Button ID="Button11" Text="Find1" CssClass="button-1"/>--%>
                            <%-- <input type ="button" value="Find" Class="button-1" />--%>
                            <%-- <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="Find" Text="Find" OnCommand="Button1_Command" CssClass="button-1" CommandArgument='<%# Eval("pax.PaxPassportNo") %>' />--%>
                            <%--<asp:Button ID="btnExport1" align="right" CausesValidation="false" runat="server" Text="Find" CommandArgument="" OnClick="btnExport1_Click" CssClass="button-1" />--%>
                            <%--<asp:Button ID="btnNoOfPassport" runat="server" Text="Find" OnClick="btnPassNo_Click" CssClass="button-1"/>--%>
                            <%--  </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>


                                <ItemTemplate>
                                    <asp:Label ID="lblPaxPassportNo" runat="server" Text='<%#Eval("pax.PaxPassportNo") %>'>></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>






                            <asp:TemplateField HeaderText="Corporate Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblcorpname" runat="server" Text='<%#Eval ("CgCorporate") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>




                            <asp:TemplateField HeaderText="Submission Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblCgSubmissionDate" runat="server" Text='<%#Eval("CgSubmissionDate","{0:MM/dd/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="Collection Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblCgEntryDate" runat="server" Text='<%#Eval("CgDeliveryDate","{0:MM/dd/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Agent Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCgAgntname" runat="server" Text='<%#Eval("ConsignmentAgent.AgentName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                            <asp:TemplateField HeaderText="Collection Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblCgDeliveryStatus" runat="server" Text='<%#Eval("CgDeliveryStatus") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="lblCgRemark" runat="server" Text='<%#Eval("CgRemarks") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                         <asp:LinkButton ID="btnEdit" runat="server" ToolTip="ConsignmentEdit" CommandName="cmdEdit"
                            ForeColor="Blue" CommandArgument='<%#Eval("ConsignmentId") %>'><i class="icon-copy black"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton1" runat="server" ToolTip="MailEdit" CommandName="cmdEditMailremark"
                            ForeColor="Blue" CommandArgument='<%#Eval("ConsignmentId") %>'><i class=" icon-mail black"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" ToolTip="PaxEdit" CommandName="cmdEditPax"
                            CommandArgument='<%#Eval("ConsignmentId") %>'><i class="glyphicon glyphicon-refresh"></i></asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" ToolTip="ConsignmentDelete" CommandName="cmdDelete"
                            OnClientClick="return confirmationSave();" CommandArgument='<%#Eval("ConsignmentId") %>'><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                        
                        <asp:LinkButton ID="LinkButton3" runat="server" ToolTip="ConsignmentView" CommandName="cmdViewCon"
                             CommandArgument='<%#Eval("ConsignmentId") %>'><i class="glyphicon glyphicon-zoom-in"></i></asp:LinkButton>
                    </ItemTemplate>  
                </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnExport" align="right" runat="server" Text="Export To Excel" OnClick="btnExport_Click" CssClass="button-1" />
                </div>
            </div>
        </div>


    </div>


</asp:Content>
