<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="JSVisaTrackingWebApplication.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="page-control" data-role="page-control">
        <ul>
            <li class="active"><a href="#page1">Consignment</a></li>
            <li><a href="#page2">PAX Details</a></li>
            <li><a href="#page3">Mail Remarks</a></li>
            <li class="place-right"><a href="#page4">To Create Invoice Click Here <i class="icon-copy">
            </i></a></li>
        </ul>
        <div class="frames">
            <div class="frame active" id="page1">
                <table class="table table-bordered table-striped table-condensed">
                    <tbody>
                        <tr>
                            <td class="left">
                                Ref No.
                            </td>
                            <td class="left" colspan="3">
                                <asp:Label ID="Label4" runat="server" Text="Refrence Number"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                Agent's Name
                            </td>
                            <td class="left" colspan="3">
                                <asp:Label ID="Label2" runat="server" Text="Agent Name"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="setupDialog" PostBackUrl="~/Login.aspx" runat="server">Select Agent's Name <i class="icon-user"></i></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" rowspan="4">
                                <table class="table table-bordered table-striped table-condensed">
                                    <tr>
                                        <td>
                                            Country
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            Countries Selected
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="left">
                                            <div class="input-control select">
                                                <select multiple="6">
                                                    <option value="1">Option 1</option>
                                                    <option value="2">Option 2</option>
                                                    <option value="3">Option 3</option>
                                                    <option value="4">Option 4</option>
                                                    <option value="5">Option 5</option>
                                                </select>
                                            </div>
                                        </td>
                                        <td class="span1">

                                            <asp:Button CssClass="bg-color-darken" ID="Button1" runat="server" Text=">>" ForeColor="Black" Font-Bold="True" Font-Size="18px" />
                                            <asp:Button CssClass="bg-color-darken" ID="Button2" runat="server" Text="<<" ForeColor="Black" Font-Bold="True" Font-Size="18px"  />
                                        </td>
                                        <td class="right">
                                            <div class="input-control select">
                                                <select multiple="6">
                                                    <option value="1">Option 1</option>
                                                    <option value="2">Option 2</option>
                                                    <option value="3">Option 3</option>
                                                    <option value="4">Option 4</option>
                                                    <option value="5">Option 5</option>
                                                </select>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="left">
                                Visa Country
                            </td>
                            <td class="left">
                                <div class="input-control select">
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem>-- Select Item --</asp:ListItem>
                                        <asp:ListItem>Apple</asp:ListItem>
                                        <asp:ListItem>Banana</asp:ListItem>
                                        <asp:ListItem>Orenge</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                Submission Date
                            </td>
                            <td class="left">
                                <div class="input-control text datepicker span4"  data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    <i class="btn-date"></i>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                Checked on Date
                            </td>
                            <td class="left">
                                <div class="input-control text datepicker span4"  data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                                    <i class="btn-date"></i>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                Group Rep.
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Collection Date
                            </td>
                            <td class="left">
                                <div class="input-control text datepicker span4"  data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                    <i class="btn-date"></i>
                                </div>
                            </td>
                            <td class="left">
                                Travel Dates
                            </td>
                            <td class="left">
                                <div class="input-control text datepicker span4"  data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="TextBox7" runat="server" required="required" requiredmessage="Date is required."></asp:TextBox>
                                    <i class="btn-date"></i>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                Instructions
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </td>
                            <td class="left">
                                Remarks
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr><td class="left" colspan="4">     
                         <div class="input-control text">
    <input type="text" />
                             <%--<asp:LinkButton ID="LinkButton6" runat="server"><i class="btn-search"></i></asp:LinkButton>--%> 
    </div></td></tr>
                        <tr>
                            <td colspan="4">
                                <label class="input-control checkbox" onclick="">
                                    <asp:CheckBox ID="CheckBox4" runat="server" />
                                    <span class="helper">Collected</span>
                                </label>
                                <label class="input-control checkbox" onclick="">
                                    <asp:CheckBox ID="CheckBox5" runat="server" />
                                    <span class="helper">Blank Collection Date</span>
                                </label>
                                <label class="input-control checkbox" onclick="">
                                    <asp:CheckBox ID="CheckBox6" runat="server" />
                                    <span class="helper">Disabled</span>
                                </label>
                                <label class="input-control checkbox" onclick="">
                                    <asp:CheckBox ID="CheckBox7" runat="server" />
                                    <span class="helper">Blank Submission Date</span>
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Area Code
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                            </td>
                            <td class="left">
                                No.of Passport
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="TextBox4" runat="server"  required="required" requiredmessage="Name is required." pattern="[a-z,A-Z]{5}"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                POE Required
                            </td>
                            <td class="left">
                                <label class="input-control checkbox" onclick="">
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                    <span class="helper">Checked box</span>
                                </label>
                            </td>
                            <td class="left">
                                Corporate
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                
                                    <asp:TextBox ID="TextBox10" runat="server" required="required" requiredmessage="Name is required."></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Transfered to
                            </td>
                            <td class="left">
                                <div class="input-control select">
                                    <asp:DropDownList ID="DropDownList2" runat="server">
                                        <asp:ListItem>-- Select Item --</asp:ListItem>
                                        <asp:ListItem>Apple</asp:ListItem>
                                        <asp:ListItem>Banana</asp:ListItem>
                                        <asp:ListItem>Orenge</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td class="left">
                                Entered By
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <h4>
                                    Sent by :</h4>
                                <div class="progress-bar">
                                    <div class="bar bg-color-blue" style="width: 100%;">
                                    </div>
                                </div>
                                <table class="table table-bordered table-striped table-condensed">
                                    <tbody>
                                        <tr>
                                            <td class="left">
                                                Name
                                            </td>
                                            <td class="left">
                                                <div class="input-control text">
                                                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                                                    <button class="btn-clear" />
                                                </div>
                                            </td>
                                            <td class="left">
                                                Mobile No.
                                            </td>
                                            <td class="left">
                                                <div class="input-control text">
                                                    <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                                                    <button class="btn-clear" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="left">
                                                Email Subscribe
                                            </td>
                                            <td class="left">
                                                <label class="input-control checkbox" onclick="">
                                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                                    <span class="helper">Chek Box</span>
                                                </label>
                                            </td>
                                            <td class="left">
                                                Email:
                                            </td>
                                            <td class="left">
                                                <div class="input-control text">
                                                    <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                                                    <button class="btn-clear" />
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <button>
                    Save<i class="icon-save right"></i></button>
                <button>
                    Delete<i class="icon-save right"></i></button>
                <button>
                    Cancel<i class="icon-save right"></i></button>
                <button>
                    Update<i class="icon-save right"></i></button>
                <button>
                    Close<i class="icon-save right"></i></button>
                <button>
                    Add<i class="icon-save right"></i></button>
            </div>
            <div class="frame" id="page2">
                <h2>
                    Page 2</h2>
                   
            </div>
            <div class="frame" id="page3">
                <h2>
                    Page 3</h2>
                <p>
                    <asp:LinkButton ID="LinkButton1" runat="server" ToolTip="Update"><i class=" icon-loading-2"></i></asp:LinkButton>
                     <asp:LinkButton ID="LinkButton2" runat="server" ToolTip="Save"><i class="icon-save"></i></asp:LinkButton> 
                      <asp:LinkButton ID="LinkButton3" runat="server" ToolTip="Edit"><i class="icon-pencil"></i></asp:LinkButton>
                       <asp:LinkButton ID="LinkButton4" runat="server" ToolTip="Cancel"><i class="icon-cancel-2"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton5" runat="server" ToolTip="Delete"><i class=" icon-remove"></i></asp:LinkButton>           
</p>
            </div>
            <div class="frame" id="page4">
                <h2>
                    Creat Invoice</h2>
                <p>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur porta condimentum
                    sem sed commodo. Praesent vestibulum, libero eget lacinia pretium, metus augue dapibus
                    odio, nec placerat mauris justo non ante. Maecenas adipiscing nulla sed sem molestie
                    quis pulvinar lectus convallis. Nam tortor arcu, gravida nec tristique sit amet,
                    pretium sagittis eros. Curabitur at nisi ut ligula ornare euismod. Ut vitae tortor
                    eget elit dictum dictum. Ut porttitor, ante non blandit gravida, felis risus feugiat
                    neque, eu tincidunt neque ante at urna. Maecenas nec felis nulla. Praesent volutpat
                    ligula vel diam venenatis feugiat. Praesent quis nunc quis nisl condimentum dapibus
                    in sed ipsum. Aenean nulla sapien, consequat id aliquam ac, sollicitudin sed nisl.
                    Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia
                    Curae; Duis vitae risus erat.</p>
            </div>
        </div>
    </div>
</asp:Content>
