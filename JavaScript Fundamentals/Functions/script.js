function insertDiv(content) {
  var newDiv = document.createElement("div");
  newDiv.innerHTML = content;
  document.body.appendChild(newDiv);
}

function randomInRange(from, to) {
  return Math.floor(Math.random() * (to - from + 1)) + from;
}

//TaskOne

function lastDigitAsWord(number) {
  var digit = Math.abs(number % 10);

  switch (digit) {
    case 0:
      insertDiv("The last digit was zero");
      break;
    case 1:
      insertDiv("The last digit was one");
      break;
    case 2:
      insertDiv("The last digit was two");
      break;
    case 3:
      insertDiv("The last digit was three");
      break;
    case 4:
      insertDiv("The last digit was four");
      break;
    case 5:
      insertDiv("The last digit was five");
      break;
    case 6:
      insertDiv("The last digit was six");
      break;
    case 7:
      insertDiv("The last digit was seven");
      break;
    case 8:
      insertDiv("The last digit was eight");
      break;
    case 9:
      insertDiv("The last digit was nine");
      break;
    default:
      insertDiv("The last digit was invalid!");
      break;
  }
}

var number = randomInRange(-1000, 1000);

insertDiv("Task One:");
insertDiv("Number: " + number);
lastDigitAsWord(number);

//TaskTwo
function reverseNumber(number) {
  var numberAsArray = number.toString().split("");

  if (number < 0) {
    numberAsArray.shift();
    insertDiv("The reversed number is: -" + numberAsArray.reverse().join(""));
  } else {
    insertDiv("The reversed number is: " + numberAsArray.reverse().join(""));
  }
}

insertDiv("Task Two:");
reverseNumber(number);

//TaskThree
function searchWord(text, word, isCaseSensitive) {
  var regex,
    indices = [];
  if (isCaseSensitive) {
    regex = new RegExp("\\b" + word + "\\b", "g");
  } else {
    regex = new RegExp("\\b" + word + "\\b", "gi");
  }

  while (regex.exec(text)) {
    indices.push(regex.lastIndex - word.length);
  }
  return indices;
}

var text = "Stackoverflow is the best of the Best",
  word = "best",
  resultCaseSensitive = searchWord(text, word, true),
  resultCaseInsensitive = searchWord(text, word, false);

insertDiv("Task Three:");
insertDiv("Text: " + text);

if (!resultCaseInsensitive && !resultCaseSensitive) {
  insertDiv("The word was not found!");
} else {
  insertDiv("The word '" + word + "' was found on index(s): " + resultCaseSensitive.join(", ") + " - case sensitive");
  insertDiv("The word '" + word + "' was found on index(s): " + resultCaseInsensitive.join(", ") + " - case insensitive");
}

//TaskFour
function findDivs(page) {
  return page.match(/\/div/g).length;
}

var currentPage = document.getElementsByTagName('html')[0].innerHTML;

insertDiv("Task Four:");
insertDiv("The current page have " + findDivs(currentPage) + " divs(loaded till now)");

//TaskFive
function countInArray(array, what) {
  var count = 0;
  for (var i = 0; i < array.length; i++) {
    if (array[i] === what) {
      count++;
    }
  }
  return count;
}

function testCountArray() {
  return countInArray(array, 4) === 4;
}

var array = [2, 2, 1, 3, 3, 5, 4, 4, 4, 4],
  numberToSearch = 3;

insertDiv("Task Five:");
insertDiv("The number " + numberToSearch + " was found " + countInArray(array, numberToSearch) + " times");
insertDiv("The function countInArray is working correctly: " + testCountArray());

//TaskSix
function biggerThanItsNeighbors(array, index) {
  if (index === 0) {
    return array[index] > array[index + 1];
  } else if (index === array.length - 1) {
    return array[index] > array[index - 1];
  } else {
    return array[index] > array[index - 1] && array[index] > array[index + 1];
  }
}

var index = 5;

insertDiv("Task Six:");
insertDiv("The number on index " + index + " is bigger than its neighbors: " + biggerThanItsNeighbors(array, index));

//TaskSeven
function findBigNeighbor(array) {
  for (var i = 0; i < array.length; i++) {
    if (biggerThanItsNeighbors(array, i)) {
      return i;
    }
  }
  return -1;
}

insertDiv("Task Seven:");
insertDiv("The first element in array that is bigger than its neighbors is " + findBigNeighbor(array));
