$(document).ready(function() {
    var cookie = document.cookie;
    //   alert(!cookie);
    if (cookie) {
        $("#user_information").show();
        $("#user_information").text($('#info_label').text());

    }

});
$('.persianDataInput').persianDatepicker({
    format: 'YYYY/MM/DD',
    autoClose: true,
    initialValue: false,
    observer: true
});


$(document).on('keydown',
    '.numeric',
    function(e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 40)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });

$(document).on('keydown',
    '.farsi_no_number',
    function(e) {
        console.log(e.key);
        if (e.key == 'Alt' || e.key == 'Shift' || e.key == 'Tab' || e.key == 'Backspace')
            return;
        if (!e.key.match(/^[ ا آ ئ ب پ ت ث ج چ ح خ د ذ ر ز ژ س ش ص ض ط ظ ع غ ف ق ک گ ل م ن و ه ی]+$/)) {
            e.preventDefault();
        }
    });

$(document).on('keydown',
    '.farsi',
    function(e) {
        console.log(e.key);
        if (e.key == 'Alt' || e.key == 'Shift' || e.key == 'Tab' || e.key == 'Backspace')
            return;
        if (!e.key.match(/^[0-9 ا آ ئ ب پ ت ث ج چ ح خ د ذ ر ز ژ س ش ص ض ط ظ ع غ ف ق ک گ ل م ن و ه ی]+$/)) {
            e.preventDefault();
        }
    });

$(document).on('keydown',
    '.engelish',
    function(e) {
        console.log(e.key);
        if (e.key == 'Alt' || e.key == 'Shift' || e.key == 'Tab')
            return;
        if (!e.key.match(/^[0-9 a-z A-Z]+$/)) {
            e.preventDefault();
        }
    });
window.setTimeout(function() {
        $(".alert").fadeTo(500, 0).slideUp(500,
            function() {
                $(this).remove();
            });
    },
    2000);

$(document).ready(function() {

    $("#Province").change(function() {
        var id = $(this).val();
        $("#CityItem").empty();
        $.get("City_Bind",
            { state_id: id },
            function(data) {
                var v = "<option>شهر را انتخاب کنید</option>";
                $.each(data,
                    function(i, v1) {
                        v += "<option value=" + v1.value + ">" + v1.text + "</option>";
                    });
                $("#CityItem").html(v);
            });
    });
});

$(".TitleType").click(function(e) {
    e.preventDefault();
    var _url = '@Url.Action("SelectTable", "Home")';

    $.ajax({
        type: "POST",
        url: _url,
        data: { uid: $(this).prop("id") },


        //data: {
        //    id: $(this).id,
        //    access_token: $("#rel").val()
        //},
        success: function(result) {
            //   window.location.reload(true);
            // $("#div1").load("#div1 > *");
            $("#div1").html(result);
        },
        error: function(result) {
            alert('error');
        }
    });
});