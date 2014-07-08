var domModule = (function () {
    var buffer = [];
    var addChild = function (childElement, parentSelector) {
        var parent = document.querySelector(parentSelector);
        parent.appendChild(childElement);
    }

    var removeChild = function (parentSelector, childElement) {
        var parent = document.querySelector(parentSelector);
        var childNode = parent.querySelector(childElement);
        parent.removeChild(childNode);
    }

    var addHandler = function (elementSelector, eventType, handler) {
        var element = document.querySelector(elementSelector);
        if (element.addEventListener) {
            element.addEventListener(eventType, handler, false);
        } else {
            element.attachEvent("on" + eventType, handler);
        }
    }

    var appendToBuffer = function (selector, element) {
        if (!document.querySelector(selector)) {
            console.error('Invalid Selector');
            return;
        }
        if (buffer[selector]) {
            buffer[selector].push(element);
            if (buffer[selector].length >= 100) {
                var currentDomElement = document.querySelector(selector);
                for (var i = 0; i < buffer[selector].length; i++) {
                    currentDomElement.appendChild(buffer[selector][i]);
                }
                buffer[selector] = [];
            }

        } else {
            buffer[selector] = [];
            buffer[selector].push(element);
            console.log(buffer);
        }
    }

    return {
        addChild: addChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer
    }
}());