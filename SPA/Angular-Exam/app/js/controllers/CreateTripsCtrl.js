'use strict';

app.controller('CreateTripsCtrl', function ($scope, $location, CreateTripResource, notifier, CitiesResource) {
    $scope.cities = CitiesResource.all();

    $scope.create = function (trip) {
        CreateTripResource.create(trip).then(function () {
            notifier.success('Trip created!');
            $location.path('/trips');
        })
    }
});
