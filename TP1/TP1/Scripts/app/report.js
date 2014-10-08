function ApplicationViewModel(datacontext, language, gridModel, projectViewModel) {

    // Make the self as 'this' reference
    var self = this;

    // Global modules.
    self.projectModule = projectViewModel;
    self.langModule = ko.observable(language);
    self.GridModule = ko.observable(gridModel);

    self.ExportModels = ko.observableArray([{ name: "Columns", value: 0 }, { name: "Tables", value: 1 }]);

    // Declare observable which will be bind with UI 
    self.DateFrom = ko.observable($.datepicker.formatDate("mm/dd/yy", new Date(new Date().setDate(new Date().getDate() - 7))));
    self.DateTo = ko.observable($.datepicker.formatDate("mm/dd/yy", new Date()));
    self.Emails = ko.observable("");
    self.ExportModel = ko.observable(self.ExportModels);

    self.displayGrid = ko.observable(true);
    self.displayForm = ko.observable(false);
    self.displayExport = ko.observable(false);

    self.readOnlyMode = ko.observable(false);
    self.isAddAction = ko.observable(true);

    // Curent project, uses at edit/view/add form.
    self.Project = ko.observable(new projectItem(null));

    // Contains the list of projects.
    self.Projects = ko.observableArray();   

    

    // Filter projects list if dates range has been changed.
    self.changeDatesRange = function () {
        var searchOptions = self.GridModule().searchOptions();
        searchOptions.From = self.DateFrom();
        searchOptions.To = self.DateTo();
        self.refreshGrid(searchOptions);
    };

    self.DateFrom.subscribe(self.changeDatesRange);
    self.DateTo.subscribe(self.changeDatesRange);

    // Delete project
    self.delete = function (project) {
        if (confirm(String.format(self.langModule().language().DeleteConfirmationQuestion, project.Title))) {
            datacontext.deleteProject(project.Id);
            self.refreshGrid(self.GridModule().searchOptions());
        }
    };

    self.save = function () {
        if (self.projectModule.addProject(self.Project)) {
            self.refreshGrid(self.GridModule().searchOptions());
            self.cancel();
        } else {
            self.Project.errors.showAllMessages();
        }
        self.isAddAction(true);
        self.readOnlyMode(false);
    };

    // Cancel edit/add/view actions. 
    self.cancel = function () {
        self.changeVisibility(true, false, false);
        self.isAddAction(true);
        self.readOnlyMode(false);
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
        self.isAddAction(true);
        self.readOnlyMode(false);
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
        self.isAddAction(false);
        self.readOnlyMode(false);
        self.changeVisibility(false, true, false);
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
        self.isAddAction(true);
        self.readOnlyMode(false);
        self.changeVisibility(false, false, true);
    };

    self.changeVisibility = function (grid, form, exp) {
        self.displayGrid(grid);
        self.displayForm(form);
        self.displayExport(exp);
    };

    self.refreshGrid = function (params) {
        datacontext.getProjectLists(params, self.Projects, self.GridModule().totalRows);
    };

    // Initialize base state.
    self.getGridData = function() {
        return self.refreshGrid(self.GridModule().searchOptions());
    };

    self.refreshGrid(self.GridModule().searchOptions());
}


