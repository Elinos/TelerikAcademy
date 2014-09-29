app.factory('TripsResource', function ($resource, authorization, baseServiceUrl) {
    var headers = authorization.getAuthorizationHeader();
    var TripsResource = $resource(baseServiceUrl + 'api/Trips', null, {
        public: {  method: 'GET', isArray: true},
        byPage: { method: 'GET', params: { page: '@page' }, isArray: true, headers: headers },
        byPageOrderBy: { method: 'GET', params: { page: '@page', orderBy: '@orderBy', orderType: '@orderType' }, isArray: true, headers: headers },
        byPageFromTo: { method: 'GET', params: { page: '@page', from: '@from', to: '@to' }, isArray: true, headers: headers },
        byPageFinished: { method: 'GET', params: { page: '@page', finished: '@finished' }, isArray: true, headers: headers },
        byPageOnlyMine: { method: 'GET', params: { page: '@page', onlyMine: '@onlyMine' }, isArray: true, headers: headers },
        getFiltered: { method: 'GET', params: { page: '@page', orderBy: '@orderBy', orderType: '@orderType', from: '@from', to: '@to', finished: '@finished', onlyMine: '@onlyMine' }, isArray: true, headers: headers },
        byId: { method: 'GET', params: { id: '@id' }, isArray: false, headers: headers }
    });

    return TripsResource;
});
