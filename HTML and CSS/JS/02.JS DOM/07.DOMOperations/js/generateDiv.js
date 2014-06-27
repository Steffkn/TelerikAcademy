window.onload = function () {
    var wrapper = document.getElementById('wrapper');
    var numberOfDivs = 15;

    function generateDiv() {
        var newDiv = document.createElement('div');
        var strongElement = document.createElement('strong');

        newDiv.style.width = getRandomNumber(20, 100) + 'px';
        newDiv.style.height = getRandomNumber(20, 100) + 'px';

        newDiv.style.backgroundColor = getRandomColor();

        newDiv.style.color = getRandomColor();

        newDiv.style.position = 'absolute';
        newDiv.style.top = getRandomNumber(10, 400) + 'px';
        newDiv.style.left = getRandomNumber(10, 500) + 'px';

        strongElement.innerText = "div";
        newDiv.appendChild(strongElement);

        newDiv.style.borderColor = getRandomColor();
        newDiv.style.borderRadius = getRandomNumber(0, 30) + 'px';
        newDiv.style.borderWidth = getRandomNumber(1, 20) + 'px';

        wrapper.appendChild(newDiv);
    }

    // Returns a random number between min and max
    function getRandomNumber(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function getRandomColor() {
        var red = getRandomNumber(0, 255);
        var green = getRandomNumber(0, 255);
        var blue = getRandomNumber(0, 255);

        return 'rgb(' + red + ', ' + green + ', ' + blue + ')'
    }


    for (var i = 0; i < numberOfDivs; i++) {
        generateDiv();
    }
};