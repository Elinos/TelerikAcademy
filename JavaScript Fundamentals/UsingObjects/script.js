function insertDiv(content) {
  var newDiv = document.createElement("div");
  newDiv.innerHTML = content;
  document.body.appendChild(newDiv);
}

//TaskOne
insertDiv("Task One:");

function getPoint(x, y) {
  return {
    x: x,
    y: y
  };
}


function getLine(point1, point2) {
  return {
    pointA: point1,
    pointB: point2
  };
}

function calculateDistance(point1, point2) {
  return parseInt(Math.abs(point1.x - point2.x) * Math.abs(point1.x - point2.x) + Math.abs(point1.y - point2.y) * Math.abs(point1.y - point2.y));
}

function isPossibleFormingATriangle(line1, line2, line3) {
  var a = calculateDistance(line1.pointA, line1.pointB);
  var b = calculateDistance(line2.pointA, line2.pointB);
  var c = calculateDistance(line3.pointA, line3.pointB);
  if (a + b > c && a + c > b && b + c > a) {
    insertDiv("It's possible to form a tringle");
  } else {
    insertDiv("It's NOT possible to form a tringle");
  }
}

var p1 = getPoint(1, 2);
var p2 = getPoint(2, 2);
var p3 = getPoint(3, 1);

var l1 = getLine(p1, p2);
var l2 = getLine(p2, p3);
var l3 = getLine(p1, p3);

var n = calculateDistance(p3, p2);
insertDiv(n);


isPossibleFormingATriangle(l1, l2, l3);

//TaskTwo

insertDiv("Task Two:");

Array.prototype.remove = function(element) {
  var arr = this;
  var newArr = [];
  for (var i = 0; i < arr.length; i++) {
    if (arr[i] !== element) {
      newArr.push(arr[i]);
    }
  }
  return newArr;
};

var arr = [1, 2, 1, 4, 1, "1", 3, 4, 1, 111, 3, 2, 1, "1"];

var finalArr = arr.remove(1);

insertDiv(finalArr.join(", "));

//TaskThree
insertDiv('Task three:');

function copyMe(obj) {
  if (typeof(obj) !== "object")
    return obj;
  else {
    var copyObj = {};
    for (var prop in obj) {
      copyObj[prop] = copyMe(obj[prop]);
    }
    return copyObj;
  }
}

var myObj = {
  x: 1,
  y: 2
};
var copiedObj = copyMe(myObj);

for (var i in copiedObj) {
  insertDiv(i + " : " + copiedObj[i]);
}

//TaskFour
function hasProperty(obj, property) {
  for (var i in obj) {
    if (i === property) {
      return true;
    }
  }
  return false;
}

insertDiv("Task Four");
insertDiv("The object has property 'x': " + hasProperty(myObj, 'x'));

//TaskFive
insertDiv("Task Five:");

var persons = [{
  firstname: "Gosho",
  lastname: "Petrov",
  age: 32
}, {
  firstname: "Bay",
  lastname: "Ivan",
  age: 81
}, {
  firstname: "Pesho",
  lastname: "Motikata",
  age: 5
}];

function findYoungest(arr) {
  var youngestPersonPosition = 0;
  var youngestPersonAge = 200;

  for (var i in arr) {
    if (arr[i].age < youngestPersonAge) {
      youngestPersonAge = arr[i].age;
      youngestPersonPosition = i;
    }
  }

  insertDiv(arr[youngestPersonPosition].firstname + " " + arr[youngestPersonPosition].lastname + " " + arr[youngestPersonPosition].age);
}

findYoungest(persons);

//TaskSix
insertDiv("Task Six");
insertDiv("See console");

(function() {

  function join(persons, prop) {
    var result = {};

    persons.forEach(function(person) {
      var value = person[prop];

      result[value] = result[value] || [];

      result[value].push(person);
    });

    return result;
  }

  var persons =
    [{
      firstName: 'Gosho',
      lastName: 'Petrov',
      age: 40
    }, {
      firstName: 'Gosho',
      lastName: 'Ivan',
      age: 30
    }, {
      firstName: 'Bay',
      lastName: 'Ivan',
      age: 40
    }, {
      firstName: 'Bay',
      lastName: 'Ivan',
      age: 30
    }]

  , prop;

  for (prop in persons[0])
    console.log(join(persons, prop));
}());
