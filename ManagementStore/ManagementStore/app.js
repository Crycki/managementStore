'use strict';

var app = angular.module('ManagmentStore', ['ngRoute', 'route-segment', 'view-segment', 'ngResource', 'ui.bootstrap']);

app.config(function ($routeSegmentProvider, $httpProvider) {

    $routeSegmentProvider.

        when('/login', 'login').
        when('/', 'login').
        when('/components/stores', 'components.stores').
        when('/components/products', 'components.products')

    .segment('login', {
        templateUrl: 'Scripts/security/loginPartial.html',
        controller: 'SessionController'
    })
    .segment('components', {
        templateUrl: 'Scripts/menu/menuPartial.html'
    })
    .within()
        .segment('stores', {
            templateUrl: 'Scripts/store/storesPartial.html',
            controller: 'StoresController'
        })
        .segment('products', {
            templateUrl: 'Scripts/product/productsPartial.html',
            controller: 'ProductsController'
        })

    $httpProvider.interceptors.push(function ($q, $location) {
        return {
            'responseError': function (rejection) {
                var message = rejection.data.replace(/['"]+/g, '');
                if (rejection.status === 403) {
                    $location.path("/login");
                }
                return $q.reject(rejection);
            },

            'response': function (response) {
                if (typeof response.data == "string" && response.data != "true" && response.data != "false"
                    && response.data.trim().indexOf("<") !== 0 && response.data !== "") {
                    var message = response.data.replace(/['"]+/g, '');
                }
                return response || $q.when(response);
            }
        };
    });
});

app.config(function ($httpProvider, $locationProvider) {
    //initialize get if not there
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }

    //disable IE ajax request caching
    $httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
    // extra
    $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
    $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';

    $locationProvider.html5Mode(true);
});