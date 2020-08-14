<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FAQ.aspx.cs" Inherits="FAQ" %>
<%@ Register Src="~/Control/FAQ.ascx" TagPrefix="uc1" TagName="PageStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
          <uc1:PageStatus runat="server" ID="PageStatus" />
</asp:Content>

