'use strict';

angular.module('ManagmentStore').factory('ProductFactory', function ($resource) {
    var productFactory = {};

    var Products = $resource('REST/Product.svc/Products');

    productFactory.getProducts = function () {
        return null;
    };

    return productFactory;
});