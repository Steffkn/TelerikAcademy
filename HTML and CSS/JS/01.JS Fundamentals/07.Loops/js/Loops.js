function clear(elementName) {
    document.getElementById(elementName).innerHTML = "";
}

// 1 Write a script that prints all the numbers from 1 to N
function print1ToN() {
    clear("result");
    var number = parseInt(prompt("Enter a number:"));
    if (number < 0) {
        for (var i = 1; i >= number; i--) {
            document.getElementById("result").innerHTML += i + "<br/>";
        }
    }
    else if (number >= 0) {
        for (var i = 1; i <= number; i++) {
            document.getElementById("result").innerHTML += i + "<br/>";
        }
    }
    else {
        console.log("Not a valid number!");
    }
}

// 2 Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time
function print1ToNConditional() {
    clear("result");
    var number = parseInt(prompt("Enter a number:"));
    if (number < 0) {
        for (var i = 1; i >= number; i--) {
            if (i % 21 !== 0) {
                document.getElementById("result").innerHTML += i + "<br />";
            }
        }
    }
    else if (number >= 0) {
        for (var i = 1; i <= number; i++) {
            if (i % 21 !== 0) {
                document.getElementById("result").innerHTML += i + "<br />";
            }
        }
    }
    else {
        console.log("Not a valid number!");
    }
}

// 3 Write a script that finds the max and min number from a sequence of numbers
function findMaxAndMin() {
    clear("result");
    var max, min, digit;
    max = Number.MIN_VALUE;
    min = Number.MAX_VALUE;
    do {
        digit = parseFloat(prompt("Enter a sequence of numbers and everything else for exit"));
        if (max < digit) {
            max = digit;
        }
        else if (min > digit) {
            min = digit;
        }
        console.log(digit);
    } while (!isNaN(digit))

    document.getElementById("result").innerText = "Minimal value: " + min + "\nMaximal value: " + max;
}

// 4 Write a script that finds the lexicographically smallest and largest property in document, window and navigator objects

function findSmallestLargesProp() {
    var objects = [window, navigator, document];
    var output = "";
    for (var i = 0; i < 3; i++) {
        var properties = new Array();
        for (var property in objects[i]) {
            output += property + " ";
        }
        properties = output.split(" ");
        properties.sort();
        output = "Min: " + properties[1] + "\nMax: " + properties[properties.length - 1];
    }
    document.getElementById("result").innerText = output;
}