app.factory('DriversResource', function ($resource, authorization, baseServiceUrl) {
    var headers = authorization.getAuthorizationHeader();
    var DriversResource = $resource(baseServiceUrl + 'api/Drivers/:id', null, {
        public: {  method: 'GET', isArray: true},
        byPage: { method: 'GET', params: { page: '@page' }, isArray: true, headers: headers },
        byPageAndUsername: { method: 'GET', params: { page: '@page', username: '@username' }, isArray: true, headers: headers },
        byId: { method: 'GET', params: { id: '@id' }, isArray: false, headers: headers }
    });

    return DriversResource;
});
