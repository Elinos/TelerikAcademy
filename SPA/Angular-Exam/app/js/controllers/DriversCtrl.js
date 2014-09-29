'use strict';

app.controller('DriversCtrl', function ($scope, DriversResource, identity) {
    $scope.currentPage = 1;
    $scope.searchedUsername = '';
    $scope.isAuthenticated = identity.isAuthenticated();

    $scope.publicDrivers = DriversResource.public();
    $scope.filteredDrivers = DriversResource.byPageAndUsername({page: $scope.currentPage, username: $scope.searchedUsername });
    $scope.getDrivers = function (page, username) {
        $scope.filteredDrivers = DriversResource.byPageAndUsername({page: page, username: username });
    };
    $scope.$watch('currentPage', function (newVal) {
        if (!newVal) return;
        $scope.getDrivers($scope.currentPage, $scope.searchedUsername);
    });
});

