function gridModel(getDataFunction, rowCount, dataToUpdate1) {
    var self = this;

    self.itemPerPage = [10, 20, 30, 40, 50];

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
        return Math.ceil(self.totalRows() / self.searchOptions().pageSize());
    };
    self.requestedPage = ko.observable(0),

    // navigation functionality
    self.selectFirst = function (dataToUpdate) {
        self.validateAndReloadGrid(1, dataToUpdate);
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
    
    self.searchOptions().pageSize.subscribe(function (item) {
        self.reloadGrid();
    });

    function checkRange(newValue) {
        return newValue > 0 && newValue <= self.totalPages();
    };

    self.validateAndReloadGrid = function (newPageValue) {
        if (checkRange(newPageValue)) {
            self.searchOptions().pageIndex(newPageValue);
            self.reloadGrid();
        }
    };

    self.reloadGrid = function () {
        self.reloadData(self.searchOptions(), dataToUpdate1, self.totalRows);
    };
};
