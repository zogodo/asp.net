<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebUI.web.login" %>

<!DOCTYPE html>
<html>
<head>
    <meta name="renderer" content="webkit" />
    <meta charset="utf-8" />
    <title>桂林电子科技大学到课率统计系统</title>
    <meta name="author" content="DeathGhost" />
    <link rel="stylesheet" type="text/css" href="../css/login.css" />
    <style>
        body {
            height: 100%;
            background: black;
            overflow: hidden;
        }

        canvas {
            z-index: -1;
            position: absolute;
        }
    </style>
    <script src="../js/jquery-3.0.0.min.js"></script>
    <script src="../js/verificationNumbers.js"></script>
    <script src="../js/Particleground.js"></script>
    <script src="../js/jquery.form.js"></script>
    <script>
        $(document).ready(function () {
            //粒子背景特效
            $('body').particleground({
                dotColor: '#5cbdaa',
                lineColor: '#5cbdaa'
            });

            // ajaxForm
            var options = {
                success: function (re_text) {
                    if (re_text == "OK") {
                        location.href = "index.aspx";
                    }
                    else if (re_text == "NO") {
                        alert("用户名或密码错误！");
                        var date = new Date();
                        var vcode = document.getElementById("code_img");
                        var vinput = document.getElementById("J_codetext");
                        vinput.value = "";
                        vinput.placeholder = "请输入验证码";
                        vcode.src = "verify_code.aspx?date=" + date;
                    }
                    else if (re_text == "no_verify") {
                        alert("验证码错误！");
                        //刷新验证码。。。
                        var date = new Date();
                        var vcode = document.getElementById("code_img");
                        var vinput = document.getElementById("J_codetext");
                        vinput.value = "";
                        vinput.placeholder = "验证码错误";
                        vcode.src = "verify_code.aspx?date=" + date;
                        document.getElementById("subm").value = "正在登陆。。。";
                    }
                },
                error: function (data) {
                    alert("服务器错误！");
                }
            };
            $("#login1").ajaxForm(options);
        });

        function check() {
            document.getElementById("subm").value = "正在登陆。。。";
            if (document.getElementById("usr").value == ""
                || document.getElementById("paw").value == "") {
                alert("用户名或密码不能为空！");
                document.getElementById("subm").value = "立即登陆";
                return false;
            }
            if (document.getElementById("J_codetext").value == "") {
                alert("验证码不能为空！");
                document.getElementById("subm").value = "立即登陆";
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form action="../ashx/login.ashx" id="login1" method="post" onsubmit="return check()">
        <dl class="admin_login">
            <dt>
                <strong>桂林电子科技大学到课率系统</strong>
                <em>GUET Attendance Statistics System</em>
            </dt>
            <dd class="user_icon">
                <input type="text" placeholder="账号" class="login_txtbx" name="username" id="usr"/>
            </dd>
            <dd class="pwd_icon">
                <input type="password" placeholder="密码" class="login_txtbx" name="password" id="paw"/>
            </dd>
            <dd class="val_icon">
                <div class="checkcode">
                    <input type="text" id="J_codetext" placeholder="验证码" maxlength="5" class="login_txtbx" name="code">
                    <img alt="验证码" src="verify_code.aspx" height="42" id="code_img" />
                </div>
            </dd>
            <dd>
                <input type="submit" value="立即登陆" class="submit_btn" id="subm"/>
            </dd>
            <dd>
            </dd>
        </dl>
    </form>
</body>
</html>

