function Solve(input) {
  var S = parseInt(input[0]);
  var C1 = parseInt(input[1]);
  var C2 = parseInt(input[2]);
  var C3 = parseInt(input[3]);

  var currentSum = 0;
  var currentMax = 0;

  for (var i = 0; i < S / C1 + 1; i++) {
    for (var j = 0; j < S / C2 + 1; j++) {
      for (var k = 0; k < S / C3 + 1; k++) {
        currentSum = (i * C1) + (j * C2) + (k * C3);
        if (currentSum <= S) {
          currentMax = Math.max(currentSum, currentMax);
        }
      }
    }
  }
  return currentMax;
}

var test1 = [
'110',
'13',
'15',
'17'
];

console.log(Solve(test1));
