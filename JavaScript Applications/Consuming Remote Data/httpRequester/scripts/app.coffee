define () ->
  require.config
    paths:
      'jquery': 'libs/jquery/dist/jquery.min'
      'httpRequester': 'httpRequester'

  require ['jquery', 'httpRequester'], ($, httpRequester) ->
    renderStudents = (data) ->
      parsedData = JSON.parse(data)
      list = $('<ul />')
      for student in parsedData
        list.append('<li>' + student.fname + ' ' + student.lname + ':' + ' ' + student.marks + '</li>')
      $('#results').append(list)

    getData = () ->
      httpRequester.getJSON('scripts/data.js').then (data) -> renderStudents data

    $('#get-results-btn').click getData

