window.onload = function() {
  'use strict';

  var CanvasDrawer = (function() {
    function CanvasDrawer(containerSelector, width, height) {
      this.DEFAULT_FILL_STYLE = 'white',
      this.DEFAULT_STROKE_STYLE = 'black',
      this.DEFAULT_STROKE_WIDTH = 1;

      this._container = document.querySelector(containerSelector);
      if (!this._container) {
        throw new Error("Container not found!");
      }

      this._canvas = document.createElement('canvas'),
      this._ctx = this._canvas.getContext('2d');

      this._canvas.setAttribute('width', width || 800);
      this._canvas.setAttribute('height', height || 600);
      this._container.appendChild(this._canvas);
    }

    CanvasDrawer.prototype.drawLine = function(args) {
      this._ctx.beginPath();
      this._ctx.moveTo(args.startX, args.startY);
      this._ctx.lineTo(args.endX, args.endY);
      this._ctx.closePath();
      this._ctx.lineWidth = args.lineWidth || this.DEFAULT_STROKE_WIDTH;
      this._ctx.strokeStyle = args.strokeStyle || this.DEFAULT_STROKE_STYLE;
      this._ctx.stroke();
    };

    CanvasDrawer.prototype.drawCircle = function(args) {
      this._ctx.beginPath();
      this._ctx.fillStyle = args.fillStyle || this.DEFAULT_FILL_STYLE;
      this._ctx.strokeStyle = args.strokeStyle || this.DEFAULT_STROKE_STYLE;
      this._ctx.lineWidth = args.lineWidth || this.DEFAULT_STROKE_WIDTH;
      this._ctx.arc(args.x, args.y, args.radius, 0, 2 * Math.PI);
      this._ctx.closePath();
      this._ctx.fill();
      this._ctx.stroke();
    };

    CanvasDrawer.prototype.drawRect = function(args) {
      this._ctx.fillStyle = args.fillStyle || this.DEFAULT_FILL_STYLE;
      this._ctx.lineWidth = args.lineWidth || this.DEFAULT_STROKE_WIDTH;
      this._ctx.strokeStyle = args.strokeStyle || this.DEFAULT_STROKE_STYLE;
      this._ctx.fillRect(args.x, args.y, args.width, args.height);
      this._ctx.strokeRect(args.x, args.y, args.width, args.height);
    };

    return CanvasDrawer;
  }());

  var canvasDrawer = new CanvasDrawer('#container', 800, 900);

  canvasDrawer.drawLine({
    startX: 50,
    startY: 50,
    endX: 100,
    endY: 100,
    lineWidth: 5,
    strokeStyle: 'gray'
  });

  canvasDrawer.drawCircle({
    x: 200,
    y: 200,
    radius: 50,
    lineWidth: 5,
    strokeStyle: 'gray',
    fillStyle: 'yellowgreen'
  });

  canvasDrawer.drawRect({
    x: 300,
    y: 300,
    width: 60,
    height: 100,
    lineWidth: 5,
    strokeStyle: 'gray',
    fillStyle: 'yellowgreen'
  });
};
