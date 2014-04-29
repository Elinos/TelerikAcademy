function insertDiv (content) {
  var newDiv = document.createElement("div");
  newDiv.innerHTML = content;
  document.body.appendChild(newDiv);
}

//Task One
var pesho, пешо, $test, _task, myVar45, quote;

pesho = 5;
пешо = "гошо";
$test = 2.4;
_task = "my task";
myVar45 = 45;

//Task Two
quote = '"How you doin\'?", Joey said.';

//Task Three
insertDiv("Type of '" + pesho + "' is " + typeof pesho);
insertDiv("Type of '" + пешо + "' is " + typeof пешо);
insertDiv("Type of '" + $test + "' is " + typeof $test);
insertDiv("Type of '" + _task + "' is " + typeof _task);
insertDiv("Type of '" + myVar45 + "' is " + typeof myVar45);
insertDiv("Type of '" + quote + "' is " + typeof quote);

//Task Four
var myNull, myUndefined;

myNull = null;
myUndefined = undefined;

insertDiv("Type of '" + myNull + "' is " + myNull);
insertDiv("Type of '" + myUndefined + "' is " + myUndefined);
