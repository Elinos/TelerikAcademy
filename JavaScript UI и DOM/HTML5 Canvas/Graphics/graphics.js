window.onload = function() {
  var canvas = document.getElementById('the-canvas');
  var ctx = canvas.getContext('2d');
  canvas.style.backgroundColor = "#444";

  function drawCylinder(x, y, w, h) {
    var xPos, yPos;
    ctx.beginPath(); //to draw the top circle
    for (var i = 0 * Math.PI; i < 2 * Math.PI; i += 0.001) {

      xPos = (x + w / 2) - (w / 2 * Math.sin(i)) *
        Math.sin(0 * Math.PI) + (w / 2 * Math.cos(i)) *
        Math.cos(0 * Math.PI);

      yPos = (y + h / 8) + (h / 8 * Math.cos(i)) *
        Math.sin(0 * Math.PI) + (h / 8 *
          Math.sin(i)) * Math.cos(0 * Math.PI);

      if (i === 0) {
        ctx.moveTo(xPos, yPos);

      } else {
        ctx.lineTo(xPos, yPos);

      }
    }
    ctx.moveTo(x, y + h / 8);
    ctx.lineTo(x, y + h - h / 8);

    for (i = 0 * Math.PI; i < Math.PI; i += 0.001) {
      xPos = (x + w / 2) - (w / 2 * Math.sin(i)) * Math.sin(0 * Math.PI) + (w / 2 * Math.cos(i)) * Math.cos(0 * Math.PI);
      yPos = (y + h - h / 8) + (h / 8 * Math.cos(i)) * Math.sin(0 * Math.PI) + (h / 8 * Math.sin(i)) * Math.cos(0 * Math.PI);

      if (i === 0) {
        ctx.moveTo(xPos, yPos);

      } else {
        ctx.lineTo(xPos, yPos);
      }
    }
    ctx.moveTo(x + w, y + h / 8);
    ctx.lineTo(x + w, y + h - h / 8);
    ctx.stroke();
  }

  function drawCircle(x, y, radius, borderWidth, borderColor, backgroundColor) {
    ctx.beginPath();
    ctx.save();
    ctx.arc(x, y, radius, 0, 2 * Math.PI);
    ctx.fillStyle = backgroundColor;
    ctx.strokeStyle = borderColor;
    ctx.lineWidth = borderWidth;
    ctx.fill();
    ctx.stroke();
    ctx.restore();
    ctx.closePath();
  }

  function drawElipse(x, y, radius, borderWidth, borderColor, backgroundColor, scaleX, scaleY) {
    ctx.beginPath();
    ctx.save();
    ctx.scale(scaleX, scaleY);
    drawCircle(x, y, radius, borderWidth, borderColor, backgroundColor);
    ctx.restore();
    ctx.closePath();
  }

  // Draw Face
  ctx.beginPath();
  drawElipse(250, 250, 70, 3, '#006060', '#87CEEB', 1, 1);
  drawElipse(300, 450, 17, 3, '#006060', '#87CEEB', 0.7, 0.5);
  drawElipse(400, 450, 17, 3, '#006060', '#87CEEB', 0.7, 0.5);
  drawElipse(680, 450, 10, 3, 'black', '#006060', 0.3, 0.5);
  drawElipse(920, 450, 10, 3, '#006060', '#006060', 0.3, 0.5);

  ctx.moveTo(250, 230);
  ctx.lineTo(240, 260);
  ctx.lineTo(260, 260);
  ctx.stroke();

  drawElipse(250, 720, 25, 3, '#006060', '#87CEEB', 1, 0.4);
  drawElipse(250, 940, 70, 5, 'black', '#006060', 1, 0.2);

  ctx.rect(210, 96, 80, 80);
  ctx.fillStyle = '#396693';
  ctx.fill();

  drawCylinder(210, 80, 80, 110);
  ctx.fill();
  ctx.closePath();


  //Bike
ctx.beginPath();
ctx.fillStyle = '#90CAD7';
ctx.strokeStyle = '#307587';
ctx.arc(120, 500, 60, 0, 2 * Math.PI);
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.fillStyle = '#90CAD7';
ctx.strokeStyle = '#307587';
ctx.arc(350, 500, 60, 0, 2 * Math.PI);
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.moveTo(120, 500);
ctx.lineTo(190, 420);
ctx.lineTo(330, 420);
ctx.lineTo(220, 500);
ctx.closePath();
ctx.stroke();

ctx.beginPath();
ctx.moveTo(220, 500);
ctx.lineTo(175, 380);
ctx.stroke();

ctx.beginPath();
ctx.moveTo(150, 380);
ctx.lineTo(200, 380);
ctx.stroke();

ctx.beginPath();
ctx.moveTo(350, 500);
ctx.lineTo(320, 370);
ctx.lineTo(350, 340);
ctx.stroke();

ctx.beginPath();
ctx.moveTo(320, 370);
ctx.lineTo(280, 380);
ctx.stroke();

ctx.beginPath();
ctx.strokeStyle = '#307587';
ctx.arc(220, 500, 15, 0, 2 * Math.PI);
ctx.stroke();

//House

ctx.beginPath();
ctx.strokeStyle = '#000';
ctx.fillStyle = '#975B5B';
ctx.lineWidth = '3';
ctx.strokeRect(700, 250, 280, 280);
ctx.fillRect(700, 250, 280, 280);

ctx.beginPath();
ctx.moveTo(700, 250);
ctx.lineTo(840, 100);
ctx.lineTo(980, 250);
ctx.closePath();
ctx.stroke();
ctx.fill();

ctx.beginPath();
ctx.strokeRect(900, 120, 30, 100);
ctx.fillRect(900, 120, 30, 100);
ctx.stroke();
ctx.fill();

ctx.beginPath();
ctx.fillRect(900, 220, 30, 5);

ctx.beginPath();
ctx.save();
ctx.scale(1, 0.3);
ctx.arc(915, 390, 15, 0, 2 * Math.PI);
ctx.restore();
ctx.stroke();
ctx.fill();

ctx.beginPath();
ctx.fillStyle = '#000';
ctx.fillRect(730, 290, 50, 40);

ctx.beginPath();
ctx.fillStyle = '#000';
ctx.fillRect(785, 290, 50, 40);

ctx.beginPath();
ctx.fillStyle = '#000';
ctx.fillRect(730, 335, 50, 40);

ctx.beginPath();
ctx.fillStyle = '#000';
ctx.fillRect(785, 335, 50, 40);

ctx.beginPath();
ctx.fillStyle = '#000';
ctx.fillRect(855, 290, 50, 40);

ctx.beginPath();
ctx.fillStyle = '#000';
ctx.fillRect(910, 290, 50, 40);

ctx.beginPath();
ctx.fillStyle = '#000';
ctx.fillRect(855, 335, 50, 40);

ctx.beginPath();
ctx.fillStyle = '#000';
ctx.fillRect(910, 335, 50, 40);

ctx.beginPath();
ctx.fillStyle = '#000';
ctx.fillRect(855, 395, 50, 40);

ctx.beginPath();
ctx.fillStyle = '#000';
ctx.fillRect(910, 395, 50, 40);

ctx.beginPath();
ctx.fillStyle = '#000';
ctx.fillRect(855, 440, 50, 40);

ctx.beginPath();
ctx.fillStyle = '#000';
ctx.fillRect(910, 440, 50, 40);

ctx.beginPath();
ctx.moveTo(740, 530);
ctx.lineTo(740, 440);
ctx.bezierCurveTo(760, 420, 790, 420, 810, 440);
ctx.lineTo(810, 530);
ctx.moveTo(775, 530);
ctx.lineTo(775, 425);
ctx.stroke();

ctx.beginPath();
ctx.arc(790, 485, 5, 0, 2 * Math.PI);
ctx.stroke();

ctx.beginPath();
ctx.arc(760, 485, 5, 0, 2 * Math.PI);
ctx.stroke();
};
