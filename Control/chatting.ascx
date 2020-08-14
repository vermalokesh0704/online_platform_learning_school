<%@ Control Language="C#" AutoEventWireup="true" CodeFile="chatting.ascx.cs" Inherits="Control_chatting" %>

<style type="text/css">
    .divsc {
        height: 500px;
        overflow-y: auto;
    }

    hr {
        border: 0;
        width: 100%;
        background-color: #20B2AA;
        height: 1px;
    }

    .rightt {
        float: right;
        text-align: right;
    }

    #footerr {
        position: fixed;
        bottom: 0;
        width: 80%;
    }
</style>
  <section class="page-title  parallax" data-jarallax='{"speed": 0.0}' style="background-image: url(../images/pattern/pattern-bg.png);">

    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="page-title-name">
                    <h1 style="color:#20B2AA;">Chatting Window </h1>
                      </div>
                    <p style="color:black;">
                        Individualizing the case is essential to prescribe the exact remedy for your symptoms. The success of the prescription depends largely on your ability to describe your symptoms.
                    </p>
                    <p style="color:black;">
NOTE – whatever is not as it should be is a symptom and must be recorded.
                    </p>
              
            </div>
        </div>
    </div>
</section>
<section class="process-list white-bg page-section-pt" style="padding-bottom: 100px;">
    <div class="container">
        <div class="row ">
            <div class="col-sm-12">
                <asp:Literal runat="server" ID="Literal1"></asp:Literal>
            </div>
        </div>
    </div>
</section>
<section class="contact white-bg page-section-ptb" runat="server" id="chhaatt">
    <div class="container">
        <div class="row ">
            <div class="col-sm-12">
                <hr />
                <br />
                <div class="contact-form clearfix">
                    <div class="col-sm-8">
                        <asp:TextBox ID="Txt_subject" autocomplete="off" CssClass="form-control" placeholder="Enter Your Subject" runat="server" MaxLength="99"></asp:TextBox>
                    </div>
                </div>
                <div class="contact-form clearfix">
                    <div class="col-sm-8">
                        <asp:TextBox ID="txt_Message" autocomplete="off" CssClass="form-control" placeholder="Enter Your Message*" TextMode="MultiLine" Rows="5" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="form_error" ID="RequiredFieldValidator13" ValidationGroup="a" runat="server" ControlToValidate="txt_Message" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-2">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </div>
                    <br />
                    <br />
                    <div class="col-sm-2">
                        <asp:Button ID="message" runat="server" CssClass="button" ValidationGroup="a" Text="Send" OnClick="message_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
