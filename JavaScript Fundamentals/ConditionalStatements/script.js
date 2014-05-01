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

//TaskFour

//TaskFive

//TaskSix

//TaskSeven

//TaskEight