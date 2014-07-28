define ['chai','httpRequester'], (chai, httpRequester) ->
  should = chai.should()

  describe "httpRequester getJSON", () ->
    it "should return promise", () ->
      httpRequester.getJSON().should.respondTo 'then'
    it "should return error with no data", () ->
      httpRequester.getJSON().then (() -> ), (error, status) -> status.should.be.gt 200
    it "should return data with correct url", () ->
      response = '[
                    {
                      "fname": "George",
                      "lname": "Todorov",
                      "marks": "4, 5, 6"
                    }, {
                      "fname": "Ivan",
                      "lname": "Ivanov",
                      "marks": "4, 5, 6"
                    }, {
                      "fname": "Petrov",
                      "lname": "Georgiev",
                      "marks": "4, 5, 6"
                    }, {
                      "fname": "Stamat",
                      "lname": "Petrov",
                      "marks": "4, 5, 6"
                    }, {
                      "fname": "Nikolay",
                      "lname": "Nikolov",
                      "marks": "4, 5, 6"
                    }, {
                      "fname": "Jana",
                      "lname": "Todorova",
                      "marks": "4, 5, 6"
                    }, {
                      "fname": "Maria",
                      "lname": "Ivanova",
                      "marks": "4, 5, 6"
                    }, {
                      "fname": "Ina",
                      "lname": "Georgieva",
                      "marks": "4, 5, 6"
                    }, {
                      "fname": "Denitsa",
                      "lname": "Petrova",
                      "marks": "4, 5, 6"
                    }, {
                      "fname": "Kameliya",
                      "lname": "Georgieva",
                      "marks": "4, 5, 6"
                    }
                  ]'
      httpRequester.getJSON('../scripts/data.js').then ((data) -> data.should.equal response), (error) ->







