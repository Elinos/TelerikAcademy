define () ->
  require.config
    paths:
      'jquery': '../scripts/libs/jquery/dist/jquery.min'
      'httpRequester': '../scripts/httpRequester'
      'mocha': "../scripts/libs/mocha/mocha"
      'chai': "../scripts/libs/chai/chai"

  require ['mocha', 'chai'], () ->
    mocha.setup 'bdd'
    require ['../tests/httpRequester.tests'], () ->
      mocha.run()
