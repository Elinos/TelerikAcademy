'use strict';

app.controller('TripDetailsCtrl', function ($scope, $routeParams, TripsResource) {
    $scope.tripId = $routeParams.id;
    $scope.tripDetails = TripsResource.byId({id: $scope.tripId});
    $scope.orderList = "";
});

