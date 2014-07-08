/// <reference path="jquery.min.js" />
$(window).bind("load", $.fn.gallery = function (cols) {
    var $this = $(this);
    var $selected = $('.selected');
    var $imageContainer = $this.find('.image-container').first();
    var $root = $this.parent();
    var $images = $this.find('.image-container');
    var srcs = [];

    //Store all src
    for (var i = 0; i < $images.length; i++) {
        srcs.push($($images[i]).find('img').attr('src'));
    }

    if (!cols) {
        cols = 4;
    }

    //Wait for css to load
    var fakeListener = setInterval(function () {
        var documentWidth = $root.parent().parent().width() - parseInt($root.css('margin-left'), 10);
        var bodyMargin = parseInt($root.parent().css('margin-left'), 10);
        var imageMarginLeft = parseInt($($images[0]).css('margin-left'), 10);
        var imageMarginRight = parseInt($($images[0]).css('margin-right'), 10);


        if ($imageContainer.css('width') !== documentWidth - bodyMargin * 2) {
            clearInterval(fakeListener);
            $this.css({
                'width': ($imageContainer.width() * cols) + (cols * (imageMarginLeft + imageMarginRight))
            });
        }
    }, 50);

    function placeCurrents($selectedImage) {
        var selectedIndex = findSrcIndex($selectedImage.attr('src'));
        var previousIndex = selectedIndex - 1;
        var nextIndex = selectedIndex + 1;

        if (previousIndex === -1) {
            previousIndex = srcs.length - 1;
        }

        if (nextIndex === srcs.length) {
            nextIndex = 0;
        }

        $selected.find('#previous-image').attr('src', srcs[previousIndex]);
        $selected.find('#current-image').attr('src', srcs[selectedIndex]);
        $selected.find('#next-image').attr('src', srcs[nextIndex]);

    }

    function showSelected(ev) {
        var $selectedImage = $(this);

        placeCurrents($selectedImage);
        $images.find('img').addClass('blurred');
        $this.addClass('disabled-background');
        $images.unbind('click');
        $selected.show();
    }

    function showList(ev) {
        $images.find('img').removeClass('blurred');
        $this.removeClass('disabled-background');
        $images.on('click', 'img', showSelected);
        $selected.hide();
    }

    function findSrcIndex(src) {
        return srcs.indexOf(src);
    }

    function next(ev) {
        var $next = $(this);
        placeCurrents($next);
    }

    function previous(ev) {
        var $previous = $(this);
        placeCurrents($previous);
    }

    $this.addClass('gallery');
    $selected.hide();
    $images.on('click', 'img', showSelected);
    $selected.find('.current-image').on('click', 'img', showList);
    $selected.find('.previous-image').on('click', 'img', next);
    $selected.find('.next-image').on('click', 'img', previous);
});