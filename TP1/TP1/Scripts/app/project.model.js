function projectItem(project) {
    var self = this;
    project = project || {};

    self.Id = ko.observable(project.Id);
    self.Title = ko.observable(project.Title).extend({ required: true });
    self.ZipCode = ko.observable(project.ZipCode).extend({ minLength: 4, maxLength: 5, required: true });
    self.City = ko.observable(project.City).extend({ required: true });
    self.Address = ko.observable(project.Address);
    self.Architect = ko.observable(project.Architect);
    self.DateModified = ko.observable(project.DateModified);
    self.Description = ko.observable(project.Description);
    self.FinishDate = ko.observable(project.FinishDate);
    self.Owner = ko.observable(project.Owner);
    self.Price = ko.observable(project.Price);
    self.Space = ko.observable(project.Space);
    self.StartDate = ko.observable(project.StartDate);
    self.PlannedApplicationDate = ko.observable(project.PlannedApplicationDate);
    self.BuildersRepresentative = ko.observable(project.BuildersRepresentative);
}