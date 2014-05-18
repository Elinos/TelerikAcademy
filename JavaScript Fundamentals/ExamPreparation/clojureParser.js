function Solve(input) {
  var functionResult = '';
  var functions = {};

  for (var i = 0; i < input.length; i++) {
    var secondFunction = false;
    var line = input[i].substring(1).trim();
    var currentOperator = '';
    var secondOperator = '';
    var lastFunctionName = '';
    var currentFuncNameOrNumber = '';
    var numbers = [];
    var innerNumbers = [];
    if (line.indexOf('def') === 0) {
      line = line.substring(3).trim();
    }

    for (var j = 0; j < line.length; j++) {
      var currentChar = line[j];

      if (currentChar === ' ' || currentChar === ')') {
        if (currentFuncNameOrNumber !== '' && !isFinite(currentFuncNameOrNumber)) {
          if (!functions[currentFuncNameOrNumber] && functions[currentFuncNameOrNumber] !== 0) {
            functions[currentFuncNameOrNumber] = 0;
            lastFunctionName = currentFuncNameOrNumber;
            currentFuncNameOrNumber = '';
          } else {
            if (secondFunction) {
              innerNumbers.push(functions[currentFuncNameOrNumber]);
            } else {
              numbers.push(functions[currentFuncNameOrNumber]);
            }

            currentFuncNameOrNumber = '';
          }
          continue;
        }

        if (currentFuncNameOrNumber !== '' && isFinite(currentFuncNameOrNumber)) {
          if (secondFunction) {
            innerNumbers.push(parseInt(currentFuncNameOrNumber));
          } else {
            numbers.push(parseInt(currentFuncNameOrNumber));
          }
          currentFuncNameOrNumber = '';
        }
        continue;
      }

      if (currentChar === '(') {
        secondFunction = true;
        continue;
      }

      if (isOperator(currentChar)) {
        if (currentChar === '-' && isNumber(line[j + 1])) {
          currentFuncNameOrNumber += '-';
          continue;
        }
        if (secondFunction) {
          secondOperator = currentChar;
          continue;
        }
        currentOperator = currentChar;
        continue;
      }

      if (isLetterOrNumber(currentChar)) {
        currentFuncNameOrNumber += currentChar;
        continue;
      }
    }
    if (currentFuncNameOrNumber !== '' && isFinite(currentFuncNameOrNumber)) {
      if (secondFunction) {
        innerNumbers.push(parseInt(currentFuncNameOrNumber));
      } else {
        numbers.push(parseInt(currentFuncNameOrNumber));
      }
      currentFuncNameOrNumber = '';
    }

    functionResult = solveFunction(numbers, currentOperator);
    if (secondFunction) {
      functionResult = solveFunction(innerNumbers, secondOperator);
    }

    if (lastFunctionName !== '') {
      functions[lastFunctionName] = functionResult;
      lastFunctionName = '';
    }

    if (!isNumber(functionResult)) {
      functionResult += i + 1;
      return functionResult;
    }
  }
  return functionResult;

  function isLetterOrNumber(char) {
    return char !== '(' && char !== ')';
  }

  function isOperator(char) {
    switch (char) {
      case '+':
        return true;
      case '-':
        return true;
      case '/':
        return true;
      case '*':
        return true;
      default:
        return false;
    }
  }

  function isNumber(char) {
    return isFinite(char) && char !== ' ';
  }

  function solveFunction(array, operator) {
    var result = array[0];
    for (var i = 1; i < array.length; i++) {
      switch (operator) {
        case '+':
          result += array[i];
          break;
        case '-':
          result -= array[i];
          break;
        case '/':
          if (array[i] === 0) {
            return "Division by zero! At Line:";
          }
          result = Math.floor(result / array[i]);
          break;
        case '*':
          result *= array[i];
          break;
        default:
          result += array[i];
          break;
      }
    }
    return result;
  }
}


var test1 = [
  '(def func 10)',
  '(def newFunc (+  func 2))',
  '(def sumFunc (+ func func newFunc 0 0 0))',
  '(* sumFunc 2)'
];
var test2 = [
  '(def func 0)',
  '(def newFunc (+  func 2))',
  '(def sumFunc (+ func func newFunc 0 0 0))',
  '(* sumFunc 2)'
];
var test3 = [
  '(def func (+ 5 2))',
  '(def func2 (/  func 5 2 1 0))',
  '(def func3 (/ func 2))',
  '(+ func3 func)'
];

console.log(Solve(test1));
console.log(Solve(test2));
console.log(Solve(test3));
