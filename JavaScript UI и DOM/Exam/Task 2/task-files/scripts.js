$.fn.gallery = function(columns) {
  $this = $(this);
  var cols = columns || 4;
  var numberOfCurrentImage;
  var $selected = $this.find('.selected').hide();
  $this.width(260 * cols);
  var onImgClick = function onImgClick() {
    $that = $(this);
    numberOfCurrentImage = $that.find('img').attr('data-info');
    $selected.show();
    var srcOfCurrent = $that.find('img').attr('src');

    var srcOfNext;
    if ($that.next().length > 0) {
      srcOfNext = $that.next().find('img').attr('src');
    } else {
      srcOfNext = $this.find('.gallery-list').children().first().find('img').attr('src');
    }

    var srcOfPrev;
    if ($that.prev().length > 0) {
      srcOfPrev = $that.prev().find('img').attr('src');
    } else {
      srcOfPrev = $this.find('.gallery-list').children().last().find('img').attr('src');
    }

    $this.find('.selected .current-image img').attr('src', srcOfCurrent);
    $this.find('.selected .previous-image img').attr('src', srcOfPrev);
    $this.find('.selected .next-image img').attr('src', srcOfNext);

    $this.find('.image-container').addClass('blurred').unbind();
    $this.addClass('disabled-background');
  };

  $this.addClass('gallery');
  $this.find('.image-container')
    .on('click', onImgClick);

  $this.find('.selected .current-image')
    .on('click', function() {
      $this.find('.image-container').removeClass('blurred').on('click', onImgClick);
      $this.removeClass('disabled-background');
      $selected.hide();
    });
  $this.find('.selected .previous-image img')
    .on('click', function() {
      $that = $(this);
      numberOfCurrentImage--;
      if (numberOfCurrentImage === 0) {
        numberOfCurrentImage = 12;
      };
      if (numberOfCurrentImage >= 1) {
        if (numberOfCurrentImage === 1) {
          $that.attr('src', 'imgs/12.jpg');
        } else {
          $that.attr('src', 'imgs/' + (numberOfCurrentImage - 1) + '.jpg');
        }
        $this.find('.selected .current-image img').attr('src', 'imgs/' + (numberOfCurrentImage) + '.jpg');
        if (numberOfCurrentImage === 12) {
          $this.find('.selected .next-image img').attr('src', 'imgs/1.jpg');
        } else {
          $this.find('.selected .next-image img').attr('src', 'imgs/' + (numberOfCurrentImage + 1) + '.jpg');
        }
      } else {
        $that.attr('src', 'imgs/12.jpg');
      }
    });

  $this.find('.selected .next-image img')
    .on('click', function() {
      $that = $(this);
      numberOfCurrentImage++;
      if (numberOfCurrentImage === 13) {
        numberOfCurrentImage = 1;
      }
      if (numberOfCurrentImage <= 12) {
        if (numberOfCurrentImage === 12) {
          $that.attr('src', 'imgs/1.jpg');
        } else {
          $that.attr('src', 'imgs/' + (numberOfCurrentImage + 1) + '.jpg');
        }
        $this.find('.selected .current-image img').attr('src', 'imgs/' + numberOfCurrentImage + '.jpg');
        if (numberOfCurrentImage === 1) {
          $this.find('.selected .previous-image img').attr('src', 'imgs/12.jpg');
        } else {
          $this.find('.selected .previous-image img').attr('src', 'imgs/' + (numberOfCurrentImage - 1) + '.jpg');
        }
      } else {
        $that.attr('src', 'imgs/12.jpg');
      }
    });
};
