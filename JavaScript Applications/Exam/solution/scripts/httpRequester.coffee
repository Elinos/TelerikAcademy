define ['jquery'], ($) ->
  httpRequester = (() ->
    makeHTTPRequest = (url, type, data, headers) ->
      promise = new RSVP.Promise (resolve, reject)->
        $.ajax
          url: url
          type: type
          headers: headers
          data: JSON.stringify(data)
          contentType: "application/json"
          timeout: 5000
          success: (resultData) ->
            resolve resultData
          error: (errorData) ->
            reject errorData
    getJSON = (url) ->
      makeHTTPRequest(url, 'GET')

    postJSON = (url, data, headers) ->
      if headers
        makeHTTPRequest(url, 'POST', data, headers)
      else
        makeHTTPRequest(url, 'POST', data)

    putJSON = (url, headers) ->
      makeHTTPRequest(url, 'PUT', "", headers)

    putJSON: putJSON
    getJSON : getJSON
    postJSON : postJSON)()
