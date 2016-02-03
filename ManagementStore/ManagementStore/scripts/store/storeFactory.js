'use strict';

angular.module('ManagmentStore').factory('StoreFactory', function ($resource) {
    var storeFactory = {};

    var Stores = $resource('REST/Store.svc/Stores');
    var Store = $resource('REST/Store.svc/Store/:storeId', { storeId: "@Id" }, { update: { method: 'PUT' } });

    storeFactory.getStores = function () {
        return Stores.query();
    };

    storeFactory.saveStore = function (store) {
        var savedStore = new Store();
        savedStore.Id = store.Id;
        savedStore.Name = store.Name;
        return (savedStore.Id) ? savedStore.$update() : savedStore.$save();
    };

    storeFactory.removeStore = function (store) {
        var deletedStore = new Store();
        deletedStore.Id = store.Id;
        return deletedStore.$delete();
    };

    return storeFactory;
});
