function gridModel(getDataFunction, rowCount) {
    var self = this;

    var requestOptions = {
        pageIndex: ko.observable(1),
        pageSize: ko.observable(10),
        sortField: ko.observable(''),
        sortOrder: ko.observable('Desc'),
    };

    self.reloadData = getDataFunction;
    self.searchOptions = ko.observable(requestOptions);
    self.totalRows = ko.observable(rowCount);

    self.totalPages = function () {
        return Math.round(self.totalRows() / self.searchOptions().pageSize());
    };
    self.requestedPage = ko.observable(0),

    // navigation functionality
    self.selectFirst = function (dataToUpdate) {
        self.validateAndReloadGrid(1, dataToUpdate);
    };

    self.selectLast = function (dataToUpdate) {
        self.validateAndReloadGrid(self.totalPages(), dataToUpdate);
    };

    self.selectNext = function (dataToUpdate) {
        var newPageValue = self.searchOptions().pageIndex() + 1;
        self.validateAndReloadGrid(newPageValue, dataToUpdate);
    };

    self.selectPrevious = function (dataToUpdate) {
        var newPageValue = self.searchOptions().pageIndex() - 1;
        self.validateAndReloadGrid(newPageValue, dataToUpdate);
    };

    function checkRange(newValue) {
        return newValue > 0 && newValue <= self.totalPages();
    };

    self.validateAndReloadGrid = function (newPageValue, dataToUpdate) {
        if (checkRange(newPageValue)) {
            self.searchOptions().pageIndex(newPageValue);
            self.reloadGrid(dataToUpdate);
        }
    };

    self.reloadGrid = function (dataToUpdate) {
        self.reloadData(self.searchOptions(), dataToUpdate, self.totalRows);
    };
};
