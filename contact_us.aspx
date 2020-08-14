<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="contact_us.aspx.cs" Inherits="contact_us" %>
<%@ Register Src="~/Control/contact_us.ascx" TagPrefix="uc1" TagName="PageStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <uc1:PageStatus runat="server" ID="PageStatus" />
</asp:Content>

