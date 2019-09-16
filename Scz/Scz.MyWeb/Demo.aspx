<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="Scz.MyWeb.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-3.3.1.js"></script>
    <style type="text/css">
        .divUl {
        }

        .myDiv {
        }

            .myDiv ul {
                list-style: none;
            }

                .myDiv ul li {
                    float: left;
                    width: 300px;
                    font-size: 16px;
                    text-align: center;
                    height: 50px;
                }

        .divUl ul {
            list-style: none;
        }

            .divUl ul li {
                float: left;
                width: 300px;
            }

                .divUl ul li dl {
                    display: none;
                }

                    .divUl ul li dl dd {
                        float: left;
                        width: 40px;
                        border: 1px solid red;
                        display: inline;
                    }


                        .divUl ul li dl dd a {
                            width: 40px;
                            text-decoration: none;
                            color: #FF0000;
                        }

                            .divUl ul li dl dd a:hover {
                                color: #FF00FF;
                                cursor: pointer;
                            }

                            .divUl ul li dl dd a:visited {
                                color: #00FF00;
                            }

                            .divUl ul li dl dd a:active {
                                color: #00FF00;
                            }
    </style>

</head>
<body>

    <form id="form1" runat="server">
        <div>
            <p>hello world!</p>
            <asp:Label ID="lblMsg" runat="server" Text="你好！！"></asp:Label>
            <br />
            <asp:Label ID="lblDate" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnMsg" runat="server" Text="Button" />
            <br />
            <asp:Label ID="lblJson" runat="server" Text=""></asp:Label>

            <div class="myDiv"></div>
            <div class="divUl">
                <ul>
                    <li>
                        <dl>
                            <dd><a href="http://baidu.com" mykey="1111">1</a></dd>
                            <dd><a href="#" mykey="222">2</a></dd>
                            <dd><a href="http://qq.com" mykey="333">3</a></dd>
                        </dl>
                    </li>
                    <li>
                        <dl>
                            <dd><a href="#">11</a></dd>
                            <dd><a href="#">21</a></dd>
                            <dd><a href="#">31</a></dd>
                        </dl>
                    </li>
                    <li>
                        <dl>
                            <dd><a href="#">111</a></dd>
                            <dd><a href="#">211</a></dd>
                            <dd><a href="#">311</a></dd>
                        </dl>
                    </li>
                </ul>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        $(function () {
            var lbl = "#<%= lblMsg.ClientID %>";
            //alert($(lbl).html());

            var btn = "#<%= btnMsg.ClientID %>"
            $(btn).click(function () {

                $(".divUl dl").css("display", "block");

                //alert($(lbl).html());

                var jsonData = $(lbl).html();
                var jsonObj = $.parseJSON(jsonData);


                $.each(jsonObj, function (index, content) {
                    console.log(content);

                    var _ul = "<ul>";
                    var _li = "<li>" + "<span>" + content.Id + " || " + content.BirthDay + "</span></li>";
                    _ul = _ul + _li + "</ul>";

                    $(".myDiv").append(_ul);
                });

                return false;
            });

            $(".divUl dd").click(function () {
                alert($(this).find("a").attr("mykey"));
                alert($(this).html());

                window.open("http://sina.com.cn", "_blank");
            });


            var jsonData = $(lbl).html();
            var jsonObj = $.parseJSON(jsonData);

            $.each(jsonObj, function (index, content) {
                console.log(content);

                var _ul = "<ul>";
                var _li = "<li>" + "<span>" + content.Id + " || " + content.BirthDay + "</span></li>";
                _ul = _ul + _li + "</ul>";

                $(".myDiv").append(_ul);
            });

        })
    </script>


</body>

</html>
