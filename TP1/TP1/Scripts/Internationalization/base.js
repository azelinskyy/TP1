/// <reference path="~/Scripts/knockout-2.2.0.js"/>

var availableLanguages = [
    {
        name: "English",
        type: "us"
    },
    {
        name: "Українська",
        type: "ua"
    }
];
//window.languageModel = {};


var languageModel = function (languages) {
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
        });;

    });
};
//window.languageModel = new languageModel(languageModel)
//ko.applyBindings(new languageModel(availableLanguages));
