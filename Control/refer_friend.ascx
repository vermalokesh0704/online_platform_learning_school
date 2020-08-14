<%@ Control Language="C#" AutoEventWireup="true" CodeFile="refer_friend.ascx.cs" Inherits="Control_refer_friend" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    textarea {
        resize: none;
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
    th {
    text-align: center;
}
</style>
<script type="text/javascript">
    var count = 500;
    function limitAddress() {
        var tex = document.getElementById("ContentPlaceHolder1_PageStatus_txt_address").value;
        var len = tex.length;
        if (len > count) {
            tex = tex.substring(0, count);
            document.getElementById("ContentPlaceHolder1_PageStatus_txt_address").value = tex;
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
                    <h1 style="color:#20B2AA;">Refer Friend</h1>
                </div>
                <p style="color:black;">How about sharing this with your dear ones? Your recommendation would be a step towards their well-being.</p>
            </div>
        </div>
    </div>
</section>
<section class="contact white-bg page-section-ptb">
    <div class="container">
        <%--    <div class="row text-center mb-50">
            <div class="col-md-offset-2 col-md-8">
                <div class="section-title">
                    <h6>let's join</h6>
                    <h2 class="title-effect">Refer Friends</h2>
                    <p>People influence people. Nothing influences people more than a recommendation from a trusted friend. A trusted referral influences people more than the best broadcast message.</p>
                </div>
            </div>
        </div>--%>
        <div class="row" style="padding-bottom: 200px;">
            <div class="col-sm-12">
                <div class="contact-form clearfix">
                    <div class="section-field">
                        <asp:TextBox ID="txt_first_name" autocomplete="off" CssClass="form-control" placeholder="Enter Your Friend Name*" runat="server" MaxLength="99"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator13" ValidationGroup="a" runat="server" ControlToValidate="txt_first_name" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                    <div class="section-field">
                        <asp:TextBox ID="mobile_no" autocomplete="off" CssClass="form-control" placeholder="Enter Your Friend Mobile No*" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator3" ValidationGroup="a" runat="server" ControlToValidate="mobile_no" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="a" Display="Dynamic" ID="RegularExpressionValidator1" CssClass="form_error" ControlToValidate="mobile_no" ValidationExpression="^[0-9]{10}" runat="server" ErrorMessage="Enter a valid 10 digit Mobile number" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        <cc1:FilteredTextBoxExtender TargetControlID="mobile_no" ID="FilteredTextBoxExtender6" FilterType="Numbers" runat="server"></cc1:FilteredTextBoxExtender>
                    </div>
                    <div class="section-field">
                        <asp:TextBox ID="email_id" autocomplete="off" CssClass="form-control" placeholder="Enter Your Friend Email id" runat="server" MaxLength="79"></asp:TextBox>
                        <%--   <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator4" ValidationGroup="a" runat="server" ControlToValidate="email_id" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ValidationGroup="a" Display="Dynamic" ID="RegularExpressionValidator3" ControlToValidate="email_id" CssClass="form_error" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ErrorMessage="Enter a valid Email" SetFocusOnError="True"></asp:RegularExpressionValidator>
                    </div>
                    <%--   <div class="section-field textarea">
                        <asp:TextBox ID="txt_address" autocomplete="off" TextMode="MultiLine" Rows="7" OnKeyUp="limitAddress();" CssClass="form-control lol" placeholder="Enter Message To Your Friend" runat="server" MaxLength="499"></asp:TextBox>
                        <asp:Label ID="limit1" CssClass="alig" runat="server" ForeColor="Maroon" Text="500"></asp:Label>
                        <asp:Label ID="lblChar1" CssClass="alig" runat="server" ForeColor="Maroon" Text="charleft"></asp:Label>
                        <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator12" ValidationGroup="a" runat="server" ControlToValidate="txt_address" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>--%>
                    <div class="section-field submit-button">
                        <asp:Button ID="refer_friend" runat="server" CssClass="button" ValidationGroup="a" Text="Refer Friend" OnClick="refer_friend_Click" />
                    </div>
                </div>
                  <br />
                <br />
                <h5>Refer History</h5>
                <hr />
                <br />
                <div class="contact-form clearfix">
                    <div class="section-field textarea">
                        <asp:GridView ID="Gridview1" GridLines="None" CssClass="table table-1 table-bordered table-striped table-2 lolll" runat="server"  AutoGenerateColumns="false" EmptyDataText="No Record to show.">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#20B2AA">
                                    <ItemTemplate>
                                        <asp:Label ID="TextBox3" Text='<%#Container.DataItemIndex+1%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" HeaderStyle-BackColor="#20B2AA" HeaderStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:Label ID="TextBox33" Text='<%# System.Web.HttpUtility.HtmlEncode( Eval("Name")) %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile No." HeaderStyle-BackColor="#20B2AA">
                                    <ItemTemplate>
                                        <asp:Label ID="TextBox333" Text='<%# System.Web.HttpUtility.HtmlEncode( Eval("mobile_no")) %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email Id" HeaderStyle-BackColor="#20B2AA" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="TextBox3333" Text='<%# System.Web.HttpUtility.HtmlEncode( Eval("email_id")) %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sending Time" HeaderStyle-BackColor="#20B2AA">
                                    <ItemTemplate>
                                        <asp:Label ID="TextBox33333" Text='<%# System.Web.HttpUtility.HtmlEncode( Eval("sendinddate")) %>' runat="server"></asp:Label>
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
