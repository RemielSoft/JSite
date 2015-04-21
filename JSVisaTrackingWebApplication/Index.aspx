<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="JSVisaTrackingWebApplication.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="container-fulid">
            <div id="myCarousel" class="carousel slide" data-interval="3000" data-ride="carousel" style="position: relative;">
                <!-- Carousel indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                    <li data-target="#myCarousel" data-slide-to="2"></li>
                   <li data-target="#myCarousel" data-slide-to="3"></li>
                </ol>
                <!-- Carousel items -->
                <div class="carousel-inner">
                     <div class="item active">
                        <a href="http://jetsaveholidays.com/" target="_blank"><img src="Imagess/banner5.jpg" class="img-responsive" /></a>
                       
                    </div>
                    <div class="item">
                        <img src="Imagess/banner1.jpg" class="img-responsive" />
                        <%-- <div class="carousel-caption">
                                <h3>First slide label</h3>
                                <p>Lorem ipsum dolor sit amet consectetur…</p>
                            </div>--%>
                    </div>
                    <div class="item">
                        <img src="Imagess/banner2.jpg" class="img-responsive" />

                    </div>
                    <div class="item">
                        <img src="Imagess/banner3.jpg" class="img-responsive" />

                    </div>
                     
                   <%-- <div class="item">
                            <img src="Imagess/banner4.jpg" class="img-responsive" /></div>--%>
                </div>
                <!-- Carousel nav -->
               <%-- @*  <a class="carousel-control left" href="#myCarousel" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
                    </a>
                    <a class="carousel-control right" href="#myCarousel" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right"></span>
                    </a>*@--%>
            </div>

        </div>


        <div class="container">
            <div class="row">
                <div class="middle">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm-9 col-xs-12">
                                <div class="col-sm-4 col-xs-12 no-padding-left">
                                    <div class="box text-center">
                                         <div class="circle">
                                            <img src="Imagess/price.png"  alt="price" /></div>
                                        <div class="heading">BEST PRICE GUARANTEE</div>
                                        Find our lowest price to destinations worldwide, guaranteed
                                    </div>
                                </div>
                                <div class="col-sm-4 col-xs-12 no-padding-left">
                                    <div class="box text-center">
                                        <div class="circle-cel">
                                            <img src="Imagess/celender.png"  alt="celender" /></div>
                                        <div class="heading">
                                            <a href="Query.aspx">EASY BOOKING</a>

                                        </div>
                                        Search, select and save - the fastest way to book your trip
                                    </div>
                                </div>
                                <div class="col-sm-4 col-xs-12  no-padding-left">
                                    <div class="box text-center">
                                         <div class="circle">
                                         <img src="Imagess/price.png" alt="customer"/>
                                             </div>
                                        <div class="heading"> <a href="AmexPayment.aspx">24/7 Online Payment</a></div>
                                        Through Credit
Cards, Debit Cards, NEFT, RTGS, Online Transfers etc.  Clicking on this link should open the page which has the payment details of 
our bank as well as both the payment gateways i.e. Amex and Visa & Master Card
                                       </div>
                                </div>
                                   <div class="col-sm-12 col-xs-12 no-padding">
                                <div class="content" style="min-height:0px">
                                    <h3 class="heading no-margin-top">Welcome to Jet Save</h3>
                         Jetsave India Tours Pvt. Ltd, which is <b>India’s leading & Most Reliable</b> Visa Facilitation company, 
                                    has been into operations of visa facilitation <b>since 1990</b> and ever since its inception our 
                                    team has given utmost importance to client’s satisfaction. With  <b>over 25 years of rich 
                                    experience</b> of visa consolidation, Jetsave has  <b>built up excellent working relationship 
                                    with all the Consulates and High Commissions</b> in India and has earned the reputation of 
                                    being the most reliable and leading visa Facilitation Company of India. Jetsave’s team 
                                    is  <b>well experienced in handling visa processing of all countries</b> having Embassy/consulate 
                                    in India. With Jetsave, one can be assured of  <b>high end quality</b> service and that too  <b>at 
                                    the competitive price.</b>
                                    <br/> <br/>
 

We, at Jetsave, treat all our clients as our valued customers and offer them 
                                    the best of our services without any fail. 
                                    Jetsave has been <b>servicing all big travel houses, 
                                    corporates, travel agents</b> operating in India and has a 
                                    turnaround of <b>over 2.5Lakhs visas a year.</b> Should you need 
                                    any assistance/guidance for your visa/legalization work, 
                                    what all you have to do is to <a href="Contact.aspx" class="link">contact</a> us or post a <a href="Query.aspx" class="link">query</a> to us. 
                                    Our team of experts will get back to you with the best possible 
                                    solution for your visa/legalization query.
                                </div>


                            </div>
                                <div class="col-sm-12 col-xs-12 no-padding">
                                <span class="slider-heading">More Holiday Package Details</span>
                                <div class="flexslider">
                                    <ul class="slides">
                                        <li>
                                            <div class="img-container">
                                                <a href="http://jetsaveholidays.com/" target="_blank">
                                                <div class="img-area">
                                                    <img src="Imagess/Rajasthan.jpg" />
                                                    <div class="rate img-circle"><div class="old-prize">33,000<span>&#x20B9;</span></div>
                                                        <div class="current-prize">28,000<span>&#x20B9;</span></div>
                                                    </div>
                                                </div>
                                                <div class="img-area-text">
                                                    <div class="img-area-text-1"><span class="glyphicon glyphicon-link plus-icon"></span></div>
                                                </div>
                                                    </a>
                                            </div>
                                            <div class="caption">
                                                <div class="col-sm-9 no-padding-right text">Best of Rajasthan  <br/> <b class="red">USD 456</b>
                                                  
                                                </div>
                                                <div class="text-center col-sm-3 days"><span style="font-size:16px;">8</span> <br/><span class="small">DAYS</span></div>
                                               <div class="col-sm-12 col-xs-12 details no-padding">
                                                   <b>What will you do - Jungle Safari, Sightseeing:</b> Wildlife, Forts, Palaces, Shrines<br/>
                                                    <b>Duration- 7Nights / 8Days :</b> Delhi – Agra – Ranthambhore – Jaipur – Udaipur - Pushkar - Delhi<br/>
                                                <b>Best time to visit:</b> Oct, Nov, Dec, Jan, Feb, Mar
                                               </div>
                                                
                                            </div>
                                             
                                        </li>
                                        <li>
                                            <div class="img-container">
                                                 <a href="http://jetsaveholidays.com/" target="_blank">
                                                <div class="img-area">
                                                    <img src="Imagess/Jodhpur.jpg" />
                                                    <div class="rate img-circle"><div class="old-prize">55,000<span>&#x20B9;</span></div>
                                                        <div class="current-prize">48,000<span>&#x20B9;</span></div>
                                                    </div>
                                                </div>
                                                <div class="img-area-text">
                                                    <div class="img-area-text-1"><span class="glyphicon glyphicon-link plus-icon"></span></div>
                                                 </div>
                                                </a>
                                            </div>

                                           <div class="caption">
                                                <div class="col-sm-9 no-padding-right text">Cultural Rajasthan <br/> <b class="red">USD 781 </b>
                                                </div>
                                                <div class="text-center col-sm-3 days"><span style="font-size:16px;">14</span> <br/><span class="small">DAYS</span></div>
                                               <div class="col-sm-12 col-xs-12 details no-padding">
                                                 <b> What will you do - Sightseeing:</b> Forts, Palaces, Monuments, Temples, Camel Ride, Shopping<br/>
<b>Duration- 13Nights / 14Days :</b> Delhi – Samode – Jaipur – Pushkar – Devigarh – Jodhpur – Jaisalmer – Bikaner – Mandawa<br/>
<b>Best time to visit:</b> Oct, Nov, Dec, Jan, Feb, Mar
                                               </div>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="img-container">
                                                 <a href="http://jetsaveholidays.com/" target="_blank">
                                                <div class="img-area">
                                                    <img src="Imagess/RanthambhoreS.jpg" />
                                                     <div class="rate img-circle"><div class="old-prize">22,000<span>&#x20B9;</span></div>
                                                        <div class="current-prize">30,000<span>&#x20B9;</span></div>
                                                    </div>
                                                </div>
                                                <div class="img-area-text">
                                                    <div class="img-area-text-1"><span class="glyphicon glyphicon-link plus-icon"></span></div>
                                                </div>
                                               </a>
                                            </div>
                                           <div class="caption">
                                                <div class="col-sm-9 no-padding-right text">Golden Triangle with Wildlife and Tigers <br> <b class="red">USD 358</b>
                                                </div>
                                                <div class="text-center col-sm-3 days"><span style="font-size:16px;">8</span> <br/><span class="small">DAYS</span></div>
                                               <div class="col-sm-12 col-xs-12 details no-padding">
                                                 <b> What will you do - Sightseeing:</b> Forts, Palaces, Monuments, Temples, Camel Ride, Shopping<br/>
<b>Duration- 13Nights / 14Days :</b> Delhi – Samode – Jaipur – Pushkar – Devigarh – Jodhpur – Jaisalmer – Bikaner – Mandawa<br/>
<b>Best time to visit:</b> Oct, Nov, Dec, Jan, Feb, Mar
                                               </div>
                                            </div>
                                        </li>
                                        <li>

                                            <div class="img-container">
                                                 <a href="http://jetsaveholidays.com/" target="_blank">
                                                <div class="img-area">
                                                    <img src="Imagess/Temple-S.jpg" />
                                                     <div class="rate img-circle"><div class="old-prize">36,000<span>&#x20B9;</span></div>
                                                        <div class="current-prize">25,000<span>&#x20B9;</span></div>
                                                    </div>
                                                </div>
                                                <div class="img-area-text">
                                                    <div class="img-area-text-1"><span class="glyphicon glyphicon-link plus-icon"></span></div>
                                                </div>
                                                     </a>
                                            </div>
                                              <div class="caption">
                                                <div class="col-sm-9 no-padding-right text">Golden Triangle with Khajuraho &amp; Varanasi  <br/><b class="red">USD 415 </b>
                                                </div>
                                                <div class="text-center col-sm-3 days"><span style="font-size:16px;">8</span> <br/><span class="small">DAYS</span></div>
                                               <div class="col-sm-12 col-xs-12 details no-padding">
                                                <b>What will you do - Sightseeing:</b> Exploring the quaint lanes of Old Delhi, Mesmeric City of Lakes at Jaipur, Erotic Sculptures at Khajuraho, Ganges river, Famous Varanasi Ghats and temples<br/>
                                                   <b> Duration- 8Nights / 9Days :</b> E Delhi – Jaipur- Agra – Orcha - Khajurao – Varanasi<br/>
                                                    <b>Best time to visit:</b> E Oct, Nov, Dec, Jan, Feb, Mar<br/>
                                               </div>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="img-container">
                                                <a href="http://jetsaveholidays.com/" target="_blank">
                                                <div class="img-area">
                                                    <img src="Imagess/Manali.-Kullu-Valley-S.jpg" />
                                                     <div class="rate img-circle"><div class="old-prize">43,000<span>&#x20B9;</span></div>
                                                        <div class="current-prize">29,800<span>&#x20B9;</span></div>
                                                    </div>
                                                </div>
                                                <div class="img-area-text">
                                                    <div class="img-area-text-1"><span class="glyphicon glyphicon-link plus-icon"></span></div>
                                                </div>
                                                    </a>
                                            </div>
                                            <div class="caption">
                                                <div class="col-sm-9 no-padding-right text">Golden Triangle with Grand Himachal  <br/> <b class="red">USD 485 </b>
                                                </div>
                                                <div class="text-center col-sm-3 days"><span style="font-size:16px;">11</span> <br/><span class="small">DAYS</span></div>
                                               <div class="col-sm-12 col-xs-12 details no-padding">
                                               <b>What will you do :</b> Sightseeing, Adventure Sports, Cultural Sites, Shopping<br/>
                                                <b>Duration- 10Nights / 11Days : </b> Delhi – Shimla– Manali - Chandigarh - Delhi - Jaipur - Agra<br/>
                                                <b>Best time to visit : </b> Oct, Nov, Dec, Jan, Feb, Mar<br/>
                                               </div>
                                            </div>
                                        </li>

                                         <li>
                                            <div class="img-container">
                                                <a href="http://jetsaveholidays.com/" target="_blank">
                                                <div class="img-area">
                                                    <img src="Imagess/Corbett-National-Park-S.jpg" />
                                                     <div class="rate img-circle"><div class="old-prize">55,000<span>&#x20B9;</span></div>
                                                        <div class="current-prize">48,000<span>&#x20B9;</span></div>
                                                    </div>
                                                </div>
                                                <div class="img-area-text">
                                                    <div class="img-area-text-1"><span class="glyphicon glyphicon-link plus-icon"></span></div>
                                                </div>
                                                    </a>
                                            </div>
                                            <div class="caption">
                                                <div class="col-sm-9 no-padding-right text">Golden Triangle with Jim Corbett  <br><b class="red">USD 342 </b>
                                                </div>
                                                <div class="text-center col-sm-3 days"><span style="font-size:16px;">8</span> <br/><span class="small">DAYS</span></div>
                                               <div class="col-sm-12 col-xs-12 details no-padding">
                                            <b>What will you do - Sightseeing: </b> Traditional and decorated villages tour, ethnic shows, explore magnificent cities and unfold all its splendours, Jeep Safari, Jungle Safari, Wildlife Spotting <br/>
                                            <b>Duration- 7Nights / 8Days : </b> Delhi – Jaipur- Agra – Delhi- Corbett<br/>
                                            <b>Best time to visit: </b> Oct, Nov, Dec, Jan, Feb, Mar<br/>
                                               </div>
                                            </div>
                                        </li>


                                         <li>
                                            <div class="img-container">
                                                <a href="http://jetsaveholidays.com/" target="_blank">
                                                <div class="img-area">
                                                    <img src="Imagess/Jodhpur.jpg" />
                                                     <div class="rate img-circle"><div class="old-prize">32,000<span>&#x20B9;</span></div>
                                                        <div class="current-prize">23,000<span>&#x20B9;</span></div>
                                                    </div>
                                                </div>
                                                <div class="img-area-text">
                                                    <div class="img-area-text-1"><span class="glyphicon glyphicon-link plus-icon"></span></div>
                                                </div>
                                                    </a>
                                            </div>
                                            <div class="caption">
                                                <div class="col-sm-9 no-padding-right text">Colorful Rajasthan  <br/> <b class="red">USD 383 </b>
                                                </div>
                                                <div class="text-center col-sm-3 days"><span style="font-size:16px;">8</span> <br/><span class="small">DAYS</span></div>
                                               <div class="col-sm-12 col-xs-12 details no-padding">
                                           <b> What will you do : </b> Sightseeing, traditional and decorated villages tour, ethnic shows, 
                                                   explore magnificent cities and unfold all its splendours, camel ride.<br />
                                            <b>Duration- 8Nights / 9Days : </b> Jaipur – Bikaner- Jaisalmer – Jodhpur- Udaipur<br />
                                            <b>Best time to visit: </b> Oct, Nov, Dec, Jan, Feb, Mar<br />
                                               </div>
                                            </div>
                                        </li>

                                        <li>
                                            <div class="img-container">
                                                <a href="http://jetsaveholidays.com/" target="_blank">
                                                <div class="img-area">
                                                    <img src="Imagess/Amritsar-S.jpg" />
                                                     <div class="rate img-circle"><div class="old-prize">36,000<span>&#x20B9;</span></div>
                                                        <div class="current-prize">25,000<span>&#x20B9;</span></div>
                                                    </div>
                                                </div>
                                                <div class="img-area-text">
                                                    <div class="img-area-text-1"><span class="glyphicon glyphicon-link plus-icon"></span></div>
                                                </div>
                                                    </a>
                                            </div>
                                            <div class="caption">
                                                <div class="col-sm-9 no-padding-right text">Golden Triangle Tour with Golden Temple  <br><b class="red">USD 310 </b>
                                                </div>
                                                <div class="text-center col-sm-3 days"><span style="font-size:16px;">7</span> <br/><span class="small">DAYS</span></div>
                                               <div class="col-sm-12 col-xs-12 details no-padding">
                                          <b>What will you do - Sightseeing : </b> Delhi, Jaipur Sightseeing, Elepant Ride, 
                                                   Golden Temple Sightseeing, Explore Sikh religion and culture.<br/>
                                            <b>Duration- 6Nights / 7Days : </b> Delhi – Jaipur- Agra – Delhi- Amritsar<br/>
                                                <b>Best time to visit : </b> Oct, Nov, Dec, Jan, Feb, Mar<br/>
                                               </div>
                                            </div>
                                        </li>




                                    </ul>

                                </div>


                            </div>

                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <div class="no-padding col-sm-12 col-xs-12">
                                    <div class="item-list">
                                        <ul>
                                            <li class="list-heading">Services
                                 <div class="service-icon">
                                     <img src="Imagess/services.png" />
                                 </div>
                                            </li>

                                            <li><a href="Services.aspx#visaService">Visa Assistance
                                 <span class="pull-right score">
                                     <img src="Imagess/visa.png" /></span> </a>
                                            </li>
                                              <li><a href="Services.aspx#LegalizationService">Legalization
                                  <span class="pull-right score"><img src="Imagess/Legalization.png" /></span></a>
                                            </li>

                                            <li><a href="Services.aspx#OnlineAppointments">Online Appointments
                                  <span class="pull-right score">
                                      <img src="Imagess/OnlineAppointmentsIcon.png" /></span></a>
                                            </li>
                                          
                                               <li><a href="Services.aspx#TravelInsurance">Travel Insurance
                                  <span class="pull-right score">
                                      <img src="Imagess/insurance.png" /></span></a>
                                            </li>

                                            <li><a href="Services.aspx#OnsiteSupport">Onsite Support & Implant
                                <span class="pull-right score"><img src="Imagess/OnsiteSupportIcon.png" /></span></a>
                                            </li>
                                          <li><a href="Services.aspx#MeetAssist">Meet and Assist
                                <span class="pull-right score"> <img src="Imagess/MeetAssistIcon.png" /></span></a>
                                            </li>
                                            
                                            <li><a href="Services.aspx#PickupDrop">Pickup and Drop
                                <span class="pull-right score"> <img src="Imagess/PickupDropIcon.png" /></span></a>
                                            </li>
                                          <li><a href="Services.aspx#CourierCargo">Courier and Cargo
                                <span class="pull-right score"> <img src="Imagess/CourierCargoIcon.png" /></span></a>
                                            </li>
                                             <li><a href="Services.aspx#InboundTours">Inbound Tours
                                <span class="pull-right score"> <img src="Imagess/InboundToursIcon.png" /></span></a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-xs-12 no-padding">
                                <div class="news-heading">
                                    News & Events
                                 <div class="service-icon">
                                     <img src="Imagess/news.png" />
                                 </div>
                                </div>

                                <div class="news" id="newsevents" runat="server">
                                    <div id="nt-example1-container">
                                      <%-- <i class="fa fa-arrow-up" id="nt-example1-prev"></i>--%>
                                        <ul id="nt-example1" style="width: 100%">
                                            <asp:Repeater ID="rptNews" runat="server">
                                                <ItemTemplate >
                                                <li>
                                                     <div class="text-right date">
                                                         <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Created_Date") %>'></asp:Label>
                                                     </div>

                                                    <asp:Label ID="lbldiscription" runat="server" Text='<%# Eval("Description") %>' />
                                                    <a  onclick="showNews('<%#Eval("TopicId")%>');" class="read-more text-right" >Read More..</a>
                                                </li>
                                                    </ItemTemplate>
                                            </asp:Repeater>
                                            <%--<li>
                                                <div class="text-right date">12/04/2014</div>
                                                Etiam imperdiet volutpat libero eu tristique. <a href="#" class="read-more">Read more...</a></li>
                                            <li>
                                                <div class="text-right date">15/04/2014</div>
                                                Curabitur porttitor ante eget hendrerit adipiscing. <a href="#" class="read-more">Read more...</a></li>
                                            <li>
                                                <div class="text-right date">12/04/2014</div>
                                                Praesent ornare nisl lorem, ut condimentum lectus gravida ut. <a href="#" class="read-more">Read more...</a></li>
                                            <li>
                                                <div class="text-right date">04/04/2014</div>
                                                Nunc ultrices tortor eu massa placerat posuere. <a href="#" class="read-more">Read more...</a></li>
                                            <li>
                                                <div class="text-right date">18/04/2014</div>
                                                Morbi sodales tellus sit amet leo congue bibendum. <a href="#" class="read-more">Read more...</a></li>
                                            <li>
                                                <div class="text-right date">02/04/2014</div>
                                                In pharetra suscipit orci sed viverra.  <a href="#" class="read-more">Read more...</a> </li>
                                            <li>
                                                <div class="text-right date">12/04/2014</div>
                                                Maecenas nec ligula sed est suscipit aliquet sed eget ipsum, suspendisse. <a href="#" class="read-more">Read more...</a></li>
                                            <li>
                                                <div class="text-right date">022/04/2014</div>
                                                Onec bibendum consectetur diam, nec euismod urna venenatis eget.. <a href="#" class="read-more">Read more...</a> </li>--%>
                                        </ul>
                                     <%--  <i class="fa fa-arrow-down" id="nt-example1-next"></i>--%>
                                    </div>
                                </div>

                            </div>
                                <div class="col-sm-12 col-xs-12 no-padding">
                                <div id="slider-1">
                                    <div>
                                        <img src="Imagess/taai.jpg" class="img-responsive text-center" />
                                    </div>

                                    <div>
                                        <img src="Imagess/tafi.jpg" class="img-responsive text-center" />
                                    </div>

                                    <div>
                                        <img src="Imagess/lato.jpg" class="img-responsive text-center" />
                                    </div>

                                    <div>
                                        <img src="Imagess/adtoi.jpg" class="img-responsive text-center" />
                                    </div>
                                    <div>
                                        <img src="Imagess/otoai.jpg" class="img-responsive text-center" />
                                    </div>
                                     <div>
                                        <img src="Imagess/iaai.jpg" class="img-responsive text-center" />
                                    </div>
                                     <div>
                                        <img src="Imagess/skal.jpg" class="img-responsive text-center" />
                                    </div>
                                    <div>
                                        <img src="Imagess/visa.jpg" class="img-responsive text-center" />

                                    </div>
                                    <div>
                                        <img src="Imagess/american.jpg" class="img-responsive text-center" />
                                    </div>
                                </div>
                            </div>
                            </div>
                       </div>


                        </div>
                    </div>

                   

                </div>
            </div>
      

    </section>

    <div id="btnShowModal" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog">
       <div class="modal-dialog modal-sm">
    <div class="modal-content">
      <div class="modal-header">
                    <button type="button" class="close glyphicon glyphicon-remove close-color-white" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">NEWS & EVENTS</h4>
                </div>
            <div class="modal-content">
               
                    <div class="modal-body" id="dvNews">

                    </div>
                
            </div>
                 </div>
        </div>
    </div>


    <div id="taj" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog">
        <div class="modal-dialog ">
            <div class="modal-content border-all-none box-shadow-none background-none">
                <div>
                    <div data-dismiss="modal" class="closed">
                        <img src="Imagess/close-icon.png" />
                    </div>
                </div>
                <div class="modal-body modal-bg no-padding-top overflow-h">
                    <div class="col-sm-4 col-xs-12">
                        <img src="Imagess/gallary/taj.jpg" class="img-responsive popup-img" /></div>
                    <div class="col-sm-8 col-xs-12">
                        <div class="table-responsive">
                            <table class="table table-striped table-bordered">
                                <tr>
                                    <td>Duration</td>
                                    <td>:</td>
                                    <td>5 Days</td>
                                </tr>

                                <tr>
                                    <td>Places Covered</td>
                                    <td>:</td>
                                    <td>Delhi - Agra - Jaipur - Delhi</td>
                                </tr>
                                <tr>
                                    <td colspan="3"><a href="#" class="red">Tour Details</a>   |   <a href="#" class="red">Book this Tour</a></td>


                                </tr>

                            </table>

                        </div>


                    </div>
                </div>

            </div>
        </div>
    </div>

   
    <script src="Scripts/jquery.newsTicker.js" type="text/javascript"></script>
    <script src="Scripts/jquery.flexslider.js" type="text/javascript"></script>

    <script type="text/javascript">
        function showNews(id) {
            $.ajax({
                type: "POST",
                url: "Index.aspx/ReadNews",
                data: '{topicId:' + id + '}',
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                async: "false",
                success: function (response) {
                    if (response.d != "") {
                        $("#dvNews").html(response.d);
                    }
                },
                error: function (response) {
                }
            }).done(function () {
                $("#btnShowModal").modal("show");
            });
        }
        $(document).ready(function () {
            $(".aShowPopUp").click(function () {
                var quzName = $(this).attr("id");
                $("#lblQuizSub").html(quzName);
                $.ajax({
                    type: "POST",
                    url: "Leaderboard.aspx/QuizResult",
                    data: '{QuizName:"' + quzName + '"}',
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    async: "false",
                    success: function (response) {
                        if (response.d != "") {
                            $("#dvQuizResult").html(response.d);
                        }
                    },
                    error: function (response) {
                    }
                }).done(function () {
                    $("#divDetail").modal("show");
                });
            });
        });
    </script>

    <script type="text/javascript">
       
        $(window).load(function () {
            $('.flexslider').flexslider({
                animation: "slide",
                animationLoop: false,
                itemWidth: 234,
                itemMargin: 3,
                minItems: 1,
                maxItems: 3,
                start: function (slider) {
                    $('body').removeClass('loading');
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(window).load(function () {
            $('code.language-javascript').mCustomScrollbar();
        });
        var nt_title = $('#nt-title').newsTicker({
            row_height: 40,
            max_rows: 1,
            duration: 3000,
            pauseOnHover: 0
        });
        var nt_example1 = $('#nt-example1').newsTicker({
            row_height: 80,
            max_rows: 3,
            duration: 4000,
            prevButton: $('#nt-example1-prev'),
            nextButton: $('#nt-example1-next')
        });
        var nt_example2 = $('#nt-example2').newsTicker({
            row_height: 60,
            max_rows: 1,
            speed: 300,
            duration: 6000,
            prevButton: $('#nt-example2-prev'),
            nextButton: $('#nt-example2-next'),
            hasMoved: function () {
                $('#nt-example2-infos-container').fadeOut(200, function () {
                    $('#nt-example2-infos .infos-hour').text($('#nt-example2 li:first span').text());
                    $('#nt-example2-infos .infos-text').text($('#nt-example2 li:first').data('infos'));
                    $(this).fadeIn(400);
                });
            },
            pause: function () {
                $('#nt-example2 li i').removeClass('fa-play').addClass('fa-pause');
            },
            unpause: function () {
                $('#nt-example2 li i').removeClass('fa-pause').addClass('fa-play');
            }
        });
        $('#nt-example2-infos').hover(function () {
            nt_example2.newsTicker('pause');
        }, function () {
            nt_example2.newsTicker('unpause');
        });
        var state = 'stopped';
        var speed;
        var add;
        var nt_example3 = $('#nt-example3').newsTicker({
            row_height: 80,
            max_rows: 1,
            duration: 0,
            speed: 10,
            autostart: 0,
            pauseOnHover: 0,
            hasMoved: function () {
                if (speed > 700) {
                    $('#nt-example3').newsTicker("stop");
                    console.log('stop')
                    $('#nt-example3-button').text("RESULT: " + $('#nt-example3 li:first').text().toUpperCase());
                    setTimeout(function () {
                        $('#nt-example3-button').text("START");
                        state = 'stopped';
                    }, 2500);

                }
                else if (state == 'stopping') {
                    add = add * 1.4;
                    speed = speed + add;
                    console.log(speed)
                    $('#nt-example3').newsTicker('updateOption', "duration", speed + 25);
                    $('#nt-example3').newsTicker('updateOption', "speed", speed);
                }
            }
        });


        </script>
</asp:Content>
