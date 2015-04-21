<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="SearchVisaForm.aspx.cs" Inherits="JSVisaTrackingWebApplication.SearchVisaForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        <i class="icon-search  fg-color-blue"></i>Find Visa From
    </h2>
    <table class="table table-bordered table-striped table-condensed">
        <tr>
            <td class="left">
                Choose City Name
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_search" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td>
                <asp:Button ID="btn_search" runat="server" Text="Search" OnClick="btn_search_Click1" />
            </td>
        </tr>
    </table>
    <div>
        <asp:GridView ID="gvDetails" DataKeyNames="Id" runat="server" AutoGenerateColumns="False"
            CssClass="gridview" PageSize="10" CellPadding="5" OnRowDeleting="gvDetails_RowDeleting">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Visa City">
                    <ItemTemplate>
                        <asp:Label ID="lblvscity" runat="server" Text='<%#Eval("VisaCity") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Visa Title">
                    <ItemTemplate>
                        <asp:Label ID="lblvstitle" runat="server" Text='<%#Eval("VisaTitle") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country For Visa">
                    <ItemTemplate>
                        <asp:Label ID="lblcountry" runat="server" Text='<%#Eval("CountryForVisa") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="File Name">
                    <ItemTemplate>
                        <asp:Label ID="lblfm" runat="server" Text='<%#Eval("AddVisaForm") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTION">
                    <ItemTemplate>
                     <asp:LinkButton ID="linbtn_Delete" runat="server" CommandName="Delete"  OnClientClick="return confirmationSave();" ToolTip="Delete"><i class=" icon-remove red"></i></asp:LinkButton>
                        <%--<asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                            ImageUrl="~/image/images (1).jpg" ToolTip="Delete" Height="30px" Width="30px" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
