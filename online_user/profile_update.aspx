<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageonline_user.master" AutoEventWireup="true" CodeFile="profile_update.aspx.cs" Inherits="online_user_profile_update" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/Control/olu_pagestatus.ascx" TagPrefix="uc1" TagName="PageStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
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
            height: 1px;
        }
    </style>
    <script type="text/javascript">

    </script>
   <section class="page-title  parallax" data-jarallax='{"speed": 0.0}' style="background-image: url(../images/pattern/pattern-bg.png);">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="page-title-name">
                        <h1 style="color:#20B2AA;">My Profile</h1>
                    </div>
                   
                </div>
            </div>
        </div>
    </section>
    <section class="page-section-ptb">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <%--   <uc1:PageStatus runat="server" ID="PageStatus" />--%>
                    <br />
                    <h5>General Information</h5>
                    <hr />
                    <br />
                    <div class="contact-form clearfix">
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">First name <span class="form_error">* </span></label>
                            <asp:TextBox ID="txt_first_name" autocomplete="off" CssClass="form-control" placeholder="Enter First Name*" runat="server" MaxLength="49"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator13" ValidationGroup="a" runat="server" ControlToValidate="txt_first_name" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Middle name</label>
                            <asp:TextBox ID="txt_middle_name" autocomplete="off" CssClass="form-control" placeholder="Enter Middle Name" runat="server" MaxLength="49"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator1" ValidationGroup="a" runat="server" ControlToValidate="txt_middle_name" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Last name <span class="form_error">* </span></label>
                            <asp:TextBox ID="txt_last_name" autocomplete="off" CssClass="form-control" placeholder="Enter Last Name*" runat="server" MaxLength="49"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator2" ValidationGroup="a" runat="server" ControlToValidate="txt_last_name" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Mobile No. <span class="form_error">* </span></label>
                            <asp:TextBox ID="mobile_no" autocomplete="off" CssClass="form-control" placeholder="Enter Mobile No*" runat="server" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator3" ValidationGroup="a" runat="server" ControlToValidate="mobile_no" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ValidationGroup="a" Display="Dynamic" ID="RegularExpressionValidator1" CssClass="form_error" ControlToValidate="mobile_no" ValidationExpression="^[0-9]{10}" runat="server" ErrorMessage="Enter a valid 10 digit Mobile number" SetFocusOnError="True"></asp:RegularExpressionValidator>
                            <cc1:FilteredTextBoxExtender TargetControlID="mobile_no" ID="FilteredTextBoxExtender6" FilterType="Numbers" runat="server"></cc1:FilteredTextBoxExtender>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Email Id <span class="form_error">* </span></label>
                            <asp:TextBox ID="email_id" autocomplete="off" CssClass="form-control" placeholder="Enter Email id*" runat="server" MaxLength="79"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator4" ValidationGroup="a" runat="server" ControlToValidate="email_id" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ValidationGroup="a" Display="Dynamic" ID="RegularExpressionValidator3" ControlToValidate="email_id" CssClass="form_error" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ErrorMessage="Enter a valid Email" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Gender <span class="form_error">* </span></label>
                            <asp:DropDownList runat="server" ID="ddl_gender" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="req_classEnt" Display="Dynamic" ControlToValidate="ddl_gender" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="contact-form clearfix">
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Nationality </label>
                            <asp:DropDownList runat="server" ID="ddl_nationality" ViewStateMode="Enabled" EnableViewState="true" CssClass="form-control"></asp:DropDownList>
                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic" ControlToValidate="ddl_nationality" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Aadhar No </label>
                            <asp:TextBox ID="aadhar_no" autocomplete="off" CssClass="form-control" placeholder="Enter Aadhar No" runat="server" MaxLength="12"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender TargetControlID="aadhar_no" ID="FilteredTextBoxExtender5" FilterType="Numbers" runat="server"></cc1:FilteredTextBoxExtender>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Alternate Contact </label>
                            <asp:TextBox ID="alternate_contact" autocomplete="off" CssClass="form-control" placeholder="Enter Alternate Contact" runat="server" MaxLength="15"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender TargetControlID="alternate_contact" ID="FilteredTextBoxExtender4" FilterType="Numbers" runat="server"></cc1:FilteredTextBoxExtender>
                        </div>
                    </div>
                    <br />
                    <h5>Profile Picture</h5>
                    <hr />
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="contact-form clearfix">
                                <div class="section-field">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator90" runat="server"
                                        ControlToValidate="FileUpload1" CssClass="form_error"
                                        ErrorMessage="Please Upload File" ValidationGroup="up" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="section-field">
                                    <asp:Button ID="btnupload" CssClass="button" runat="server" Text="Upload" OnClick="btnupload_Click" ValidationGroup="up" />
                                </div>
                                <div class="section-field">
                                    <asp:Image ID="Image1" runat="server" Height="150px" Width="120px" />
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnupload" />
                            <asp:PostBackTrigger ControlID="Button1" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <br />
                    <h5>Postal Address</h5>
                    <hr />
                    <br />
                    <div class="contact-form clearfix">
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Country <span class="form_error">* </span></label>
                            <asp:DropDownList runat="server" ID="ddl_country" ViewStateMode="Enabled" EnableViewState="true" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" ControlToValidate="ddl_country" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">State </label>
                            <asp:DropDownList runat="server" ID="ddl_state" OnSelectedIndexChanged="ddl_state_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" ControlToValidate="ddl_state" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">City </label>
                            <asp:DropDownList runat="server" ID="ddl_city" CssClass="form-control"></asp:DropDownList>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" ControlToValidate="ddl_city" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>

                    <div class="contact-form clearfix">
                        <div class="section-field textarea">
                            <label class="mb-10" for="name">Address </label>
                            <asp:TextBox ID="txt_address" autocomplete="off" TextMode="MultiLine" Rows="3" CssClass="form-control lol" placeholder="Enter Address" runat="server" MaxLength="999"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator15" ValidationGroup="a" runat="server" ControlToValidate="txt_address" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Pincode </label>
                            <asp:TextBox ID="pincode" autocomplete="off" CssClass="form-control" placeholder="Enter Pincode" runat="server" MaxLength="6"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator16" ValidationGroup="a" runat="server" ControlToValidate="pincode" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                            <cc1:FilteredTextBoxExtender TargetControlID="pincode" ID="FilteredTextBoxExtender3" FilterType="Numbers" runat="server"></cc1:FilteredTextBoxExtender>
                        </div>
                    </div>
                    <br />
                    <h5>Health Information</h5>
                    <hr />
                    <br />
                    <div class="contact-form clearfix">
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Age </label>
                            <asp:DropDownList runat="server" ID="ddl_age" ViewStateMode="Enabled" EnableViewState="true" CssClass="form-control"></asp:DropDownList>
                            <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" ControlToValidate="ddl_age" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Height in Feet </label>
                            <asp:TextBox ID="height" autocomplete="off" CssClass="form-control" placeholder="Enter Height in Feet" runat="server" MaxLength="3"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator6" ValidationGroup="a" runat="server" ControlToValidate="height" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                            <cc1:FilteredTextBoxExtender TargetControlID="height" ID="FilteredTextBoxExtender2" FilterType="Numbers, Custom" ValidChars=".," runat="server"></cc1:FilteredTextBoxExtender>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Weight in KG</label>
                            <asp:TextBox ID="weight" autocomplete="off" CssClass="form-control" placeholder="Enter Weight in KG" runat="server" MaxLength="6"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator7" ValidationGroup="a" runat="server" ControlToValidate="weight" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                            <cc1:FilteredTextBoxExtender TargetControlID="weight" ID="FilteredTextBoxExtender1" FilterType="Numbers, Custom" ValidChars="." runat="server"></cc1:FilteredTextBoxExtender>
                        </div>
                    </div>
                    <div class="contact-form clearfix">

                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Martial Status </label>
                            <asp:DropDownList runat="server" ID="ddl_martial" ViewStateMode="Enabled" EnableViewState="true" CssClass="form-control"></asp:DropDownList>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Display="Dynamic" ControlToValidate="ddl_martial" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Blood Pressure </label>
                            <asp:DropDownList runat="server" ID="ddl_bp" ViewStateMode="Enabled" EnableViewState="true" CssClass="form-control"></asp:DropDownList>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="ddl_bp" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Diabetic </label>
                            <asp:DropDownList runat="server" ID="ddl_diabetic" ViewStateMode="Enabled" EnableViewState="true" CssClass="form-control"></asp:DropDownList>
                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" ControlToValidate="ddl_diabetic" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Smoking </label>
                            <asp:DropDownList runat="server" ID="ddl_smoking" ViewStateMode="Enabled" EnableViewState="true" CssClass="form-control"></asp:DropDownList>
                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" ControlToValidate="ddl_smoking" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Alcoholic </label>
                            <asp:DropDownList runat="server" ID="ddl_alcpohal" ViewStateMode="Enabled" EnableViewState="true" CssClass="form-control"></asp:DropDownList>
                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Display="Dynamic" ControlToValidate="ddl_alcpohal" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="section-field mb-20 col-sm-4">
                            <label class="mb-10" for="name">Blood Group </label>
                            <asp:DropDownList runat="server" ID="ddl_blood" ViewStateMode="Enabled" EnableViewState="true" CssClass="form-control"></asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" Display="Dynamic" ControlToValidate="ddl_blood" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <br />
                    <h5>Medical History</h5>
                    <hr />
                    <br />
                    <div class="contact-form clearfix">
                        <div class="section-field textarea">
                            <asp:TextBox ID="txt_previous_medical" autocomplete="off" TextMode="MultiLine" Rows="3" CssClass="form-control lol" placeholder="Enter Previous Medical History" runat="server" MaxLength="999"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator1" ValidationGroup="a" runat="server" ControlToValidate="txt_previous_medical" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <br />
                    <h5>Medical History Upload</h5>
                    <hr />
                    <br />
                    <div class="contact-form clearfix">
                        <div class="section-field">
                            <asp:FileUpload ID="FileUpload2" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="FileUpload2" CssClass="form_error"
                                ErrorMessage="Please Upload File" ValidationGroup="upp" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="section-field">
                            <asp:Button ID="Button1" CssClass="button" runat="server" Text="Upload" OnClick="Button1_Click" ValidationGroup="upp" />
                        </div>
                        <div class="section-field">
                        </div>
                    </div>
                    <br />
                    <div class="contact-form clearfix">
                        <div class="section-field textarea">
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="file_id,user_id"
                                OnRowCommand="GridView2_RowCommand" OnRowDeleting="GridView2_RowDeleting" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDataBound="GridView2_RowDataBound" Width="100%" CssClass="table table-1 table-bordered table-striped table-2 lolll" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                EmptyDataText="No Record to show.">
                                <Columns>
                                    <asp:BoundField DataField="document_name" HeaderText="Document Name" ItemStyle-Width="15%" SortExpression="document_name" />
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Download_report" CommandArgument='<%#Eval("file_id") %>' runat="server" OnClick="Download_report_Click" CausesValidation="false" Text="View File"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton CssClass="distance" ID="LinkButton1" CommandArgument='<%# Eval("file_id") %>' CommandName="Delete" runat="server" Text="Delete"> </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                    <hr />
                    <br />
                    <div class="contact-form clearfix">
                        <div class="section-field">
                        </div>
                        <div class="section-field submit-button" style="margin-left: 50%">
                            <input type="hidden" name="action" value="sendEmail" />
                            <asp:Button ID="submit_part1" runat="server" CssClass="button" ValidationGroup="a" Text="Save" OnClick="submit_part1_Click" />
                        </div>
                        <div class="section-field">
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>

</asp:Content>

