<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="Scz.MyWeb.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title></title>
  <script type="text/javascript" src="Scripts/jquery-3.3.1.js"></script>
  <script type="text/javascript" src="Scripts/jquery.blockUI.min.js"></script>

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

    #box {
      width: 500px;
      height: 400px;
      text-align: center;
      font-size: 50px;
      display: none;
      background-color: beige;
    }

    #demo {
      width: 100px;
      height: 24px;
      text-align: center;
    }

    #displayBox {
      display: none;
    }
  </style>

</head>
<body>

  <form id="form1" runat="server">
    <div>
      <input type="button" id="demo" value="点击弹出"></input>
      <div id="displayBox">
        这里是弹出层显示的内容！！！<br />
        <br />
        <br />
        <a href="javascript:void(0);" onclick="$.unblockUI();return false;" title="点击关闭">点击关闭</a>
      </div>

      <p>hello world!</p>
      <input type="button" id="box_btn" value="block UI 测试" />
      <br />
      <div id="box">block UI 测试！！</div>
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
       $('#demo').click(function(){
         $.blockUI({
             message: $('#displayBox'),
             css: {
                 width: '500px',
                 height: '100px',
                 backgroundColor: '#eee',
                 border: '1px solid red',
                 color: 'green',
                 textAlign: 'center',
                 cursor: 'default'
             }
         });

         setTimeout($.unblockUI, 2000);

      });

      $('#box_btn').click(function () {   //给box_btn绑定一个鼠标点击的事件  
        $.blockUI({    //当点击事件发生时调用弹出层  
          message: $('#box'),    //要弹出的元素box  
          css: {    //弹出元素的CSS属性  
            top: '50%',
            left: '50%',
            textAlign: 'left',
            marginLeft: '-320px',
            marginTop: '-145px',
            width: '600px',
            background: 'none'
          }
        });
        $('.blockOverlay').attr('title', '单击关闭').click($.unblockUI);   //遮罩层属性的设置以及当鼠标单击遮罩层可以关闭弹出层  
        $('.close').click($.unblockUI);  //也可以自定义一个关闭按钮来关闭弹出层  
      });


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
          var _li = "<li>" + "<span>" + content.id + " || " + content.birthDay + "</span></li>";
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
        var _li = "<li>" + "<span>" + content.id + " || " + content.birthDay + "</span></li>";
        _ul = _ul + _li + "</ul>";

        $(".myDiv").append(_ul);
      });

    })
  </script>


</body>

</html>
