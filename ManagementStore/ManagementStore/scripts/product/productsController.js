'use strict';

angular.module('ManagmentStore').controller('ProductsController', function ($scope, $location, ProductFactory) {

    $scope.products = ProductFactory.getProducts();

    $scope.removeProduct = function (product) {
        ProductFactory.removeProduct(product).then(function () {
            $scope.products = ProductFactory.getProducts();
        });
    };

});