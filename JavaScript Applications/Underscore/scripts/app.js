(function() {
    require.config({
        baseUrl: 'bower_components',
        paths: {
            chance: 'chance/chance',
            underscore: 'underscore/underscore',
            main: '../scripts/main'
        }
    });

    require(['main']);
}());
