window.project = window.project || {};

window.project.projectViewModel = function(datacontext) {

	var addProject = function (project) {
		if (countOfExistedError(project.errors()) == 0) {
            if (project().Id() > 0) {
            	update(project());
            } else {
            	create(project());
            }

		    return true;
		} 

		return false;		
	};

	//Add New Item
	var create = function (project) {
		datacontext.createProject(project);
	};

	// Update product details
	var update = function (project) {
		datacontext.updateProject(project);
	};

    return {
        addProject: addProject
    };
};

function countOfExistedError(arr) {
	var count = 0;
	var i = arr.length;
	while (i--) {
		if (arr[i] !== null) {
			count++;
		}
	}
	return count;
}