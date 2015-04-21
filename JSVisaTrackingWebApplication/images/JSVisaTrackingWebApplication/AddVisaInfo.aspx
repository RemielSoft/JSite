<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddVisaInfo.aspx.cs" Inherits="JSVisaTrackingWebApplication.AddVisaInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .dropdown
        {
            width: 77px;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
    <div class="box span12">
        <div class="box-header well">
            <h2>
                Visa Information</h2>
        </div>
        <div class="box-content">
            <table  border="1px">
                <tr>
                    <td colspan="4">
                        
                        <asp:Label ID="Label1" runat="server" Width="590px"></asp:Label>
                    </td>
                </tr>
                <tr >
                    <td >
                        Country*
                    </td>
                    <td >
                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="dropdown"   
                           >
                        
                        </asp:DropDownList>
                    </td>
                    <td >
                        Consulate*
                    </td>
                    <td >
                        <asp:DropDownList ID="ddlconsulate" runat="server" CssClass="dropdown"  
                            >
                        
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr >
                    <td >
                        Visa Type
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlVisaType" runat="server" CssClass="dropdown" 
                            >
                       
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        
                        <asp:Button ID="BtnShow" runat="server" Text="Show Details" Width="173px" 
                            onclick="BtnShow_Click" />
                       
                    </td>
                </tr>
                <tr >
                    <td>
                        Consulate Address
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtconAdd" runat="server" TextMode="MultiLine" Width="550px" Height="30px" CssClass="mlttext"></asp:TextBox>
                    </td>
                </tr>
                <tr >
                    
                    <td colspan="4" >
                        (please seperate each linein consulate address with &)
                    </td>
                </tr>
                <tr >
                    <td >
                        Fee*
                    </td>
                    <td >
                        <asp:TextBox ID="txtFee" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                    <td >
                         Process Time
                    </td>
                    <td >
                        <asp:TextBox ID="txtprotime" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr >
                    <td >
                        Submission Days
                    </td>
                    <td >
                        <asp:TextBox ID="txtSubday" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                    <td >
                       Submission Time
                    </td>
                    <td>
                        <asp:TextBox ID="txtsubtime" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr >
                    <td >
                        Collection days
                    </td>
                    <td >
                        <asp:TextBox ID="txtcolday" runat="server" CssClass="TextBox" 
                           ></asp:TextBox>
                    </td>
                    <td >
                         Collection Time
                    </td>
                    <td >
                        <asp:TextBox ID="txtcoltime" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr >
                    <td >
                        Basic Requirements
                    </td>
                    <td colspan="3">
                        <textarea id="txtBasic" runat="server" rows="3" style="width:550px; Height:30px;" Class="mlttext"></textarea>
                    </td>
                </tr>
                <tr>
                    <td >
                        Note
                    </td>
                    <td colspan="3" >
                        <textarea id="TxtNote" runat="server" rows="3" style="width:550px; Height:30px;" Class="mlttext"></textarea>
                    </td>
                </tr>
                <tr >
                    <td >
                        Medical Requirements
                    </td>
                    <td colspan="3">
                        <textarea id="TxtMed" runat="server" rows="3" style="width:550px; Height:30px;" Class="mlttext"></textarea>
                    </td>
                </tr>
                <tr >
                    <td >
                        Other informations
                    </td>
                    <td colspan="3">
                        <textarea id="Txtother" runat="server" rows="3" style="width:550px; Height:30px;" Class="mlttext"></textarea>
                    </td>
                </tr>
                
            </table>
            <br />
             <div class="Button_align">
                        <asp:Button ID="Btnclose" runat="server" Text="Close" 
                            CssClass="button_color action red"/>
                            <asp:Button ID="Btnupdate" runat="server" Text="Update" CssClass="button_color action green" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" 
                            CssClass="button_color action green" onclick="btnSave_Click" />
                       <%-- <input type="submit" id="btnSave" Class="button_color action blue" value="Add New Record" runat="server" 
                             onclick="return btnSave_onclick()" />--%>
                        
                        </div>
        </div>
    </div>
    </form>
</body>
</html>
