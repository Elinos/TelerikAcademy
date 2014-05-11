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
    }
    else {
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

//TaskSix

//TaskSeven
