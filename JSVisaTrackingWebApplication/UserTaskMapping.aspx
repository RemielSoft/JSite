<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UserTaskMapping.aspx.cs" Inherits="JSVisaTrackingWebApplication.UserTaskMapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">User Task Mapping</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Holiday / User Task Mapping</div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                <div class="form-inner-bg">
                    <div class="col-sm-12 col-xs-12">
                         <div class="row form-group">
                        <div class="col-sm-1 col-xs-12 no-padding">
                               <label><b>User Name</b></label> 
                          
                        </div>
                         <div class="col-sm-11 col-xs-12">
                                <asp:Label ID="lblUserName" runat="server"></asp:Label>
                        <asp:HiddenField ID="hdfldUserId" runat="server" />

                           
                             </div>
                             </div>
                         <div class="row form-group">
                         <div class="col-sm-1 col-xs-12 no-padding">
                             <label><b>User's Task</b></label> 
                             </div>
                        <div class="col-sm-11 col-xs-12">
                         <asp:CheckBoxList ID="chbxUserTask" runat="server" RepeatColumns="5">
                        </asp:CheckBoxList>
                            </div>
                             </div>
                          <div class="text-right">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
