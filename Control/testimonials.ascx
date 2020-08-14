<%@ Control Language="C#" AutoEventWireup="true" CodeFile="testimonials.ascx.cs" Inherits="Control_testimonials" %>

<section class="page-title  parallax" data-jarallax='{"speed": 0.0}' style="background-image: url(../images/pattern/pattern-bg.png);">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="page-title-name">
                    <h1 style="color:#20B2AA;">Testimonials</h1>
                </div>
            </div>
        </div>
    </div>
</section>

<section class="gray-bg page-section-ptb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 text-center">
                <div class="isotope columns-2 popup-gallery">
                    <div class="grid-item photography branding">
                        <asp:Literal runat="server" ID="Literal1"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
