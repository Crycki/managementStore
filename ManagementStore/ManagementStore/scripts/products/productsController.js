'use strict';

angular.module('ManagmentStore').controller('ProductsController', function ($scope, $location, ProductFactory) {
    $scope.products = ProductFactory.getProducts();
});