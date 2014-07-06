define ['courses/student'], (Student) ->
  'use strict'
  class Course
    constructor: (@name, @totalScoreFormula) ->
      @_students = []
    addStudent: (student) ->
      throw new Error "You can add only students!" if student not instanceof Student
      @_students.push student
      this
    calculateResults: () ->
      @_totalScores = []
      for student in @_students
        @_totalScores.push
          student: student
          totalScore: @totalScoreFormula student
      this
    _getSortedStudents: (sortBy) ->
      unless @_totalScores and @_totalScores.length is @_students.length
        @calculateResults()
      @_totalScores.sort sortBy
    getTopStudentsByExam: (count) ->
      sortedStudentsByExam = @_getSortedStudents (st1, st2) -> st2.student.exam - st1.student.exam
      if count? then sortedStudentsByExam[...count] else sortedStudentsByExam
    getTopStudentsByTotalScore: (count) ->
      sortedByTotalScores = @_getSortedStudents (st1, st2) -> st2.totalScore - st1.totalScore
      if count? then sortedByTotalScores[...count] else sortedByTotalScores
  Course
