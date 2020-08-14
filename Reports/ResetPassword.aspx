<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_login_signup.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="Reports_ResetPassword" %>

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

        .RadioButtonWidth label {
            margin-right: 40px;
            margin-left: 10px;
        }

        .RadioButtonWidth1 label {
            margin-right: 10px;
            margin-left: 5px;
        }

        .lol label {
            margin-left: 10px;
        }
    </style>
    <section class="login-box-main height-100vh page-section-ptb" style="background: url(../images/signup/06.jpg);">
        <div class="login-box-main-middle">
            <div class="container">
                <div class="row row-eq-height no-gutter">
                    <div class="col-md-2 col-md-offset-1">
                        <div class="login-box-left  white-bg">
                            <img class="logo-small" src="../images/logonew.png" alt="" />
                            <ul class="nav">
                                <li><a href="login"><i class="ti-user"></i>Login</a></li>
                                <li><a href="signup"><i class="ti-pencil-alt"></i>Signup</a></li>
                                <li class="active"><a href="#"><i class="ti-pencil-alt"></i>Reset Password</a></li>
                                <li><a href="../Default"><i class="ti-home"></i>Home</a></li>
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
                            <h2 class="text-white mb-20">Welcome to Cell Salts</h2>

                            <div class="form-group" style="padding-top: 50px; color: black;">
                                <span style="color: black;">Mobile/Email will be used for Login  </span>
                            </div>
                        <%--    <div class="form-group" style="padding-top: 30px; padding-bottom:100px;">
                                <span class="form_error">Password Policy:- Minimum 8 and Maximum 15 characters, atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character( ! @ # $ & * )
                                </span>
                            </div>
                            <asp:Label ID="lblhelp1" runat="server" CssClass="infoma" />
                            <cc1:PasswordStrength runat="server" ID="PasswordStrength1" TargetControlID="Password" DisplayPosition="RightSide" BarIndicatorCssClass="BarBorder" MinimumSymbolCharacters="1" MinimumUpperCaseCharacters="1" PreferredPasswordLength="8" CalculationWeightings="25;25;15;35" RequiresUpperAndLowerCaseCharacters="true" TextStrengthDescriptions="Poor; Weak; Good; Strong; Excellent" HelpStatusLabelID="lblhelp1" StrengthIndicatorType="BarIndicator" HelpHandlePosition="AboveLeft" BarBorderCssClass="barIndicatorBorder" StrengthStyles="barIndicator_poor; barIndicator_weak; barIndicator_good; barIndicator_strong; barIndicator_excellent" MinimumLowerCaseCharacters="1" MinimumNumericCharacters="1"></cc1:PasswordStrength>--%>

                            <ul class="list-unstyled list-inline pos-bot pb-100" >
                                <li><a class="text-white" href="../terms_and_conditions">Terms of use</a> </li>
                                <%-- <li><a class="text-white" href="#">Privacy Policy</a></li>--%>
                            </ul>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="login-box pb-50 clearfix white-bg">
                            <h3 class="mb-30">Reset Password</h3>
                            <div class="row">
                                <div class="section-field mb-20 col-sm-6">
                                    <label class="mb-10" for="Password">Password  <span class="form_error">* </span></label>
                                    <asp:TextBox ID="Password" CssClass="form-control" autocomplete="off" placeholder="Password" TextMode="Password" runat="server" MaxLength="15"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="a" Display="Dynamic" ID="RequiredFieldValidator7" ControlToValidate="Password" CssClass="form_error" runat="server" SetFocusOnError="True" ForeColor="#FF3300" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
                                 <%--   <asp:RegularExpressionValidator ValidationGroup="a" Display="Dynamic" ID="RegularExpressionValidator7" runat="server" ControlToValidate="Password" ValidationExpression="^(?=.*[A-Z])(?=.*[!@#$&*])(?=.*[0-9])(?=.*[a-z]).{8,15}$" ErrorMessage="Please Follow Password Policy" ForeColor="#FF3300" SetFocusOnError="True"></asp:RegularExpressionValidator>--%>
                                </div>
                                <div class="section-field mb-20 col-sm-6">
                                    <label class="mb-10" for="Password">Confirm Password  <span class="form_error">* </span></label>
                                    <asp:TextBox ID="Confirm" CssClass="form-control" autocomplete="off" placeholder="Confirm" TextMode="Password" runat="server" MaxLength="15"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="a" Display="Dynamic" ID="RequiredFieldValidator9" SetFocusOnError="True" ForeColor="#FF3300" ControlToValidate="Confirm" CssClass="form_error" runat="server" ErrorMessage="Confirm Required"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator Display="Dynamic" ID="CompareValidator1" runat="server" ControlToCompare="Password" ControlToValidate="Confirm" ErrorMessage="Password does not match" SetFocusOnError="True" ForeColor="#FF3300"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="section-field mb-20 col-sm-6">
                                    <asp:Button ID="reset" runat="server" CssClass="button" ValidationGroup="a" Text="Reset" OnClick="reset_Click" />
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

