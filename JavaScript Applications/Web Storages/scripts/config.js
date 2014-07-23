require.config({
    baseUrl: 'scripts',
    paths: {
        RamsAndSheep: 'rams-and-sheep',
        RamsAndSheepUI: 'rams-and-sheep-ui',
        RNG: 'rng',
        jquery: 'bower_components/jquery/dist/jquery',
        Storage: 'storage'
    }
});

require(['app']);
