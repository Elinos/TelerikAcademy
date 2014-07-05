define [], () ->
  'use strict'
  class Student
    constructor: (data) ->
      {@name, @exam, @homework, @attendance, @teamwork, @bonus} = data
  Student

