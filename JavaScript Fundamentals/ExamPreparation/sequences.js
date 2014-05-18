function Solve(input) {
  var count = 1;
  var numbers = input.slice(1).map(Number);
  for (var i = 0; i < numbers.length - 1; i++) {
    if (numbers[i + 1] < numbers[i]) {
      count++;
    }
  }
  return count;
}

var test1 = [
  '9',
  '1',
  '8',
  '8',
  '7',
  '6',
  '5',
  '7',
  '7',
  '6'
];

var test2 = [
  '6',
  '1',
  '3',
  '-5',
  '8',
  '7',
  '-6'
];

console.log(Solve(test1));
console.log(Solve(test2));
