app.factory('StatsResource', function ($resource, baseServiceUrl) {
    var StatsResource = $resource(baseServiceUrl + 'api/Stats', null, {
        public: {  method: 'GET', isArray: false}
    });

    return StatsResource;
});

