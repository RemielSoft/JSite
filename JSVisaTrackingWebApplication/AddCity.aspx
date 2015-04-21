<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddCity.aspx.cs" Inherits="JSVisaTrackingWebApplication.AddCity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">City Master</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Admin / City Master</div>
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
                                <label>Country</label>
                               <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select The Country"
                    Display="None" ValidationGroup="validgroup" ControlToValidate="ddlCountry" ForeColor="Red">
                </asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <label>State</label>
                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control"></asp:DropDownList>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select The State"
                    Display="None" ValidationGroup="validgroup" ControlToValidate="ddlState" ForeColor="Red">
                </asp:RequiredFieldValidator>
                            </div>
                             <div class="col-sm-3 col-xs-12">
                                <label>City Name</label>
                                <asp:TextBox ID="txtCityName" runat="server" CssClass="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter The City Name"
                    Display="None" ValidationGroup="validgroup" ControlToValidate="txtCityName" ForeColor="Red">
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
        <asp:GridView ID="GrdCity" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            CellPadding="5" CssClass="gridview table table-bordered table-striped table-condensed" PageSize="10"
            OnPageIndexChanging="GrdCity_PageIndexChanging"
            OnRowCommand="GrdCity_RowCommand">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="Id">
                    <ItemTemplate>
                        <asp:Label ID="lblCityId" runat="server"  Text='<%# Eval("CityId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Country Name">
                    <ItemTemplate>
                        <asp:Label ID="lblCountryName" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="State Name">
                    <ItemTemplate>
                        <asp:Label ID="lblstateName" runat="server" Text='<%# Eval("stateName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City Name">
                    <ItemTemplate>
                        <asp:Label ID="lblCityName" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" CommandName="cmdedit"
                            CommandArgument='<%#Eval("CityId") %>'><i class="glyphicon glyphicon-edit" ></i></asp:LinkButton>
                        <asp:LinkButton ID="lnkdelete" runat="server" ToolTip="Delete" CommandName="cmddelete"
                            CommandArgument='<%#Eval("CityId") %>' OnClientClick="return confirm ('Are you Sure to Delete?')"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
                   </div>
        </div>
    </div>
</asp:Content>
