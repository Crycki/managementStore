'use strict';

angular.module('ManagmentStore').controller('SessionController', function ($scope, $http, $location, SessionFactory) {
    
    $scope.logout = function () {
        SessionFactory.logout();
        $http.defaults.headers.common['user_session_id'] = "";
    };

    $scope.login = function () {
        SessionFactory.login($scope.username, $scope.password).then(function (session) {
            $http.defaults.headers.common['user_session_id'] = session.SessionId;
            $location.path("/billing/summaryInvoices");
        });
    };

});
