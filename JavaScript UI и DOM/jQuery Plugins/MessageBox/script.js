(function ($) {
    $.fn.messageBox = function () {
        var $this = $(this);

        return {
            success: function (message) {
                $('#message-box')
                    .text(message)
                    .css('color', 'green')
                    .fadeIn(1000)
                    .delay(3000)
                    .fadeOut(1000);
                return $this;
            },
            error: function (message) {
                $('#message-box')
                    .text(message)
                    .css('color', 'red')
                    .fadeIn(1000)
                    .delay(3000)
                    .fadeOut(1000);
                return $this;
            }
        };
    };
}(jQuery));

var msgBox = $('#message-box').messageBox();
        $('#success').click(function () { msgBox.success('Success message'); });
        $('#error').click(function () { msgBox.error('Error message'); });
