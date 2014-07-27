define ['jquery'], ($) ->
  httpRequester = (() ->
    makeHTTPRequest = (url, type, data) ->
      $.ajax
        url: url
        type: type
        data: JSON.stringify(data)
        contentType: "application/json"
        timeout: 5000

    getJSON = (url) ->
      makeHTTPRequest(url, 'GET')

    postJSON = (url, data) ->
      makeHTTPRequest(url, 'POST', data)

    deleteJSON = (url) ->
      makeHTTPRequest(url, "POST", {_method: 'delete'})

    getJSON : getJSON
    postJSON : postJSON
    deleteJSON: deleteJSON)()
