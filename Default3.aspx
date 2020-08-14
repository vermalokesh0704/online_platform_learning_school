<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default3.aspx.vb" Inherits="Default3" %>

<!DOCTYPE html>

<html>
<head>
</head>
<body>
     <%-- <video width="480" height="320" controls="controls" autoplay="autoplay" preload="auto" loop>
        <source src="Videos/What are the Odds (2020) Hindi 720p.mp4" type="video/mp4">
    </video>--%>
    <video src="Videos/What are the Odds (2020) Hindi 720p.mp4" id="video" controls="controls" autoplay="autoplay" preload="auto" loop></video>
  <%--  <script>
        window.URL = window.URL || window.webkitURL;

    


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
             //   var url = URL.createObjectURL(blob);
                var url = window.URL.createObjectURL(blob);
                document.getElementById('video').src = url;
            }
            reader.readAsDataURL(xhr.response);
        };
        xhr.open('GET', '/Videos/X-Men- Days Of Future Past - 'Wolverine Meets Beast' - Clip HD.mp4');
        xhr.send();
    </script>--%>
</body>
</html>

