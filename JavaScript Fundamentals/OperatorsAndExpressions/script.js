function insertDiv (content) {
  var newDiv = document.createElement("div");
  newDiv.innerHTML = content;
  document.body.appendChild(newDiv);
}

function randomInRange (from, to) {
  return Math.floor((Math.random() * to) + from);
}

var randomNumber = randomInRange(1, 10000);

//TaskOne
function isOdd (number) {
  if (number % 2 === 0) {
    return true;
  }
}

insertDiv("Task One:");
if (isOdd(randomNumber)) {
  insertDiv("The number " + randomNumber + " is odd");
}
else {
  insertDiv("The number " + randomNumber + " is even");
}

//TaskTwo
insertDiv("Task Two:");
if (randomNumber % 7 === 0 && randomNumber % 5 === 0) {
  insertDiv("The number " + randomNumber + " can be devided by 5 and 7 at the same time!");
}
else {
  insertDiv("The number " + randomNumber + " can NOT be devided by 5 and 7 at the same time!");
}

//TaskThree
function calculateRectangleArea (width, height) {
  return width * height;
}

var width = randomInRange(1, 100);
var height = randomInRange(1, 100);

insertDiv("Task Three:");
insertDiv("The area of rectangle with width of " + width + " and height of " +
          height + " is " + calculateRectangleArea(width, height));

//TaskFour
function checkThirdDigitOfNumber (number, checker) {
  var numberAsString = number.toString();
  var digitToCheck = numberAsString.charAt(numberAsString.length - 3);

  return parseInt(digitToCheck) === checker;
}

insertDiv("Task Four:");
insertDiv("The third digit(right to left) of the number " + randomNumber +
          " is 7 : " + checkThirdDigitOfNumber(randomNumber, 7));

//TaskFive
/*jshint bitwise: false*/

function checkIfBitIsSet (number, position) {
  return !!(number & (1 << position));
}

insertDiv("Task Five:");
if (checkIfBitIsSet(randomNumber, 3)) {
  insertDiv("The bit at position 3 in number " + randomNumber + "(" + randomNumber.toString(2)+ ")" + " is SET!");
}
else {
  insertDiv("The bit at position 3 in number " + randomNumber + "(" + randomNumber.toString(2)+ ")" + " is NOT SET!");
}

//TaskSix
function inCircle(center_x, center_y, radius, x, y) {
  var square_dist = Math.pow((center_x - x), 2) + Math.pow((center_y - y), 2);
  return square_dist <= Math.pow(radius, 2);
}

var x = randomInRange(-10, 10);
var y = randomInRange(-10, 10);

insertDiv("Task Six");
if (inCircle(0, 0, 5, x, y)) {
  insertDiv("The point with coordinates x = " + x + " and y = " + y +" is within a circle K(O, 5)!");
}
else {
  insertDiv("The point with coordinates x = " + x + " and y = " + y +" is NOT within a circle K(O, 5)!");
}
