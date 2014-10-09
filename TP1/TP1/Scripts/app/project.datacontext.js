window.project = window.project || {};


window.project.datacontext = (function () {
    var datacontext = {
        getProjectLists: getProjectLists,
        deleteProject: deleteProject,
        updateProject: updateProject,
        createProject: createProject
    };

    return datacontext;

    function getProjectLists(requestOptions, projectObservable, totalCount) {
        // Initialize the view-model
        ajaxRequest("GET", projectUrl(null, "GetReport"), requestOptions).done(getSucceeded);
        function getSucceeded(data) {
            projectObservable($.parseJSON(data.result)); //Put the response in ObservableArray
            totalCount(data.totalRows);
        }
    };

    function updateProject(projectToUpdate) {
        ajaxRequest("PUT", projectApiUrl(projectToUpdate.Id()), ko.toJSON(projectToUpdate));
    };

    function deleteProject(projectId) {
        ajaxRequest("DELETE", projectApiUrl(projectId));
    };

    function createProject(newProject) {
        ajaxRequest("POST", projectApiUrl(null), ko.toJSON(newProject));
    };

    // private methods
    function ajaxRequest(type, url, data, dataType) { // Ajax helper
        var options = {
            dataType: dataType || "json",
            contentType: "application/json",
            cache: false,
            type: type,
            data: data,
            async: false
        };

        var antiForgeryToken = $("#antiForgeryToken").val();
        if (antiForgeryToken) {
            options.headers = {
                'RequestVerificationToken': antiForgeryToken
            };
        }

        return $.ajax(url, options);
    }

    // routes
    function projectUrl(id, action) {
         return "/Report/" + action + "/" + (id || "");
    }

    // routes
    function projectApiUrl(id) {
        return "/api/project/" + (id || "");
    }
});