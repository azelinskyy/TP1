function initSpinner() {
    var spinnerDiv = $("#spinner");
    $(document).bind("ajaxSend", function () {
        spinnerDiv.show();
    }).bind("ajaxStop", function () {
        spinnerDiv.hide();
    }).bind("ajaxError", function () {
        spinnerDiv.hide();
    });
}