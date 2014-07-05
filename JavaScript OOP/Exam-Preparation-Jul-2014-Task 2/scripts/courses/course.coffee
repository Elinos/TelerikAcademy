define ['courses/student'], (Student) ->
  'use strict'
  class Course
    constructor: (@name, @totalScoreFormula) ->
      @_students = []
      @_totalScores = []
    addStudent: (student) ->
      throw new Error "You can add only students!" if student not instanceof Student
      @_students.push student
      @
    calculateResults: () ->
      for student in @_students
        @_totalScores.push
          student: student
          totalScore: @totalScoreFormula student
      @
    _getSortedStudents: (sortBy) ->
      unless @_totalScores and @_totalScores.length is @_students.length
        @calculateResults()
      sortedStudents =  @_totalScores.sort sortBy
    getTopStudentsByExam: (count) ->
      sortedStudentsByExam = @_getSortedStudents (st1, st2) -> st2.student.exam - st1.student.exam
      sortedStudentsByExam[...count]
    getTopStudentsByTotalScore: (count) ->
      sortedByTotalScores = @_getSortedStudents (st1, st2) -> st2.totalScore - st1.totalScore
      sortedByTotalScores[...count]
  Course
