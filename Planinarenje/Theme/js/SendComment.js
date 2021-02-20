function AjaxCallCommentArea(url, data, method, returnPlace) {
    $.ajax({
        url: url,
        data: data,
        method: method,
        success: function (data) {
            if (data != null) {
                placeCommentsLocal.innerHTML = data;
            }
        },
        error: function (data) {
            if (data != null) {
                placeCommentsLocal.innerHTML = data;
            }
        }

    })
}