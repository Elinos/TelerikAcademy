window.onload = function() {
  var canvas = document.getElementById('the-canvas');
  var ctx = canvas.getContext('2d');
  canvas.style.backgroundColor = "#444";

  var ball = {
    x: 10,
    dx: 1,
    y: 10,
    dy: 1,
    r: 10,
    color: 'black',
    draw: function draw() {
      ctx.beginPath();
      ctx.save();
      ctx.arc(this.x, this.y, this.r, 0, 2 * Math.PI);
      ctx.fill();
      ctx.restore();
      ctx.closePath();
    }
  };

  function clearCanvas() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
  }

  function changePosition(newX, newY) {
    ball.x = newX;
    ball.y = newY;
  }

  function moveBall() {

    if (ball.x - ball.r < 0 || ball.x + ball.r > canvas.width) {
      ball.dx *= -1;
    }
    if (ball.y - ball.r < 0 || ball.y + ball.r > canvas.height) {
      ball.dy *= -1;
    }

    changePosition(ball.x + ball.dx, ball.y + ball.dy);
    clearCanvas();
    ball.draw();
  }
  setInterval(moveBall, 5);
};
