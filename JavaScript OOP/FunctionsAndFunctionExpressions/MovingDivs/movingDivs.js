window.onload = function() {
  var movingShapes = (function() {
    var increase = Math.PI * 2,
      radius = 80,
      maxWidth = screen.width - 250,
      maxHeight = screen.height - 500,
      haveDivsInCircle = false,
      haveDivsInRectangle = false;

    var getRandomColor = function getRandomColor() {
      var letters = '0123456789ABCDEF'.split(''),
        color = '#';

      for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
      }
      return color;
    };

    var generateRandomDiv = function generateRandomDiv(shape) {
      var div = document.createElement("div");
      div.style.width = '25px';
      div.style.height = '25px';
      div.style.color = getRandomColor();
      div.style.background = getRandomColor();
      div.style.border = '1px solid' + getRandomColor();
      div.style.position = "absolute";
      var topPos = (Math.random() * maxHeight) + 100;
      div.style.top = topPos + "px";
      var left = (Math.random() * maxWidth) + 100;
      div.style.left = left + "px";

      switch (shape) {
        case 'circle':
          div.centerX = left;
          div.centerY = (topPos + radius);
          div.angle = 0;
          div.style.borderRadius = '20px';
          div.className = 'circle';
          break;
        case 'rectangle':
          div.startX = left;
          div.currentX = left;
          div.startY = topPos;
          div.currentY = topPos;
          div.movementDirection = 1;
          div.className = 'rectangle';
          break;
        default:
          break;
      }

      return div;
    };

    var moveInCircle = function moveInCircle() {
      var divsInCircle = document.querySelectorAll('.circle');

      for (var i = 0, len = divsInCircle.length; i < len; i++) {
        var x = radius * Math.cos(divsInCircle[i].angle) + divsInCircle[i].centerX;
        var y = radius * Math.sin(divsInCircle[i].angle) + divsInCircle[i].centerY;
        divsInCircle[i].style.left = x + "px";
        divsInCircle[i].style.top = y + "px";
        divsInCircle[i].angle += increase;
        divsInCircle[i].angle += 0.06;
      }
    };

    var moveInRectangle = function moveInRectangle() {
      var divsInRectangle = document.querySelectorAll('.rectangle');

      for (var i = 0, len = divsInRectangle.length; i < len; i++) {
        var dir = divsInRectangle[i].movementDirection,
          x = divsInRectangle[i].currentX,
          y = divsInRectangle[i].currentY,
          stX = divsInRectangle[i].startX,
          stY = divsInRectangle[i].startY;

        if (dir === 1 && x < (stX + (radius * 2))) {
          divsInRectangle[i].style.left = (x + 3) + "px";
          divsInRectangle[i].currentX = x + 3;
          if (divsInRectangle[i].currentX >= (stX + (radius * 2))) {
            divsInRectangle[i].movementDirection = 2;
          }
        } else if (dir === 2 && y < (stY + (radius * 2))) {
          divsInRectangle[i].style.top = (y + 3) + "px";
          divsInRectangle[i].currentY = y + 3;
          if (divsInRectangle[i].currentY >= (stY + (radius * 2))) {
            divsInRectangle[i].movementDirection = 3;
          }
        } else if (dir === 3 && x > stX) {
          divsInRectangle[i].style.left = (x - 3) + "px";
          divsInRectangle[i].currentX = x - 3;
          if (divsInRectangle[i].currentX <= stX) {
            divsInRectangle[i].movementDirection = 4;
          }
        } else if (dir === 4 && y > stY) {
          divsInRectangle[i].style.top = (y - 3) + "px";
          divsInRectangle[i].currentY = y - 3;
          if (divsInRectangle[i].currentY <= stY) {
            divsInRectangle[i].movementDirection = 1;
          }
        }
      }
    };

    var add = function add(shape) {
      switch (shape) {
        case 'circle':
          var newCircularDiv = generateRandomDiv('circle');
          document.body.appendChild(newCircularDiv);

          if (!haveDivsInCircle) {
            haveDivsInCircle = true;
            setInterval(moveInCircle, 1000 / 30);
          }
          break;
        case 'rectangle':
          var newRectangularDiv = generateRandomDiv('rectangle');
          document.body.appendChild(newRectangularDiv);

          if (!haveDivsInRectangle) {
            haveDivsInRectangle = true;
            setInterval(moveInRectangle, 1000 / 30);
          }
          break;
        default:
          break;
      }
    };

    return {
      add: add
    };
  }());
  var addCircleButton = document.querySelector('button#add-circle');
  var addRectangleButton = document.querySelector('button#add-rectangle');

  addCircleButton.addEventListener('click', function() {
    movingShapes.add('circle');
  });
  addRectangleButton.addEventListener('click', function() {
    movingShapes.add('rectangle');
  });
};
