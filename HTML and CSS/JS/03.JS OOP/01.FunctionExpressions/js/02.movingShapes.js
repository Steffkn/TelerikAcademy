var movingShapes = (function () {
    var interval = undefined;
 
    function addRectToHolder() {
        var holder = document.getElementById('holderForRect');
        var div = document.createElement('div');
            div.style.backgroundColor = generateRandomColor();
            div.style.color = generateRandomColor();
            div.style.borderColor = generateRandomColor();
            div.innerHTML = 'DIV';
            div.className = 'rect';
            div.setAttribute('wayToMove', 'down');
        holder.appendChild(div);
    }

    function addCircleToHolder() {
        var holder = document.getElementById('holderForCircle');
        var div = document.createElement('div');
        div.style.backgroundColor = generateRandomColor();
        div.style.color = generateRandomColor();
        div.style.borderColor = generateRandomColor();
        div.innerHTML = 'DIV';
        div.className = 'circle';
        div.setAttribute('angle', '0.1');
        div.style.top = '100px';
        div.style.left = '100px';

        holder.appendChild(div);
    }

    function generateRandomColor() {
        var red = (Math.random() * 256) | 0;
        var green = (Math.random() * 256) | 0;
        var blue = (Math.random() * 256) | 0;

        return "rgb(" + red + "," + green + "," + blue + ")";
    }

    function move() {
        var element = document.getElementsByClassName('rect');
        var circle = document.getElementsByClassName('circle');
        var position = 'down';
        var angle = 0.1;
        var radius = 100;
        var top = element.offsetTop;
        var left = element.offsetTop;

        for (var i = 0, len = element.length; i < len; i++) {
            moveElementInRect(element[i]);
        }

        for (var r = 0, length = circle.length; r < length; r++) {
            moveElementInCiricle(circle[r]);
        }

        function moveElementInRect(element) {
            var position = element.getAttribute('wayToMove');
            if (parseInt(element.offsetTop) < 200 && position == 'down') {
                for (var i = 0; i < 4; i++) {
                    element.style.top = parseInt(element.offsetTop) + 1 + 'px';
                }
                if (parseInt(element.offsetTop) == 200) {
                    element.setAttribute('wayToMove', 'right');
                }
            }
            else if (parseInt(element.offsetLeft) < 200 && position == 'right') {
                for (var i = 0; i < 4; i++) {
                    element.style.left = parseInt(element.offsetLeft) + 1 + 'px';
                }
                if (parseInt(element.offsetLeft) == 200) {
                    element.setAttribute('wayToMove', 'up');
                }
            } else if (parseInt(element.offsetTop) > 0 && position == 'up') {
                for (var i = 0; i < 4; i++) {
                    element.style.top = parseInt(element.offsetTop) - 1 + 'px';
                }
                if (parseInt(element.offsetTop) == 0) {
                    element.setAttribute('wayToMove', 'left');
                }
            } else if (parseInt(element.offsetLeft) > 0 && position == 'left') {
                for (var i = 0; i < 4; i++) {
                    element.style.left = parseInt(element.offsetLeft) - 1 + 'px';
                }
                if (parseInt(element.offsetLeft) == 0) {
                    element.setAttribute('wayToMove', 'down');
                }
            }
        }

        function moveElementInCiricle(rect) {
            var angle = parseFloat(rect.getAttribute('angle'));
            rect.style.left = Math.cos(angle + 2 * Math.PI / 5 * 5) / radius * 10000 + "px";
            rect.style.top = Math.sin(angle + 2 * Math.PI / 5 * 5) / radius * 10000 + "px";
            angle += 0.1;
            rect.setAttribute('angle', angle);
        }
    }

    function add(shapeName) {
        switch (shapeName) {
            case 'rect': addRectToHolder(); break;
            case 'ellipse': addCircleToHolder(); break;
            default: alert('Invalid Element'); break;

        }
    }

    var moveElements = function () {
        if (interval) {
            clearInterval(interval);
            interval = undefined;
        }
        else {
            interval = setInterval(function () { move() }, 100);
        }
    }
    return {
        add: add,
        move: moveElements
    }

}());