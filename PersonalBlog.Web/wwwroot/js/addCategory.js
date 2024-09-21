$(document).ready(function () {
    $('#exampleModalCenter').on('shown.bs.modal', function () {
        $('#categoryName').focus();
    });
    
    $('#btnSave').click(function () {
        var categoryName = $('#categoryName').val();

        $.ajax({
            url: app.Urls.addCategory,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ Name: categoryName }),
            success: function (data) {
                if (data.success) {
                    window.location.href = app.Urls.addArticle;
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
});