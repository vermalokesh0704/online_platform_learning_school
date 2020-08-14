<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageonline_user.master" AutoEventWireup="true" CodeFile="terms_and_conditions.aspx.cs" Inherits="online_user_terms_and_conditions" %>
<%@ Register Src="~/Control/terms_and_conditions.ascx" TagPrefix="uc1" TagName="PageStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <uc1:PageStatus runat="server" ID="PageStatus" />
</asp:Content>

