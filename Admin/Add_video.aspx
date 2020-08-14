<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_admin.master" AutoEventWireup="true" CodeFile="Add_video.aspx.cs" Inherits="Admin_Add_video" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <style type="text/css">
        textarea {
            resize: none !important;
        }

        .lol {
            resize: none !important;
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

        .pad {
            padding-left: 50px;
        }
    </style>
    <section class="page-title  parallax" data-jarallax='{"speed": 0.0}' style="background-image: url(../images/pattern/pattern-bg.png);">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="page-title-name">
                        <h1 style="color: #20B2AA;">Add Video's</h1>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <asp:UpdatePanel runat="server" ID="updatepanel1">
        <ContentTemplate>
            <section class="white-bg page-section-ptb position-re">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <div class="isotope columns-1 popup-gallery">
                                <div class="grid-item photography branding">
                                    <div class="contact-form clearfix">
                                        <div class="section-field mb-20 col-sm-4">
                                            <h5>Topic <span class="form_error">* </span></h5>
                                            <asp:DropDownList runat="server" ID="ddl_class" CssClass="form-control"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="req_classEnt" Display="Dynamic" ControlToValidate="ddl_class" ValidationGroup="a" CssClass="form_error" runat="server" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="section-field mb-20 col-sm-4">
                                            <h5>Video Heading <span class="form_error">* </span></h5>
                                            <asp:TextBox ID="txt_Heading" autocomplete="off" CssClass="form-control" placeholder="Enter Video Heading" runat="server" MaxLength="49"></asp:TextBox>
                                            <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator13" ValidationGroup="a" runat="server" ControlToValidate="txt_Heading" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="section-field mb-20 col-sm-4">
                                            <h5>Video Reference URL </h5>
                                            <asp:TextBox ID="txt_url" autocomplete="off" CssClass="form-control" placeholder="Enter reference url" runat="server" MaxLength="49"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator1" ValidationGroup="a" runat="server" ControlToValidate="txt_url" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                    <div class="contact-form clearfix">
                                        <h5>Upload Video <span class="form_error">* </span></h5>
                                        <div class="contact-form clearfix">
                                            <div class="section-field textarea">
                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                                <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator3" ValidationGroup="a" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="contact-form clearfix">
                                        <h5>Video Description <span class="form_error">* </span></h5>
                                        <div class="contact-form clearfix">
                                            <div class="section-field textarea">
                                                <asp:TextBox ID="txt_review" autocomplete="off" TextMode="MultiLine" Rows="5" CssClass="form-control lol" placeholder="Enter Video Description" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator2" ValidationGroup="a" runat="server" ControlToValidate="txt_review" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <br />
                                    <div class="contact-form clearfix">
                                        <div class="section-field">
                                        </div>
                                        <div class="section-field submit-button" style="margin-left: 45%">
                                            <asp:Button ID="Button1" runat="server" CssClass="button" ValidationGroup="a" Text="Submit" OnClick="submit_review_Click" />
                                        </div>
                                        <div class="section-field">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="contact-form clearfix">
                                <div class="section-field textarea">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="video_id,Topic_id,path"
                                        OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDataBound="GridView2_RowDataBound" Width="100%" CssClass="table table-1 table-bordered table-striped table-2 lolll" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                        EmptyDataText="No records has been added"
                                        OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" AllowPaging="true"
                                        OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting"
                                        PageSize="50">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S No." ItemStyle-Width="5%" HeaderStyle-BackColor="#20B2AA" ItemStyle-ForeColor="Black">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" Width="10%" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Class, Subject & Topic Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="0%" HeaderStyle-BackColor="#20B2AA" ItemStyle-ForeColor="Black">
                                                <ItemTemplate>
                                                    <asp:Label ID="topicname" runat="server" Text='<%# Eval("topicname") %>' ForeColor="Black"> </asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Video Heading" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="0%" HeaderStyle-BackColor="#20B2AA" ItemStyle-ForeColor="Black">
                                                <ItemTemplate>
                                                    <asp:Label ID="videoheading" runat="server" Text='<%# Eval("video_heading") %>' ForeColor="Black"> </asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="video url" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="0%" HeaderStyle-BackColor="#20B2AA" ItemStyle-ForeColor="Black">
                                                <ItemTemplate>
                                                    <asp:Label ID="videourl" runat="server" Text='<%# Eval("video_url") %>' ForeColor="Black"> </asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="video description" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="0%" HeaderStyle-BackColor="#20B2AA" ItemStyle-ForeColor="Black">
                                                <ItemTemplate>
                                                    <asp:Label ID="videodescription" runat="server" Text='<%# Eval("video_description") %>' ForeColor="Black"> </asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="30%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Upload" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="0%" HeaderStyle-BackColor="#20B2AA" ItemStyle-ForeColor="Black">
                                                <ItemTemplate>
                                                    <asp:Label ID="path" runat="server" Text='<%# Eval("path") %>' ForeColor="Black"> </asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="30%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:CommandField ButtonType="Link" ShowDeleteButton="true" ShowEditButton="false" HeaderText="Action" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#20B2AA" ItemStyle-ForeColor="Black"
                                                ItemStyle-Width="150" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Button1" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>

