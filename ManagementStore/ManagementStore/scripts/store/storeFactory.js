'use strict';

angular.module('ManagmentStore').factory('StoreFactory', function ($resource) {
    var storeFactory = {};

    var Stores = $resource('REST/Store.svc/Stores');

    storeFactory.getStores = function () {
        return Stores.query();
    };

    return storeFactory;
});
