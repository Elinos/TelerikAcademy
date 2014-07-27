define () ->
  require.config
    paths:
      'jquery': 'libs/jquery/dist/jquery.min'
      'httpRequester': 'httpRequester'
      'Persister': 'Persister'
      'sammy': 'libs/sammy/lib/sammy'
      'Controller': 'Controller'

  require ['sammy', 'Controller'], (Sammy, Controller) ->
    appController = new Controller('#wrapper')
    appController.addEvents()

    app = Sammy('#wrapper', () ->
        @get("#/", () ->
          appController.loadMainPage())
        @get("#/students", () ->
          appController.loadMainPage(() -> appController.loadStudentsPage()))
        @get("#/delete", () ->
          appController.loadMainPage(() -> appController.deleteStudentPage()))
        @get("#/add", () ->
          appController.loadMainPage(() -> appController.addStudentPage()))
        )
    app.run('#/');

