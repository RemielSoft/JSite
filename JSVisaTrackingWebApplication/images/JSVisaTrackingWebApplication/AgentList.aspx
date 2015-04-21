<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AgentList.aspx.cs" Inherits="JSVisaTrackingWebApplication.AgentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
       <i class="icon-list  fg-color-blue"></i> Agent List</h2>
   
  
        <table class="bordered">
            <tr>
                <td>
                    Agent Name
                </td>
                <td class="left">
                    <div class="input-control text">
                        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                        <button class="btn-clear" />
                        &nbsp;</div>
                </td>
                <td>
                    <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="LblAgent" runat="server" Text="" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:ListBox ID="LstAgent" runat="server" Width="100%" Height="300px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="right">
                    <asp:Button ID="btnAddConsignment" runat="server" Text="AddConsignment" OnClick="btnAddConsignment_Click" />
                </td>
            </tr>
        </table>
   
</asp:Content>
