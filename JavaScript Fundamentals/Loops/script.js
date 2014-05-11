function insertDiv(content) {
  var newDiv = document.createElement("div");
  newDiv.innerHTML = content;
  document.body.appendChild(newDiv);
}

//TaskOne
function printAllNumbers(n) {
  var numbers = [];
  for (var i = 1; i <= n; i++) {
    numbers.push(i);
  }
  insertDiv(numbers.join(", "));
}
insertDiv("Task One:");
printAllNumbers(100);

//TaskTwo
function printAllNumbersNotDivisibleBy3and7(n) {
  var numbers = [];
  for (var i = 1; i <= n; i++) {
    if (i % 3 !== 0 || i % 7 !== 0) {
      numbers.push(i);
    }
  }
  insertDiv(numbers.join(", "));
}
insertDiv("Task Two:");
printAllNumbersNotDivisibleBy3and7(100);
//TaskThree
var numbers = [3, 5, 6, 7, 324, -2];
var max_of_array = Math.max.apply(Math, numbers);
var min_of_array = Math.min.apply(Math, numbers);

insertDiv("Task Three:");
insertDiv("The max number is " + max_of_array);
insertDiv("The max number is " + min_of_array);
//TaskFour

function findPropertiesOfObject(object) {
  var properties = [];

  /*jshint forin: false*/
  for (var prop in object) {
    properties.push(prop);
  }
  return properties;
}

var propertiesOfDocument = findPropertiesOfObject(document),
  propertiesOfWindow = findPropertiesOfObject(window),
  propertiesOfNavigator = findPropertiesOfObject(navigator);

var sortedPropertiesOfDocument = propertiesOfDocument.sort(),
  sortedPropertiesOfWindow = propertiesOfWindow.sort(),
  sortedPropertiesOfNavigator = propertiesOfNavigator.sort();

insertDiv("Task Four:");

function printTheSmallesAndLargestProperties(sortedArrayOfProperties, objectAsString) {
  insertDiv("The smallest property of " + objectAsString + " is " + sortedArrayOfProperties[0]);
  insertDiv("The largest property of " + objectAsString + " is " + sortedArrayOfProperties[sortedArrayOfProperties.length - 1]);
}

printTheSmallesAndLargestProperties(sortedPropertiesOfDocument, "document");
printTheSmallesAndLargestProperties(sortedPropertiesOfWindow, "window");
printTheSmallesAndLargestProperties(sortedPropertiesOfNavigator, "navigator");
