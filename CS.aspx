<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CS.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />
    <hr />
    <asp:DataList ID="DataList1" Visible="true" runat="server" AutoGenerateColumns="false"
        RepeatColumns="2" CellSpacing="5">
        <ItemTemplate>
            <u>
                <%# Eval("Name") %></u>
            <hr />
            <video id="VideoPlayer" src='<%# Eval("video_id", "File.ashx?Id={0}") %>' controls="true"
                width="300" height="300" loop="true" />
        </ItemTemplate>
    </asp:DataList>
    </form>
</body>
</html>
