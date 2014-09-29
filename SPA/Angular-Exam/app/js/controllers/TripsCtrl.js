'use strict';

app.controller('TripsCtrl', function ($scope, TripsResource, CitiesResource, identity) {
    $scope.currentPage = 1;

    $scope.publicTrips = TripsResource.public();
    $scope.filteredTrips = TripsResource.byPage({page: $scope.currentPage});
    $scope.cities = CitiesResource.all();

    $scope.isAuthenticated = identity.isAuthenticated();
    $scope.sort = 'driver';
    $scope.order = 'asc';
    $scope.from = '';
    $scope.to = '';
    $scope.finished = false;
    $scope.onlyMine = false;

    $scope.getFilteredTrips = function () {
        $scope.filteredTrips = TripsResource.getFiltered({
            page: $scope.currentPage,
            orderBy: $scope.sort,
            orderType: $scope.order,
            from: $scope.from,
            to: $scope.to,
            finished: $scope.finished,
            onlyMine: $scope.onlyMine
        });
    };
    $scope.$watch('currentPage', function (newVal) {
        if (!newVal) return;
        $scope.getFilteredTrips();
    });


});


