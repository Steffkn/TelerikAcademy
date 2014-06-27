(function ($) {
    $.fn.messageBox = function () {
        var $this = $(this);
        $this
            .css('display', 'none')
            .css('border', '1px solid black')
            .css('color', 'black')
            .css('padding', '10px');

        $.fn.success = function (text) {
            $this.fadeIn(1000)
                .delay(3000)
                .fadeOut(1000)
                .text(text)
                .css('background-color', '#40FF5C');
        }
        $.fn.error = function (text) {
            $this
                .fadeIn(1000)
                .delay(3000)
                .fadeOut(1000)
                .text(text)
                .css('background-color', '#FF2B44');
        }

        return $this;
    }

    var msgBox = $("#messageBox").messageBox();

    $('<button>')
        .text('Check for success box')
        .on('click', function () {
            msgBox.success('Success message');
        })
        .appendTo('body');

    $('<button>')
        .text('Check for error box')
        .on('click', function () {
            msgBox.error('Error message');
        })
        .appendTo('body');
}(jQuery));
