<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_login_signup.master" AutoEventWireup="true" CodeFile="otp_verification.aspx.cs" Inherits="Reports_otp_verification" %>

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

        .RadioButtonWidth label {
            margin-right: 40px;
            margin-left: 10px;
        }

        .RadioButtonWidth1 label {
            margin-right: 10px;
            margin-left: 5px;
        }
    </style>
    <section class="login-box-main height-100vh page-section-ptb" style="background: url(../images/signup/06.jpg);">
        <div class="login-box-main-middle">
            <div class="container">
                <div class="row row-eq-height no-gutter">
                    <div class="col-md-2 col-md-offset-1">
                        <div class="login-box-left  white-bg">
                            <img class="logo-small" src="../images/wp2296420_small.jpg" alt="" />
                            <ul class="nav">
                                <li><a href="login.aspx"><i class="ti-user"></i>Login</a></li>
                                <li class="active"><a href="otp_verification.aspx"><i class="ti-pencil-alt"></i>OTP Verification</a></li>
                                <li><a href="../Default.aspx"><i class="ti-home"></i>Home</a></li>
                            </ul>
                            <div class="social-icons color clearfix pos-bot pb-30 pl-30">
                                             <label style="font-weight:bolder; text-align:center;" class="text-black" >Follow us :</label>
                       
                                <ul>
                                    <li class="social-facebook"><a href="https://www.facebook.com/cellsalts4health/" target="_blank"><i class="fa fa-facebook"></i></a></li>
                                      <li class="social-youtube"><a href="https://www.youtube.com/channel/UCDs5KYN98dNtGuU_SBD9ZWg?view_as=subscriber" target="_blank"><i class="fa fa-youtube"></i></a></li>
                                    <li class="social-gplus"><a href="https://plus.google.com/u/0/communities/115123221768058437390?cfem=1" target="_blank"><i class="fa fa-google-plus"></i></a></li>
                                     <li class="sharethis-inline-share-buttons"></li>
                                    <%--<li class="social-twitter"><a href="#"><i class="fa fa-twitter"></i></a></li>
                                    <li class="social-instagram"><a href="#"><i class="fa fa-instagram"></i></a></li>--%>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 theme-bg">
                        <div class="login-box pos-r text-white login-box-theme">
                            <h2 class="text-white mb-20">Welcome to Hogwarts Institute</h2>

                            <div class="form-group" style="padding-top: 10px; color: black;">
                                <span style="color: black;">Note: Please Enter OTP which is sent to the mobile no. provided by you at the time of registration   </span>
                            </div>
                            <div class="form-group" style="padding-top: 20px; color: black;">
                                <span style="color: black;">Mobile/Email will be used for Login  </span>
                            </div>
                            <div class="form-group" style="padding-top: 100px; color: black;">
                                <ul class="list-unstyled list-inline pos-bot pb-100" style="padding-top: 300px;">
                                    <li><a class="text-white" href="../terms_and_conditions.aspx">Terms of use</a> </li>
                                    <%-- <li><a class="text-white" href="#">Privacy Policy</a></li>--%>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="login-box pb-50 clearfix white-bg">
                            <h3 class="mb-30">OTP Verification</h3>
                            <div class="section-field mb-20">
                                <label class="mb-10" for="name">OTP  <span class="form_error">* </span></label>
                                <asp:TextBox ID="otp" TextMode="Password" CssClass="form-control" autocomplete="off" MaxLength="7" placeholder="Enter 7 digit OTP" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="a" Display="Dynamic" ID="RequiredFieldValidator10" ControlToValidate="otp" CssClass="form_error" runat="server" ErrorMessage="OTP is Required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender TargetControlID="otp" ID="FilteredTextBoxExtender6" FilterType="Numbers" runat="server"></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="row">
                                <div class="section-field mb-20 col-sm-6">
                                    <asp:Button ID="Signup" runat="server" CssClass="button" ValidationGroup="a" Text="Verification" OnClick="Signup_Click" />
                                </div>
                                <div class="section-field mb-20 col-sm-6">
                                    <asp:Button ID="Resend" runat="server" CssClass="button" Text="Resend" OnClick="Resend_Click" />
                                </div>
                            <span class="form_error" style="float: right;">( *  ) Indicates  Mandatory Fields</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
    </section>
</asp:Content>

