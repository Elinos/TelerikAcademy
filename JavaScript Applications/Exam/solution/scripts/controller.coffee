define ['jquery', 'persisters', 'handlebars'], ($, persisters, Handlebars) ->
  class Controller
    url = 'http://localhost:3000'
    constructor: (selector) ->
      @selector = $(selector)
      @persisters = persisters.get url

    addEvents: () ->
      self = @
      @selector.on('click', '#register-link', () ->
        window.location = '#/register')
      @selector.on('click', '#btn-register', () ->
        user =
          username: self.selector.find('#tb-register-username').val()
          password: self.selector.find('#tb-register-password').val()
        self.persisters.user.register(user).then(
          (data) ->
            successMsg = $('<div />').addClass('successMessage').text("User #{user.username} registered!")
            self.selector.find('.forms').append(successMsg.fadeIn(3000).fadeOut(3000))
          (error) ->
            errorMsg = $('<div />').addClass('errorMessage').text("Something went wrong!")
            self.selector.find('.forms').append(errorMsg.fadeIn(3000).fadeOut(3000))))
      @selector.on('click', '#logout-link', () ->
        self.persisters.user.logout().then(
          (data) ->
            successMsg = $('<div />').addClass('successMessage').text("User #{user.username} logouted!")
            self.selector.find('.forms').append(successMsg.fadeIn(3000).fadeOut(3000))
          (error) ->
            errorMsg = $('<div />').addClass('errorMessage').text("Something went wrong!")
            self.selector.find('.forms').append(errorMsg.fadeIn(3000).fadeOut(3000))))
      @selector.on('click', '#btn-login', () ->
        user =
          username: self.selector.find('#tb-login-username').val()
          password: self.selector.find('#tb-login-password').val()
        self.persisters.user.login(user).then(
          (data) ->
            successMsg = $('<div />').addClass('successMessage').text("User #{user.username} loged in!")
            self.selector.find('.forms').append(successMsg.fadeIn(3000).fadeOut(3000))
            self.selector.find('#register-link').hide()
            self.selector.find('#login-link').hide()
            self.selector.find('#login-form').hide()
            persisters.saveUserData(data)
            postForm = $('<div>').append($('<div>').text('Post Title'))
            postForm.append($('<input>').addClass('post-title'))
            postForm.append($('<div>').text('Post Body'))
            postForm.append($('<input>').addClass('post-body'))
            postForm.append($('<button>').addClass('post-bt').text('Add Post'))

            self.selector.find('.posts').prepend(postForm)
          (error) ->
            errorMsg = $('<div />').addClass('errorMessage').text("Something went wrong!")
            self.selector.find('.forms').append(errorMsg.fadeIn(3000).fadeOut(3000))))

      @selector.on('click', '.post-bt', () ->
        post =
          title: self.selector.find('.post-title').val()
          body: self.selector.find('.post-body').val()
        self.persisters.post.createPost(post).then(
          (data) ->
            successMsg = $('<div />').addClass('successMessage').text("Post created!")
            self.selector.find('.forms').append(successMsg.fadeIn(3000).fadeOut(3000))
            self.loadMainPage()
          (error) ->
            errorMsg = $('<div />').addClass('errorMessage').text("Something went wrong!")
            self.selector.find('.forms').append(errorMsg.fadeIn(3000).fadeOut(3000))))

      return false
    loadMainPage: (callback) ->
      @selector.load('../view/partials/main.html', callback)
      if @persisters.isUserLoggedIn()
              $('#register-link').hide()
              $('#login-link').hide()
      @loadPostsPage()

    loadPostsPage: () ->
      if @persisters.isUserLoggedIn()
        $('#register-link').hide()
        $('#login-link').hide()
      @selector.find('.posts').empty()
      self = @
      @persisters.post.getAllPosts().then(
        (data) ->
          $.get('../view/partials/posts.html', (partial) ->
            postTemplateHTML = $(partial).html()
            postTemplate = Handlebars.compile(postTemplateHTML);
            self.selector.find('.posts').html(postTemplate(data)))
        (error) ->
          errorMsg = $('<div />').addClass('errorMessage').text("Something went wrong!")
          self.selector.find('.posts').append(errorMsg.fadeIn(3000).fadeOut(3000)))

    loadRegisterPage: () ->
      @selector.find('.forms').empty()
      @selector.find('.forms').load("../view/partials/login.html #register-form")

    loadLoginPage: () ->
      if @persisters.isUserLoggedIn()
        $('#register-link').hide()
        $('#login-link').hide()
      @selector.find('.forms').empty()
      @selector.find('.forms').load("../view/partials/login.html #login-form")
