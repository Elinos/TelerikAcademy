function createSlider(selector, data) {
    var $this = $(this),
        $data = $(data),
        rightClick = function () {
            var $current = $('.current');
            if ($current.next().length > 0) {
                $current.next().addClass('current');
            } else {
                $slideContainer.children().first().addClass('current');
            }
            $current.removeClass('current');
            clearInterval(interval);
            interval = setInterval(rightClick, 5000);
        },
        interval = setInterval(rightClick, 5000),
        $slideLeft = $('<span />')
            .addClass('leftArrow')
            .html('\u21E6')
            .click(function () {
                var $current = $('.current');
                if ($current.prev().length > 0) {
                    $current.prev().addClass('current');
                } else {
                    $slideContainer.children().last().addClass('current');
                }
                $current.removeClass('current');
                clearInterval(interval);
                interval = setInterval(rightClick, 5000);
            }),
        $slideContainer = $('<div />').addClass('slide-container'),
        $slideRight = $('<span />')
            .addClass('rightArrow')
            .html('\u21E8')
            .click(rightClick);

    $.each(data, function (i, val) {
        $slideContainer.append(val);
    });

    $slideContainer.children().first().addClass('current');
    $(selector).append($slideLeft);
    $(selector).append($slideContainer);
    $(selector).append($slideRight);
}

var slider = [
    $('<div />').html('some text in div'),
    $('<a />').html("a link").attr('href', '#'),
    $('<h1 />').html('This is a H1 tag')
];

createSlider('#slider-container', slider);

