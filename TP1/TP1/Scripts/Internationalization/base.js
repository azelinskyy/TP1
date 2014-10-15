/// <reference path="~/Scripts/knockout-2.2.0.js"/>

var availableLanguages = [
    {
        name: "Deutsch",
        type: "de",
        culture: "de-DE"
    },
    {
        name: "English",
        type: "en",
        culture: "en-US"
    },
    {
        name: "Українська",
        type: "ua",
        culture: "uk-UA"
    }  
];

var uProjects = [];

function unselectedProjectsModel() {
    var self = this;
    self.unselectedProjects = ko.observableArray(uProjects);
    self.updateProject = function(project, event) {
        if (event.target.checked) {
            var index = self.unselectedProjects.indexOf(project.Id);
            if (index != -1) {
                self.unselectedProjects.splice(index, 1);
            }
        } else {
            if (self.unselectedProjects.indexOf(project.Id) == -1) {
                self.unselectedProjects.push(project.Id);
            }
        }
    }
    self.updateProjects = function(projects, event) {
        for (var i = 0; i < projects.length; i++) {
            self.updateProject(projects[i], event);
        }
    }
    self.projectChecked = function (id) {
        var index = self.unselectedProjects.indexOf(id);
        return index == -1;
    }
    self.allProjectsChecked = function (projects) {
        for (var i = 0; i < projects.length; i++) {
            if (self.projectChecked(projects[i].id) == false) {
                return false;
            }
        }
        return true;
    }

    self.reset = function() {
        self.unselectedProjects([]);
    }
}

function languageModel(languages) {
    var self = this;
    self.languages = ko.observableArray(languages);
    self.selectedLanguage = ko.observable();
    self.language = ko.observable();
   
    // Whenever the language changes, change languages
    self.selectedLanguage.subscribe(function (item) {
        
        var options = {
            dataType: "json",
            contentType: "application/json",
            cache: true,
            type: "get",
            async: false,
            data: { language: item.type }
        };

        $.ajax("/Internationalization/GetLanguage/", options).done(function (data) {
            self.language(data);
        });
    });
};

if (!String.format) {
    String.format = function () {
        var s = arguments[0];
        for (var i = 0; i < arguments.length - 1; i++) {
            var reg = new RegExp("\\{" + i + "\\}", "gm");
            s = s.replace(reg, arguments[i + 1]);
        }

        return s;
    };
}