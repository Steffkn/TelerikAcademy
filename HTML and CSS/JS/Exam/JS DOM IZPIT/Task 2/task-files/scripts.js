$.fn.gallery = function (givenCols) {
    var columns = givenCols || 4;
    var $this = $(this);
    var $root = $('#root');
    var $imageContainer = $('.image-container');
    var $galleryList = $('.gallery-list');
    var galery = $('#gallery').addClass('gallery').addClass('clearfix');
    var numberOfImages = $("div.image-container").size();

    $galleryList.css('width', getGalleryWidth());
    $this.find('.selected').hide();

    var $disablingBGDiv = addDisablingDiv();
    var $currentImage;
    var $prevImage;
    var $nextImage;

    $('#current-image').on('click', function () {
        $disablingBGDiv.hide();
        galery.find('.selected').hide();
        $galleryList.removeClass('blurred');
    });
    $('#previous-image').on('click', function () {
        var $this = $(this);

        $nextImage.attr('src', $currentImage.attr('src'));
        $nextImage.attr('data-info', $currentImage.attr('data-info'));
        $currentImage.attr('src', $prevImage.attr('src'));
        $currentImage.attr('data-info', $prevImage.attr('data-info'));

        var prevIndex = parseInt($prevImage.attr('data-info')) - 1;

        if (prevIndex <= 0) {
            prevIndex = numberOfImages;
        }

        var $prevSRC = $galleryList
            .find('img[data-info="' + prevIndex + '"]').attr('src');
        $prevImage.attr('src', $prevSRC).attr('data-info', prevIndex);
    });

    $('#next-image').on('click', function () {
        var $this = $(this);
        $prevImage.attr('src', $currentImage.attr('src'));
        $prevImage.attr('data-info', $currentImage.attr('data-info'));
        $currentImage.attr('src', $nextImage.attr('src'));
        $currentImage.attr('data-info', $nextImage.attr('data-info'));

        var nextIndex = parseInt($nextImage.attr('data-info')) + 1;

        if (nextIndex > numberOfImages) {
            nextIndex = 1;
        }
        
        var $nextSRC = $galleryList
            .find('img[data-info="' + nextIndex + '"]').attr('src');
        $nextImage.attr('src', $nextSRC).attr('data-info', nextIndex);
    });

    $imageContainer.on('click', function () {
        var $this = $(this);
        $galleryList.addClass('blurred');
        $disablingBGDiv.show();
        changeImages($this);
    });

    function changeImages($clickedImage) {
        var currentIndex = parseInt($clickedImage.find('img').attr('data-info'));

        var nextIndex = currentIndex + 1;
        var prevIndex = currentIndex - 1;
        if (nextIndex > numberOfImages) {
            nextIndex = 1;
        }
        if (prevIndex <= 0) {
            prevIndex = numberOfImages;
        }

        var currentSRC = $clickedImage
            .find('img')
            .attr('src');

        $currentImage = galery.find('#current-image')
            .attr('src', currentSRC)
            .attr('data-info', currentIndex);

        var nextSRC = $galleryList
            .find('img[data-info="' + nextIndex + '"]')
            .attr('src');

        $nextImage = galery.find('.selected #next-image')
            .attr('src', nextSRC)
            .attr('data-info', nextIndex);

        var prevSRC = $galleryList
            .find('img[data-info="' + prevIndex + '"]')
            .attr('src');

        $prevImage = galery.find('.selected #previous-image')
            .attr('src', prevSRC)
            .attr('data-info', prevIndex);

        galery.find('.selected').show();
    }

    function addDisablingDiv() {
        // or the gallery itself
        var $bluredDiv = $('<div>')
            .addClass('disabled-background')
            .html('&nbsp;')
            .hide()
            .appendTo(galery);
        return $bluredDiv;
    }

    function getGalleryWidth() {
        var imageContainerWidht = parseInt($imageContainer.css('width'));
        var imageContainerMargin = parseInt($imageContainer.css('margin'));
        var imageContainerPadding = parseInt($imageContainer.css('padding'));
        var imageContainerBorder = parseInt($imageContainer.css('border-width'));
        var width = (imageContainerWidht + 2 * imageContainerMargin + 2 * imageContainerPadding + imageContainerBorder) * (columns);
        return width;
    }
};