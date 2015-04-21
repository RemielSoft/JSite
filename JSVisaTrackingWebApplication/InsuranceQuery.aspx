<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceQuery.aspx.cs" MasterPageFile="~/Site.Master" Inherits="JSVisaTrackingWebApplication.InsuranceQuery" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="container-fulid page-heading">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-sm-12">Insurance Query</div>
                </div>
            </div>
        </div>
    </section>
    <div class="container">
        <div class="row">
            <div class="middle">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12 col-xs-12">
                            <div class="content">
                                <div class="col-sm-12 col-xs-12">
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 form-group">
                                            <div style="background: #e70012; color: #fff; padding: 4px 8px; padding-top: 8px;">
                                                <label>
                                                    <b>Your Contact Details</b>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-sm-3 col-xs-12">
                                            <label>
                                                Your Name <span class="red">*</span>
                                            </label>
                                            <%--<input type="text" class="form-control" />--%>
                                            <asp:RequiredFieldValidator ID="requireValidate" runat="server" ControlToValidate="txtyourname" display ="None" 
                                     ErrorMessage="Please Fill The Your Name" ForeColor="Red" ToolTip="Arrival is required." 
                                     ValidationGroup="QueryValidationGroup">*</asp:RequiredFieldValidator>
                                            <asp:TextBox id="txtyourname" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <label>
                                                Your Email <span class="red">*</span>
                                            </label>
                                            <asp:RequiredFieldValidator ID="requireMail" runat="server" ControlToValidate="txtyouremail" display ="None" 
                                     ErrorMessage="Please Fill The Your Email" ForeColor="Red" ToolTip="Arrival is required." 
                                     ValidationGroup="QueryValidationGroup">*</asp:RequiredFieldValidator>
                                            <asp:TextBox id="txtyouremail" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <label>
                                                Company Name
                                            </label>
                                           <%-- <input type="text" class="form-control" />--%>
                                            <asp:TextBox id="txtcompanyname" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <label>
                                                Website
                                            </label>
                                            <%--<input type="text" class="form-control" />--%>
                                            <asp:TextBox id="txtwebsite" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-sm-3 col-xs-12">
                                            <label>
                                                Country <span class="red">*</span>
                                            </label>
                                            <%--<input type="text" class="form-control" />--%>
                                             <asp:TextBox id="txtcountry" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <label>
                                                City <span class="red">*</span>
                                            </label>
                                            <%--<input type="text" class="form-control" />--%>
                                            <asp:TextBox id="txtcity" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 col-xs-12">
                                            <label style="display:block"> 
                                                Mobile <span class="red">*</span>
                                            </label>
                                             <div class="col-sm-2 col-xs-12 no-padding">
                                                  
                                                
                                                    <input type="text" class="form-control" placeholder="+91" />
                                             </div>
                                                <div class="col-sm-6 col-xs-12">
                                                    <asp:RequiredFieldValidator ID="requireMobiel" runat="server" ControlToValidate="txtmobile" display ="None" 
                                     ErrorMessage="Please Fill The Your Mobile No." ForeColor="Red" ToolTip="Arrival is required." 
                                     ValidationGroup="QueryValidationGroup">*</asp:RequiredFieldValidator>
                                                    <asp:TextBox id="txtmobile" runat="server"  CssClass="form-control"></asp:TextBox>
                 <asp:RegularExpressionValidator runat="server" ID="rexNumber" Display="Dynamic" ForeColor="Red" ControlToValidate="txtmobile" 
                         ValidationExpression="^[7-9][0-9]{9}$" ErrorMessage="Please enter a valid mobile number" />
                    
                                             </div>
                                             

                                        </div>

                                    </div>
                                    <div class="row form-group">
                                       
                                    </div>

                                </div>
                                <div class="col-sm-8 col-xs-12">
                                    <div class="package">
                                        <span class="packages-heading">Send Your Query</span>
                                    </div>
                                    <asp:ValidationSummary ID="QueryValidationSummary" runat="server" ValidationGroup="QueryValidationGroup" CssClass="failureNotification" 
         ShowMessageBox="true"  ShowSummary="false" EnableClientScript="true" Enabled="true" />
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 form-group">
                                            <label>
                                                Describe Your Travel Plan/Requirements
                                            </label>
                                           <asp:RequiredFieldValidator ID="requireDescribe" runat="server" ControlToValidate="txtdescribe" display ="None" 
                                     ErrorMessage="Please Fill Your Requirement" ForeColor="Red" 
                                     ValidationGroup="QueryValidationGroup">*</asp:RequiredFieldValidator>
                                            <asp:TextBox id="txtdescribe" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row  form-group">
                                        <div class="col-sm-4 col-xs-12">
                                            <label>
                                                Country
                                            </label>
                                            <div style="height: 80px; padding: 2px; overflow: auto; border: 1px solid #ccc;">
                                                <asp:CheckBoxList ID="chkCountry" runat="server">
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                         <div class="col-sm-4 col-xs-12">
                                            <label>
                                                Date of travel
                                            </label>

                                            <div class="input-group text datepicker" data-param-year-buttons="1" data-param-lang="en">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfrmdate" display ="None" 
                                     ErrorMessage="Please Fill The Date First" ForeColor="Red" ToolTip="Arrival is required." 
                                     ValidationGroup="QueryValidationGroup">*</asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtTravl" runat="server" CssClass="form-control"></asp:TextBox>
                                                <i class="input-group-addon glyphicon glyphicon-calendar"></i>
                                                <i class="btn-date"></i>
     
                                            
                                            </div>
                                        </div>
                                         <div class="col-sm-4 col-xs-12">
                                            <label>
                                                Date of return
                                            </label>

                                            <div class="input-group text datepicker" data-param-year-buttons="1" data-param-lang="en">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfrmdate" display ="None" 
                                     ErrorMessage="Please Fill The Date First" ForeColor="Red" ToolTip="Arrival is required." 
                                     ValidationGroup="QueryValidationGroup">*</asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtreturn" runat="server" CssClass="form-control"></asp:TextBox>
                                                <i class="input-group-addon glyphicon glyphicon-calendar"></i>
                                                <i class="btn-date"></i>
     
                                            
                                            </div>
                                        </div>







                                        <div class="col-sm-4 col-xs-12">
                                            <label>
                                                Expected Arrival
                                            </label>

                                            <div class="input-group text datepicker" data-param-year-buttons="1" data-param-lang="en">
                                                <asp:RequiredFieldValidator ID="txtdate" runat="server" ControlToValidate="txtfrmdate" display ="None" 
                                     ErrorMessage="Please Fill The Date First" ForeColor="Red" ToolTip="Arrival is required." 
                                     ValidationGroup="QueryValidationGroup">*</asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtfrmdate" runat="server" CssClass="form-control"></asp:TextBox>
                                                <i class="input-group-addon glyphicon glyphicon-calendar"></i>
                                                <i class="btn-date"></i>
     
                                            
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xs-12 form-group">
                                            <label>
                                               No. of applicant
                                            </label>
                                            <asp:DropDownList id="ddlapllicant" runat="server" CssClass="form-control">
                                               <asp:ListItem>---Select---</asp:ListItem> 
                                                 <asp:ListItem>1</asp:ListItem> 
                                                <asp:ListItem>2</asp:ListItem> 
                                                <asp:ListItem>3</asp:ListItem> 
                                                <asp:ListItem>4</asp:ListItem> 
                                                <asp:ListItem>5</asp:ListItem> 
                                            </asp:DropDownList>
                                            <%--<select class="form-control">
                                                <option>---Select---</option>
                                                <option>1-3 Days</option>
                                                <option>4-7 Days</option>
                                                <option>8-14 Days</option>
                                                <option>2-3 Weeks</option>
                                                <option>> 3 Weeks</option>
                                            </select>--%>
                                        </div>
                                        <div class="col-sm-4 col-xs-12">
                                            <label style="display: block;">
                                                Number of Children(0-6)
                                            </label>
                                            <asp:DropDownList id="ddlchildren06" runat="server" CssClass="form-control">
                                               
                                                 <asp:ListItem>(0-6 Years)</asp:ListItem> 
                                                <asp:ListItem>0</asp:ListItem> 
                                                <asp:ListItem>1</asp:ListItem> 
                                                <asp:ListItem>2</asp:ListItem> 
                                                <asp:ListItem>3</asp:ListItem> 
                                                <asp:ListItem>4</asp:ListItem> 
                                            </asp:DropDownList>
                                             
                                        </div>
                                        <div class="col-sm-4 col-xs-12">
                                            <label style="display: block;">
                                                Number of Children(6-12)
                                            </label>
                                            <asp:DropDownList id="ddlchilred6" runat="server" CssClass="form-control">
                                              
                                                 <asp:ListItem>(6-12 Years)</asp:ListItem> 
                                                <asp:ListItem>6</asp:ListItem> 
                                                <asp:ListItem>7</asp:ListItem> 
                                                <asp:ListItem>8</asp:ListItem> 
                                                <asp:ListItem>9</asp:ListItem> 
                                                <asp:ListItem>10</asp:ListItem> 
                                                <asp:ListItem>11</asp:ListItem> 
                                                 <asp:ListItem>12</asp:ListItem> 
                                            </asp:DropDownList>
                                          </div>
                                        <div class="col-sm-4 col-xs-12">
                                            <label>
                                                Passport Issue from
                                            </label>
                                            <asp:DropDownList id="ddlState" runat="server"  CssClass="form-control">
                                                <asp:ListItem>---Select---</asp:ListItem>  
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                       <div class="row">
                                        <div class="col-sm-4 col-xs-12">
                                            <label>
                                                Query field
                                            </label>
                                            <asp:TextBox ID="txtOtherfield" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        </div>
                                           <div class="col-sm-4 col-xs-12">
                                            <label>
                                                 Preferred Company
                                            </label>
                                            <asp:TextBox ID="txtCompany" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        </div>
                                       

                                    </div>
                                    <div></div>
                                    <div class="row">
                                        
                                            <div class="col-sm-12 col-xs-12 text-right">
                                                <%--<input type="Submit" class="send-btn form-group" value="Send Enquiry">--%>
                                                <asp:Button ID="btnSendQuery" runat="server" Text="Send Enquiry" ValidationGroup="QueryValidationGroup" class="send-btn form-group" OnClick="btnSendQuery_Click" />
                                            </div>
                                       
                                    </div>
                                    


                                </div>
                                <div class="col-sm-4 col-xs-12">
                                    <img src="Imagess/send-query.jpg" class="img img-responsive pull-right" />
                                </div>

                                
                            </div>
                        </div>
                    </div>
                </div>




            </div>
        </div>
    </div>


</asp:Content>
