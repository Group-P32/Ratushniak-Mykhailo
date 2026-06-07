$(document).ready(function () {
    $("#btnLogin").click(function () {
        var nickName = $("#txtUserName").val();
        if (nickName) {
            var href = "/Chat?user=" + encodeURIComponent(nickName) + "&logOn=true";
            $("#LoginButton").attr("href", href).click();
            $("#UsernameText").text(nickName);
        }
    });
});

function LoginOnSuccess(result) {
    Scroll();
    ShowLastRefresh();
    setTimeout("Refresh();", 5000);

    $('#txtMessage').keydown(function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            $("#btnMessage").click();
        }
    });

    $("#btnMessage").click(function () {
        var text = $("#txtMessage").val();
        if (text) {
            var href = "/Chat?user=" + encodeURIComponent($("#Username").text());
            href = href + "&chatMessage=" + encodeURIComponent(text);
            $("#ActionLink").attr("href", href).click();
            $("#txtMessage").val("");
        }
    });

    $("#btnLogOff").click(function () {
        var href = "/Chat?user=" + encodeURIComponent($("#Username").text()) + "&logOff=true";
        $("#ActionLink").attr("href", href).click();
        document.location.href = "/Chat";
    });
}

function LoginOnFailure(result) {
    $("#Error").text(result.responseText);
    setTimeout("$('#Error').empty();", 2000);
}

function Refresh() {
    var href = "/Chat?user=" + encodeURIComponent($("#Username").text());
    $("#ActionLink").attr("href", href).click();
    setTimeout("Refresh();", 5000);
}

function ChatOnFailure(result) {
    $("#Error").text(result.responseText);
    setTimeout("$('#Error').empty();", 2000);
}

function ChatOnSuccess(result) {
    Scroll();
    ShowLastRefresh();
}

function Scroll() {
    var win = $('#Messages');
    if (win.length) {
        win.scrollTop(win[0].scrollHeight);
    }
}

function ShowLastRefresh() {
    var dt = new Date();
    var time = dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds();
    $("#LastRefresh").text("Останнє оновлення: " + time);
}