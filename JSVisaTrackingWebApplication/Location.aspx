<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Location.aspx.cs" Inherits="JSVisaTrackingWebApplication.Location" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Location</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Admin / Location</div>
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
                                <label>Company Name <span class="red">*</span></label>
                                <asp:TextBox ID="txtcompanyName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter The Company Name"
                                    Display="None" ValidationGroup="validgroup" ControlToValidate="txtcompanyName"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <label>Location Address<span class="red">*</span></label>
                                <asp:TextBox ID="txtlocationaddress" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter The  Location Address "
                                    ValidationGroup="validgroup" ControlToValidate="txtlocationaddress" ForeColor="Red"
                                    Display="None"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-3 col-xs-12">
                                <label>City<span class="red">*</span></label>
                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Select The city"
                                    InitialValue="0" Display="None" ForeColor="Red" ValidationGroup="validgroup"
                                    ControlToValidate="ddlCity">
                                </asp:RequiredFieldValidator>
                            </div>


                            <div class="col-sm-3 col-xs-12">
                                <label>Location Title<span class="red">*</span></label>
                                <asp:TextBox ID="txtlocation" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter The Location Title"
                                    ValidationGroup="validgroup" ControlToValidate="txtlocation" ForeColor="Red"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                                <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
                                    runat="server" ValidationGroup="validgroup" />
                            </div>




                        </div>
                        <div class="text-right">
                            <asp:Button ID="BtnAdd" runat="server" Text="Add" ValidationGroup="validgroup" OnClick="BtnAdd_Click"  CssClass="button-1"/>
                            <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click"
                                ValidationGroup="validgroup" CssClass="button-1" />
                            <asp:Button ID="btncancle" runat="server" Text="Cancel" OnClick="btncancle_Click" CssClass="cancel-btn" />
                        </div>
                    </div>
                </div>


                <div class="form-inner-bg">
                    <div class="col-sm-12 col-xs-12">
                        <div class="row form-group">
                            <div class="col-sm-3 col-xs-12">
                                <label>Search By City <span class="red">*</span></label>
                                <div class="input-group">
                                <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:LinkButton ID="lnkSearch" runat="server" OnClick="lnkSearch_Click" CssClass="input-group-addon">
                            <i class="glyphicon glyphicon-search"></i>
                                </asp:LinkButton>
                                    </div>
                            </div>
                        </div>
                    </div>
                </div>



                <div class="table table-responsive">
                    <asp:GridView ID="Grdlocation" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        CellPadding="5" CssClass="gridview table table-bordered table-striped table-condensed" PageSize="10" OnPageIndexChanging="Grdlocation_PageIndexChanging"
                        OnRowCommand="Grdlocation_RowCommand">
                        <HeaderStyle CssClass="gridViewHeader" />
                        <RowStyle CssClass="gridViewRow" />
                        <AlternatingRowStyle CssClass="gridViewAltRow" />
                        <SelectedRowStyle CssClass="gridViewSelectedRow" />
                        <PagerStyle CssClass="gridViewPager" />
                        <Columns>
                            <asp:TemplateField HeaderText="Company Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblcompanyId" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location Address">
                                <ItemTemplate>
                                    <asp:Label ID="lblLocationAddress" runat="server" Text='<%# Eval("LocationAddress") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location Title">
                                <ItemTemplate>
                                    <asp:Label ID="lblLocationTitle" runat="server" Text='<%# Eval("LocationTitle") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" ToolTip="Edit" CommandName="cmdedit"
                                        CommandArgument='<%#Eval("LocationId") %>'><i class="glyphicon glyphicon-edit" ></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton5" runat="server" ToolTip="Delete" CommandName="cmddelete"
                                        CommandArgument='<%#Eval("LocationId") %>' OnClientClick="return confirm ('Are you Sure to Delete?')"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
