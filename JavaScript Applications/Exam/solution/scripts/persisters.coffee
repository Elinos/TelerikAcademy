define ['httpRequester'], (httpRequester) ->
  persisters = (() ->
    username = localStorage.getItem("username")
    sessionKey = localStorage.getItem("sessionKey")
    saveUserData = (userData) ->
      localStorage.setItem("username", userData.username)
      localStorage.setItem("sessionKey", userData.sessionKey)
      username = userData.username
      sessionKey = userData.sessionKey

    clearUserData = () ->
      localStorage.removeItem("username")
      localStorage.removeItem("sessionKey")
      username = ""
      sessionKey = ""

    class MainPersister
      constructor: (rootUrl) ->
        @rootUrl = rootUrl;
        @user = new UserPersister(@rootUrl);
        @post = new PostPersister(@rootUrl)
      isUserLoggedIn: () ->
        isLoggedIn = username != null && sessionKey != null

    class UserPersister
      constructor: (rootUrl) ->
        @rootUrl = rootUrl

      login: (user) ->
        url = @rootUrl + '/auth'
        userData =
          username: user.username,
          authCode: CryptoJS.SHA1(user.username + user.password).toString()
        httpRequester.postJSON(url, userData)
      register: (user) ->
        url = @rootUrl + '/user'
        userData =
          username: user.username,
          authCode: CryptoJS.SHA1(user.username + user.password).toString()

        httpRequester.postJSON(url, userData)

      logout: () ->
        url = @rootUrl + '/user'
        httpRequester.putJSON(url, {'X-SessionKey': sessionKey})

    class PostPersister
      constructor: (rootUrl) ->
        @rootUrl = rootUrl + "/post"

      getAllPosts: () ->
        url = @rootUrl + ''
        httpRequester.getJSON(url)

      createPost: (data) ->
        url = @rootUrl
        httpRequester.postJSON(url, data, {'X-SessionKey': sessionKey})


    get: (url) ->
      return new MainPersister(url)
    saveUserData: saveUserData
    clearUserData: clearUserData

  )()
