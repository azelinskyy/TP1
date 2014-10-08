function ApplicationViewModel(datacontext, language, gridModel, projectViewModel) {

    //Make the self as 'this' reference
    var self = this;
    self.projectModule = projectViewModel;

    self.langModule = ko.observable(language);

    self.ExportModels = ko.observableArray([{ name: "Columns", value: 0 }, { name: "Tables", value: 1 }]);

    //Declare observable which will be bind with UI 
    self.DateFrom = ko.observable($.datepicker.formatDate("mm/dd/yy", new Date(new Date().setDate(new Date().getDate() - 7))));
    self.DateTo = ko.observable($.datepicker.formatDate("mm/dd/yy", new Date()));
    self.Emails = ko.observable("");
    self.ExportModel = ko.observable(self.ExportModels);

    self.displayGrid = ko.observable(true);
    self.displayForm = ko.observable(false);
    self.displayExport = ko.observable(false);

    self.readOnlyMode = ko.observable(true);

    self.Grid = ko.observable(gridModel);

    self.Project = ko.observable(new projectItem(null));
    self.Projects = ko.observableArray();   // Contains the list of projects
    self.Language = ko.observableArray();
    self.RowCount = ko.observable();

    datacontext.getProjectLists(self.Grid().searchOptions(), self.Projects, self.Grid().totalRows);

    // Filter projects list if dates range has been changed.
    self.changeDatesRange = function () {
        var searchOptions = self.Grid().searchOptions();
        searchOptions.From = self.DateFrom();
        searchOptions.To = self.DateTo();
        datacontext.getProjectLists(searchOptions, self.Projects, self.Grid().totalRows);
    };

    self.DateFrom.subscribe(self.changeDatesRange);
    self.DateTo.subscribe(self.changeDatesRange);

    // Delete project
    self.delete = function (project) {
        if (confirm(String.format(self.langModule().language().DeleteConfirmationQuestion, project.Title))) {
            datacontext.deleteProject(project.Id);
            datacontext.getProjectLists(self.Grid().searchOptions(), self.Projects, self.Grid().totalRows);
        }
    };

    self.save = function () {
        if (self.projectModule.addProject(self.Project)) {
            datacontext.getProjectLists(self.Grid().searchOptions(), self.Projects, self.Grid().totalRows);
            self.cancel();
        } else {
            self.Project.errors.showAllMessages();
        }
    };



    // Cancel project details
    self.cancel = function () {
        self.changeVisibility(true, false, false);
        refreshModel();
    };

    self.export = function () {
        $.ajax({
            url: '/Report/Export',
            cache: false,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON({ From: self.DateFrom(), To: self.DateTo(), Emails: self.Emails(), Model: self.ExportModel().value, Culture: self.langModule().selectedLanguage().culture }),
            success: function (data) {
                self.viewProjects();
                self.Emails("");
            }
        })
            .fail(
                function (xhr, textStatus, err) {
                    alert(err);
                    self.viewProjects();
                    self.Emails("");
                });
    };

    self.saveAs = function () {
        var input = { From: self.DateFrom(), To: self.DateTo(), Model: self.ExportModel().value, Culture: self.langModule().selectedLanguage().culture };
        window.open('/Report/SaveAs?' + decodeURIComponent($.param(input)), '_blank');
        self.viewProjects();
    };

    // Tabs switch related code.
    self.viewProjects = function () {
        self.changeVisibility(true, false, false);
    };

    self.add = function () {
        self.readOnlyMode(false);
        self.changeVisibility(false, true, false);
        refreshModel();
    };

    function refreshModel() {
        return setModel(null);
    }

    function setModel(project) {
        self.Project(new projectItem(project));
        self.errors = ko.validation.group(self.Project);
    }

    self.edit = function (project) {
        self.changeVisibility(false, true, false);
        self.readOnlyMode(false);
        setModel(project);
        //self.Project(project);
    };

    self.view = function (project) {
        self.changeVisibility(false, true, false);
        self.readOnlyMode(true);
        setModel(project);
        //self.Project(project);
    };

    self.tryExport = function () {
        self.changeVisibility(false, false, true);
    };

    self.changeVisibility = function (grid, form, exp) {
        self.displayGrid(grid);
        self.displayForm(form);
        self.displayExport(exp);
    };


}


