<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="NewsLetter.aspx.cs" Inherits="JSVisaTrackingWebApplication.NewsLetter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">

</style>
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<iframe src="Test2.aspx"style=" width:100%; height:800px;">

<%--<asp:TextBox ID="txteditor" CssClass="htmleditor" runat="server"  Width="100%" Height="800"></asp:TextBox>
  <asp:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" TargetControlID="txteditor" EnableSanitization="false">
        </asp:HtmlEditorExtender> --%>
       

</iframe>
         
    <div>
   
        <asp:Label ID="lbltopic" runat="server" Text="Topic"></asp:Label>
        <asp:TextBox ID="txtTopic" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="txtdes" runat="server" TextMode="MultiLine"></asp:TextBox><br />
        <br />
        <asp:Button ID="btn" runat="server" Text="Save" OnClick="btn_Click" />
        <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />
        <br />
        <asp:FileUpload ID="File1" runat="server" />
        <asp:Button ID="btnupload" runat="server" Text="Upload" OnClick="btnupload_Click" />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="gvwNews" runat="server" AutoGenerateColumns="False" Width="30%"
            OnRowCommand="gvwNews_RowCommand" GridLines="Horizontal" BackColor="White" 
             CellPadding="4" 
            ForeColor="#fff">
            <Columns>
                <asp:BoundField DataField="TopicName" HeaderText="" />
                <%--<asp:Label ID="lblname" runat="server" Text='<%#Eval("TopicName") %>'></asp:Label>--%>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkedit" runat="server" CommandName="cmdEdit" CommandArgument='<%#Eval("TopicId") %>'>Edit</asp:LinkButton>
                        <asp:LinkButton ID="lnkdelete" runat="server" CommandName="cmdelete" CommandArgument='<%#Eval("TopicId") %>'>Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>               
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        </div><br />
        
</asp:Content>
