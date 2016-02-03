'use strict';

angular.module('ManagmentStore').controller('StoreController', function ($scope, $location, StoreFactory) {
    $scope.stores = StoreFactory.getStores();
});