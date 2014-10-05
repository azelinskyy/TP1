function ReportViewModel(datacontext) {

    //Make the self as 'this' reference
    var self = this;

    self.ExportModels = [{ name: "Columns", value: "0" }, { name: "Tables", value: "1" }];

    //Declare observable which will be bind with UI 
    self.DateFrom = ko.observable(new Date(new Date().setDate(new Date().getDate() - 7)).toLocaleDateString());
    self.DateTo = ko.observable(new Date().toLocaleDateString());
    self.Emails = ko.observable("");
    self.ExportModel = ko.observable("");

    self.displayGrid = ko.observable(true);
    self.displayForm = ko.observable(false);
    self.displayExport = ko.observable(false);

    var projectModel = {
        Id: ko.observable(""),
        Title: ko.observable(""),
        ZipCode: ko.observable(""),
        City: ko.observable(""),
        Address: ko.observable(""),
        Architect: ko.observable(""),
        DateModified: ko.observable(""),
        Description: ko.observable(""),
        FinishDate: ko.observable(""),
        Owner: ko.observable(""),
        Price: ko.observable(""),
        Space: ko.observable(""),
        StartDate: ko.observable("")
    };

    self.Grid = ko.observable();


    self.Project = ko.observable(projectModel);
    self.Projects = ko.observableArray();   // Contains the list of projects
    self.Language = ko.observableArray();
    self.RowCount = ko.observable();
    var ints = 0;
    datacontext.getProjectLists(null, self.Projects, ints);

    self.changeDatesRange = function () {
        //// Place to refresh grid based on new dates range.
    };

    self.DateFrom.subscribe(self.changeDatesRange);
    self.DateTo.subscribe(self.changeDatesRange);

    //Add New Item
    self.create = function () {
        datacontext.self.createProject(self.Project());
    };

    // Delete project
    self.delete = function (project) {
        if (confirm('Are you sure you want to delete project "' + project.Title + '"?')) {
            datacontext.deleteProject(project.Id);
            datacontext.getProjectLists(null, self.Projects, ints);
        }
    };

    // Update product details
    self.update = function () {
        datacontext.updateProject(self.Project());
        self.changeVisibility(true);
        datacontext.getProjectLists(null, self.Projects, ints);
    };

    // Cancel project details
    self.cancel = function () {
        self.changeVisibility(true);
        // self.Project(null);
    };

    self.hideExport = function () {
        self.displayExport(false);
        self.displayGrid(true);
    };

    self.export = function() {
        $.ajax({
                url: '/Report/Export',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON({ From: self.DateFrom(), To: self.DateTo(), Emails: self.Emails(), Model: self.ExportModel().value, Language: "en-US" /*self.Culture.selectedLanguage().type*/ }),
                success: function(data) {
                    self.viewProjects();
                }
            })
            .fail(
                function(xhr, textStatus, err) {
                    alert(err);
                    self.viewProjects();
                });
    };

    self.saveAs = function () {
        $.ajax({
            url: '/Report/SaveAs',
            cache: false,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON({ From: self.DateFrom(), To: self.DateTo(), Email: self.Email(), Model: self.ExportModel().value, Language: "en-US" /*self.Culture.selectedLanguage().type*/ }),
            success: function (data) {
                self.viewProjects();
            }
        })
            .fail(
                function (xhr, textStatus, err) {
                    alert(err);
                    self.viewProjects();
                });
    }

    // Tabs switch related code.
    self.viewProjects = function() {
        self.changeVisibility(true, false, false);
    };

    self.add = function () {
        self.changeVisibility(false, true, false);
        self.Project(projectModel);
    };

    self.edit = function (project) {
        self.changeVisibility(false, true, false);
        self.Project(project);
    };

    self.tryExport = function () {
        self.changeVisibility(false, false, true);
        self.Emails("");
    };

    self.changeVisibility = function (grid, form, exp) {
        self.displayGrid(grid);
        self.displayForm(form);
        self.displayExport(exp);
    };
}
