app.factory('CitiesResource', function ($resource, baseServiceUrl) {
    var CitiesResource = $resource(baseServiceUrl + 'api/Cities', null, {
        all: {  method: 'GET', isArray: true}
    });

    return CitiesResource;
});
