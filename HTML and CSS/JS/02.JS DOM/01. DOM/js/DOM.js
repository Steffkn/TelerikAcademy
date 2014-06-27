// 1 Write a script that selects all the div nodes that are directly inside other div elements
//      Create a function using querySelectorAll()
//      Create a function using getElementsByTagName()

function usingQuerySelectorAll() {
    var nestedDivs = document.querySelectorAll('div > div');
    printInElement('Using query selection: ' + nestedDivs.length, true);
}

function usingGetElementsByTagName() {
    var listOfDivs = document.getElementsByTagName("div");
    var countDivs = 0;
    for (var i = 0, length = listOfDivs.length; i < length; i += 1) {
        var curentDiv = listOfDivs[i];
        if (curentDiv.parentNode.nodeName == "DIV") {
            countDivs++;
        }
    }

    printInElement('Using element selection: ' + countDivs, true);
}

// 2 Create a function that gets the value of <input type="text"> ands prints its value to the console

function getValueOfInputText(input) {
    printInElement('Element ID: ' + input.id + '\n', true);
    printInElement('Element content: ' + input.value);
}


// 3 Create a function that gets the value of <input type="color"> and sets the background of the body to this value

function changeBGColor() {
    var colorInput = document.getElementById("colorPicker");
    document.bgColor = colorInput.value;
    printInElement('Color: ' + colorInput.value, true);
}