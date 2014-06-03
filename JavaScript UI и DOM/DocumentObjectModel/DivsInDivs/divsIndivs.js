(function findDivsInDivs() {
  var divs = document.getElementsByTagName('div');

  for (var i = 0; i < divs.length; i++) {
    if (divs[i].parentNode.nodeName === 'DIV') {
      console.log(divs[i]);
    }
  }
})();

var divsInDivsWithQuery = document.querySelectorAll('div>div');
console.log(divsInDivsWithQuery);
