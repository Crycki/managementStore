'use strict';

angular.module('ManagmentStore').factory('SessionFactory', function ($resource) {
    var sessionFactory = {};

    var Session = $resource('REST/Security.svc/Session');

    sessionFactory.login = function (username, password) {
        var newSession = new Session();
        newSession.UserName = username;
        newSession.Password = password;
        return newSession.$save();
    };

    sessionFactory.logout = function () {
        var sessionToDelete = new Session();
        sessionToDelete.$delete();
    };

    return sessionFactory;
});
