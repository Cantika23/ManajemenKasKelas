function GetDropDownValue(_url, objectid) {
    $.ajax({
        url: _url,
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            var html = "";
            if (result.Data != null) {
                $("#" + objectid + "").val("");
                //var html = "";
                for (var i = 0; i < result.Data.length; i++) {
                    if (i == 0)
                        html += "<option value=''>Pilih...</option>"

                    html += "<option value='" + result.Data[i].Id + "'>" + result.Data[i].Description + "</option>"
                }
                //$("#" + objectid + "").html(html);
            }
            else {
                html = "<option value=''>Pilih...</option>"
            }
            $("#" + objectid + "").html(html);
        },
        failure: function (response) {
            alert(response.d);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jQuery.parseJSON(jqXHR.responseText));
        },
        async: false,
        processData: false
    });
}
