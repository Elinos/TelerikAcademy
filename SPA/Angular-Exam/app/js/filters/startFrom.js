app.filter('startFrom', function () {
    return function (input, start) {
        start = parseInt(start);
        return input.slice(start);
    }
});