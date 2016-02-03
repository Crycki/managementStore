'use strict';

angular.module('ManagmentStore').controller('StoreController', function ($scope, $location, StoreFactory) {
    $scope.stores = StoreFactory.getStores();
    $scope.selectStore = function (store) {
        $scope.selectedStore = (store) ? angular.copy(store) : {};
    };
    $scope.saveStore = function () {
        StoreFactory.saveStore($scope.selectedStore).then(function (result) {
            $scope.selectedStore = undefined;
            $scope.stores = StoreFactory.getStores();
        });
    };
    $scope.removeStore = function (store) {
        StoreFactory.removeStore(store).then(function (result) {
            $scope.stores = StoreFactory.getStores();
        });
    }
});