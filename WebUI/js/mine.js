$.ajax({
    url: "../handler/pubulic.ashx",
    type: "POST",
    data: {
        test1: test1,
        test2: test2,
    },
    success: function (res_text) {
        alert(res_text);
        if (res_text == "OK") {
            location.href = "index.html";
        }
    },
    error: function (res_text) {
        error_mess = res_text.responseText
        error_mess = error_mess.replace(/\s/g, " ");
        error_mess = error_mess.replace(/.+<title>(.+)<\/title>.+/g, "$1");
        alert("服务器错误：\n" + error_mess);
        //document.getElementsByTagName("html")[0].innerHTML=res_text.responseText;
    }
});

//刷新页面
window.location.reload();

//后退
location.href = document.referrer;

function getURLParameter(name) {
    return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [, ""])[1].replace(/\+/g, '%20')) || null;
}
var type = getURLParameter("type");

//对话框
if (confirm("确定?")) {
    alert("确定");
}
