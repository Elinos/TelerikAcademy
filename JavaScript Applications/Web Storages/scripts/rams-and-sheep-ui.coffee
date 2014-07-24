define ['jquery'], ($) ->
  class RamsAndSheepUI
    constructor: (container) ->
      @$container = $(container)
      @$result = $('<div />').addClass('result-container')

    drawStartScreen: () ->
      @$container.append($('<img />').addClass('splash').attr("src", "images/splash.jpg"))
                 .append($('<button />').addClass('btn-start-new-game').html('Start new game'))

    drawGameScreen: () ->
      @$container.empty()
      @$container.append($('<div />').text('Enter your guess!'))
      @$container.append($('<input />').addClass('input'))
      @$container.append($('<button />').addClass('btn-make-guess').html('Guess'))

    drawGuess: (guessedNumber, result) ->
      $result = @$result.clone()
      for i in [0...result.rams]
        $result.append($('<img />').addClass('ramImg').attr("src", "images/ram.jpg"))
      for i in [0...result.sheep]
        $result.append($('<img />').addClass('sheepImg').attr("src", "images/sheep.jpg"))
      @$container.append $result.prepend("#{guessedNumber} : ")

    drawError: (guessedNumber) ->
      $errorMsg = $("<div />").text("Invalid number: '#{guessedNumber}'!").addClass('error')
      @$container.append($errorMsg.fadeIn(1500).fadeOut(1500))

    drawWinScreen: (score) ->
      @$container.empty()
      @getName(score)

    drawHighScores: (highScores) ->
      @$container.empty()
      $table = $('<table />').addClass('highScoreTable')
      $table.append($('<thead />').append($('<th />').html('Name')).append($('<th />').html('Score')))
      $tbody = $table.append($('<tbody />'))
      for highScore in highScores
        $tbody.append($('<tr />').append($('<td />').html(highScore.name)).append($('<td />').html(highScore.score)))
      @$container.append($('<div />').text('Highscores').addClass('hs-title'))
      @$container.append($table)
      @$container.append($('<button />').addClass('restart-game').html('Restart game'))

    getName: (guesses) ->
      @$container.append($('<div />').addClass('winning-msg').html("You guessed the number in #{guesses} guesses"))
      @$container.append($('<div />').text('Enter your name!'))
      @$container.append($('<input />').addClass('hi-score-name'))
      @$container.append($('<button />').addClass('add-name').html('Submit'))

  RamsAndSheepUI
