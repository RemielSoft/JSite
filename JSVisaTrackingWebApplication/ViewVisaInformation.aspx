<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ViewVisaInformation.aspx.cs" Inherits="JSVisaTrackingWebApplication.ViewVisaInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
    <script type="text/javascript">
        function confirmationSave() {
            if (confirm('Are you sure you want to Delete ?')) {
                return true;
            } else {
                return false;
            }
        }
        document.createElement('header');
        document.createElement('section');
        document.createElement('article');
        document.createElement('aside');
        document.createElement('nav');
        document.createElement('footer');
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">View Visa Information</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Visa /  View Visa Information</div>
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
             <label>Enter country name to search</label>
        <div class="input-group"> 
            <asp:TextBox ID="txtcountrysearch" runat="server" CssClass="form-control">
                    </asp:TextBox>
                    <asp:LinkButton ID="LnkBtnSearch" runat="server" OnClick="LnkBtnSearch_Click" CssClass="input-group-addon"> <i class="glyphicon glyphicon-search"></i></asp:LinkButton>
        </div>
        </div></div></div>
                     </div>
         

    <div class="table-responsive">
        <asp:GridView runat="server" ID="gridview_visaInfo" AutoGenerateColumns="False" AllowPaging="True"
            EmptyDataText="No Record Found" OnPageIndexChanging="gridview_visaInfo_PageIndexChanging"
            OnRowCommand="gridview_visaInfo_RowCommand" CssClass="gridview table table-bordered table-striped table-condensed" PageSize="10"
            CellPadding="5" OnRowDataBound="gridview_visaInfo_RowDataBound">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="Req Id">
                    <ItemTemplate>
                        <asp:Label ID="lblREQ_ID" runat="server" Text='<%#Eval("ReqId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country Name">
                    <ItemTemplate>
                        <asp:Label ID="lblCOUNTRY_NAME" runat="server" Text='<%#Eval("CountryName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Visa Type">
                    <ItemTemplate>
                        <asp:Label ID="lblVISA_TYPE" runat="server" Text='<%#Eval("VisaType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Consulate">
                    <ItemTemplate>
                        <asp:Label ID="lblFK_CON" runat="server" Text='<%#Eval("FkConsulate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fee">
                    <ItemTemplate>
                        <asp:Label ID="lblFEE" runat="server" Text='<%#Eval("Fee") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Process Time">
                    <ItemTemplate>
                        <asp:Label ID="lblPROCESS_TIME" runat="server" Text='<%#Eval("ProcessTime") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Basic Requirement">
                    <ItemTemplate>
                        <asp:Label ID="lblBASIC_REQ" runat="server" Text='<%#Eval("BasicRequirements ") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="90px">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" ToolTip="Edit" CommandName="cmdEdit"
                            CommandArgument='<%#Eval("ReqId") %>'><i class="glyphicon glyphicon-edit"></i></asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" ToolTip="Delete" CommandName="cmdDelete"
                            OnClientClick="return confirmationSave();" CommandArgument='<%#Eval("ReqId") %>'><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                        <asp:LinkButton ID="btnView" runat="server" ToolTip="View" CommandName="cmdView"
                            CommandArgument='<%#Eval("ReqId") %>'><i class="glyphicon glyphicon-zoom-in"></i></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
                     </div>

        </div>

   </div>
</asp:Content>
