function insertDiv(content) {
  var newDiv = document.createElement("div");
  newDiv.innerHTML = content;
  document.body.appendChild(newDiv);
}

//TaskOne
var arrayOfIntgers = [];

for (var i = 0; i < 20; i++) {
  arrayOfIntgers[i] = i * 5;
}
insertDiv("Task One:");
insertDiv(arrayOfIntgers.join(", "));

//TaskTwo
var str = "string1",
  str2 = "string2";

function compareStrings(strOne, strTwo) {
  if (strOne.length !== strTwo.length) {
    return false;
  }

  for (var i = 0; i < strOne.length; i++) {
    if (strOne[i] !== strTwo[i]) {
      return false;
    }
  }

  return true;
}
insertDiv("Task Two:");
insertDiv("The strings are equal: " + compareStrings(str, str2));

//TaskThree
var arrayOfNumbers = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1];

function arrayOfMaxSequence(array) {
  var maxCount = 1,
    currentCount = 1,
    maxChar = array[0],
    currentChar = array[0];

  for (var i = 1; i < array.length; i++) {
    if (array[i] === currentChar) {
      currentCount++;
    } else {
      currentChar = array[i];
      currentCount = 1;
    }

    if (currentCount > maxCount) {
      maxCount = currentCount;
      maxChar = currentChar;
    }
  }
  var returnedArray = new Array(maxCount);
  for (var k = 0; k < returnedArray.length; k++) {
    returnedArray[k] = maxChar;
  }
  return returnedArray;
}

insertDiv("Task Tree:");
insertDiv(arrayOfMaxSequence(arrayOfNumbers).join(", "));

//TaskFour
function maximalIncreasingSequence(remainingSequence, biggerThan) {
  var sequenceWith = [];
  if (remainingSequence.length === 0) {
    return remainingSequence;
  }
  var bestSequence = maximalIncreasingSequence(remainingSequence.slice(1, remainingSequence.length), biggerThan);
  var first = remainingSequence[0];

  if ((first > biggerThan) || (biggerThan === null)) {
    sequenceWith = [first].concat(maximalIncreasingSequence(remainingSequence.slice(1, remainingSequence.length), first));
  }
  if (sequenceWith.length >= bestSequence.length) {
    bestSequence = sequenceWith;
  }
  return bestSequence;
}

insertDiv("Task Four:");
insertDiv(maximalIncreasingSequence([3, 2, 3, 4, 2, 2, 4], null).join(", "));

//TaskFive
function selectionSort(array) {
  var i, j, tmp, tmp2;
  for (i = 0; i < array.length - 1; i++) {
    tmp = i;
    for (j = i + 1; j < array.length; j++)
      if (array[j] < array[tmp])
        tmp = j;

    tmp2 = array[tmp];
    array[tmp] = array[i];
    array[i] = tmp2;
  }
}

var arrayToSort = [3, 2, 3, 4, 2, 2, 4];
selectionSort(arrayToSort);

insertDiv("Task Five:");
insertDiv(arrayToSort);

//TaskSix
var myArray = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];
var sortedArray = myArray.sort(function(a, b) {
  return a - b;
});

var arrayWithMostFrequentNumber = arrayOfMaxSequence(sortedArray);

insertDiv("Task Six:");
insertDiv("The most frequent number in the array is " +
  arrayWithMostFrequentNumber[0] + "(" + arrayWithMostFrequentNumber.length + " times)");

//TaskSeven
function binaryIndexOf(array, searchElement) {
  /*jshint bitwise: false*/
  var minIndex = 0;
  var maxIndex = array.length - 1;
  var currentIndex;
  var currentElement;

  while (minIndex <= maxIndex) {
    currentIndex = (minIndex + maxIndex) / 2 | 0;
    currentElement = array[currentIndex];

    if (currentElement < searchElement) {
      minIndex = currentIndex + 1;
    } else if (currentElement > searchElement) {
      maxIndex = currentIndex - 1;
    } else {
      return currentIndex;
    }
  }

  return -1;
}

var arrayToSearchIn = [0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95];

var index = binaryIndexOf(arrayToSearchIn, 5);

insertDiv("Task Seven:");
insertDiv("The index of numer 5 is " + index);
