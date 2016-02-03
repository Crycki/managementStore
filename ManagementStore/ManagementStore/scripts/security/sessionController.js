'use strict';

angular.module('ManagmentStore').controller('SessionController', function ($scope, $location, SessionFactory) {

    $scope.login = function () {
        SessionFactory.login($scope.username, $scope.password).then(function (session) {
            $location.path("/components/store");
        });
    };

});
