﻿/// <reference path="~/Scripts/knockout-2.2.0.js"/>

var availableLanguages = [
    {
        name: "English",
        type: "en",
        culture: "en-EN"
    },
    {
        name: "Українська",
        type: "ua",
        culture: "uk-UA"
    },
    {
        name: "Deutsch",
        type: "de",
        culture: "de-DE"
    }
];

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

if (!String.format) {
    String.format = function () {
        var s = arguments[0];
        for (var i = 0; i < arguments.length - 1; i++) {
            var reg = new RegExp("\\{" + i + "\\}", "gm");
            s = s.replace(reg, arguments[i + 1]);
        }

        return s;
    }
}