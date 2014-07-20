(function() {
  require.config({
    baseUrl: 'bower_components',
    paths: {
      book: '../scripts/book',
      person: '../scripts/person',
      animal: '../scripts/animal',
      student: '../scripts/student',
      chance: 'chance/chance',
      underscore: 'underscore/underscore',
      main: '../scripts/main'
    }
  });

  require(['main']);
}());
