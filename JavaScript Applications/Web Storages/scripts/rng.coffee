define [], () ->
  class RNG
    constructor: () ->

    getInteger: (min = 0, max = 9) ->
      min + Math.random() * (max - min + 1) >> 0

    getSecretNumber: () ->
      digits = [0..9]
      secretNumber = ''
      secretNumber += digits.splice(@getInteger(1, 9), 1) # First digit cannot be zero
      secretNumber += digits.splice(@getInteger(0, 9 - i), 1) for i in [1..3]
      secretNumber
