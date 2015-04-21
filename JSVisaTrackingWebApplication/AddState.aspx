<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddState.aspx.cs" Inherits="JSVisaTrackingWebApplication.AddState" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">State Master</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Admin / State Master</div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                <div class="form-inner-bg">
                    <div class="col-sm-12 col-xs-12">
                        <div class="row form-group">
                             <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
                            runat="server" ValidationGroup="validgroup" />
                            <div class="col-sm-3 col-xs-12">
                                <label>Country Name</label>
                                <asp:DropDownList id="ddlCountry" runat="server" CssClass="form-control"></asp:DropDownList>
                                <%--<asp:TextBox ID="txtstate" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter The Country Name"
                    Display="None" ValidationGroup="validgroup" ControlToValidate="ddlCountry" ForeColor="Red">
                </asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                  <label>State Name</label>
                                  <asp:TextBox ID="txtState" runat="server" CssClass="form-control"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter The State Name"
                    Display="None" ValidationGroup="validgroup" ControlToValidate="txtState" ForeColor="Red">
                </asp:RequiredFieldValidator>
                            </div>
                        </div>

                          <div class="text-right">
        <asp:Button ID="BtnAdd" runat="server" Text="Add" ValidationGroup="validgroup"
            OnClick="BtnAdd_Click"  CssClass="button-1"/>
        <asp:Button ID="btnupdate" runat="server" Text="Update"
            ValidationGroup="validgroup" OnClick="btnupdate_Click"  CssClass="button-1"/>
        <asp:Button ID="btncancle" runat="server" Text="Cancel"
            OnClick="btncancle_Click" CssClass="cancel-btn"/>
    </div>

                    </div>
                </div>
         

  
    <div class="table table-responsive">
        <asp:GridView ID="grdState" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            CellPadding="5" CssClass="gridview table table-bordered table-striped table-condensed" PageSize="10"
            OnPageIndexChanging="grdState_PageIndexChanging"
            OnRowCommand="grdState_RowCommand">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="Id">
                    <ItemTemplate>
                        <asp:Label ID="lblStateId" runat="server" Text='<%# Eval("stateId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country Name">
                    <ItemTemplate>
                        <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="State">
                    <ItemTemplate>
                        <asp:Label ID="lblState" runat="server" Text='<%# Eval("stateName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" CommandName="cmdedit"
                            CommandArgument='<%#Eval("stateId") %>'><i class="glyphicon glyphicon-edit" ></i></asp:LinkButton>
                        <asp:LinkButton ID="lnkdelete" runat="server" ToolTip="Delete" CommandName="cmddelete"
                            CommandArgument='<%#Eval("stateId") %>' OnClientClick="return confirm ('Are you Sure to Delete?')"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
                   </div>
        </div>
    </div>
</asp:Content>

