window.onload = function() {
  var specialConsole = (function() {
    var stringFormat = function stringFormat(str, args) {
      return str.replace(/\{(\d+)\}/g, function(match, p1) {
        return args[parseInt(p1) + 1].toString();
      });
    };

    var writeLine = function writeLine(message) {
      var selfArguments = arguments;

      if (selfArguments.length === 1) {
        console.log(message);
      } else {
        var formattedMessage = stringFormat(message, selfArguments);
        console.log(formattedMessage);
      }
    };

    var writeError = function writeError(message) {
      var selfArguments = arguments;

      if (selfArguments.length === 1) {
        console.error(message);
      } else {
        var formattedMessage = stringFormat(message, selfArguments);
        console.error(formattedMessage);
      }
    };

    var writeWarning = function writeWarning(message) {
      var selfArguments = arguments;

      if (selfArguments.length === 1) {
        console.warn(message);
      } else {
        var formattedMessage = stringFormat(message, selfArguments);
        console.warn(formattedMessage);
      }
    };

    return {
      writeLine: writeLine,
      writeError: writeError,
      writeWarning: writeWarning
    };
  }());

  specialConsole.writeLine("Message: hello");
  specialConsole.writeLine("Message: {0}", "hello");
  specialConsole.writeError("Error: {0}", "Something happened");
  specialConsole.writeWarning("Warning: {0}", "A warning");
};
