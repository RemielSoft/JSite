<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="VaccinationVisaForm.aspx.cs" Inherits="JSVisaTrackingWebApplication.VaccinationVisaForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Add Vaccination Visa Form</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Visa / Vaccination Visa Form</div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                <div class="form-inner-bg">
                    <div class="col-sm-12 col-xs-12">
                        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
                            runat="server" ValidationGroup="Summery1" />
                        <div class="row form-group">
                        </div>
                        <div class="col-sm-4 col-xs-12">
                            <label>Visa Title<span class="red">*</span></label>
                            <asp:TextBox ID="txtvisatitle" runat="server" width="240px" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_visatitle" runat="server" ControlToValidate="txtvisatitle"
                                ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Visa Title"
                                Display="None">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-4 col-xs-12">
                            <label>Upload Visa Form<span class="red">*</span></label>
                            <asp:FileUpload ID="uploadform" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uploadform"
                                ErrorMessage="File Required!" Display="None" ValidationGroup="Summery1">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RValidator" runat="server"
                                ControlToValidate="uploadform"
                                ValidationGroup="Summery1"
                                ErrorMessage="Upload PDF files only"
                                Display="None"
                                CssClass="validationMsg"
                                ValidationExpression="^(([0-9])|([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF|.doc|.DOC|.docx|.DOCX)$" />
                        </div>
                    </div>
                    <div class="text-right">
                        <%--  <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="button-1"/>--%>
                        <asp:Button ID="btnadd" runat="server" Text="Add" OnClick="btnadd_Click" ValidationGroup="Summery1" CssClass="button-1" />
                    </div>
                </div>
            </div>
            
        </div>
        <div class="table-responsive">
                <asp:GridView runat="server" ID="Vaccination_gridview" AutoGenerateColumns="False" OnRowCommand="Vaccination_gridview_RowCommand"
                    CellPadding="5" CssClass="gridview table table-bordered table-striped table-condensed" PageSize="10">
                    <HeaderStyle CssClass="gridViewHeader" />
                    <RowStyle CssClass="gridViewRow" />
                    <AlternatingRowStyle CssClass="gridViewAltRow" />
                    <SelectedRowStyle CssClass="gridViewSelectedRow" />
                    <PagerStyle CssClass="gridViewPager" />
                    <Columns>
                        <%--<asp:TemplateField HeaderText="Visa City">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Visa_City" runat="server" Text='<%#Eval("VisaCity") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Country Name For Visa">
                            <ItemTemplate>
                                <asp:Label ID="lbl_country" runat="server" Text='<%#Eval("CountryForVisa") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Visa Title">
                            <ItemTemplate>
                               <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Form") %>' ForeColor="blue">
                                <asp:Label ID="lbl_title" runat="server" Text='<%#Eval("VisaTitle") %>'></asp:Label>
                                   </asp:HyperLink>
                                    </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Form">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Form" runat="server" Text='<%#Eval("Form") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ACTION">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton5" runat="server" CommandName="cmdDelete" CommandArgument='<%#Eval("Id") %>'
                                    ToolTip="Delete" OnClientClick="return confirmation1();"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Size="10pt" />
                </asp:GridView>
            </div>
    </div>
</asp:Content>
