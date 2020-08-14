<%@ Control Language="C#" AutoEventWireup="true" CodeFile="website_review.ascx.cs" Inherits="Control_website_review" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .Star {
        background-image: url(../images/Star.gif);
        height: 17px;
        width: 17px;
    }

    .WaitingStar {
        background-image: url(../images/WaitingStar.gif);
        height: 17px;
        width: 17px;
    }

    .FilledStar {
        background-image: url(../images/FilledStar.gif);
        height: 17px;
        width: 17px;
    }

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

    .pad {
        padding-left: 50px;
    }
</style>
<script type="text/javascript">
    var count = 400;
    function limitAddress() {
        var tex = document.getElementById("ContentPlaceHolder1_PageStatus_txt_review").value;
        var len = tex.length;
        if (len > count) {
            tex = tex.substring(0, count);
            document.getElementById("ContentPlaceHolder1_PageStatus_txt_review").value = tex;
            return false;
        }
        document.getElementById("ContentPlaceHolder1_PageStatus_limit1").innerHTML = count - len;
    }
</script>
<section class="page-title  parallax" data-jarallax='{"speed": 0.0}' style="background-image: url(../images/pattern/pattern-bg.png);">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="page-title-name">
                    <h1 style="color: #20B2AA;">Review</h1>
                </div>
            </div>
        </div>
    </div>
</section>

<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</cc1:ToolkitScriptManager>
<asp:UpdatePanel runat="server" ID="updatepanel1">
    <ContentTemplate>
        <section class="white-bg page-section-ptb position-re">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12">
                        <div class="section-title">
                            <h2 class="title-effect">Write Your Review</h2>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="isotope columns-1 popup-gallery">
                            <div class="grid-item photography branding">
                                <div class="contact-form clearfix">
                                    <cc1:Rating ID="Rating1" AutoPostBack="true" OnChanged="OnRatingChanged" runat="server"
                                        StarCssClass="Star" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star"
                                        FilledStarCssClass="FilledStar">
                                    </cc1:Rating>

                                    <asp:Label ID="lblRatingStatus" runat="server" CssClass="pad" Text=""></asp:Label>
                                </div>
                                <br />
                                <div class="contact-form clearfix">
                                    <h5>Heading <span class="form_error">* </span></h5>
                                    <asp:TextBox ID="txt_Heading" autocomplete="off" CssClass="form-control" placeholder="Enter Heading" runat="server" MaxLength="49"></asp:TextBox>
                                    <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator13" ValidationGroup="a" runat="server" ControlToValidate="txt_Heading" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <h5>Review <span class="form_error">* </span></h5>
                                <div class="contact-form clearfix">
                                    <div class="section-field textarea">
                                        <asp:TextBox ID="txt_review" OnKeyUp="limitAddress();" autocomplete="off" TextMode="MultiLine" Rows="3" CssClass="form-control lol" placeholder="Enter Review" runat="server" MaxLength="299"></asp:TextBox>
                                        <asp:Label ID="limit1" CssClass="alig" runat="server" ForeColor="Maroon" Text="400"></asp:Label>
                                        <asp:Label ID="lblChar1" CssClass="alig" runat="server" ForeColor="Maroon" Text="character limit"></asp:Label>
                                        <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator1" ValidationGroup="a" runat="server" ControlToValidate="txt_review" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <hr />
                                <br />
                                <div class="contact-form clearfix">
                                    <div class="section-field">
                                    </div>
                                    <div class="section-field submit-button" style="margin-left: 45%">
                                        <asp:Button ID="submit_review" runat="server" CssClass="button" ValidationGroup="a" Text="Submit" OnClick="submit_review_Click" />
                                    </div>
                                    <div class="section-field">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="contact-form clearfix">
                            <div class="section-field textarea">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="status"
                                    OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDataBound="GridView2_RowDataBound" Width="100%" CssClass="table table-1 table-bordered table-striped table-2 lolll" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                    EmptyDataText="No Record to show." PageSize="50">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No." ItemStyle-Width="5%" HeaderStyle-BackColor="#20B2AA" ItemStyle-ForeColor="Black">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="10%" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rating" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="0%" HeaderStyle-BackColor="#20B2AA" ItemStyle-ForeColor="Black">
                                            <ItemTemplate>
                                                <asp:Label ID="rating" runat="server" Text='<%# Eval("Rating") %>' ForeColor="Black"> </asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="50%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="headline" HeaderText="Headline" ItemStyle-Width="20%" SortExpression="headline" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="Black" HeaderStyle-HorizontalAlign="Left"  HeaderStyle-BackColor="#20B2AA" />
                                        <asp:BoundField DataField="review" HeaderText="Review" ItemStyle-Width="50%" SortExpression="review" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="Black" HeaderStyle-HorizontalAlign="Left"  HeaderStyle-BackColor="#20B2AA" />
                                         <asp:TemplateField HeaderText="Rating" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%" HeaderStyle-BackColor="#20B2AA" ItemStyle-ForeColor="Black">
                                            <ItemTemplate>
                                                <asp:Literal runat="server" ID="Literal2"></asp:Literal>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" ItemStyle-Width="20%" HeaderStyle-BackColor="#20B2AA" ItemStyle-ForeColor="Black">
                                            <ItemTemplate>
                                                <asp:Label ID="status" runat="server" Text='<%#Eval("status_name") %>' ForeColor="Black"> </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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

