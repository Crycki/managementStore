'use strict';

angular.module('ManagmentStore').factory('ProductFactory', function ($resource) {
    var productFactory = {};

    var Products = $resource('REST/Product.svc/Products');
    var Product = $resource('REST/Product.svc/Product/:productId', { productId: "@Id" }, { update: { method: 'PUT' } });

    productFactory.getProducts = function () {
        return Products.query();
    };

    productFactory.removeProduct = function (product) {
        var deletedProduct = new Product();
        deletedProduct.Id = product.Id;

        return deletedProduct.$delete();
    }

    return productFactory;
});