'use strict';

app.factory('CreateTripResource', function ($http, $q, identity, authorization, baseServiceUrl) {
    var usersApi = baseServiceUrl + '/api/trips';

    return {
        create: function (trip) {
            var deferred = $q.defer();
            var headers = authorization.getAuthorizationHeader();
            $http.post(usersApi, trip, { headers: headers })
                .success(function () {
                    deferred.resolve();
                }, function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        }
    }
});
