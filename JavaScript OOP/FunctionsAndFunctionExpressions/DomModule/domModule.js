window.onload = function() {
  var domModule = (function() {
    var buffer = [];

    var appendChild = function appendChild(element, selector) {
      var selectedParent = document.querySelector(selector);
      selectedParent.appendChild(element);
    };

    var removeChild = function removeChild(parentElementSelector, selector) {
      var selectedParent = document.querySelector(parentElementSelector),
        elementToRemove = selectedParent.querySelector(selector);

      selectedParent.removeChild(elementToRemove);
    };

    var addHandler = function addHandler(selector, eventType, callback) {
      var selectedElements = document.querySelectorAll(selector);

      for (var i = 0; i < selectedElements.length; i++) {
        selectedElements[i].addEventListener(eventType, callback);
      }
    };

    var appendFromBufferToDom = function appendFromBufferToDom(selector) {
      var elements = buffer[selector];

      for (var i = 0; i < elements.length; i++) {
        var elementToAppend = elements[i];
        appendChild(elementToAppend, selector);
      }
      buffer[selector] = [];
    };

    var appendToBuffer = function appendToBuffer(selector, element) {
      if (buffer[selector]) {
        buffer[selector].push(element);
      } else {
        buffer[selector] = [element];
      }

      if (buffer[selector].length === 100) {
        appendFromBufferToDom(selector);
      }
    };

    return {
      appendChild: appendChild,
      removeChild: removeChild,
      addHandler: addHandler,
      appendToBuffer: appendToBuffer
    };
  }());

  var div = document.createElement("div");
  div.style.width = '10px';
  div.style.height = '10px';
  div.style.background = 'red';
  div.style.border = '1px solid black';
  div.style.display = 'inline-block';

  //appends div to #wrapper
  domModule.appendChild(div, "#wrapper");

  //removes li:first-child from ul
  domModule.removeChild("ul", "li:first-child");

  //add handler to each a element with class button
  domModule.addHandler("a.button", 'click',
    function() {
      alert("Clicked anchor #" + this.innerText);
    });

  //appendToBuffer
  for (var i = 0; i < 99; i++) {
    domModule.appendToBuffer("#container", div.cloneNode(true));
  }
  for (var j = 0; j < 100; j++) {
    domModule.appendToBuffer("#main-nav ul", div.cloneNode(true));
  }
};
