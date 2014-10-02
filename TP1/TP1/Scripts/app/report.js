function ReportViewModel() {

    //Make the self as 'this' reference
    var self = this;
    //Declare observable which will be bind with UI 
    self.Id = ko.observable("");
    self.DateAdded = ko.observable("");
    self.Title = ko.observable("");
    self.ZipCode = ko.observable("");
    self.DateFrom = ko.observable();
    self.DateTo = ko.observable();
    self.Email = ko.observable("");


    self.displayGrid = ko.observable(true);
    self.displayForm = ko.observable(false);
    self.displayExport = ko.observable(false);

    var project = {
        Id: self.Id,
        Name: self.Title,
        Price: self.ZipCode,
        Category: self.DateAdded
    };

    self.Grid = ko.observable();

    self.EditableItem = ko.observable();

    self.Project = ko.observable();
    self.Products = ko.observableArray();   // Contains the list of products
    self.Language = ko.observableArray();
    self.RowCount = ko.observable();

    self.LoadData = function (requestOptions) {
        // Initialize the view-model
        $.ajax({
            url: '/Report/GetReport',
            cache: false,
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            data: requestOptions,
            success: function (data) {
                var parsedData = $.parseJSON(data);
                self.Products($.parseJSON(parsedData.result)); //Put the response in ObservableArray
            }
        });
    };

    self.LoadData();

    self.changeDatesRange = function() {
        //// Place to refresh grid based on new dates range.
    };

    self.DateFrom.subscribe(self.changeDatesRange);
    self.DateTo.subscribe(self.changeDatesRange);

    //Add New Item
    self.create = function() {
        if (project.Name() != "" && project.Price() != "" && project.Category() != "") {
            $.ajax({
                url: '@Url.Action("AddProduct", "Product")',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(project),
                success: function(data) {
             
                }
            }).fail(
                function(xhr, textStatus, err) {
                    alert(err);
                });
        } else {
            alert('Please Enter All the Values !!');
        }
    };

    // Delete project
    self.delete = function(project) {
        if (confirm('Are you sure to Delete "' + project.Title + '" product ??')) {
            var id = project.Id;
            $.ajax({
                url: '/Report/DeleteProject',
                cache: false,
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                data: { id: id },
                success: function(data) {
                    self.LoadData();
                }
            }).fail(
                function(xhr, textStatus, err) {
                    alert(err);
                });
        }
    };

    // Edit project details
    self.add = function() {
        self.changeVisibility(false);
    };

    // Edit project details
    self.edit = function(project) {
        self.changeVisibility(false);
        self.Project(project);
        self.EditableItem = project;
    };

    // Update product details
    self.update = function() {
        var projectToUpdate = self.Project();
        $.ajax({
                url: '/Report/PutProject',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(projectToUpdate),
                success: function(data) {
                    self.changeVisibility(true);
                    self.LoadData();
                }
            })
            .fail(
                function(xhr, textStatus, err) {
                    alert(err);
                });
    };

    // Reset product details
    self.reset = function() {
        self.Title("");
        self.ZipCode("");
    };

    // Cancel product details
    self.cancel = function() {
        self.changeVisibility(true);
        self.Project(null);
    };

    self.changeVisibility = function(state) {
        self.displayGrid(state);
        self.displayForm(!state);
    };

    self.tryExport = function() {
        self.displayGrid(false);
        self.displayForm(false);
        self.displayExport(true);
    };

    self.hideExport = function() {
        self.displayExport(false);
        self.displayGrid(true);
    };

    self.export = function () {
        $.ajax({
            url: '/Report/Export',
            cache: false,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON({ From: self.DateFrom(), To: self.DateTo(), Email: self.Email(), Language: "en-US"/*self.Culture.selectedLanguage().type*/ }),
            success: function (data) {
                self.hideExport();
            }
        })
    .fail(
        function (xhr, textStatus, err) {
            alert(err);
            self.hideExport();
        });
    }
}
