﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="slider-parallax video-background-banner bg-overlay-black-60 parallax" data-jarallax='{"speed": 0.6}' style="background-image: url('Videos/video.jpg');" data-jarallax-video="mp4:Videos/video.mp4,webm:Videos/video.webm,ogv:Videos/video.ogv">
        <div class="slider-content-middle">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12">
                        <div class="slider-content text-center">
                            <span>Welcome to</span>
                            <h1 class="text-white">We're Hogwarts </h1>
                            <p>So you can learn it by yourself !</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <a class="scroll-down move" title="Scroll Down" href="#about-us"><i></i></a>
    </section>

  <%--  <section id="about-us" class="page-section-ptb">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 col-md-6 sm-mb-40">
                    <div class="section-title">
                        <h6>Who we are and what we do</h6>
                        <h2 class="title-effect">Get to know us better.</h2>
                        <p>We truly care about our users and our product. We are dedicated to providing you with the best experience possible. </p>
                    </div>
                    <p>Let's make something great together consectetur adipisicing elit. <span class="theme-color" data-toggle="tooltip" data-placement="top" title="" data-original-title="HTML5 template">Webster</span>  conseqt quibusdam, enim expedita sed quia nesciunt. Vero quod conseqt quibusdam, enim expedita sed quia nesciunt incidunt accusamus necessitatibus</p>
                    <div class="row mt-30">
                        <div class="col-md-6">
                            <ul class="list list-unstyled list-hand">
                                <li>Award-winning design</li>
                                <li>Super Fast Customer support </li>
                            </ul>
                        </div>
                        <div class="col-md-6">
                            <ul class="list list-unstyled list-hand">
                                <li>Easy to Customize pages</li>
                                <li>Powerful Performance </li>
                            </ul>
                        </div>
                    </div>

                </div>
                <div class="col-lg-6 col-md-6 xs-mt-30 xs-mb-30">
                    <div class="owl-carousel" data-nav-arrow="true" data-items="1" data-md-items="1" data-sm-items="1" data-xs-items="1" data-xx-items="1">
                        <div class="item">
                            <img class="img-responsive full-width" src="images/about/01.jpg" alt="">
                        </div>
                        <div class="item">
                            <img class="img-responsive full-width" src="images/about/02.jpg" alt="">
                        </div>
                        <div class="item">
                            <img class="img-responsive full-width" src="images/about/03.jpg" alt="">
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4 xs-mb-30">
                    <div class="feature-text m left-icon mt-60">
                        <div class="feature-icon">
                            <span class="ti-desktop theme-color" aria-hidden="true"></span>
                        </div>
                        <div class="feature-info">
                            <h5>Our company</h5>
                            <p>Enim expedita sed quia nesciunt dolor sit consectetur conseqt quibusdam</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 xs-mb-30">
                    <div class="feature-text left-icon mt-60">
                        <div class="feature-icon">
                            <span class="ti-server theme-color" aria-hidden="true"></span>
                        </div>
                        <div class="feature-info">
                            <h5>Our Mission</h5>
                            <p>Conseqt quibusdam, enim expedita sed quia nesciunt dolor sit consectetur</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="feature-text left-icon mt-60">
                        <div class="feature-icon">
                            <span class="ti-heart theme-color" aria-hidden="true"></span>
                        </div>
                        <div class="feature-info">
                            <h5 class="text-back">We Love</h5>
                            <p>Expedita sed quia nesciunt dolor sit consectetur conseqt quibusdam enim</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


    
 <!--=================================
counter-->

<section class="page-section-ptb bg-overlay-black-90 parallax" style="background: url(images/bg/06.jpg);">
 <div class="container">
<div class="row">
     <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6 col-xx-12 xs-mb-30">       
       <div class="counter text-white">
        <span class="icon ti-user theme-color" aria-hidden="true"></span>
        <span class="timer" data-to="4905" data-speed="10000">4905</span>
        <label>ORDERED COFFEE'S</label>
      </div>

      </div>
     <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6 col-xx-12 xs-mb-30">
     <div class="counter text-white">
        <span class="icon ti-help-alt theme-color" aria-hidden="true"></span>
        <span class="timer" data-to="3750" data-speed="10000">3750</span>
        <label>QUESTIONS ANSWERED</label>
      </div>
     </div>
     <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6 col-xx-12 xx-mb-30">
    <div class="counter text-white">
        <span class="icon ti-check-box theme-color" aria-hidden="true"></span>
        <span class="timer" data-to="4782" data-speed="10000">4782</span>
        <label>COMPLETED PROJECTS</label>
      </div>
     </div>
      <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6 col-xx-12">
     <div class="counter text-white">
        <span class="icon ti-face-smile theme-color" aria-hidden="true"></span>
        <span class="timer" data-to="3237" data-speed="10000">3237</span>
        <label>HAPPY CLIENTS</label>
      </div>
     </div>
  </div>
 </div>
</section> 

<!--=================================
counter-->

<!--=================================
key features  -->

 <section id="services" class="page-section-ptb parallax"  data-jarallax='{"speed": 0.6}' style="background-image: url(images/bg/07.jpg);">
   <div class="container">
    <div class="row">
           <div class="col-lg-8">
             <div class="section-title">
              <h6>Why webster is best! </h6>
              <h2 class="title-effect">Our awesome core features</h2>
              <p>Webster's ultimate, easy to use and customizable UI elements make it most customizable template on the market.</p>
            </div>
          </div>            
          </div>
     <div class="row">
         <div class="col-lg-4 col-md-4 col-sm-6">
          <div class="feature-text left-icon mb-40">
              <div class="feature-icon">
              <span class="ti-layers-alt theme-color" aria-hidden="true"></span>
            </div>
            <div class="feature-info">
              <h5 class="text-back">Many Style Available</h5>
              <p>Enim expedita sed quia nesciunt dolor sit consectetur conseqt quibusdam</p>
            </div>
         </div>
         <div class="feature-text left-icon mb-40">
              <div class="feature-icon">
              <span class="ti-split-v theme-color" aria-hidden="true"></span>
            </div>
            <div class="feature-info">
              <h5 class="text-back">Parallax Sections</h5>
              <p>Quibusdam, enim expedita sed quia nesciunt dolor sit consectetur conseqt </p>
            </div>
         </div>
         <div class="feature-text left-icon xs-mb-40">
              <div class="feature-icon">
              <span class="ti-heart theme-color" aria-hidden="true"></span>
            </div>
            <div class="feature-info">
              <h5 class="text-back">Blog Options</h5>
              <p>Quia nesciunt dolor sit consectetur <span data-original-title="Sed hendrerit enim non justo" data-toggle="tooltip" data-placement="top" class="tooltip-content">conseqt quibusdam,</span> enim expedita sed </p>
            </div>
         </div>
         </div>
         <div class="col-lg-4 col-md-4 col-sm-6">
             <div class="feature-text left-icon mb-40">
             <div class="feature-icon"><span
              class="ti-image theme-color" aria-hidden="true"></span>
            </div>
            <div class="feature-info">
              <h5 class="text-back">Revolution Slider</h5>
              <p>Consectetur dolor sit <span data-original-title="Sed hendrerit enim non justo" data-toggle="tooltip" data-placement="top" class="tooltip-content">conseqt quibusdam,</span> enim expedita sed quia nesciunt</p>
            </div>
         </div>
         <div class="feature-text left-icon mb-40">
              <div class="feature-icon">
              <span class="ti-paint-bucket theme-color" aria-hidden="true"></span>
            </div>
            <div class="feature-info">
              <h5 class="text-back">Unlimited Colors</h5>
              <p>Quia nesciunt dolor sit consectetur conseqt quibusdam, enim expedita sed </p>
            </div>
         </div>
         <div class="feature-text left-icon">
              <div class="feature-icon">
              <span class="ti-star theme-color" aria-hidden="true"></span>
            </div>
            <div class="feature-info">
              <h5 class="text-back">and much more...</h5>
              <p>Enim expedita sed quia nesciunt dolor sit consectetur conseqt quibusdam</p>
            </div>
         </div>
         </div>
      </div>
   </div>
 </section>

<!--=================================
key features -->

<!--=================================
 portfolio -->

<section id="portfolio" class="portfolio white-bg page-section-ptb">
 <div class="container">
   <div class="row">
       <div class="section-title text-center">
          <h6>Super creative</h6>
          <h2 class="title-effect">Our Latest Works</h2>
        </div>
     </div>  
    <div class="isotope-filters">
      <button data-filter="" class="active">All</button>
      <button data-filter=".photography">photography</button>
      <button data-filter=".illustration">illustration</button>
      <button data-filter=".branding">branding</button>
      <button data-filter=".web-design">web-design</button>
 </div> 
 <div class="isotope popup-gallery columns-3">
    <div class="grid-item photography illustration">
      <div class="portfolio-item-2">
         <img src="images/portfolio/small/01.jpg" alt="">
           <div class="portfolio-hover">
              <div class="hover-name">
                <span> With some description</span>
                <a href="#">PHOTO ITEM</a>
              </div>
              <div class="hover-icon">
              <a class="portfolio-img" href="images/portfolio/small/01.jpg"><i class="fa fa-arrows-alt"></i></a>
              </div>
           </div> 
       </div>
    </div>
    <div class="grid-item photography">
      <div class="portfolio-item-2">
         <img src="images/portfolio/small/02.jpg" alt="">
            <div class="portfolio-hover">
              <div class="hover-name">
                <span> With some description</span>
                <a href="#">PHOTO ITEM</a>
              </div>
              <div class="hover-icon">
               <a class="portfolio-img" href="images/portfolio/small/02.jpg"><i class="fa fa-arrows-alt"></i></a>
              </div>
           </div>
       </div>
    </div>
     <div class="grid-item photography branding">
      <div class="portfolio-item-2">
         <img src="images/portfolio/small/03.jpg" alt="">
            <div class="portfolio-hover">
              <div class="hover-name">
                <span> With some description</span>
                <a href="#">PHOTO ITEM</a>
              </div>
              <div class="hover-icon">
               <a class="portfolio-img" href="images/portfolio/small/03.jpg"><i class="fa fa-arrows-alt"></i></a>
              </div>
           </div>
       </div>
    </div>
    <div class="grid-item web-design">
      <div class="portfolio-item-2">
         <img src="images/portfolio/small/04.gif" alt="">
            <div class="portfolio-hover">
              <div class="hover-name">
                <span> With some description</span>
                <a href="#">PHOTO ITEM</a>
              </div>
              <div class="hover-icon">
               <a class="portfolio-img" href="images/portfolio/small/04.gif"><i class="fa fa-arrows-alt"></i></a>
              </div>
           </div>
       </div>
    </div>
    <div class="grid-item photography illustration">
      <div class="portfolio-item-2">
         <img src="images/portfolio/small/05.jpg" alt="">
            <div class="portfolio-hover">
              <div class="hover-name">
                <span> With some description</span>
                <a href="#">PHOTO ITEM</a>
              </div>
              <div class="hover-icon">
               <a class="portfolio-img" href="images/portfolio/small/05.jpg"><i class="fa fa-arrows-alt"></i></a>
              </div>
           </div>
       </div>
    </div>
    <div class="grid-item photography">
      <div class="portfolio-item-2">
         <img src="images/portfolio/small/06.jpg" alt="">
            <div class="portfolio-hover">
              <div class="hover-name">
                <span> With some description</span>
                <a href="#">PHOTO ITEM</a>
              </div>
              <div class="hover-icon">
               <a class="portfolio-img" href="images/portfolio/small/06.jpg"><i class="fa fa-arrows-alt"></i></a>
              </div>
           </div>
       </div>
    </div>
    <div class="grid-item">
      <div class="portfolio-item-2">
         <img src="images/portfolio/small/07.jpg" alt="">
            <div class="portfolio-hover">
              <div class="hover-name">
                <span> With some description</span>
                <a href="#">PHOTO ITEM</a>
              </div>
              <div class="hover-icon">
               <a class="portfolio-img" href="images/portfolio/small/07.jpg"><i class="fa fa-arrows-alt"></i></a>
              </div>
           </div>
       </div>
    </div>
      <div class="grid-item photography branding">
      <div class="portfolio-item-2">
         <img src="images/portfolio/small/08.gif" alt="">
         <div class="portfolio-hover">
              <div class="hover-name">
                <span> With some description</span>
                <a href="#">PHOTO ITEM</a>
              </div>
              <div class="hover-icon">
               <a class="portfolio-img" href="images/portfolio/small/08.gif"><i class="fa fa-arrows-alt"></i></a>
              </div>
           </div>
       </div>
    </div>
     <div class="grid-item illustration">
      <div class="portfolio-item-2">
         <img src="images/portfolio/small/09.jpg" alt="">
         <div class="portfolio-hover">
              <div class="hover-name">
                <span> With some description</span>
                <a href="#">PHOTO ITEM</a>
              </div>
              <div class="hover-icon">
               <a class="portfolio-img" href="images/portfolio/small/09.jpg"><i class="fa fa-arrows-alt"></i></a>
              </div>
           </div>
       </div>
     </div>
    </div>
    <div class="row">
      <div class="col-lg-12 col-md-12 text-center mt-30">
          <a href="#" class="button icon">View all projects <i class="fa fa-angle-right"></i></a>
      </div>
    </div>
   </div>
 </section>

<!--=================================
 portfolio -->
 

  <!--=================================
 Our Blog -->

<section id="blog" class="our-blog gray-bg page-section-ptb">
  <div class="container">
    <div class="row">
     <div class="col-lg-12 col-md-12">
         <div class="section-title text-center">
            <h6>Fresh Webster News</h6>
            <h2 class="title-effect">Latest Articles</h2>
          </div>
       </div>
    </div>
   <div class="row">
     <div class="col-lg-4 col-md-4 col-sm-4">
        <div class="blog-box blog-2">        
        <img class="img-responsive" src="images/about/01.jpg" alt="">
         <div class="blog-info">
          <span class="post-category"><a href="#">Business</a></span>
          <h4> <a href="#"> Does your life lack meaning</a></h4>
          <p>I truly believe Augustine’s words are true.</p>
          <span><i class="fa fa-calendar-check-o"></i> 21 April 2016 </span>
          <a class="button icon-color" href="#">Read More<i class="fa fa-angle-right"></i></a>
          </div>            
     
        </div>
        </div>
     <div class="col-lg-4 col-md-4 col-sm-4">
        <div class="blog-box blog-2 active">        
        <img class="img-responsive" src="images/about/02.jpg" alt="">
         <div class="blog-info">
          <span class="post-category"><a href="#">Business</a></span>
          <h4> <a href="#"> Supercharge your motivation</a></h4>          
          <p>We also know those epic stories, those modern-day.</p>
          <span><i class="fa fa-calendar-check-o"></i> 21 April 2016 </span>
          <a class="button icon-color" href="#">Read More<i class="fa fa-angle-right"></i></a>
          </div>  
        </div>
        </div>
     <div class="col-lg-4 col-md-4 col-sm-4">
        <div class="blog-box blog-2">
          <img class="img-responsive" src="images/about/03.jpg" alt="">
          <div class="blog-info">
           <span class="post-category"><a href="#">Business</a></span>
          <h4> <a href="#">  Helen keller a teller & a seller </a></h4>         
          <p>I truly believe Augustine’s words are true.</p>
          <span><i class="fa fa-calendar-check-o"></i> 21 April 2016 </span>
          <a class="button icon-color" href="#">Read More<i class="fa fa-angle-right"></i></a>
          </div>
        </div>
      </div>
     </div>
    </div>
 </section>

 <!--=================================
 Our Blog -->

 <!--=================================
contact  -->

<section id="contact-us" class="white-bg contact-3 clearfix o-hidden">
   <!-- =============================== -->
   <div class="container-fluid pos-r">
    <div class="row row-eq-height full-height">
    <div class="col-lg-6 col-md-6 map-side g-map" id="map" data-type='black'>
       <div class="contact-map">
     </div>       
    </div>
   </div>
  </div>
  <div class="container">
  <div class="row">
      <div class="col-lg-5 col-md-5 col-md-offset-7"> 
      <div class="contact-3-info page-section-ptb">
       <div class="clearfix">
          <div class="section-title mb-0">
           <h6>let's work together </h6>
           <h2 class="title-effect">Let’s Get In Touch!</h2>
          </div> 
           <p class="mb-50">It would be great to hear from you! If you got any questions, please do not hesitate to send us a message. We are looking forward to hearing from you! We reply within <span class="tooltip-content-2" data-original-title="Mon-Fri 10am–7pm (GMT +1)" data-toggle="tooltip" data-placement="top"> 24 hours!</span></p>
            <div id="formmessage">Success/Error Message Goes Here</div>
             <form class="form-horizontal" id="contactform" role="form" method="post" action="php/contact-form.php">
               <div class="contact-form clearfix">
                  <div class="section-field">
                    <input id="name" type="text" placeholder="Name*" class="form-control"  name="name">
                   </div> 
                   <div class="section-field">
                      <input type="email" placeholder="Email*" class="form-control" name="email">
                    </div>
                   <div class="section-field">
                      <input type="text" placeholder="Phone*" class="form-control" name="phone">
                    </div>
                   <div class="section-field textarea">
                     <textarea class="input-message form-control" placeholder="Comment*"  rows="7" name="message"></textarea>
                    </div>
                    <!-- Google reCaptch-->
                    <div class="g-recaptcha section-field clearfix" data-sitekey="[Add your site key]"></div>
                    <input type="hidden" name="action" value="sendEmail"/>
                     <button id="submit" name="submit" type="submit" value="Send" class="button"><span> Send message </span> <i class="fa fa-paper-plane"></i></button>
                    </div> 
                  </form>
                 <div id="ajaxloader" style="display:none"><img class="center-block mt-30 mb-30" src="images/pre-loader/loader-02.svg" alt=""></div>
              </div>          
         </div>
    </div>
    </div>
    </div>
</section>

<!--=================================
 contact -->


<!--=================================
action box- -->

<section class="action-box theme-bg full-width">
  <div class="container">
    <div class="row">
     <div class="col-lg-12 col-md-12">
        <h3><strong> Webster: </strong> The most powerful template ever on the market</h3>
        <p>Create tailor-cut websites with the exclusive multi-purpose responsive template along with powerful features.</p>
        <a class="button border white" href="#">
          <span>Purchase Now</span>
          <i class="fa fa-download"></i>
       </a> 
    </div>
  </div>
 </div>
</section>
 
<!--=================================
action box- -->
 
 
<!--=================================
 footer -->
 
<footer class="footer footer-one-page page-section-pt black-bg">
 <div class="container">
  <div class="row text-center">
   <div class="col-lg-4 col-md-4">
      <div class="contact-add mb-30"> 
       <div class="text-center">
           <i class="ti-map-alt text-white"></i>
           <h5 class="mt-15">Address</h5>
           <p>17504 Carlton Cuevas Rd, Gulfport, MS, 3950</p>
          </div>
      </div>
   </div>
   <div class="col-lg-4 col-md-4">
      <div class="contact-add mb-30"> 
       <div class="text-center">
         <i class="ti-mobile text-white"></i>
         <h5 class="mt-15">Call Us</h5>
         <p>+(704) 279-1249</p>
        </div>
      </div>
   </div>
   <div class="col-lg-4 col-md-4">
      <div class="contact-add mb-30"> 
        <div class="text-center">
         <i class="ti-email text-white"></i>
         <h5 class="mt-15">Email Us</h5>
         <p>letstalk@webster.com</p>
       </div>
      </div>
   </div>
   </div>
    <div class="row">
    <div class="col-md-offset-4 col-md-4">
       <div class="footer-Newsletter text-center mt-30 mb-40">
          <div id="mc_embed_signup_scroll">
            <form action="php/mailchimp-action.php" method="POST" id="mc-embedded-subscribe-form" name="mc-embedded-subscribe-form" class="validate">
             <div id="msg"> </div>                 
              <div id="mc_embed_signup_scroll_2">
                <input id="mce-EMAIL" class="form-control" type="text" placeholder="Email address" name="email1" value="">
              </div>
              <div id="mce-responses" class="clear">
                <div class="response" id="mce-error-response" style="display:none"></div>
                <div class="response" id="mce-success-response" style="display:none"></div>
                </div>    <!-- real people should not fill this in and expect good things - do not remove this or risk form bot signups-->
                <div style="position: absolute; left: -5000px;" aria-hidden="true">
                    <input type="text" name="b_b7ef45306f8b17781aa5ae58a_6b09f39a55" tabindex="-1" value="">
                </div>
                <div class="clear">
                  <button type="submit" name="submitbtn" id="mc-embedded-subscribe" class="button border mt-20 form-button">  Get notified </button>
                </div>
              </form>
            </div>
            </div>
     </div>
    </div>
   <div class="footer-widget mt-20">
    <div class="row">
      <div class="col-lg-6 col-md-6 col-sm-6">
      <p class="mt-15">&copy;Copyright <span id="copyright"> <script>document.getElementById('copyright').appendChild(document.createTextNode(new Date().getFullYear()))</script></span> <a href="#"> Webster </a> All Rights Reserved</p>
      </div>
      <div class="col-lg-6 col-md-6 col-sm-6 ">
        <div class="footer-widget-social text-right">
         <ul> 
          <li><a href="#"><i class="fa fa-facebook"></i></a></li>
          <li><a href="#"><i class="fa fa-twitter"></i></a></li>
          <li><a href="#"><i class="fa fa-dribbble"></i> </a></li>
          <li><a href="#"><i class="fa fa-linkedin"></i> </a></li>
         </ul>
       </div>
      </div>
    </div>    
  </div>
  </div>
</footer>

<!--=================================
 footer -->
 
 </div>

  --%>

<div id="back-to-top"><a class="top arrow" href="#top"><i class="fa fa-angle-up"></i> <span>TOP</span></a></div> 
 
</asp:Content>


