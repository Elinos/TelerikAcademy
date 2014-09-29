'use strict';

app.controller('DriverDetailsCtrl', function ($scope, $routeParams, DriversResource) {
    $scope.driverId = $routeParams.id;
    $scope.driverDetails = DriversResource.byId({id: $scope.driverId});
    $scope.orderList = "";
});
