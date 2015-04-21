<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="VaccinationCoverNote.aspx.cs" Inherits="JSVisaTrackingWebApplication.VaccinationCoverNote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">View Vaccination / CoverNote Visa Form</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Visa / Vaccination / CoverNote Visa Form</div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
        </div>



        <div class="table-responsive">
            <div>
                <label><b style="font-size: large;">Vaccination Form</b></label></div>
            <asp:GridView runat="server" ID="grdVaccination" AutoGenerateColumns="False" CellPadding="5" CssClass="gridview table table-bordered table-striped table-condensed" PageSize="10">
                <HeaderStyle CssClass="gridViewHeader" />
                <RowStyle CssClass="gridViewRow" />
                <AlternatingRowStyle CssClass="gridViewAltRow" />
                <SelectedRowStyle CssClass="gridViewSelectedRow" />
                <PagerStyle CssClass="gridViewPager" />
                <Columns>
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
                </Columns>
                <HeaderStyle Font-Size="10pt" />
            </asp:GridView>
        </div>


        <div class="table-responsive">
            <div>
                <label><b style="font-size: large;">Jetsave Cover Note</b></label></div>
            <asp:GridView runat="server" ID="CoverNote_gridview" AutoGenerateColumns="False"
                CellPadding="5" CssClass="gridview table table-bordered table-striped table-condensed" PageSize="10">
                <HeaderStyle CssClass="gridViewHeader" />
                <RowStyle CssClass="gridViewRow" />
                <AlternatingRowStyle CssClass="gridViewAltRow" />
                <SelectedRowStyle CssClass="gridViewSelectedRow" />
                <PagerStyle CssClass="gridViewPager" />
                <Columns>
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
                </Columns>
                <HeaderStyle Font-Size="10pt" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

