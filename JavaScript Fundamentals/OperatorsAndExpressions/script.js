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
