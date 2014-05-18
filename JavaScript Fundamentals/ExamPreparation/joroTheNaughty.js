function Solve(input) {
  var firstInputRow = input[0].split(' ').map(Number),
    secondInputRow = input[1].split(' ').map(Number),
    N = firstInputRow[0],
    M = firstInputRow[1],
    J = firstInputRow[2],
    startRow = secondInputRow[0],
    startCol = secondInputRow[1],
    matrix = [],
    number = 1,
    sumOfNumbers = 0,
    countOfJumps = 0,
    jumps = [],
    visited = {};

  for (var i = 0; i < J; i++) {
    var jump = input[i + 2].split(' ').map(Number);
    jumps.push(jump);
  }

  for (i = 0; i < N; i++) {
    matrix[i] = [];
    for (var j = 0; j < M; j++) {
      matrix[i][j] = number++;
    }
  }

  var currentRow = startRow;
  var currentCol = startCol;

  while (true) {
    if (!inRange(currentRow, currentCol, matrix)) {
      return "escaped " + sumOfNumbers;
    }
    var currentNumber = matrix[currentRow][currentCol];

    if (visited[currentNumber]) {
      return "caught " + countOfJumps;
    }

    currentRow += jumps[countOfJumps % J][0];
    currentCol += jumps[countOfJumps % J][1];

    visited[currentNumber] = true;
    countOfJumps++;
    sumOfNumbers += currentNumber;
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
  '6 7 3',
  '0 0',
  '2 2',
  '-2 2',
  '3 -1'
];

console.log(Solve(test1));
