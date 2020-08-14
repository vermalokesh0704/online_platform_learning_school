<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_login_signup.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Reports_login" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .form_error {
            font: arial black,arial,verdana,helvetica !important;
            color: red !important;
        }

        .infoma {
            font: arial black,arial,verdana,helvetica !important;
            color: black !important;
        }

        .lol label {
            margin-left: 10px;
        }
        .lol1{
            float:right;
        }
    </style>
    <section class="login-box-main height-100vh page-section-ptb" style="background: url(../images/login/06.jpg);">
        <div class="login-box-main-middle">
            <div class="container">
                <div class="row row-eq-height no-gutter">
                    <div class="col-md-2 col-md-offset-1">
                        <div class="login-box-left  white-bg">
                            <img class="logo-small" src="../images/wp2296420_small.jpg" alt="" />
                            <ul class="nav">
                                <li class="active"><a href="#"><i class="ti-user"></i>Login</a></li>
                                <li><a href="signup"><i class="ti-pencil-alt"></i>Signup</a></li>
                                <li><a href="../Default"><i class="ti-home"></i>Home</a></li>
                            </ul>
                              <div class="social-icons color clearfix pos-bot pb-30 pl-30">
                                      <label style="font-weight:bolder; text-align:center;" class="text-black" >Follow us :</label>
                       
                                <ul>
                                    <li class="social-facebook"><a href="https://www.facebook.com/hogwartsinstitute/" target="_blank"><i class="fa fa-facebook"></i></a></li>
                                      <li class="social-youtube"><a href="" target="_blank"><i class="fa fa-youtube"></i></a></li>
                                    <li class="social-gplus"><a href="" target="_blank"><i class="fa fa-google-plus"></i></a></li>
                                     <li class="sharethis-inline-share-buttons"></li>
                                   <%-- <li class="social-twitter"><a href="#"><i class="fa fa-twitter"></i></a></li>
                                    <li class="social-instagram"><a href="#"><i class="fa fa-instagram"></i></a></li>--%>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 theme-bg">
                        <div class="login-box pos-r text-white login-box-theme">
                            <h2 class="text-white mb-20">Welcome to Hogwarts Institute</h2>
                            <%--    <p class="mb-10 text-white">Create tailor-cut websites </p>--%>
                            <div class="form-group" style="padding-top: 70px; color: black;">
                                <span style="color: black;">Use Registered Mobile Number/Email Id For Login  </span>
                            </div>
                            <div class="form-group" style="padding-top: 30px;">
                                <span class="form_error">Password Policy:- Minimum 8 and Maximum 15 characters, atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character( ! @ # $ & * )
                                </span>
                            </div>
                            <ul class="list-unstyled list-inline pos-bot pb-40">
                                <li><a class="text-white" href="../terms_and_conditions">Terms of use</a> </li>
                                <%-- <li><a class="text-white" href="#">Privacy Policy</a></li>--%>
                            </ul>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="login-box pb-50 clearfix white-bg">
                            <h3 class="mb-30">Login</h3>
                            <div class="section-field mb-20">
                                <label class="mb-10" for="name">Mobile/Email  <span class="form_error">* </span></label>
                                <asp:TextBox ID="txt_login" autocomplete="off" CssClass="form-control" placeholder="Enter Mobile/Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_login" ErrorMessage="Mobile/Email Required" Display="Dynamic"></asp:RequiredFieldValidator>

                            </div>
                            <div class="section-field mb-20">
                                <label class="mb-10" for="Password">Password  <span class="form_error">* </span></label>
                                <asp:TextBox ID="Password" CssClass="form-control" autocomplete="off" placeholder="Password" TextMode="Password" runat="server" MaxLength="15"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" ControlToValidate="Password" CssClass="form_error" runat="server" SetFocusOnError="True" ForeColor="#FF3300" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator7" runat="server" ControlToValidate="Password" ValidationExpression="^(?=.*[A-Z])(?=.*[!@#$&*])(?=.*[0-9])(?=.*[a-z]).{8,15}$" ErrorMessage="Please Follow Password Policy" ForeColor="#FF3300" SetFocusOnError="True"></asp:RegularExpressionValidator>
                            </div>
                            <div class="section-field mb-20">
                                <label class="mb-10" for="name">Enter the Characters shown in image <span class="form_error">* </span></label>
                                <asp:TextBox ID="txt_captcha" runat="server" autocomplete="off" CssClass="text_box form-control" MaxLength="6"
                                    placeholder="Enter Captcha Characters"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Captcha Required" SetFocusOnError="True" ControlToValidate="txt_captcha" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </div>
                            <div class="row">
                                <div class="section-field mb-20 col-sm-6">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <cc1:CaptchaControl ID="Captcha1" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                                CaptchaHeight="50" CaptchaWidth="160" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                                                CaptchaMaxTimeout="240" FontColor="#529E00" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="section-field mb-20 col-sm-6">
                                    <asp:Button ID="Login" runat="server" CssClass="button" Text="Log in" OnClick="Login_Click" />
                                </div>
                               <%-- <div class="section-field mb-20 col-sm-4">
                                    </div>--%>
                            </div>
                            <div class="section-field">
                                <div class="remember-checkbox mb-30">
                                    <asp:CheckBox ID="ChkContent" runat="server" Text="Remember me" CssClass="lol" Font-Bold="true" />
                                    <%--  <label for="two">Remember me</label>--%>
                                     <asp:LinkButton ID="lnk_password" runat="server" CssClass="lol1" OnClick="lnk_password_Click" CausesValidation="False">Forgot Password?</asp:LinkButton>
                                </div>
                            </div>
                            <div class="section-field">
                                <div class="remember-checkbox mb-30">
                                    <a href="../Reports/signup" class="pull-left">New User Signup Here?</a>
                                </div>
                            </div>
                            <%--  <a href="#" class="button">
                                    <span>Log in</span>
                                    <i class="fa fa-check"></i>
                                </a>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

