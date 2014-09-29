'use strict';

app.controller('HomeCtrl', function ($scope, TripsResource, DriversResource, StatsResource) {
    $scope.publicTrips = TripsResource.public();
    $scope.publicDrivers = DriversResource.public();
    $scope.publicStats = StatsResource.public();
});
