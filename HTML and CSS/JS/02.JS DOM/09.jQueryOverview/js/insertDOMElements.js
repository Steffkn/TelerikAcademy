(function () {
    var $beforeDiv = $('<div>').text('Before');
    var $afterDiv = $('<div>').text('After');
    var $mainElement = $('#mainElement');

    $('#btn-before').on('click', onAddBeforeButtonClick)
    $('#btn-after').on('click', onAddAfterButtonClick)

    function onAddBeforeButtonClick() {
        $mainElement.before($beforeDiv);
    }
    function onAddAfterButtonClick() {
        $mainElement.after($afterDiv);
    }
})();