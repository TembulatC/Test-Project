$(document).on('click', '#itemButton', function () {
    $.ajax({
        type: "GET",
        url: "/Home/AdminPage",
        contentType: "application/json; charset=utf-8",
        success: function () {
            document.getElementById("itemContent").style.display = "block";
            document.getElementById("clientContent").style.display = "none";
            document.getElementById("orderContent").style.display = "none";
        },
        error: function () {
            alert("Ошибка!");
        }
    });

    return false;
})

$(document).on('click', '#clientButton', function () {
    $.ajax({
        type: "GET",
        url: "/Home/AdminPage",
        contentType: "application/json; charset=utf-8",
        success: function () {
            document.getElementById("itemContent").style.display = "none";
            document.getElementById("clientContent").style.display = "block";
            document.getElementById("orderContent").style.display = "none";
        },
        error: function () {
            alert("Ошибка!");
        }
    });

    return false;
})

$(document).on('click', '#orderButton', function () {
    $.ajax({
        type: "GET",
        url: "/Home/AdminPage",
        contentType: "application/json; charset=utf-8",
        success: function () {
            document.getElementById("itemContent").style.display = "none";
            document.getElementById("clientContent").style.display = "none";
            document.getElementById("orderContent").style.display = "block";
        },
        error: function () {
            alert("Ошибка!");
        }
    });

    return false;
})