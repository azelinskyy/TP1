ko.bindingHandlers.datepicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var options = allBindingsAccessor().datepicker || {};
        var dateInput = $(element);
        dateInput.datepicker(options);

        dateInput.next('.btn').click(function () {
            $(document).ready(function () {
                dateInput.datepicker().focus();
            });
        });
    }
};
