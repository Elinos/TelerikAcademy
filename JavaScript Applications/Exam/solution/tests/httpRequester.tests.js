// Generated by CoffeeScript 1.7.1
define(['chai', 'httpRequester'], function(chai, httpRequester) {
  var should;
  should = chai.should();
  return describe("httpRequester getJSON", function() {
    return it("should return promise", function() {
      return httpRequester.getJSON().should.respondTo('then');
    });
  });
});

//# sourceMappingURL=httpRequester.tests.map