(function ($) {
    $.fn.dropdown = function () {
        var $this = $(this);
        // hide the dropdown
        $this.css('display', 'none');
        var $div = $('<div>')
            .addClass('dropdown-list-container')
            .appendTo(document.body);
        var $ul = $('<ul>')
            .addClass('dropdown-list-options')
            .appendTo($div);
        var $options = $this.children();

        // add the first li element
        $('<li>')
            .addClass('dropdown-list-option')
            .attr('data-value', $options.first().val())
            .html($options.first().html())
            .on('click', selectOptinNode)
            .appendTo($ul);

        for (var i = 1; i < $options.length; i++) {
            // add the rest li elements
            $('<li>')
                .addClass('dropdown-list-option')
                .attr('data-value', $options.next().val())
                .html($options.next().html())
                .on('click', selectOptinNode)
                .appendTo($ul);
        }

        return $this;
    }

    function selectOptinNode() {
        // clear the old selected element
        $('option:selected').removeAttr('selected');
        // find the node with wanted value and add attribute selected
        $('option[value="' + $(this).attr('data-value') + '"]').attr('selected', 'selected');
    }

    $('#dropdown').dropdown();

    // i don't know why but this selects the first element if option is not selected
    $('<button>')
        .text('Check which option is currently selected')
        .on('click', function () {
            $('<div>')
                .html('currently selected -> ' + $('#dropdown :selected').text())
                .appendTo('body');
        })
        .appendTo('body');

}(jQuery));
