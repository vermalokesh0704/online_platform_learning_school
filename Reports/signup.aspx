<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_login_signup.master" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="Reports_signup" %>

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
    <script type="text/javascript">

        function MobileAvailability() {
            $.ajax({
                type: "POST",
                url: "signup.aspx/Check_user_mobile",
                data: '{mobile: "' + $("#<%=Mobile.ClientID%>")[0].value + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response);
                }
            });
        }
        function OnSuccess(response) {
            switch (response.d) {
                case "true":

                    break;
                case "false":
                    $("#<%=Mobile.ClientID%>")[0].value = "";
                    document.getElementById("ContentPlaceHolder1_Mobile").focus();
                    alert("Mobile Number already Exists !!!! Please Try Different Mobile Number");
                    break;
            }
        }

        function EmailAvailability() {
            $.ajax({
                type: "POST",
                url: "signup.aspx/Check_user_email",
                data: '{email: "' + $("#<%=Email.ClientID%>")[0].value + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess1,
                failure: function (response) {
                    alert(response);
                }
            });
        }
        function OnSuccess1(response) {
            switch (response.d) {
                case "true":

                    break;
                case "false":
                    $("#<%=Email.ClientID%>")[0].value = "";
                    document.getElementById("ContentPlaceHolder1_Email").focus();
                    alert("Email Id already Exists !!!! Please Try Different Email Id");
                    break;
            }
        }
    </script>
    <section class="login-box-main height-100vh page-section-ptb" style="background: url(../images/signup/06.jpg);">
        <div class="login-box-main-middle">
            <div class="container">
                <div class="row row-eq-height no-gutter">
                    <div class="col-md-2 col-md-offset-1">
                        <div class="login-box-left  white-bg">
                            <img class="logo-small" src="../images/wp2296420_small.jpg" alt="" />
                            <ul class="nav">
                                <li><a href="login"><i class="ti-user"></i>Login</a></li>
                                <li class="active"><a href="#"><i class="ti-pencil-alt"></i>Signup</a></li>
                                <li><a href="../Default"><i class="ti-home"></i>Home</a></li>
                            </ul>
                            <div class="social-icons color clearfix pos-bot pb-30 pl-30">
                                <label style="font-weight: bolder; text-align: center;" class="text-black">Follow us :</label>

                                <ul>
                                    <li class="social-facebook"><a href="https://www.facebook.com/hogwartsinstitute/" target="_blank"><i class="fa fa-facebook"></i></a></li>
                                    <li class="social-youtube"><a href="" target="_blank"><i class="fa fa-youtube"></i></a></li>
                                    <li class="social-gplus"><a href="" target="_blank"><i class="fa fa-google-plus"></i></a></li>
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

                            <div class="form-group" style="padding-top: 70px; color: black;">
                                <span style="color: black;">Note: An OTP will be sent to the mobile no. which is provided here for activation of the account   </span>
                            </div>
                            <div class="form-group" style="padding-top: 40px; color: black;">
                                <span style="color: black;">Mobile/Email will be used for Login  </span>
                            </div>
                            <%--  <div class="form-group" style="padding-top: 20px; color: black;">
                                <span style="color: black;">International user should use Email Id for OTP verification  </span>
                            </div>--%>
                            <div class="form-group" style="padding-top: 30px;">
                                <span class="form_error">Password Policy:- Minimum 8 and Maximum 15 characters, atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character( ! @ # $ & * )
                                </span>
                            </div>
                            <asp:Label ID="lblhelp1" runat="server" CssClass="infoma" />
                            <cc1:PasswordStrength runat="server" ID="PasswordStrength1" TargetControlID="Password" DisplayPosition="RightSide" BarIndicatorCssClass="BarBorder" MinimumSymbolCharacters="1" MinimumUpperCaseCharacters="1" PreferredPasswordLength="8" CalculationWeightings="25;25;15;35" RequiresUpperAndLowerCaseCharacters="true" TextStrengthDescriptions="Poor; Weak; Good; Strong; Excellent" HelpStatusLabelID="lblhelp1" StrengthIndicatorType="BarIndicator" HelpHandlePosition="AboveLeft" BarBorderCssClass="barIndicatorBorder" StrengthStyles="barIndicator_poor; barIndicator_weak; barIndicator_good; barIndicator_strong; barIndicator_excellent" MinimumLowerCaseCharacters="1" MinimumNumericCharacters="1"></cc1:PasswordStrength>

                            <ul class="list-unstyled list-inline pos-bot pb-100">
                                <li><a class="text-white" href="../terms_and_conditions">Terms of use</a> </li>
                                <%-- <li><a class="text-white" href="#">Privacy Policy</a></li>--%>
                            </ul>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="login-box pb-50 clearfix white-bg">
                            <h3 class="mb-30">Signup</h3>
                            <div class="section-field mb-20">
                                <label class="mb-10" for="name">User Type  <span class="form_error">* </span></label>
                                <br />
                                <asp:RadioButtonList CssClass="RadioButtonWidth" ID="user_type" RepeatDirection="Horizontal" runat="server" RepeatLayout="Flow">
                                    <asp:ListItem Text="Student" Selected="True" Value="USER"></asp:ListItem>
                                    <asp:ListItem Text="Teacher" Value="TEA"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ControlToValidate="user_type" ErrorMessage="Required" ForeColor="#FF3300" CssClass="form_error"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                            <div class="row">
                                <div class="section-field mb-20 col-sm-6">
                                      <label class="mb-10" for="name">Class  <span class="form_error">* </span></label>
                                    <asp:DropDownList runat="server" ID="ddl_class" OnSelectedIndexChanged="ddl_class_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="req_classEnt" Display="Dynamic" ControlToValidate="ddl_class" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                                 <div class="section-field mb-20 col-sm-6">
                                       <label class="mb-10" for="name">Stream  <span class="form_error">* </span></label>
                                    <asp:DropDownList runat="server" ID="ddl_stream" CssClass="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="ddl_stream" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                                            </ContentTemplate>
                                  </asp:UpdatePanel>
                            <div class="row">
                                <div class="section-field mb-20 col-sm-6">
                                    <label class="mb-10" for="name">First name <span class="form_error">* </span></label>
                                    <asp:TextBox ID="txt_first_Name" autocomplete="off" CssClass="form-control" placeholder="First Name" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="a" CssClass="form_error" ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_first_Name" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                                <div class="section-field mb-20 col-sm-6">
                                    <label class="mb-10" for="name">Last name <span class="form_error">*</span> </label>
                                    <asp:TextBox ID="txt_last_Name" autocomplete="off" CssClass="form-control" placeholder="Last Name" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="a" CssClass="form_error" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_last_Name" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <%-- <div class="section-field mb-20 col-sm-6">
                                    <label class="mb-10" for="name">Country Code <span class="form_error">* </span></label>
                                    <asp:DropDownList runat="server" ID="ddl_code" OnSelectedIndexChanged="ddl_code_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="ddl_code" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>

                                </div>--%>
                            <%--<div class="section-field mb-20 col-sm-6">--%>
                            <div class="section-field mb-20">
                                <label class="mb-10" for="name">Mobile  <span class="form_error">* </span></label>
                                <asp:TextBox ID="Mobile" CssClass="form-control" autocomplete="off" MaxLength="10" placeholder="Mobile No." runat="server" onchange="MobileAvailability();"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="a" Display="Dynamic" ID="RequiredFieldValidator10" ControlToValidate="Mobile" CssClass="form_error" runat="server" ErrorMessage="Mobile number is Required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ValidationGroup="a" Display="Dynamic" ID="RegularExpressionValidator1" CssClass="form_error" ControlToValidate="Mobile" ValidationExpression="^[0-9]{10}" runat="server" ErrorMessage="Enter a valid Mobile number" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                <cc1:FilteredTextBoxExtender TargetControlID="Mobile" ID="FilteredTextBoxExtender6" FilterType="Numbers" runat="server"></cc1:FilteredTextBoxExtender>
                            </div>
                            <%-- <div class="section-field mb-20">
                                <label class="mb-10" for="name">Mobile  <span class="form_error">* </span></label>

                                <asp:TextBox ID="Mobile" CssClass="form-control" autocomplete="off" MaxLength="10" placeholder="Enter Your 10 digit Mobile Number" runat="server" onchange="MobileAvailability();"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="a" Display="Dynamic" ID="RequiredFieldValidator10" ControlToValidate="Mobile" CssClass="form_error" runat="server" ErrorMessage="Mobile number is Required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ValidationGroup="a" Display="Dynamic" ID="RegularExpressionValidator1" CssClass="form_error" ControlToValidate="Mobile" ValidationExpression="^[0-9]{10}" runat="server" ErrorMessage="Enter a valid 10 digit Mobile number" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                <cc1:FilteredTextBoxExtender TargetControlID="Mobile" ID="FilteredTextBoxExtender6" FilterType="Numbers" runat="server"></cc1:FilteredTextBoxExtender>

                            </div>--%>
                            <div class="section-field mb-20">
                                <label class="mb-10" for="name">Email  <span class="form_error">* </span></label>
                                <asp:TextBox ID="Email" CssClass="form-control" autocomplete="off" placeholder="Enter Your Email" runat="server" MaxLength="50" onchange="EmailAvailability();"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="a" Display="Dynamic" ID="RequiredFieldValidator11" ControlToValidate="Email" CssClass="form_error" runat="server" ErrorMessage="Email Should Not be Left Blank" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ValidationGroup="a" Display="Dynamic" ID="RegularExpressionValidator3" ControlToValidate="Email" CssClass="form_error" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ErrorMessage="Enter a valid Email" SetFocusOnError="True"></asp:RegularExpressionValidator>
                            </div>

                            <%--  <div class="section-field mb-20">--%>
                            <div class="row">
                                <div class="section-field mb-20 col-sm-6">
                                    <label class="mb-10" for="Password">Password  <span class="form_error">* </span></label>
                                    <asp:TextBox ID="Password" CssClass="form-control" autocomplete="off" placeholder="Password" TextMode="Password" runat="server" MaxLength="15"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="a" Display="Dynamic" ID="RequiredFieldValidator7" ControlToValidate="Password" CssClass="form_error" runat="server" SetFocusOnError="True" ForeColor="#FF3300" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ValidationGroup="a" Display="Dynamic" ID="RegularExpressionValidator7" runat="server" ControlToValidate="Password" ValidationExpression="^(?=.*[A-Z])(?=.*[!@#$&*])(?=.*[0-9])(?=.*[a-z]).{8,15}$" ErrorMessage="Please Follow Password Policy" ForeColor="#FF3300" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                </div>
                                <%--<div class="section-field mb-20">--%>
                                <div class="section-field mb-20 col-sm-6">
                                    <label class="mb-10" for="Password">Confirm Password  <span class="form_error">* </span></label>
                                    <asp:TextBox ID="Confirm" CssClass="form-control" autocomplete="off" placeholder="Confirm" TextMode="Password" runat="server" MaxLength="15"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="a" Display="Dynamic" ID="RequiredFieldValidator9" SetFocusOnError="True" ForeColor="#FF3300" ControlToValidate="Confirm" CssClass="form_error" runat="server" ErrorMessage="Confirm Required"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator Display="Dynamic" ID="CompareValidator1" runat="server" ControlToCompare="Password" ControlToValidate="Confirm" ErrorMessage="Password does not match" SetFocusOnError="True" ForeColor="#FF3300"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="row">
                                <label class="mb-10" for="name">Enter the Characters shown in image <span class="form_error">* </span></label>
                                <div class="section-field mb-20  col-sm-6">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <cc1:CaptchaControl ID="Captcha1" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                                CaptchaHeight="50" CaptchaWidth="160" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                                                CaptchaMaxTimeout="240" FontColor="#529E00" />
                                            <%-- <asp:Button ID="Signup" runat="server" CssClass="button" ValidationGroup="a" Text="Signup" OnClick="Signup_Click" />--%>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="section-field mb-20 col-sm-6">
                                    <asp:TextBox ID="txt_captcha" runat="server" autocomplete="off" CssClass="text_box form-control" MaxLength="6"
                                        placeholder="Enter Captcha Characters"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="a" Display="Dynamic" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Captcha Required" SetFocusOnError="True" ControlToValidate="txt_captcha" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="section-field mb-20 col-sm-6">
                                    <div class="remember-checkbox">
                                        <asp:CheckBox ID="ChkContent" runat="server" Text=" I agree to terms " Font-Bold="true" />
                                        <asp:CustomValidator ID="Custom1" CssClass="errorTop" ValidationGroup="a" Display="Dynamic"
                                            ClientValidationFunction="CheckBoxValidation"
                                            runat="server"
                                            ErrorMessage="You must select this box to proceed">
                                        </asp:CustomValidator>
                                    </div>
                                </div>

                                <%-- <div class="section-field mb-20  col-sm-6">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <cc1:CaptchaControl ID="Captcha1" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                                CaptchaHeight="50" CaptchaWidth="160" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                                                CaptchaMaxTimeout="240" FontColor="#529E00" />
                                            
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>--%>
                                <div class="section-field mb-20 col-sm-6">
                                    <asp:Button ID="Signup" runat="server" CssClass="button" ValidationGroup="a" Text="Signup" OnClick="Signup_Click" />
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

