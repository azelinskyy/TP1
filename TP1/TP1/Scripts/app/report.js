function ApplicationViewModel(datacontext, language, gridModel, projectViewModel, unselectedProjects) {
    // Make the self as 'this' reference
    var self = this;

    
    self.UnselectedProjectsModule = ko.observable(unselectedProjects);

    self.ExportModels = ko.observableArray([{ name: "Columns", value: 0 }, { name: "Tables", value: 1 }]);

    // Declare observable which will be bind with UI 
    self.DateFrom = ko.observable($.datepicker.formatDate("mm/dd/yy", new Date(new Date().setDate(new Date().getDate() - 7))));
    self.DateTo = ko.observable($.datepicker.formatDate("mm/dd/yy", new Date()));
    self.Emails = ko.observable("");
    self.ExportModel = ko.observable(self.ExportModels);

    // View related properties.
    self.displayGrid = ko.observable(true);
    self.displayForm = ko.observable(false);
    self.displayExport = ko.observable(false);
    self.readOnlyMode = ko.observable(false);
    self.isAddAction = ko.observable(true);

    // Curent project, uses at edit/view/add form.
    self.Project = ko.observable(new projectModel(null));

    // Contains the list of projects.
    self.Projects = ko.observableArray();

    // Global modules.
    self.projectModule = projectViewModel;
    self.langModule = ko.observable(language);
    self.GridModule = ko.observable(new gridModel(datacontext.getProjectLists, null, self.Projects));

    // Filter projects list if dates range has been changed.
    self.changeDatesRange = function () {
        var searchOptions = self.GridModule().searchOptions();
        searchOptions.From = self.DateFrom();
        searchOptions.To = self.DateTo();
        self.refreshGrid(searchOptions);
        self.UnselectedProjectsModule().reset();
    };

    self.DateFrom.subscribe(self.changeDatesRange);
    self.DateTo.subscribe(self.changeDatesRange);

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
        self.performShowActions("grid");
        setModel(null);
    };

    self.export = function () {
        $.ajax({
            url: '/Report/Export',
            cache: false,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON({ From: self.DateFrom(), To: self.DateTo(), Emails: self.Emails(), Model: self.ExportModel().value, Culture: self.langModule().selectedLanguage().culture, UnselectedIds : self.UnselectedProjectsModule().unselectedProjects() }),
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
        var input = { From: self.DateFrom(), To: self.DateTo(), Model: self.ExportModel().value, Culture: self.langModule().selectedLanguage().culture, UnselectedIds: self.UnselectedProjectsModule().unselectedProjects() };
        window.open('/Report/SaveAs?' + decodeURIComponent($.param(input)), '_blank');
        self.viewProjects();
    };

    // Tabs switch related code.
    self.viewProjects = function () {
        self.performShowActions("gridTab");
    };

    // Display add form.
    self.add = function () {
        self.performShowActions("addForm");
        setModel(null);
    };

    // Delete project.
    self.delete = function (project) {
        if (confirm(String.format(self.langModule().language().DeleteConfirmationQuestion, project.Title))) {
            datacontext.deleteProject(project.Id);
            self.refreshGrid(self.GridModule().searchOptions());
        }
    };

    // Display edit project form.
    self.edit = function (project) {
        self.performShowActions("editForm");
        setModel(project);
    };

    // Display view project page.
    self.view = function (project) {
        self.performShowActions("viewForm");
        setModel(project);
    };

    function setModel(project) {
        self.Project(new projectModel(project));
        self.errors = ko.validation.group(self.Project);
    };

    // Show export form.
    self.tryExport = function () {
        self.performShowActions("exportTab");
    };

    // Initialize base state.
    self.getGridData = function() {
        return self.refreshGrid(self.GridModule().searchOptions());
    };

    self.performShowActions = function (action) {
        switch (action) {
            case "exportTab":
                self.displayGrid(false);
                self.displayForm(false);
                self.displayExport(true);
                self.isAddAction(true);
                self.readOnlyMode(false);
                break;
            case "viewForm":
                self.displayGrid(false);
                self.displayForm(true);
                self.displayExport(false);
                self.isAddAction(false);
                self.readOnlyMode(true);
                break;
            case "editForm":
                self.displayGrid(false);
                self.displayForm(true);
                self.displayExport(false);
                self.isAddAction(false);
                self.readOnlyMode(false);
                break;
            case "addForm":
                self.displayGrid(false);
                self.displayForm(true);
                self.displayExport(false);
                self.readOnlyMode(false);
                self.isAddAction(true);
                break;
            case "gridTab":
            default:
                self.displayGrid(true);
                self.displayForm(false);
                self.displayExport(false);
                self.isAddAction(true);
                self.readOnlyMode(false);
                break;
        }
    };

    self.refreshGrid = function (params) {
        datacontext.getProjectLists(params, self.Projects, self.GridModule().totalRows);
    };

    self.refreshGrid(self.GridModule().searchOptions());
}


