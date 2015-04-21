<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="JSVisaTrackingWebApplication._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <%-- <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="UserId" HeaderText="User ID" />
            <asp:BoundField DataField="USerName" HeaderText="Name" />
            <asp:TemplateField HeaderText="USer Location">
                <ItemTemplate>
                    <asp:Label ID="lblUserLocation" runat="server" Text='<%#Eval("UserLocation.LocationName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>--%>
</asp:Content>
