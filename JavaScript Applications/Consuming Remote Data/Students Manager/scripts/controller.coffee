define ['jquery', 'Persister'], ($, Persister) ->
  class Controller
    url = 'http://localhost:3000/students'
    constructor: (selector) ->
      @selector = $(selector)
      @persister = new Persister url

    addEvents: () ->
      self = @
      @selector.on('click', '#list-students', () ->
        window.location = '#/students')
      @selector.on('click', '#add-student', () ->
        window.location = '#/add')
      @selector.on('click', '#delete-student', () ->
        window.location = '#/delete')
      @selector.on('click', '.delete-button', () ->
        studentID = self.getStudentId()
        self.persister.deleteStudent(studentID).then(
          () ->
            msg = $('<div />').addClass('successMessage')
                              .text("Deleted student with ID : #{studentID}")
            self.selector.find('#page').append(msg.fadeIn(1500).fadeOut(1500))
          (error) ->
            errorMsg = $('<div />').addClass('errorMessage').text("Something went wrong!")
            self.selector.find('#page').append(errorMsg.fadeIn(3000).fadeOut(3000))))
      @selector.on('click', '.add-button', () ->
        self.persister.addStudent(self.getStudent()).then(
          () ->
            msg = $('<div />').addClass('successMessage').text('Student added!')
            self.selector.find('#page').append(msg.fadeIn(1500).fadeOut(1500))
          (error) ->
            errorMsg = $('<div />').addClass('errorMessage').text("Something went wrong!")
            self.selector.find('#page').append(errorMsg.fadeIn(3000).fadeOut(3000))))

    loadMainPage: (callback) ->
      @selector.load('../partials/main.html', callback)

    loadStudentsPage: () ->
      @selector.find('#page').empty()
      self = @
      @persister.getStudents().then(
        (data) ->
          self.generateList(data.students)
        (error) ->
          errorMsg = $('<div />').addClass('errorMessage').text("Something went wrong!")
          self.selector.find('#page').append(errorMsg.fadeIn(3000).fadeOut(3000)))

    addStudentPage: () ->
      @selector.find('#page').empty()
      @selector.find('#page').load('../partials/add.html')

    deleteStudentPage: () ->
      @selector.find('#page').empty()
      @selector.find('#page').load('../partials/delete.html')

    generateList: (students) ->
      if students.length == 0
        @selector.find('#page').append ($('<div />').text("No students"))
      else
        table = $('<table />').addClass('students-table')
        table.append $('<th />').text('ID')
        table.append $('<th />').text('Name')
        table.append $('<th />').text('Grade')
        for student in students
          row = $('<tr />')
          row.append($('<td />').text student.id)
          row.append($('<td />').text student.name)
          row.append($('<td />').text student.grade)
          table.append row
        @selector.find('#page').append table

    getStudentId: () ->
      @selector.find(".delete-input").val()

    getStudent: () ->
      name = @selector.find(".student-name-input").val()
      grade = @selector.find(".student-grade-input").val()
      name: name
      grade: grade



