<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageonline_user.master" AutoEventWireup="true" CodeFile="User_Dashboard.aspx.cs" Inherits="online_user_User_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function lol() {
            window.location.href = "set_session_user.aspx";
        }
        $(window).load(function () {
            var serverDateTime = $("#<%= hidden1.ClientID %>").val();
            if (serverDateTime == "Y") {
                $('#myModal1').modal('show');
            }
            else {
                $('#myModal1').modal('hide');
            }
        });

        function order() {
            window.location.href = "order_medicine";
        }
        function labmix() {
            window.location.href = "how_it_is_made";
        }
        function earth() {
            window.location.href = "why_meditation";
        }
    </script>
    <style type="text/css">
        .tiledBackground {
            width: 100%;
            height: 150%;
            padding-top: 500px;
        }

        .Star {
            background-image: url(images/Star.gif);
            height: 17px;
            width: 17px;
        }

        .WaitingStar {
            background-image: url(images/WaitingStar.gif);
            height: 17px;
            width: 17px;
        }

        .FilledStar {
            background-image: url(images/FilledStar.gif);
            height: 17px;
            width: 17px;
        }

        textarea {
            resize: none;
        }

        .lol {
            resize: none;
        }

        .form_error {
            font: arial black,arial,verdana,helvetica !important;
            color: red !important;
        }

        .infoma {
            font: arial black,arial,verdana,helvetica !important;
            color: black !important;
        }

        hr {
            border: 0;
            width: 100%;
            background-color: #20B2AA;
            height: 2px;
        }

        .pad {
            padding-left: 50px;
        }

        .llol {
            border-radius: 50%;
        }

        .product.left .product-image {
            width: 05%;
        }
    </style>

    <asp:HiddenField runat="server" ID="hidden1" />
    <section class="rev-slider" style="padding-top: 43px;">
        <div id="rev_slider_6_1_wrapper" class="rev_slider_wrapper fullwidthbanner-container" data-alias="slider-medicine" data-source="gallery" style="margin: 0px auto; background: transparent; padding: 0px; margin-top: 0px; margin-bottom: 0px;">
            <!-- START REVOLUTION SLIDER 5.4.5.2 fullwidth mode -->
            <div id="rev_slider_6_1" class="rev_slider fullwidthabanner" style="display: none;" data-version="5.4.5.2">
                <ul>
                    <!-- SLIDE  -->
                    <li data-index="rs-13" data-transition="fade" data-slotamount="default" data-hideafterloop="0" data-hideslideonmobile="off" data-easein="default" data-easeout="default" data-masterspeed="300" data-thumb="../revolution/assets/medical_img3.jpg" data-rotate="0" data-saveperformance="off" data-title="Slide" data-param1="" data-param2="" data-param3="" data-param4="" data-param5="" data-param6="" data-param7="" data-param8="" data-param9="" data-param10="" data-description="">
                        <!-- MAIN IMAGE -->
                        <%--<img src="../revolution/assets/medical_img4.png" alt="" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" class="rev-slidebg" data-no-retina>--%>
                        <img src="../revolution/assets/medical_img3.jpg" alt="" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" class="rev-slidebg" data-no-retina>


                        <!-- LAYERS -->
                        <!-- LAYER NR. 1 -->
                        <div class="tp-caption   tp-resizeme"
                            id="slide-13-layer-1"
                            data-x="395"
                            data-y="323"
                            data-width="['auto']"
                            data-height="['auto']"
                            data-type="text"
                            data-responsive_offset="on"
                            data-frames='[{"delay":300,"speed":2000,"frame":"0","from":"x:[-100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;","mask":"x:0px;y:0px;s:inherit;e:inherit;","to":"o:1;","ease":"Power3.easeInOut"},{"delay":"wait","speed":300,"frame":"999","to":"opacity:0;","ease":"Power3.easeInOut"}]'
                            data-textalign="['inherit','inherit','inherit','inherit']"
                            data-paddingtop="[0,0,0,0]"
                            data-paddingright="[0,0,0,0]"
                            data-paddingbottom="[0,0,0,0]"
                            data-paddingleft="[0,0,0,0]"
                            style="z-index: 5; white-space: nowrap; font-size: 90px; line-height: 90px; font-weight: 600; color: white; letter-spacing: 0px; font-family: Montserrat;">
                            <%--  We Care --%>
                        </div>
                        <!-- LAYER NR. 2 -->
                        <div class="tp-caption   tp-resizeme  rev-color"
                            id="slide-13-layer-2"
                            data-x="395"
                            data-y="400"
                            data-width="['auto']"
                            data-height="['auto']"
                            data-type="text"
                            data-responsive_offset="on"
                            data-frames='[{"delay":1340,"speed":2000,"frame":"0","from":"x:[100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;","mask":"x:0px;y:0px;s:inherit;e:inherit;","to":"o:1;","ease":"Power3.easeInOut"},{"delay":"wait","speed":300,"frame":"999","to":"opacity:0;","ease":"Power3.easeInOut"}]'
                            data-textalign="['inherit','inherit','inherit','inherit']"
                            data-paddingtop="[0,0,0,0]"
                            data-paddingright="[0,0,0,0]"
                            data-paddingbottom="[0,0,0,0]"
                            data-paddingleft="[0,0,0,0]"
                            style="z-index: 6; white-space: nowrap; font-size: 90px; line-height: 90px; font-weight: 600; color: #20B2AA; letter-spacing: 0px; font-family: Montserrat;">
                            Learn From Within
                        </div>
                        <!-- LAYER NR. 3 -->
                        <div class="tp-caption   tp-resizeme"
                            id="slide-13-layer-3"
                            data-x="395"
                            data-y="503"
                            data-width="['auto']"
                            data-height="['auto']"
                            data-type="text"
                            data-responsive_offset="on"
                            data-frames='[{"delay":3240,"speed":2000,"frame":"0","from":"z:0;rX:0;rY:0;rZ:0;sX:0.9;sY:0.9;skX:0;skY:0;opacity:0;","to":"o:1;","ease":"Power2.easeOut"},{"delay":"wait","speed":300,"frame":"999","to":"opacity:0;","ease":"Power3.easeInOut"}]'
                            data-textalign="['inherit','inherit','inherit','inherit']"
                            data-paddingtop="[0,0,0,0]"
                            data-paddingright="[0,0,0,0]"
                            data-paddingbottom="[0,0,0,0]"
                            data-paddingleft="[0,0,0,0]"
                            style="z-index: 7; white-space: nowrap; font-size: 36px; line-height: 36px; font-weight: 400; color: #323232; letter-spacing: 0px; font-family: Montserrat;">
                            <%-- Entrust Your Health Our Doctors--%>
                        </div>
                        <!-- LAYER NR. 4 -->

                    </li>
                    <!-- SLIDE  -->
                    <li data-index="rs-15" data-transition="fade" data-slotamount="default" data-hideafterloop="0" data-hideslideonmobile="off" data-easein="default" data-easeout="default" data-masterspeed="300" data-thumb="../revolution/assets/medical_img3.jpg" data-rotate="0" data-saveperformance="off" data-title="Slide" data-param1="" data-param2="" data-param3="" data-param4="" data-param5="" data-param6="" data-param7="" data-param8="" data-param9="" data-param10="" data-description="">
                        <!-- MAIN IMAGE -->
                        <img src="../revolution/assets/medical_img3.jpg" alt="" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" class="rev-slidebg" data-no-retina>
                        <!-- LAYERS -->
                        <!-- LAYER NR. 5 -->
                        <div class="tp-caption   tp-resizeme"
                            id="slide-15-layer-1"
                            data-x="right" data-hoffset="371"
                            data-y="323"
                            data-width="['auto']"
                            data-height="['auto']"
                            data-type="text"
                            data-responsive_offset="on"
                            data-frames='[{"delay":300,"speed":2000,"frame":"0","from":"y:-50px;opacity:0;","to":"o:1;","ease":"Power2.easeInOut"},{"delay":"wait","speed":300,"frame":"999","to":"opacity:0;","ease":"Power3.easeInOut"}]'
                            data-textalign="['inherit','inherit','inherit','inherit']"
                            data-paddingtop="[0,0,0,0]"
                            data-paddingright="[0,0,0,0]"
                            data-paddingbottom="[0,0,0,0]"
                            data-paddingleft="[0,0,0,0]"
                            style="z-index: 5; white-space: nowrap; font-size: 90px; line-height: 90px; font-weight: 600; color: #323232; letter-spacing: 0px; font-family: Montserrat; text-transform: capitalize;">
                            Good Education is a Foundation
                        </div>
                        <!-- LAYER NR. 6 -->
                        <div class="tp-caption   tp-resizeme  rev-color"
                            id="slide-15-layer-2"
                            data-x="right" data-hoffset="370"
                            data-y="419"
                            data-width="['auto']"
                            data-height="['auto']"
                            data-type="text"
                            data-responsive_offset="on"
                            data-frames='[{"delay":1340,"speed":1500,"frame":"0","from":"x:[-100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;","mask":"x:0px;y:0px;s:inherit;e:inherit;","to":"o:1;","ease":"Power3.easeInOut"},{"delay":"wait","speed":300,"frame":"999","to":"opacity:0;","ease":"Power3.easeInOut"}]'
                            data-textalign="['inherit','inherit','inherit','inherit']"
                            data-paddingtop="[0,0,0,0]"
                            data-paddingright="[0,0,0,0]"
                            data-paddingbottom="[0,0,0,0]"
                            data-paddingleft="[0,0,0,0]"
                            style="z-index: 6; white-space: nowrap; font-size: 90px; line-height: 90px; font-weight: 600; color: #0058cc; letter-spacing: 0px; font-family: Montserrat;">
                            For A Better Future
                        </div>
                        <!-- LAYER NR. 7 -->
                        <div class="tp-caption   tp-resizeme"
                            id="slide-15-layer-3"
                            data-x="right" data-hoffset="370"
                            data-y="515"
                            data-width="['auto']"
                            data-height="['auto']"
                            data-type="text"
                            data-responsive_offset="on"
                            data-frames='[{"delay":3240,"speed":2000,"frame":"0","from":"x:200px;skX:-85px;opacity:0;","to":"o:1;","ease":"Power2.easeOut"},{"delay":"wait","speed":300,"frame":"999","to":"opacity:0;","ease":"Power3.easeInOut"}]'
                            data-textalign="['inherit','inherit','inherit','inherit']"
                            data-paddingtop="[0,0,0,0]"
                            data-paddingright="[0,0,0,0]"
                            data-paddingbottom="[0,0,0,0]"
                            data-paddingleft="[0,0,0,0]"
                            style="z-index: 7; white-space: nowrap; font-size: 36px; line-height: 36px; font-weight: 400; color: #323232; letter-spacing: 0px; font-family: Montserrat;">
                            <%-- Entrust your health our doctors--%>
                        </div>
                        <!-- LAYER NR. 8 -->

                    </li>

                    <li style="cursor: pointer;" onclick="order();" data-index="rs-16" data-transition="fade" data-slotamount="default" data-hideafterloop="0" data-hideslideonmobile="off" data-easein="default" data-easeout="default" data-masterspeed="300" data-thumb="../revolution/assets/Book-with-light-AdobeStock_100291262-780x405.jpeg" data-rotate="0" data-saveperformance="off" data-title="Slide" data-param1="" data-param2="" data-param3="" data-param4="" data-param5="" data-param6="" data-param7="" data-param8="" data-param9="" data-param10="" data-description="">
                        <!-- MAIN IMAGE -->
                        <img src="../revolution/assets/Book-with-light-AdobeStock_100291262-780x405.jpeg" alt="" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" class="rev-slidebg" data-no-retina>
                        <!-- LAYERS -->
                        <!-- LAYER NR. 5 -->
                        <div class="tp-caption   tp-resizeme"
                            id="slide-16-layer-1"
                            data-x="right" data-hoffset="371"
                            data-y="323"
                            data-width="['auto']"
                            data-height="['auto']"
                            data-type="text"
                            data-responsive_offset="on"
                            data-frames='[{"delay":300,"speed":2000,"frame":"0","from":"y:-50px;opacity:0;","to":"o:1;","ease":"Power2.easeInOut"},{"delay":"wait","speed":300,"frame":"999","to":"opacity:0;","ease":"Power3.easeInOut"}]'
                            data-textalign="['inherit','inherit','inherit','inherit']"
                            data-paddingtop="[0,0,0,0]"
                            data-paddingright="[0,0,0,0]"
                            data-paddingbottom="[0,0,0,0]"
                            data-paddingleft="[0,0,0,0]"
                            style="z-index: 5; height: 120%; white-space: nowrap; font-size: 90px; line-height: 90px; font-weight: 600; color: #323232; letter-spacing: 0px; font-family: Montserrat; text-transform: capitalize;">
                            An Investment In Knowledge 
                        </div>
                        <!-- LAYER NR. 6 -->
                        <div class="tp-caption   tp-resizeme  rev-color"
                            id="slide-16-layer-2"
                            data-x="right" data-hoffset="370"
                            data-y="419"
                            data-width="['auto']"
                            data-height="['auto']"
                            data-type="text"
                            data-responsive_offset="on"
                            data-frames='[{"delay":1340,"speed":1500,"frame":"0","from":"x:[-100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;","mask":"x:0px;y:0px;s:inherit;e:inherit;","to":"o:1;","ease":"Power3.easeInOut"},{"delay":"wait","speed":300,"frame":"999","to":"opacity:0;","ease":"Power3.easeInOut"}]'
                            data-textalign="['inherit','inherit','inherit','inherit']"
                            data-paddingtop="[0,0,0,0]"
                            data-paddingright="[0,0,0,0]"
                            data-paddingbottom="[0,0,0,0]"
                            data-paddingleft="[0,0,0,0]"
                            style="z-index: 6; white-space: nowrap; font-size: 90px; line-height: 90px; font-weight: 600; color: #0058cc; letter-spacing: 0px; font-family: Montserrat;">
                           Pays The Best Interest
                        </div>
                        <!-- LAYER NR. 7 -->
                        <div class="tp-caption   tp-resizeme"
                            id="slide-16-layer-3"
                            data-x="right" data-hoffset="370"
                            data-y="515"
                            data-width="['auto']"
                            data-height="['auto']"
                            data-type="text"
                            data-responsive_offset="on"
                            data-frames='[{"delay":3240,"speed":2000,"frame":"0","from":"x:200px;skX:-85px;opacity:0;","to":"o:1;","ease":"Power2.easeOut"},{"delay":"wait","speed":300,"frame":"999","to":"opacity:0;","ease":"Power3.easeInOut"}]'
                            data-textalign="['inherit','inherit','inherit','inherit']"
                            data-paddingtop="[0,0,0,0]"
                            data-paddingright="[0,0,0,0]"
                            data-paddingbottom="[0,0,0,0]"
                            data-paddingleft="[0,0,0,0]"
                            style="z-index: 7; white-space: nowrap; font-size: 36px; line-height: 36px; font-weight: 400; color: #323232; letter-spacing: 0px; font-family: Montserrat;">
                        </div>
                        <!-- LAYER NR. 8 -->

                    </li>
                          <li style="cursor: pointer;" onclick="labmix();" data-index="rs-17" data-transition="fade" data-slotamount="default" data-hideafterloop="0" data-hideslideonmobile="off" data-easein="default" data-easeout="default" data-masterspeed="300" data-thumb="../revolution/assets/labmix.jpg" data-rotate="0" data-saveperformance="off" data-title="Slide" data-param1="" data-param2="" data-param3="" data-param4="" data-param5="" data-param6="" data-param7="" data-param8="" data-param9="" data-param10="" data-description="">
                        <!-- MAIN IMAGE -->
                        <img src="../revolution/assets/books_fire_weigel-678x380.jpg" alt="" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" class="rev-slidebg" data-no-retina>
                        <!-- LAYERS -->
                        <!-- LAYER NR. 5 -->
                        <div class="tp-caption   tp-resizeme"
                            id="slide-17-layer-1"
                            data-x="right" data-hoffset="371"
                            data-y="323"
                            data-width="['auto']"
                            data-height="['auto']"
                            data-type="text"
                            data-responsive_offset="on"
                            data-frames='[{"delay":300,"speed":2000,"frame":"0","from":"y:-50px;opacity:0;","to":"o:1;","ease":"Power2.easeInOut"},{"delay":"wait","speed":300,"frame":"999","to":"opacity:0;","ease":"Power3.easeInOut"}]'
                            data-textalign="['inherit','inherit','inherit','inherit']"
                            data-paddingtop="[0,0,0,0]"
                            data-paddingright="[0,0,0,0]"
                            data-paddingbottom="[0,0,0,0]"
                            data-paddingleft="[0,0,0,0]"
                            style="z-index: 5; height: 120%; white-space: nowrap; font-size: 90px; line-height: 90px; font-weight: 600; color: #323232; letter-spacing: 0px; font-family: Montserrat; text-transform: capitalize;">
                           They Know Enough 
                        </div>
                        <!-- LAYER NR. 6 -->
                        <div class="tp-caption   tp-resizeme  rev-color"
                            id="slide-17-layer-2"
                            data-x="right" data-hoffset="370"
                            data-y="419"
                            data-width="['auto']"
                            data-height="['auto']"
                            data-type="text"
                            data-responsive_offset="on"
                            data-frames='[{"delay":1340,"speed":1500,"frame":"0","from":"x:[-100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;","mask":"x:0px;y:0px;s:inherit;e:inherit;","to":"o:1;","ease":"Power3.easeInOut"},{"delay":"wait","speed":300,"frame":"999","to":"opacity:0;","ease":"Power3.easeInOut"}]'
                            data-textalign="['inherit','inherit','inherit','inherit']"
                            data-paddingtop="[0,0,0,0]"
                            data-paddingright="[0,0,0,0]"
                            data-paddingbottom="[0,0,0,0]"
                            data-paddingleft="[0,0,0,0]"
                            style="z-index: 6; white-space: nowrap; font-size: 90px; line-height: 90px; font-weight: 600; color: #0058cc; letter-spacing: 0px; font-family: Montserrat;">
                           Who Know How To Learn
                        </div>
                        <!-- LAYER NR. 7 -->
                        <div class="tp-caption   tp-resizeme"
                            id="slide-17-layer-3"
                            data-x="right" data-hoffset="370"
                            data-y="515"
                            data-width="['auto']"
                            data-height="['auto']"
                            data-type="text"
                            data-responsive_offset="on"
                            data-frames='[{"delay":3240,"speed":2000,"frame":"0","from":"x:200px;skX:-85px;opacity:0;","to":"o:1;","ease":"Power2.easeOut"},{"delay":"wait","speed":300,"frame":"999","to":"opacity:0;","ease":"Power3.easeInOut"}]'
                            data-textalign="['inherit','inherit','inherit','inherit']"
                            data-paddingtop="[0,0,0,0]"
                            data-paddingright="[0,0,0,0]"
                            data-paddingbottom="[0,0,0,0]"
                            data-paddingleft="[0,0,0,0]"
                            style="z-index: 7; white-space: nowrap; font-size: 36px; line-height: 36px; font-weight: 400; color: #323232; letter-spacing: 0px; font-family: Montserrat;">
                        </div>
                        <!-- LAYER NR. 8 -->

                    </li>
                              <li style="cursor: pointer;" onclick="earth();" data-index="rs-18" data-transition="fade" data-slotamount="default" data-hideafterloop="0" data-hideslideonmobile="off" data-easein="default" data-easeout="default" data-masterspeed="300" data-thumb="../revolution/assets/yoga1.jpg" data-rotate="0" data-saveperformance="off" data-title="Slide" data-param1="" data-param2="" data-param3="" data-param4="" data-param5="" data-param6="" data-param7="" data-param8="" data-param9="" data-param10="" data-description="">
                        <!-- MAIN IMAGE -->
                        <img src="../revolution/assets/GettyImages-698733848-1600x1067.jpg" alt="" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" class="rev-slidebg" data-no-retina>
                        <!-- LAYERS -->
                        <!-- LAYER NR. 5 -->
                        <div class="tp-caption   tp-resizeme"
                            id="slide-18-layer-1"
                            data-x="right" data-hoffset="371"
                            data-y="323"
                            data-width="['auto']"
                            data-height="['auto']"
                            data-type="text"
                            data-responsive_offset="on"
                            data-frames='[{"delay":300,"speed":2000,"frame":"0","from":"y:-50px;opacity:0;","to":"o:1;","ease":"Power2.easeInOut"},{"delay":"wait","speed":300,"frame":"999","to":"opacity:0;","ease":"Power3.easeInOut"}]'
                            data-textalign="['inherit','inherit','inherit','inherit']"
                            data-paddingtop="[0,0,0,0]"
                            data-paddingright="[0,0,0,0]"
                            data-paddingbottom="[0,0,0,0]"
                            data-paddingleft="[0,0,0,0]"
                            style="z-index: 5; height: 120%; white-space: nowrap; font-size: 90px; line-height: 90px; font-weight: 600; color: #323232; letter-spacing: 0px; font-family: Montserrat; text-transform: capitalize;">
                        Learning Is Not Compulsory
                        </div>
                        <!-- LAYER NR. 6 -->
                        <div class="tp-caption   tp-resizeme  rev-color"
                            id="slide-18-layer-2"
                            data-x="right" data-hoffset="370"
                            data-y="419"
                            data-width="['auto']"
                            data-height="['auto']"
                            data-type="text"
                            data-responsive_offset="on"
                            data-frames='[{"delay":1340,"speed":1500,"frame":"0","from":"x:[-100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;","mask":"x:0px;y:0px;s:inherit;e:inherit;","to":"o:1;","ease":"Power3.easeInOut"},{"delay":"wait","speed":300,"frame":"999","to":"opacity:0;","ease":"Power3.easeInOut"}]'
                            data-textalign="['inherit','inherit','inherit','inherit']"
                            data-paddingtop="[0,0,0,0]"
                            data-paddingright="[0,0,0,0]"
                            data-paddingbottom="[0,0,0,0]"
                            data-paddingleft="[0,0,0,0]"
                            style="z-index: 6; white-space: nowrap; font-size: 90px; line-height: 90px; font-weight: 600; color: #0058cc; letter-spacing: 0px; font-family: Montserrat;">
                           Neither Is Survival
                        </div>
                        <!-- LAYER NR. 7 -->
                        <div class="tp-caption   tp-resizeme"
                            id="slide-18-layer-3"
                            data-x="right" data-hoffset="370"
                            data-y="515"
                            data-width="['auto']"
                            data-height="['auto']"
                            data-type="text"
                            data-responsive_offset="on"
                            data-frames='[{"delay":3240,"speed":2000,"frame":"0","from":"x:200px;skX:-85px;opacity:0;","to":"o:1;","ease":"Power2.easeOut"},{"delay":"wait","speed":300,"frame":"999","to":"opacity:0;","ease":"Power3.easeInOut"}]'
                            data-textalign="['inherit','inherit','inherit','inherit']"
                            data-paddingtop="[0,0,0,0]"
                            data-paddingright="[0,0,0,0]"
                            data-paddingbottom="[0,0,0,0]"
                            data-paddingleft="[0,0,0,0]"
                            style="z-index: 7; white-space: nowrap; font-size: 36px; line-height: 36px; font-weight: 400; color: #323232; letter-spacing: 0px; font-family: Montserrat;">
                        </div>
                        <!-- LAYER NR. 8 -->

                    </li>
                </ul>
                <div class="tp-bannertimer tp-bottom" style="visibility: hidden !important;"></div>
            </div>
        </div>
    </section>
    <hr />
   <%-- <section class="page-section-ptb " style="padding-bottom: 120px; padding-top: 100px; background: url(../images/pattern/pattern-bg.png) repeat;">
        <div class="container" style="padding-bottom: 150px; width: 80%;">
            <div class="row" style="padding-top: 40px;">
                <div class="col-lg-12 col-md-12">
                    <div class="section-title text-center">
                        <h1 class="title-effect">What We Offer</h1>
                    </div>
                </div>
            </div>

            <div class="row" style="padding-top: 50px;">
                <div class="col-lg-4 col-md-4 col-sm-6 sm-mb-30">
                    <div class="team team-hover">
                        <div class="team-photo">
                            <img class="img-responsive center-block" src="../images/homepage/cell salt.png" style="height: 250px; width: 250px;" alt="">
                        </div>
                        <div class="team-description">
                            <div class="team-contact">
                                <a href="know_my_cell_salts"><span class="call">
                                    <h4 style="color: #20B2AA;"><b>Cell Salt Finder</b></h4>
                                </span></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-6 sm-mb-30">
                    <div class="team team-hover">
                        <div class="team-photo">
                            <img class="img-responsive center-block" src="../images/homepage/consult online.jpg" alt="" style="height: 250px; width: 250px;">
                        </div>
                        <div class="team-description">
                            <div class="team-contact">
                                <a href="Consult_online_new"><span class="call">
                                    <h4 style="color: #20B2AA;"><b>Consult With Homeopath</b></h4>
                                </span></a>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-6">
                    <div class="team team-hover">
                        <div class="team-photo">
                            <img class="img-responsive center-block" src="../images/homepage/all about.png" alt="" style="height: 250px; width: 250px;">
                        </div>
                        <div class="team-description">
                            <div class="team-contact">
                                <a href="cell_salt"><span class="call">
                                    <h4 style="color: #20B2AA;"><b>Know all about Cell Salts </b></h4>
                                </span></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="padding-top: 60px;">
                <div class="col-lg-6 col-md-6 col-sm-6 sm-mb-30">
                    <div class="team team-hover">
                        <div class="team-photo">
                            <img class="img-responsive center-block" src="../images/homepage/angel.png" style="height: 250px; width: 250px;" alt="">
                        </div>
                        <div class="team-description">
                            <div class="team-contact">
                                <a href="Angelcardreading"><span class="call">
                                    <h4 style="color: #20B2AA;"><b>Angel card reading</b></h4>
                                </span></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6 sm-mb-30">
                    <div class="team team-hover">
                        <div class="team-photo">
                            <img class="img-responsive center-block" src="../images/homepage/meditation.png" alt="" style="height: 250px; width: 250px;">
                        </div>
                        <div class="team-description">
                            <div class="team-contact">
                                <a href="meditation4health"><span class="call">
                                    <h4 style="color: #20B2AA;"><b>Online Meditation classes</b></h4>
                                </span></a>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>--%>

   
    <section class="page-section-ptb " style="padding-bottom: 150px; padding-top: 100px; background: url(../images/pattern/pattern-bg.png) repeat;">
        <div class="container " style="padding-bottom: 100px; width: 80%;">
            <div class="row" style="padding-top: 40px;">
                <div class="col-lg-12 col-md-12">
                    <div class="section-title text-center">
                        <h2 class="title-effect">Reviews</h2>
                    </div>
                </div>
            </div>
            <div class="row" style="padding-top: 50px;">
                <div class="col-lg-12 col-md-12 col-sm-12 " style="height: 300px; overflow: auto;">
                    <asp:Literal runat="server" ID="Literal2"></asp:Literal>
                </div>
            </div>
        </div>
    </section>
    <%--   <section class="gray-bg page-section-ptb position-re">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-8">
                    <div class="section-title">
                        <h2 class="title-effect">Testimonial</h2>
                        <h4>What People Are Saying About Us</h4>
                        <h6><i>Don't just take if from us, let our customers do the talking!</i></h6>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 text-center">
                    <div class="isotope columns-2 popup-gallery">
                        <asp:Literal runat="server" ID="Literal1"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </section>--%>

    <%--<section id="raindrops" class="raindrops" style="height: 50px;"></section>--%>
    <!--=================================
page-title -->
    <section class="theme-bg pos-r page-section-ptb" style="height: 500px; background: url(../images/pattern/08.jpg) repeat;">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <div class="section-title" style="padding-top: 150px;">
                        <center>   <h1 style="color:gray; font-size:100px;"><strong>Learn It By Yourself  </strong></h1></center>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <div class="modal fade" id="myModal1" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header" style="background-color: #20B2AA;">
                    <button type="button" class="close" style="color: black;" data-dismiss="modal" onclick="lol();" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <div class="section-title mb-10">
                        <h2 style="text-align: center; color: #fff;">Profile Update </h2>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="text-center">
                        <h3><b>Please Update your profile First !</b></h3>
                    </div>
                </div>
                <div class="modal-footer">
                    <div style="padding-left: 230px;">
                        <button type="button" class="button large" data-dismiss="modal" onclick="lol();">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <section id="raindrops" class="raindrops" style="height: 50px;"></section>
    <section class="action-box theme-bg full-width">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <h3><strong>Disclaimer  </strong></h3>
                    <p>The Hogwarts Institute Website is for educational and informational purposes only.  Information contained in this website can and will change without notice.  The institute shall not be liable for any special, incidental, or consequential damages resulting from the use of this website.  
 
Every effort is made to assure that the most accurate and current information is posted on this site.  The institute does not guarantee this website is free from typographical errors or inadvertently inaccurate information.  
 
The institute makes no representations or warranties regarding the condition or functionality of this website, its suitability for use, or that this web service will be uninterrupted or error-free. </p>

                </div>
            </div>
        </div>
    </section>
</asp:Content>

