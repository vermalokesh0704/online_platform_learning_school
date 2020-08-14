<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageonline_user.master" AutoEventWireup="true" CodeFile="notes.aspx.cs" Inherits="online_user_notes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="../css/jquery-ui.css" />
    <!--================================= hi lokeh 
page-title-->
    <section class="page-title  parallax" data-jarallax='{"speed": 0.0}' style="background-image: url(../images/pattern/pattern-bg.png);">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="page-title-name">
                        <h1 style="color:#20B2AA;"><asp:Label runat="server" ID="class_name"></asp:Label></h1>
                    </div>
<%--                <ul class="page-breadcrumb">
                        <li hello style="color:#20B2AA;"><a style="color:#20B2AA;" href="https://www.youtube.com/watch?v=Nubucx_OQ5Q&t=3s" target="_blank"><span class="ti-youtube" style="color:black;"></span>&nbsp;&nbsp;Why Cell Salts</a> </li>
                    </ul>--%>
                </div>
            </div>
        </div>
    </section>
    <style type="text/css">
        .autocomplete_completionListElement {
            margin: 0px !important;
            z-index: 99999 !important;
            background-color: ivory;
            color: windowtext;
            border: buttonshadow;
            border-width: 1px;
            border-style: solid;
            cursor: 'default';
            overflow: auto;
            height: 200px;
            text-align: left;
            left: 0px;
            list-style-type: none;
        }
        /* AutoComplete highlighted item */
        .autocomplete_highlightedListItem {
            z-index: 99999 !important;
            background-color: #ffff99;
            color: black;
            padding: 1px;
            cursor: hand;
        }
        /* AutoComplete item */
        .autocomplete_listItem {
            z-index: 99999 !important;
            background-color: window;
            color: windowtext;
            padding: 1px;
            cursor: hand;
        }

        .lol {
            background-color: black;
            border-color: black;
        }


        .page-section-ptb {
            padding: 8px 0px;
        }

        .contact-form .form-control {
            position: relative;
            width: 100%;
            margin-bottom: 0px;
        }
    </style>
    <!--=================================
page-title -->
    <script type="text/javascript">
        $(document).ready(function () {
            SearchText();
        });

        var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
        prmInstance.add_endRequest(function () {
            SearchText();
        });

        function SearchText() {
            $('#<%= txtManufacturing_Name.ClientID %>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "notes.aspx/GetMainManufactureService",
                        data: "{ 'Desc': '" + request.term + "'}",
                        dataType: "json",
                        success: function (data) {
                            if (data.d.length > 0) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('#')[0],
                                        val: item.split('#')[1]
                                    }
                                }));
                            }
                            else {
                                response([{ label: 'No results found.', val: -1 }]);
                            }
                        },
                        error: function (result) {
                            alert('There is a problem processing your request');
                        }
                    });
                },
                select: function (event, ui) {
                    if (ui.item.val == -1) {
                        return false;
                    }

                    var v = document.getElementById("ctl00_ContentPlaceHolder1_code");
                    v.value = ui.item.val;
                }
            });
        }

        function ShowCurrentTime() {
            PageMethods.GetCurrentTime("A", OnSuccess);
        }
        function OnSuccess(response, userContext, methodName) {
            document.getElementById('myId').innerHTML = response;
        }
    </script>
    <asp:HiddenField ID="code" runat="server" />
    <section class="page-section-ptb theme-bg">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="contact-form clearfix " >
                        <div class="col-sm-10">
                            <asp:TextBox ID="TextBox1" placeholder="e.g. Topic name" CssClass="form-control" type="search" MaxLength="50" runat="server" ValidationGroup="a" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtManufacturing_Name" placeholder="e.g. Topic name" CssClass="form-control" type="search" MaxLength="50" runat="server" ValidationGroup="a"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <asp:Button ID="search" runat="server" CssClass="button medium lol" Text="Search" OnClick="search_Click" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="page-section-ptb">
        <div class="container">
            <div class="col-sm-12">
                <h3 class="text-center">Search By A-Z</h3>
                <nav>
                    <ul class="pagination">
                        <li>
                            <asp:LinkButton runat="server" ID="a_link" OnClick="a_link_Click" CausesValidation="false" Text="A"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton1" OnClick="b_link_Click" CausesValidation="false" Text="B"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton2" OnClick="c_link_Click" CausesValidation="false" Text="C"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton3" OnClick="d_link_Click" CausesValidation="false" Text="D"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton4" OnClick="e_link_Click" CausesValidation="false" Text="E"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton5" OnClick="f_link_Click" CausesValidation="false" Text="F"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton6" OnClick="g_link_Click" CausesValidation="false" Text="G"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton7" OnClick="h_link_Click" CausesValidation="false" Text="H"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton8" OnClick="i_link_Click" CausesValidation="false" Text="I"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton9" OnClick="j_link_Click" CausesValidation="false" Text="J"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton10" OnClick="k_link_Click" CausesValidation="false" Text="K"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton11" OnClick="l_link_Click" CausesValidation="false" Text="L"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton12" OnClick="m_link_Click" CausesValidation="false" Text="M"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton13" OnClick="n_link_Click" CausesValidation="false" Text="N"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton14" OnClick="o_link_Click" CausesValidation="false" Text="O"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton15" OnClick="p_link_Click" CausesValidation="false" Text="P"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton16" OnClick="q_link_Click" CausesValidation="false" Text="Q"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton17" OnClick="r_link_Click" CausesValidation="false" Text="R"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton18" OnClick="s_link_Click" CausesValidation="false" Text="S"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton19" OnClick="t_link_Click" CausesValidation="false" Text="T"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton20" OnClick="u_link_Click" CausesValidation="false" Text="U"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton21" OnClick="v_link_Click" CausesValidation="false" Text="V"></asp:LinkButton>

                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton22" OnClick="w_link_Click" CausesValidation="false" Text="W"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton23" OnClick="x_link_Click" CausesValidation="false" Text="X"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton24" OnClick="y_link_Click" CausesValidation="false" Text="Y"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton25" OnClick="z_link_Click" CausesValidation="false" Text="Z"></asp:LinkButton>
                        </li>
                    </ul>
                </nav>
            </div>

        </div>
    </section>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
        <ContentTemplate>
            <section class="page-section-ptb">
                <div class="container">
                    <div class="row mt-10">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <div class="accordion gray plus-icon round mb-30">
                                <asp:Literal runat="server" ID="literal1"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </ContentTemplate>

    </asp:UpdatePanel>
    <section id="raindrops" class="raindrops" style="height: 50px;"></section>
    <section class="action-box theme-bg full-width">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <h3><strong>Disclaimer  </strong></h3>
                    <p>The Hogwarts Institute Website is for educational and informational purposes only.  Information contained in this website can and will change without notice.  The institute shall not be liable for any special, incidental, or consequential damages resulting from the use of this website.  
 
Every effort is made to assure that the most accurate and current information is posted on this site.  The institute does not guarantee this website is free from typographical errors or inadvertently inaccurate information.  
 
The institute makes no representations or warranties regarding the condition or functionality of this website, its suitability for use, or that this web service will be uninterrupted or error-free. </p>

                </div>
            </div>
        </div>
    </section>
</asp:Content>

