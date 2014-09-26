window.reportApp = window.reportApp || {};
window.reportApp.eW = window.reportApp.eW || {};
window.reportApp.eW.Services = window.reportApp.eW.Services || {};

window.reportApp.eW.Services.AjaxPostCall = function (fullUrl, dataObj, callbackFunction) {
    $.ajax({
        url: fullUrl,
        cache: false,
        type: 'post',
        data: dataObj,
        success: function (data) { callbackFunction(window.reportApp.eW.Utils.GetJson(data)); },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("error :" + XMLHttpRequest.responseText);
            alert('There was an error in performing this operation.');
        }
    });
};

window.reportApp.eW.DataGridAjax = (function () {
    var getDataUrl = '';
    function DataGridAjax(url, pageSize) {
        var self = this;
        getDataUrl = url;
        self.GridParams = {
            pageIndex: ko.observable(1),
            pageSize: ko.observable(pageSize),
            sortField: ko.observable(''),
            sortOrder: ko.observable(0),
            totalRows: ko.observable(0),
            totalPages: ko.observable(0),
            requestedPage: ko.observable(0),
            pageSizeOptions: [5, 10, 20, 30, 50, 100]
        };
        self.DataRows = ko.observableArray();
        self.SelectedPageSizeOption = ko.observable(pageSize);
        self.GridParams.requestedPage.subscribe(self.FlipPageDirect, self);
        self.SelectedPageSizeOption.subscribe(self.ChangePageSize, self);
    }
    DataGridAjax.prototype.GetData = function () {
        var self = this;
        window.reportApp.eW.Services.AjaxPostCall(getDataUrl, self.GridParams, $.proxy(self.OnGetDataDone, this));
    };
    DataGridAjax.prototype.OnGetDataDone = function (data) {
        var self = this;
        self.DataRows(window.reportApp.eW.Utils.GetJson(data.result));
        self.GridParams.totalRows(window.reportApp.eW.Utils.GetJson(data.totalRows));
        var totalPages = Math.ceil(self.GridParams.totalRows() / self.GridParams.pageSize());
        self.GridParams.totalPages(totalPages);
        self.GridParams.requestedPage(self.GridParams.pageIndex());
    };
    DataGridAjax.prototype.FlipPage = function (newPageNo) {
        var self = this;
        if (parseInt(newPageNo) > 0 && parseInt(newPageNo) <= self.GridParams.totalPages()) {
            self.GridParams.pageIndex(newPageNo);
            self.GetData();
        }
    };
    DataGridAjax.prototype.FlipPageDirect = function (newValue) {
        var self = this;
        var ri = parseInt(self.GridParams.requestedPage());
        if (ri == NaN) {
            self.GridParams.requestedPage(self.GridParams.pageIndex());
            return;
        }
        if (ri > 0 && ri <= self.GridParams.totalPages()) {
            self.GridParams.pageIndex(ri);
            self.GetData();
            return;
        }
        self.GridParams.requestedPage(self.GridParams.pageIndex());
        return;
    };
    DataGridAjax.prototype.ChangePageSize = function () {
        var self = this;
        if (self.GridParams.pageSize() != self.SelectedPageSizeOption()) {
            self.GridParams.pageSize(self.SelectedPageSizeOption());
            self.GridParams.pageIndex(1);
            self.GridParams.requestedPage(1);
            self.GetData();
        }
    };
    DataGridAjax.prototype.Sort = function (col) {
        var self = this;
        if (self.GridParams.sortField() === col) {
            if (self.GridParams.sortOrder() === 0) {
                self.GridParams.sortOrder(1);
            } else {
                self.GridParams.sortOrder(0);
            }
        } else {
            self.GridParams.sortOrder(0);
            self.GridParams.sortField(col);
        }
        self.GetData();
    };
    return DataGridAjax;
})();

window.reportApp.eW.Utils = window.reportApp.eW.Utils || {};
window.reportApp.eW.Utils.GetJson = function (data) {
    if (data == '' || data == 'undefined') return null;
    return (JSON && JSON.parse(data) || $.parseJSON(data));
};