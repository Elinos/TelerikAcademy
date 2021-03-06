// Generated by CoffeeScript 1.7.1
define(['jquery', 'Persister'], function($, Persister) {
  var Controller;
  return Controller = (function() {
    var url;

    url = 'http://localhost:3000/students';

    function Controller(selector) {
      this.selector = $(selector);
      this.persister = new Persister(url);
    }

    Controller.prototype.addEvents = function() {
      var self;
      self = this;
      this.selector.on('click', '#list-students', function() {
        return window.location = '#/students';
      });
      this.selector.on('click', '#add-student', function() {
        return window.location = '#/add';
      });
      this.selector.on('click', '#delete-student', function() {
        return window.location = '#/delete';
      });
      this.selector.on('click', '.delete-button', function() {
        var studentID;
        studentID = self.getStudentId();
        return self.persister.deleteStudent(studentID).then(function() {
          var msg;
          msg = $('<div />').addClass('successMessage').text("Deleted student with ID : " + studentID);
          return self.selector.find('#page').append(msg.fadeIn(1500).fadeOut(1500));
        }, function(error) {
          var errorMsg;
          errorMsg = $('<div />').addClass('errorMessage').text("Something went wrong!");
          return self.selector.find('#page').append(errorMsg.fadeIn(3000).fadeOut(3000));
        });
      });
      return this.selector.on('click', '.add-button', function() {
        return self.persister.addStudent(self.getStudent()).then(function() {
          var msg;
          msg = $('<div />').addClass('successMessage').text('Student added!');
          return self.selector.find('#page').append(msg.fadeIn(1500).fadeOut(1500));
        }, function(error) {
          var errorMsg;
          errorMsg = $('<div />').addClass('errorMessage').text("Something went wrong!");
          return self.selector.find('#page').append(errorMsg.fadeIn(3000).fadeOut(3000));
        });
      });
    };

    Controller.prototype.loadMainPage = function(callback) {
      return this.selector.load('../partials/main.html', callback);
    };

    Controller.prototype.loadStudentsPage = function() {
      var self;
      this.selector.find('#page').empty();
      self = this;
      return this.persister.getStudents().then(function(data) {
        return self.generateList(data.students);
      }, function(error) {
        var errorMsg;
        errorMsg = $('<div />').addClass('errorMessage').text("Something went wrong!");
        return self.selector.find('#page').append(errorMsg.fadeIn(3000).fadeOut(3000));
      });
    };

    Controller.prototype.addStudentPage = function() {
      this.selector.find('#page').empty();
      return this.selector.find('#page').load('../partials/add.html');
    };

    Controller.prototype.deleteStudentPage = function() {
      this.selector.find('#page').empty();
      return this.selector.find('#page').load('../partials/delete.html');
    };

    Controller.prototype.generateList = function(students) {
      var row, student, table, _i, _len;
      if (students.length === 0) {
        return this.selector.find('#page').append($('<div />').text("No students"));
      } else {
        table = $('<table />').addClass('students-table');
        table.append($('<th />').text('ID'));
        table.append($('<th />').text('Name'));
        table.append($('<th />').text('Grade'));
        for (_i = 0, _len = students.length; _i < _len; _i++) {
          student = students[_i];
          row = $('<tr />');
          row.append($('<td />').text(student.id));
          row.append($('<td />').text(student.name));
          row.append($('<td />').text(student.grade));
          table.append(row);
        }
        return this.selector.find('#page').append(table);
      }
    };

    Controller.prototype.getStudentId = function() {
      return this.selector.find(".delete-input").val();
    };

    Controller.prototype.getStudent = function() {
      var grade, name;
      name = this.selector.find(".student-name-input").val();
      grade = this.selector.find(".student-grade-input").val();
      return {
        name: name,
        grade: grade
      };
    };

    return Controller;

  })();
});

//# sourceMappingURL=controller.map
