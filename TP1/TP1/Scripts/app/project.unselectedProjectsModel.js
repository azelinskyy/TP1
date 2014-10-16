var uProjects = [];

function unselectedProjectsModel() {
    var self = this;
    self.unselectedProjects = ko.observableArray(uProjects);
    self.updateProject = function (project, event) {
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
    self.updateProjects = function (projects, event) {
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

    self.reset = function () {
        self.unselectedProjects([]);
    }
}