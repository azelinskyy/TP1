
var gridModel = function (getDataFunction) {
    var self = this;

    self.reloadData = getDataFunction;
    var requestOptions = {
        pageIndex: ko.observable(1),
        pageSize: ko.observable(10),
        sortField: ko.observable(''),
        sortOrder: ko.observable('Desc'),
    };

    self.searchOptions = ko.observable(requestOptions),
    self.totalRows = ko.observable(0),
    self.totalPages = ko.observable(0),
    self.requestedPage = ko.observable(0),

    // navigation functionality
    self.selectFirst = function () {
        self.validateAndReloadGrid(1);
    };

    self.selectLast = function () {
        self.validateAndReloadGrid(self.totalPages());
    };

    self.selectNext = function () {
        var newPageValue = self.searchOptions().pageIndex() + 1;
        self.validateAndReloadGrid(newPageValue);
    };

    self.selectPrevious = function () {
        var newPageValue = self.searchOptions().pageIndex() - 1;
        self.validateAndReloadGrid(newPageValue);
    };

    self.checkRange = function (newValue) {
        return newValue > 0 || newValue <= self.searchOptions().pageIndex();
    };

    self.validateAndReloadGrid = function (newPageValue) {
        checkRange(newPageValue);
        self.searchOptions().pageIndex(newPageValue);
        self.reloadGrid();
    };

    self.reloadGrid = function () {
        self.reloadData(self.searchOptions());
    };
};
