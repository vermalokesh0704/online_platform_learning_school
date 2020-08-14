<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageonline_user.master" AutoEventWireup="true" CodeFile="videos.aspx.cs" Inherits="online_user_videos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .pad_top {
            padding-top: 350px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("video").each(function () {
                $(this).attr('controlsList', 'nodownload');
                $(this).load();
            });
        });
    </script>
    <section class="page-title pad_top" data-jarallax='{"speed": 0.6}' data-jarallax-video="https://www.youtube.com/embed/-E5cole97r4?start=43">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="page-title-name">
                    <h1 style="color:#20B2AA;"><asp:Label runat="server" ID="class_name"></asp:Label></h1>
                </div>
            </div>
        </div>
    </div>
</section>
    <section class="masonry-main white-bg page-section-ptb">
    <div class="container">
        <asp:Literal runat="server" ID="videos"></asp:Literal>
                </div>
    <%-- <video id="video" src="<%# Eval("path") %>"  controlsList="nodownload" controls="controls" autoplay="autoplay" preload="auto" loop/>--%>
                               <%--<div class="masonry-item">
                        <div class="blog-entry-html-video clearfix">
                            <div class="video-container">
                                <div id="youtube_canvas">
                                    <iframe width="560" height="315" src="<%# Eval("path") %>" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>
                                </div>
                            </div>
                        </div>
                    </div>--%>

</section>
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

