'use strict';

angular.module('ManagmentStore').controller('ProductsController', function ($scope, $modal, $location, ProductService, ProductFactory) {

    $scope.products = ProductFactory.getProducts();

    $scope.removeProduct = function (product) {
        ProductFactory.removeProduct(product).then(function () {
            $scope.products = ProductFactory.getProducts();
        });
    };


    $scope.modifyProduct = function (product) {
        ProductService.product = product;
        var modalInstance = $modal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalContent.html',
            controller: 'ProductController',
            size: 'md'
        });
    }

});

angular.module('ManagmentStore').controller('ProductController', function ($scope, $modalInstance, ProductService, ProductFactory) {
    $scope.selectedProduct = ProductService.product;
});

angular.module('ManagmentStore').service('ProductService', function () {
    var product;
});