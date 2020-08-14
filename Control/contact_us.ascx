<%@ Control Language="C#" AutoEventWireup="true" CodeFile="contact_us.ascx.cs" Inherits="Control_contact_us" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    textarea {
        resize: none !important;
    }

    .lol {
        resize: none;
    }

    .alig {
        float: right;
        padding-right: 15px;
        font-size: 15px;
    }

    .form_error {
        font: arial black,arial,verdana,helvetica !important;
        color: red !important;
    }

    .infoma {
        font: arial black,arial,verdana,helvetica !important;
        color: black !important;
    }
</style>
<script type="text/javascript">
    var count = 1000;
    function limitAddress() {
        var tex = document.getElementById("ctl00_ContentPlaceHolder1_PageStatus_txt_address").value;
        var len = tex.length;
        if (len > count) {
            tex = tex.substring(0, count);
            document.getElementById("ctl00_ContentPlaceHolder1_PageStatus_txt_address").value = tex;
            return false;
        }
        document.getElementById("ctl00_ContentPlaceHolder1_PageStatus_limit1").innerHTML = count - len;
    }
</script>
  <section class="page-title  parallax" data-jarallax='{"speed": 0.0}' style="background-image: url(../images/pattern/pattern-bg.png);">

    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="page-title-name">
                    <h1 style="color:#20B2AA;">Contact Us</h1>
                </div>
            
            </div>
        </div>
    </div>
</section>
<section class="contact white-bg page-section-ptb">
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-md-8 col-md-offset-2">
                <div class="section-title text-center">
                  <%--  <h6>let's work together</h6>--%>
                    <h2>Let’s Get In Touch!</h2>
                    <%--<p>It would be great to hear from you! If you got any questions</p>--%>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="touch-in white-bg">
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="contact-box text-center">
                        <i class="ti-map-alt theme-color"></i>
                        <h5 class="uppercase mt-20">Address</h5>
                        <p class="mt-20">Chagorabhata Raipur, Chhattisgarh - 492001 </p>
                    </div>
                </div>
                <%--<div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="contact-box text-center">
                        <i class="ti-mobile theme-color"></i>
                        <h5 class="uppercase mt-20">Phone</h5>
                        <p class="mt-20">+91 9986546496, +91 9588968360</p>
                    </div>
                </div>--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="contact-box text-center">
                        <i class="ti-email theme-color"></i>
                        <h5 class="uppercase mt-20">Email</h5>
                        <p class="mt-20">hogwartsinstitute@gmail.com</p>
                        
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12 col-md-12 text-center">
                <p class="mt-50 mb-30">
                   <%-- It would be great to hear from you! If you got any questions, please do not hesitate to send us a message. We are looking forward to hearing from you! We reply within
                    <br />
                    <span class="tooltip-content-2" data-original-title="Mon-Fri 10am–7pm (GMT +1)" data-toggle="tooltip" data-placement="top">24 hours!</span>--%>
                </p>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="contact-form clearfix">
                            <div class="section-field">
                                <asp:TextBox ID="txt_first_name" autocomplete="off" CssClass="form-control" placeholder="Enter Your Name*" runat="server" MaxLength="99"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator13" ValidationGroup="a" runat="server" ControlToValidate="txt_first_name" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="section-field">
                                <asp:TextBox ID="email_id" autocomplete="off" CssClass="form-control" placeholder="Enter Your Email id*" runat="server" MaxLength="79"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator4" ValidationGroup="a" runat="server" ControlToValidate="email_id" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ValidationGroup="a" Display="Dynamic" ID="RegularExpressionValidator3" ControlToValidate="email_id" CssClass="form_error" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ErrorMessage="Enter a valid Email" SetFocusOnError="True"></asp:RegularExpressionValidator>
                            </div>
                            <div class="section-field">
                                <asp:TextBox ID="mobile_no" autocomplete="off" CssClass="form-control" placeholder="Enter Your Mobile No*" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator3" ValidationGroup="a" runat="server" ControlToValidate="mobile_no" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ValidationGroup="a" Display="Dynamic" ID="RegularExpressionValidator1" CssClass="form_error" ControlToValidate="mobile_no" ValidationExpression="^[0-9]{10}" runat="server" ErrorMessage="Enter a valid 10 digit Mobile number" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                <cc1:FilteredTextBoxExtender TargetControlID="mobile_no" ID="FilteredTextBoxExtender6" FilterType="Numbers" runat="server"></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="section-field textarea">
                                <asp:TextBox ID="txt_address" autocomplete="off" TextMode="MultiLine" Rows="7" OnKeyUp="limitAddress();" CssClass="form-control lol" placeholder="Enter Your Message*" runat="server" MaxLength="499"></asp:TextBox>
                                <asp:Label ID="limit1" CssClass="alig" runat="server" ForeColor="Maroon" Text="1000"></asp:Label>
                                <asp:Label ID="lblChar1" CssClass="alig" runat="server" ForeColor="Maroon" Text="character limit"></asp:Label>
                                <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator12" ValidationGroup="a" runat="server" ControlToValidate="txt_address" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="section-field submit-button">
                    <asp:Button ID="submit_part1" runat="server" CssClass="button" ValidationGroup="a" Text="Send your message" OnClick="submit_part1_Click" />
                </div>
            </div>
        </div>
    </div>
</section>
