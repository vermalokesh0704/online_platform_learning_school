﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageonline_user_review.master" AutoEventWireup="true" CodeFile="website_review.aspx.cs" Inherits="online_user_website_review" %>

<%@ Register Src="~/Control/website_review.ascx" TagPrefix="uc1" TagName="PageStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <uc1:PageStatus runat="server" ID="PageStatus" />
</asp:Content>

