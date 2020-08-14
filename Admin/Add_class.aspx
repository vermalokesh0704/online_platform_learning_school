<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_admin.master" AutoEventWireup="true" CodeFile="Add_class.aspx.cs" Inherits="Admin_Add_class" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <style type="text/css">
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

        .pad {
            padding-left: 50px;
        }
    </style>
    <section class="page-title  parallax" data-jarallax='{"speed": 0.0}' style="background-image: url(../images/pattern/pattern-bg.png);">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="page-title-name">
                        <h1 style="color: #20B2AA;">Add Class</h1>
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
                                        <div class="section-field mb-20 col-sm-6">
                                            <h5>Class <span class="form_error">* </span></h5>
                                            <asp:TextBox ID="txt_Heading" autocomplete="off" CssClass="form-control" placeholder="Enter Class Name" runat="server" MaxLength="49"></asp:TextBox>
                                            <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator13" ValidationGroup="a" runat="server" ControlToValidate="txt_Heading" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="section-field mb-20 col-sm-6">
                                            <h5><span class="form_error">&nbsp; </span></h5>
                                            <asp:Button ID="submit_review" runat="server" CssClass="button" ValidationGroup="a" Text="Submit" OnClick="submit_review_Click" />
                                        </div>
                                    </div>
                                    <hr />
                                    <br />
                                </div>
                            </div>
                            <div class="contact-form clearfix">
                                <div class="section-field textarea">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Class_id"
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
                                            <asp:TemplateField HeaderText="Class Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="0%" HeaderStyle-BackColor="#20B2AA" ItemStyle-ForeColor="Black">
                                                <ItemTemplate>
                                                    <asp:Label ID="Class_Name" runat="server" Text='<%# Eval("Class_Name") %>' ForeColor="Black"> </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Class_Name") %>' ForeColor="Black"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="50%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" HeaderText="Action" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-BackColor="#20B2AA" ItemStyle-ForeColor="Black"
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
    </asp:UpdatePanel>

</asp:Content>

