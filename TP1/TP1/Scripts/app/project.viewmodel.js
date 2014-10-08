window.project = window.project || {};

window.project.projectViewModel = function(datacontext) {

    var addProject = function(project) {
    	datacontext.updateProject(project);
    };

    return {
        addProject: addProject
    };

};