<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: "POST",
                url: "Default4.aspx/GetCustomers",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (r) {
                    alert(r.d);
                },
                error: function (response) {
                    alert(r.d);
                }
            });
        });

        function OnSuccess(r) {
            
            //Parse the XML and extract the records.
            var customers = $($.parseXML(r.d)).find("Table");

            //Reference GridView Table.
            var table = $("[id*=gvCustomers]");

            //Reference the Dummy Row.
            var row = table.find("tr:last-child").clone(true);

            //Remove the Dummy Row.
            $("tr", table).not($("tr:first-child", table)).remove();

            //Loop through the XML and add Rows to the Table.
            $.each(customers, function () {
                var customer = $(this);
                $("td", row).eq(0).html($(this).find("Name").text());
                ///////////////
                var xhr = new XMLHttpRequest();
                xhr.responseType = 'blob';
                xhr.onload = function () {
                    var reader = new FileReader();
                    reader.onloadend = function () {
                        var byteCharacters = atob(reader.result.slice(reader.result.indexOf(',') + 1));
                        var byteNumbers = new Array(byteCharacters.length);
                        for (var i = 0; i < byteCharacters.length; i++) {
                            byteNumbers[i] = byteCharacters.charCodeAt(i);
                        }
                        var byteArray = new Uint8Array(byteNumbers);
                        var blob = new Blob([byteArray], { type: 'video/mp4' });
                        var url = URL.createObjectURL(blob);
                        document.getElementById('video').src = url;
                    }
                    reader.readAsDataURL(xhr.response);
                };
                xhr.open('GET', $(this).find("path").text());
                xhr.send();

                /////////////
             //   $("td", row).eq(1).html($(this).find("path").text());
                table.append(row);
                row = table.find("tr:last-child").clone(true);
            });
        }


       
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <video id="video" controls/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
