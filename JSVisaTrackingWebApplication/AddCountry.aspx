<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddCountry.aspx.cs" Inherits="JSVisaTrackingWebApplication.AddCountry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Country Master</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Admin / Country Master</div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                <div class="form-inner-bg">
                    <div class="col-sm-12 col-xs-12">
                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                                <label>Country Name<span class="red">*</span></label>
                                <asp:TextBox ID="txtCountryName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter The Country Name"
                                    Display="None" ValidationGroup="validgroup" ControlToValidate="txtCountryName" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Description<span class="red">*</span></label>
                                 <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
            runat="server" ValidationGroup="validgroup" />
                            </div>
                            <div class="col-sm-4 col-xs-12 text-right">
                                <label>&nbsp;</label><br/>
        <asp:Button ID="BtnAdd" runat="server" Text="Add" ValidationGroup="validgroup"
            OnClick="BtnAdd_Click" CssClass="button-1" />
        <asp:Button ID="btnupdate" runat="server" Text="Update"
            ValidationGroup="validgroup" OnClick="btnupdate_Click"  CssClass="button-1"/>
        <asp:Button ID="btncancle" runat="server" Text="Cancel"
            OnClick="btncancle_Click" CssClass="cancel-btn"/>
    </div>
                        </div>
                        
                    </div>
                </div>
                <div class="table-responsive">
        <asp:GridView ID="GrdCountry" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            CellPadding="5" CssClass="gridview table table-bordered" PageSize="10"
            OnPageIndexChanging="GrdCountry_PageIndexChanging"
            OnRowCommand="GrdCountry_RowCommand">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
               <%-- <asp:TemplateField HeaderText="Id">
                    <ItemTemplate>
                        <asp:Label ID="lblCountryId" runat="server" Text='<%# Eval("CountryId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Country Name">
                    <ItemTemplate>
                        <asp:Label ID="lblCountryName" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("LocationTitle") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" CommandName="cmdedit"
                            CommandArgument='<%#Eval("CountryId") %>'><i class="glyphicon glyphicon-edit" ></i></asp:LinkButton>
                        <asp:LinkButton ID="lnkdelete" runat="server" ToolTip="Delete" CommandName="cmddelete"
                            CommandArgument='<%#Eval("CountryId") %>' OnClientClick="return confirm ('Are you Sure to Delete?')"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
            </div>
        </div>
    </div>


    
    
</asp:Content>

