// Generated by CoffeeScript 1.7.1
define(['jquery'], function($) {
  var httpRequester;
  return httpRequester = (function() {
    var deleteJSON, getJSON, makeHTTPRequest, postJSON;
    makeHTTPRequest = function(url, type, data) {
      return $.ajax({
        url: url,
        type: type,
        data: JSON.stringify(data),
        contentType: "application/json",
        timeout: 5000
      });
    };
    getJSON = function(url) {
      return makeHTTPRequest(url, 'GET');
    };
    postJSON = function(url, data) {
      return makeHTTPRequest(url, 'POST', data);
    };
    deleteJSON = function(url) {
      return makeHTTPRequest(url, "POST", {
        _method: 'delete'
      });
    };
    return {
      getJSON: getJSON,
      postJSON: postJSON,
      deleteJSON: deleteJSON
    };
  })();
});

//# sourceMappingURL=httpRequester.map