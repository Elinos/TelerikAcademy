// Generated by CoffeeScript 1.7.1
define(['courses/student'], function(Student) {
  'use strict';
  var Course;
  Course = (function() {
    function Course(name, totalScoreFormula) {
      this.name = name;
      this.totalScoreFormula = totalScoreFormula;
      this._students = [];
    }

    Course.prototype.addStudent = function(student) {
      if (!(student instanceof Student)) {
        throw new Error("You can add only students!");
      }
      this._students.push(student);
      return this;
    };

    Course.prototype.calculateResults = function() {
      var student, _i, _len, _ref;
      this._totalScores = [];
      _ref = this._students;
      for (_i = 0, _len = _ref.length; _i < _len; _i++) {
        student = _ref[_i];
        this._totalScores.push({
          student: student,
          totalScore: this.totalScoreFormula(student)
        });
      }
      return this;
    };

    Course.prototype._getSortedStudents = function(sortBy) {
      if (!(this._totalScores && this._totalScores.length === this._students.length)) {
        this.calculateResults();
      }
      return this._totalScores.sort(sortBy);
    };

    Course.prototype.getTopStudentsByExam = function(count) {
      var sortedStudentsByExam;
      sortedStudentsByExam = this._getSortedStudents(function(st1, st2) {
        return st2.student.exam - st1.student.exam;
      });
      if (count != null) {
        return sortedStudentsByExam.slice(0, count);
      } else {
        return sortedStudentsByExam;
      }
    };

    Course.prototype.getTopStudentsByTotalScore = function(count) {
      var sortedByTotalScores;
      sortedByTotalScores = this._getSortedStudents(function(st1, st2) {
        return st2.totalScore - st1.totalScore;
      });
      if (count != null) {
        return sortedByTotalScores.slice(0, count);
      } else {
        return sortedByTotalScores;
      }
    };

    return Course;

  })();
  return Course;
});

//# sourceMappingURL=course.map
