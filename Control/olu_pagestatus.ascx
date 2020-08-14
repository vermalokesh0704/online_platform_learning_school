<%@ Control Language="C#" AutoEventWireup="true" CodeFile="olu_pagestatus.ascx.cs" Inherits="Control_olu_pagestatus" %>
<style type="text/css">
    textarea {
        resize: none;
    }

    .not-active {
        pointer-events: none;
        cursor: default;
    }

    .active1 {
        pointer-events: none;
        cursor: default;
    }

    .active {
        pointer-events: all;
        cursor: default;
    }
</style>
<script type="text/javascript">
    function part1() {
        window.location.href = "../online_user/profile_update.aspx";
    }
    function part2() {
        window.location.href = "../online_user/profile_update_part2.aspx";
    }
    function part3() {
        window.location.href = "../online_user/profile_update_part3.aspx";
    }
</script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="stepwizard">
            <div class="stepwizard-row">
                <div class="stepwizard-step">
                    <button type="button" class="btn btn-default btn-circle" id="button1" onclick="part1()" runat="server">1</button>
                    <p>Part 1 </p>
                </div>
             <%--   <div class="stepwizard-step">
                    <button type="button" class="btn btn-default btn-circle" id="button2" onclick="part2()" runat="server">2</button>
                    <p>Part 2</p>
                </div>
                <div class="stepwizard-step">
                    <button type="button" class="btn btn-default btn-circle" id="button3" onclick="part3()" runat="server">3</button>
                    <p>Part 3</p>
                </div>--%>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
