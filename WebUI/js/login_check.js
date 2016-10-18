
$(function () {
    $.ajax({
        url: "../ashx/login_check.ashx",
        type: "POST",
        success: function (res_text) {
            if (res_text == "NO") {
                location.href = "login.aspx";
                return;
            }
            document.getElementById("username").innerHTML = res_text;
        },
        error: function (res_text) {
            alert("服务器发生错误！");
            location.href = "login.aspx";
        }
    });
})

