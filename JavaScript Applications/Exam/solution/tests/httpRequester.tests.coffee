define ['chai','httpRequester'], (chai, httpRequester) ->
  should = chai.should()

  describe "httpRequester getJSON", () ->
    it "should return promise", () ->
      httpRequester.getJSON().should.respondTo 'then'
