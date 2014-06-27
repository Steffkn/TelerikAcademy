var slides = [

    '<img src="img/beautiful_blue_free_hd_by_luisbc-d7e1t8z.png" />',

    '<img src="img/cat.jpg" />',

    '<article><header><h1>Lorem ipsum</h1></header><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></article>',
];

(function () {
    var currentSlide = 0;
    var timeInterval = 5000;
    var autoSlideChanger = setInterval(onNextButtonClick, timeInterval);
    var $slider = $("#slider");
    var $slide = $('<div>')
        .addClass('slide')
        .appendTo($slider);

    $('<button />')
        .html('>>')
        .addClass('btn-next')
        .appendTo($slider);

    $('<button />')
        .html('<<')
        .addClass('btn-prev')
        .appendTo($slider);

    $('.btn-next').on('click', onNextButtonClick);
    $('.btn-prev').on('click', onPrevButtonClick);


    function onNextButtonClick() {
        currentSlide++;
        if (currentSlide >= slides.length) {
            currentSlide = 0;
        }

        setSlide();
        resetTimer();
    }

    function onPrevButtonClick() {
        currentSlide--;
        if (currentSlide < 0) {
            currentSlide = slides.length - 1;
        }

        setSlide();
        resetTimer();
    }

    function setSlide() {
        $('.slide').html(slides[currentSlide]);
    }

    function resetTimer() {
        clearInterval(autoSlideChanger);
        autoSlideChanger = setInterval(onNextButtonClick, timeInterval);
    }

    setSlide();
})();