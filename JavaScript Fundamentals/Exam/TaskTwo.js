function solve(input) {
  var firstRow = input[0].split(' ');
  var rows = parseInt(firstRow[0]);
  var cols = parseInt(firstRow[1]);
  var sum = 0;
  var steps = 0;

  var matrix = [];
  var directions = [];

  for (var i = 0; i < rows; i++) {
    matrix[i] = [];
    for (var j = 0; j < cols; j++) {
      matrix[i][j] = Math.pow(2, i) - j;
    }
  }

  for (i = 0; i < rows; i++) {
    directions.push(input[i + 1].split('').map(Number));
  }
  var currentRow = rows - 1;
  var currentCol = cols - 1;
  var currentDirection = directions[currentRow][currentCol];

  while (true) {
    if (!inRange(currentRow, currentCol, matrix)) {
      return 'Go go Horsy! Collected ' + sum + ' weeds';
    }
    var currentNumber = matrix[currentRow][currentCol];

    if (directions[currentRow][currentCol] === "x") {
      return 'Sadly the horse is doomed in ' + steps + ' jumps';
    }
    directions[currentRow][currentCol] = "x";


    currentRow += getDirection(currentDirection).row;
    currentCol += getDirection(currentDirection).col;

    if (inRange(currentRow, currentCol, matrix)) {
      currentDirection = directions[currentRow][currentCol];
    }

    steps++;
    sum += currentNumber;
  }

  function getDirection(number) {
    switch (number) {
      case 1:
        return {
          row: -2,
          col: 1
        };
      case 2:
        return {
          row: -1,
          col: 2
        };
      case 3:
        return {
          row: 1,
          col: 2
        };
      case 4:
        return {
          row: 2,
          col: 1
        };
      case 5:
        return {
          row: 2,
          col: -1
        };
      case 6:
        return {
          row: 1,
          col: -2
        };
      case 7:
        return {
          row: -1,
          col: -2
        };
      case 8:
        return {
          row: -2,
          col: -1
        };
    }
  }

  function inRange(row, col, matrix) {
    if (0 <= row && row < matrix.length &&
      0 <= col && col < matrix[0].length) {
      return true;
    }
    return false;
  }
}

var test1 = [
  '3 5',
  '54361',
  '43326',
  '52181'
];

var test2 = [
  '3 5',
  '54361',
  '43326',
  '52188'
];

console.log(solve(test2));
