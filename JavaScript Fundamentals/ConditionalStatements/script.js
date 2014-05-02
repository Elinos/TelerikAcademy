function insertDiv(content) {
  var newDiv = document.createElement("div");
  newDiv.innerHTML = content;
  document.body.appendChild(newDiv);
}

function randomInRange(from, to) {
  return Math.floor(Math.random() * (to - from + 1)) + from;
}

//TaskOne
var first = randomInRange(-10, 10),
  second = randomInRange(-10, 10);

if (first > second) {
  var tmp = first;
  first = second;
  second = tmp;
}

insertDiv("Task One:");
insertDiv("Smaller number is " + first + " " + " the other is " + second);

//TaskTwo
var firstNumber = randomInRange(-10, 10),
  secondNumber = randomInRange(-20, 20),
  thirdNumber = randomInRange(-30, 30);

function isNegativeProduct(first, second, third) {
  var negativeCount = 0;
  if (first < 0) {
    negativeCount++;
  }
  if (second < 0) {
    negativeCount++;
  }
  if (third < 0) {
    negativeCount++;
  }

  return Math.pow(-1, negativeCount) < 0;
}

insertDiv("Task Two:");
if (firstNumber === 0 || secondNumber === 0 || thirdNumber === 0) {
  insertDiv("The product of " + firstNumber + ", " + secondNumber + " and " + thirdNumber +
    " will be 0: ");
}
else if (isNegativeProduct(firstNumber, secondNumber, thirdNumber))
  insertDiv("The product of " + firstNumber + ", " + secondNumber + " and " + thirdNumber +
    " will be negative");
else {
  insertDiv("The product of " + firstNumber + ", " + secondNumber + " and " + thirdNumber +
    " will be positive");
}

//TaskThree
insertDiv("Task Three:");

if (firstNumber > secondNumber) {
  if (firstNumber > thirdNumber) {
    insertDiv("The biggest number is " + firstNumber);
  }
  else {
    insertDiv("The biggest number is " + thirdNumber);
  }
}
else {
  if (secondNumber > thirdNumber) {
    insertDiv("The biggest number is " + secondNumber);
  }
  else {
    insertDiv("The biggest number is " + thirdNumber);
  }
}

//TaskFour
insertDiv("Task Four: ");

if (firstNumber >= secondNumber && firstNumber >= thirdNumber) {
  if (secondNumber >= thirdNumber) {
    insertDiv("Numbers in descending order are: " + firstNumber + ", " + secondNumber + ", " + thirdNumber);
  }
  else {
    insertDiv("Numbers in descending order are: " + firstNumber + ", " + thirdNumber + ", " + secondNumber);
  }
}
else if (secondNumber >= firstNumber && secondNumber >= thirdNumber) {
  if (thirdNumber >= firstNumber) {
    insertDiv("Numbers in descending order are: " + secondNumber + ", " + thirdNumber + ", " + firstNumber);
  }
  else {
    insertDiv("Numbers in descending order are: " + secondNumber + ", " + firstNumber + ", " + thirdNumber);
  }
}
else {
  if (firstNumber >= secondNumber) {
    insertDiv("Numbers in descending order are: " + thirdNumber + ", " + firstNumber + ", " + secondNumber);
  }
  else {
    insertDiv("Numbers in descending order are: " + thirdNumber + ", " + secondNumber + ", " + firstNumber);
  }
}

//TaskFive
var input = parseInt(prompt("Please enter a digit"));
insertDiv("Task Five");
switch (input) {
  case 0:
    insertDiv("The digit you entered was zero");
    break;
  case 1:
    insertDiv("The digit you entered was one");
    break;
  case 2:
    insertDiv("The digit you entered was two");
    break;
  case 3:
    insertDiv("The digit you entered was three");
    break;
  case 4:
    insertDiv("The digit you entered was four");
    break;
  case 5:
    insertDiv("The digit you entered was five");
    break;
  case 6:
    insertDiv("The digit you entered was six");
    break;
  case 7:
    insertDiv("The digit you entered was seven");
    break;
  case 8:
    insertDiv("The digit you entered was eight");
    break;
  case 9:
    insertDiv("The digit you entered was nine");
    break;
  default:
    insertDiv("The digit you entered was invalid!");
    break;
}

//TaskSix

function quadraticEquationSolver(a, b, c) {
  var sqrtpart = b * b - 4 * a * c;
  var x, x1, x2;
  if (sqrtpart > 0) {
    x1 = (-b + Math.sqrt(sqrtpart)) / (2 * a);
    x2 = (-b - Math.sqrt(sqrtpart)) / (2 * a);
    insertDiv("Two real solutions: " + x1 + " and " + x2);
  }
  else if (sqrtpart < 0) {
    insertDiv("No real solution!");
  }
  else {
    x = (-b + Math.sqrt(sqrtpart)) / (2 * a);
    insertDiv("One real solution: " + x);
  }
}

insertDiv("Task Six: ");
quadraticEquationSolver(firstNumber, secondNumber, thirdNumber);

//TaskSeven
insertDiv("Task Seven: ");
insertDiv("Numbers are: ");
var numbers = [];
for (var i = 0; i < 5; i++) {
  numbers[i] = randomInRange(-100, 100);
  insertDiv(numbers[i]);
}
var currentMax = numbers[0];
for (var i = 1; i < numbers.length; i++) {
  if (numbers[i] > currentMax) {
    currentMax = numbers[i];
  }
}
insertDiv("The biggest number is " + currentMax);

//TaskEight
var numberToParse = randomInRange(0, 999);
var hundreds = Math.floor(numberToParse / 100);
var tens = Math.floor((numberToParse % 100) / 10);
var ones = Math.floor(numberToParse % 10);

insertDiv("Task Eight:");
insertDiv("The number with digits: " + numberToParse);

var numberWithWords = "";

var words0 = ["One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine "];
var words1 = ["Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen "];
var words2 = ["", "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety "];

if (hundreds > 0) {
  numberWithWords += words0[hundreds - 1] + "Hundred ";
}
if (tens > 1) {
  if (ones === 0 && hundreds > 0) {
    numberWithWords += "and ";
  }
  numberWithWords += words2[tens - 1];
  if (ones > 0) {
    numberWithWords += words0[ones - 1];
  }
}
else if (tens === 1) {
  if (hundreds > 0) {
    numberWithWords += "and ";
  }
  numberWithWords += words1[ones];
}
else {
  if (hundreds > 0) {
    if (ones > 0) {
      numberWithWords += "and " + words0[ones - 1];
    }
  }
  else {
    if (numberToParse === 0) {
      numberWithWords += "Zero";
    }
    else {
      numberWithWords += words0[ones - 1];
    }
  }
}
insertDiv("The number with words: " + numberWithWords.trimRight());
