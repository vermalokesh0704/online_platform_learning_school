﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageonline_user.master" AutoEventWireup="true" CodeFile="aboutus.aspx.cs" Inherits="online_user_aboutus" %>

<%@ Register Src="~/Control/aboutus.ascx" TagPrefix="uc1" TagName="PageStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <uc1:PageStatus runat="server" ID="PageStatus" />
</asp:Content>

