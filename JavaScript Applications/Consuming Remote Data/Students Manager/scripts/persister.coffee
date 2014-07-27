define ['httpRequester'], (httpRequester) ->
  class Persister
    constructor: (@url) ->
    getStudents: () ->
      httpRequester.getJSON(@url)
    addStudent: (student) ->
      httpRequester.postJSON(@url, student)
    deleteStudent: (id) ->
      httpRequester.deleteJSON(@url + "/#{id}")



