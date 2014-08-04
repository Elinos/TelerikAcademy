define () ->
  require.config
    paths:
      'jquery': 'libs/jquery/dist/jquery.min'
      'httpRequester': 'httpRequester'
      'persisters': 'persisters'
      'sammy': 'libs/sammy/lib/sammy'
      'Controller': 'controller'
      'handlebars': 'libs/handlebars/handlebars-v1.3.0'
      'underscore': 'libs/underscore/underscore'
      'ui': 'ui'
    shim:
      "handlebars":
        exports: "Handlebars"
      "underscore":
        exports: '_'

  require ['sammy', 'Controller'], (Sammy, Controller) ->
    appController = new Controller('#wrapper')
    appController.addEvents()

    app = Sammy('#wrapper', () ->
        @get("#/", () ->
          appController.loadMainPage()
        @get("#/post", () ->
          appController.loadMainPage(() -> appController.loadPostsPage())
        @get("#/register", () ->
          appController.loadMainPage(() -> appController.loadRegisterPage())
        @get("#/login", () ->
          appController.loadMainPage(() -> appController.loadLoginPage())
        )))))
    app.run('#/');
