function insertDiv(content) {
  var newDiv = document.createElement("div");
  newDiv.innerHTML = content;
  document.body.appendChild(newDiv);
}

function randomInRange(from, to) {
  return Math.floor(Math.random() * (to - from + 1)) + from;
}

var randomNumber = randomInRange(1, 10000);

//TaskOne
function isOdd(number) {
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
function calculateRectangleArea(width, height) {
  return width * height;
}

var width = randomInRange(1, 100);
var height = randomInRange(1, 100);

insertDiv("Task Three:");
insertDiv("The area of rectangle with width of " + width + " and height of " +
  height + " is " + calculateRectangleArea(width, height));

//TaskFour
function checkThirdDigitOfNumber(number, checker) {
  var numberAsString = number.toString();
  var digitToCheck = numberAsString.charAt(numberAsString.length - 3);

  return parseInt(digitToCheck) === checker;
}

insertDiv("Task Four:");
insertDiv("The third digit(right to left) of the number " + randomNumber +
  " is 7 : " + checkThirdDigitOfNumber(randomNumber, 7));

//TaskFive
/*jshint bitwise: false*/

function checkIfBitIsSet(number, position) {
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

insertDiv("Task Six:");
if (inCircle(0, 0, 5, x, y)) {
  insertDiv("The point with coordinates x = " + x + " and y = " + y +" is within a circle K(O, 5)!");
}
else {
  insertDiv("The point with coordinates x = " + x + " and y = " + y +" is NOT within a circle K(O, 5)!");
}

//TaskSeven
function isPrime(number) {
  if (number % 1 || number < 2) return false;

  var m=Math.sqrt(number);
  for (var i = 2; i <= m; i++) {
    if (number % i === 0){
      return false;
    }
    return true;
  }
}

insertDiv("TaskSeven:");
var positiveIntegerNumber = randomInRange(1, 100);
if (isPrime(positiveIntegerNumber)) {
  insertDiv("The number " + positiveIntegerNumber + " is Prime!");
}
else {
  insertDiv("The number " + positiveIntegerNumber + " is NOT Prime!");
}

//TaskEight
function calculateAreaOfTrapezoid(baseOne, baseTwo, height) {
  return (baseOne + baseTwo) / 2 * height;
}

var a  = randomInRange(1, 10);
var b  = randomInRange(1, 10);
var h  = randomInRange(1, 10);

insertDiv("Task Eight:");
insertDiv("The area of Trapezoid with sides " + a + " and " + b +
          " and height " + h + " is " + calculateAreaOfTrapezoid(a, b, h));

//TaskNine
function inRectangle(rTop, rLeft, rWidth, rHeight, x, y) {
  var rBottom = rTop - rHeight;
  var rRight = rLeft + rWidth;

  var xWithinRectange = x >= rLeft && x <= rRight;
  var yWithinRectangle = y >= rBottom && y <= rTop;

  return xWithinRectange && yWithinRectangle;
}
var newX = randomInRange(-4, 4);
var newY = randomInRange(-4, 4);

insertDiv("Task Nine:");
if (inCircle(1, 1, 3, newX, newY) && !inRectangle(1, -1, 6, 2, newX, newY)) {
  insertDiv("The point with coordinates x = " + newX + " and y = " + newY +
            " is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2)");
}
else {
  insertDiv("The point with coordinates x = " + newX + " and y = " + newY +
            " is  NOT within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2)");
}
