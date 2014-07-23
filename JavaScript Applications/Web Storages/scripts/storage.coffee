define [], () ->
  class Storage
    constructor: () ->

    getStorage: () ->
      JSON.parse(localStorage.getItem('highScores')) || []

    setStorage: (highScores) ->
      localStorage.setItem('highScores', JSON.stringify(highScores))
