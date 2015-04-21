<%@  Page Title="Coverage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Coverage.aspx.cs" Inherits="JSVisaTrackingWebApplication.About" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="container-fulid page-heading">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-sm-12">Coverage</div>
                    
                </div>
            </div>
        </div>
    </section>
    <div class="container">
    <div class="row">
        <div class="middle">
            <div class="container">
                <div class="row">
                    <div class="col-sm-5 col-xs-12">
                       <img src="Imagess/map1.gif"  class="img-responsive"/>
                        <span class="kol">
                            <span class="location">Kolkata</span>
                            <span class="add">Address : 55/55/1, Chowringhee Road, 2nd Floor, Room No-29, Chowringhee Court, 
                                (Above Maharaja Restaurant) Kolkata - 700 071 </span>
                        </span>

                         <span class="hyd">
                            <span class="location">Hyderabad</span>
                            <span class="add">Address : 3-6-322, Chamber No. 205, 2nd Flr, Mahavir House, Basheerbagh,Andhra Pradesh, Hyderabad - 500029.</span>
                        </span>

                          <span class="del">
                            <span class="location">Delhi</span>
                            <span class="add">Address : 30/28, IIIrd Floor, (Opp Mughal Mahal Restaurant), East Patel Nagar, New Delhi-110008, India</span>
                        </span>
                         <span class="gur">
                            <span class="location">Gurgaon</span>
                            <span class="add">Address : F-16, Lower Ground Floor Sushant Shopping Arcade, Sushant Lok-1, Gurgaon - 122009. </span>
                        </span>
                         <span class="mum">
                            <span class="location">Mumbai</span>
                            <span class="add">Address : 801-802, Crystal Towers, 48 Maruti Lane, Fort, Maharashtra. Mumbai - 400001 </span>
                        </span>

                         <span class="bang">
                            <span class="location">Bangalore</span>
                            <span class="add">Address : 2/3 ,Momdi House .1st Floor, Plain Street, Infantry Road, Bangalore - 560001 </span>
                        </span>
                          <span class="chan">
                            <span class="location">Chennai </span>
                            <span class="add"> Address : No. 15/8, Thanthondriamman Koil Street Agaram, Chennai-600 082</span>
                        </span>
                                        


      <%--  <asp:ImageMap ID="ImageMap1" runat="Server" ImageUrl="Imagess/map1.gif" Width="300" HotSpotMode="PostBack"  runat="server">
                      
        <asp:RectangleHotSpot Top="0" Bottom="225" Left="0" Right="150" AlternateText="Address : 30/28, IIIrd Floor, (Opp Mughal Mahal Restaurant), East Patel Nagar, New Delhi-110008, India " PostBackValue="You are on left side of SearTowers" />
          
          <asp:RectangleHotSpot Top="0" Bottom="225" Left="0" Right="50" AlternateText="Address : F-16, Lower Ground Floor Sushant Shopping Arcade, Sushant Lok-1, Gurgaon - 122009. " PostBackValue="You are on left side of SearTowers" />
        
            <asp:RectangleHotSpot Top="0" Bottom="225" Left="151" Right="300" AlternateText="chicago1" PostBackValue="You are on right side of SearTowers" />
       
                    </asp:ImageMap>--%>
                    </div>

                    <div class="col-sm-7 col-xs-12">
                        <div class="content">
                       
                            Jetsave started its operations in Delhi and over last 25 years, it has spread its wings across nation with Head Office situated at 
                            <b>Delhi & Branches at Bangalore, Kolkata, Gurgaon, Mumbai, Hyderabad & Chennai.</b>
                            <br/> All our branch offices are full-fledged and fully functional with a team of experienced visa executives servicing our clients. Besides this, Jetsave has networked with the travel agents in every city/town having consulates.  As on today, Jetsave caters to over 4000 travel agents and clients across Country and has a track record of facilitating over 2,50,000 (two hundred and fifty thousand) visas in a year.
         </div>
                    </div>
                    
                </div>
            </div>




        </div>
    </div>
</div>

</asp:Content>
