'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']).
    config(function ($routeProvider) {

        var routeUserChecks = {
            authenticated: {
                authenticate: function (auth) {
                    return auth.isAuthenticated();
                }
            }
        };

        $routeProvider
            .when('/', {
                templateUrl: 'views/partials/home.html',
                controller: 'HomeCtrl'
            })
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'SignUpCtrl'
            })
            .when('/drivers', {
                templateUrl: 'views/partials/drivers.html',
                controller: 'DriversCtrl'
            })
            .when('/drivers/:id', {
                templateUrl: 'views/partials/driver-details.html',
                controller: 'DriverDetailsCtrl',
                resolve: routeUserChecks.authenticated
            })
            .when('/trips', {
                templateUrl: 'views/partials/trips.html',
                controller: 'TripsCtrl'
            })
            .when('/trips/create', {
                templateUrl: 'views/partials/create-trip.html',
                controller: 'CreateTripsCtrl',
                resolve: routeUserChecks.authenticated
            })
            .when('/trips/:id', {
                templateUrl: 'views/partials/trip-details.html',
                controller: 'TripDetailsCtrl'
            })
            .when('/unauthorized', {
                templateUrl: 'views/partials/unauthorized.html'
            })

            .otherwise({ redirectTo: '/' });
    }).config(function ($provide, $httpProvider) {
        $httpProvider.interceptors.push('myErrorHandler')
    })
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://spa2014.bgcoder.com/');

app.run(function ($rootScope, $location, notifier) {
    $rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
        $location.path('/unauthorized');
        notifier.error(rejection)
    })
});