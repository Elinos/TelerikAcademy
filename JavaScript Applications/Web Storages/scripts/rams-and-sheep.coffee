define ['RNG'], (RNG) ->
  class RamsAndSheep
    MAX_HIGH_SCORES = 5

    constructor: () ->
      @_rng = new RNG()
      @_secretNumber = ''

    getGuesses: () -> @_guesses

    startGame: () ->
      @_secretNumber = @_rng.getSecretNumber()
      @_guesses = 0

    makeGuess: (number) ->
      @_guesses++
      @countRamsAndSheep(number)

    isNumberValid: (number) ->
      number = number.toString()
      return no if number.length isnt 4
      return no if number[0] is '0'
      for digit, i in number
        return no if not /^\d$/.test(digit)
        return no if number.indexOf(digit, i+1) isnt -1
      yes

    countRamsAndSheep: (number) ->
      rams = 0
      sheep = 0
      for i in [0..3]
        if number[i] is @_secretNumber[i]
          rams++
        else if number[i] in @_secretNumber.split('')
          sheep++
      {rams: rams, sheep: sheep}

    updateHighScores: (result, highScores = []) ->
      highScores.push(result) if highScores.length < MAX_HIGH_SCORES
      highScores.sort((a, b) -> b.score - a.score)
      if highScores.length is MAX_HIGH_SCORES and highScores[0].score > result.score
        highScores[0] = result
      highScores.sort((a, b) -> a.score - b.score)

  RamsAndSheep
