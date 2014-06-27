// 1 Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.

function exchangeValues() {

    var firstInteger = parseInt(prompt("Enter first integer"));
    var secondInteger = parseInt(prompt("Enter second integer"));
    var temp = firstInteger;

    if (firstInteger > secondInteger) {
        firstInteger = secondInteger;
        secondInteger = temp;
        console.log("Exchanged! " + firstInteger + " < " + secondInteger);
        document.getElementById("result").innerText = "Exchanged! " + firstInteger + " < " + secondInteger;
    } else {
        console.log("Not exchanged! " + firstInteger + " < " + secondInteger);
        document.getElementById("result").innerText = "Not exchanged! " + firstInteger + " < " + secondInteger;
    }
}

// 2 Write a script that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.

function showSign() {

    var firstValue = parseInt(prompt("Enter first integer"));
    var secondValue = parseInt(prompt("Enter second integer"));
    var thirdValue = parseInt(prompt("Enter third integer"));

    var positive = true;

    if (firstValue < 0) {
        positive = !positive;
    }

    if (secondValue < 0) {
        positive = !positive;
    }

    if (thirdValue < 0) {
        positive = !positive;
    }

    if (positive) {
        console.log("(" + firstValue + ", " + secondValue + ", " + thirdValue + ") The product will be a positive number!")
        document.getElementById("result").innerText =
            "(" + firstValue + ", " + secondValue + ", " + thirdValue + ")The product will be a positive number!";
    } else {
        console.log("(" + firstValue + ", " + secondValue + ", " + thirdValue + ") The product will be a negative number!")
        document.getElementById("result").innerText =
            "(" + firstValue + ", " + secondValue + ", " + thirdValue + ")The product will be a negative number!";
    }
}

// 3 Write a script that finds the biggest of three integers using nested if statements.

function biggestOfThree() {

    var firstValue = parseInt(prompt("Enter first integer"));
    var secondValue = parseInt(prompt("Enter second integer"));
    var thirdValue = parseInt(prompt("Enter third integer"));

    // if a >= b
    if (firstValue >= secondValue) {
        if (firstValue >= thirdValue) {

            // if a >= c, then 'a' is the biggest
            console.log("The biggest value is " + firstValue);
            document.getElementById("result").innerText = "The biggest value is " + firstValue;
        } else if (thirdValue >= secondValue) {

            // else if c >= b, then 'c' is the biggest
            console.log("The biggest value is " + thirdValue);
            document.getElementById("result").innerText = "The biggest value is " + thirdValue;
        }
    } else if (secondValue >= thirdValue) {

        // else if b >= c and b > a, then 'b' is the biggest
        console.log("The biggest value is " + secondValue);
        document.getElementById("result").innerText = "The biggest value is " + secondValue;
    } else {
        // else 'c' is the biggest
        console.log("The biggest value is " + thirdValue);
        document.getElementById("result").innerText = "The biggest value is " + thirdValue;
    }

}

// 4 Sort 3 real values in descending order using nested if statements.

function arrangeDescending() {

    var firstValue = parseInt(prompt("Enter first integer"));
    var secondValue = parseInt(prompt("Enter second integer"));
    var thirdValue = parseInt(prompt("Enter third integer"));

    console.log("Unordered: " + firstValue + ", " + secondValue + ", " + thirdValue);
    document.getElementById("result").innerHTML = "Unordered: " + firstValue + ", " + secondValue + ", " + thirdValue + "<br/>";

    // a >= b
    if (firstValue >= secondValue) {
        // a>= b && b >= c - descending order
        if (secondValue >= thirdValue) {
        }

            // a>= b && a >= c but b < c
        else if (firstValue >= thirdValue) {
            var temp = secondValue;
            secondValue = thirdValue;
            thirdValue = temp;
            // b > c - descending order
        } else {
            // a >= b but b < c and a < c => c > a >= b
            var temp = firstValue;
            firstValue = thirdValue;
            thirdValue = secondValue;
            secondValue = temp;
            // a > b > c - descending order
        }
    } else if (firstValue >= thirdValue) {
        // a < b && a >= c => b > a >= c
        var temp = secondValue;
        secondValue = firstValue;
        firstValue = temp;
        // a > b >= c - descending order
    } else if (secondValue >= thirdValue) {
        // a < b && b >= c and a < c => b >= c > a 
        var temp = secondValue;
        secondValue = thirdValue;
        thirdValue = firstValue;
        firstValue = temp;
        // a >= b > c - descending order
    } else { // a < b, a < c and c > b => c > b > a
        var temp = thirdValue;
        thirdValue = firstValue;
        firstValue = temp;
        // a > b > c - descending order
    }

    console.log("Descending order: " + firstValue + ", " + secondValue + ", " + thirdValue);
    document.getElementById("result").innerHTML =
        document.getElementById("result").innerHTML + "Descending order: " + firstValue + ", " + secondValue + ", " + thirdValue;
}

// 5 Write script that asks for a digit and depending on the input shows the name of that digit (in English) using a switch statement.

function convertNumberToWord() {

    var first = parseInt(prompt("Enter a number to be converted to its English word representation"));

    switch (first) {
        case 1:
            console.log("English name of digit 1 is: one");
            document.getElementById("result").innerText = "English name of digit 1 is: one";
            break;
        case 2:
            console.log("English name of digit 2 is: two");
            document.getElementById("result").innerText = "English name of digit 2 is: two ";
            break;
        case 3:
            console.log("English name of digit 3 is: three");
            document.getElementById("result").innerText = "English name of digit 3 is: three ";
            break;
        case 4:
            console.log("English name of digit 4 is: four");
            document.getElementById("result").innerText = "English name of digit 4 is: four ";
            break;
        case 5:
            console.log("English name of digit 5 is: five");
            document.getElementById("result").innerText = "English name of digit 5 is: five ";
            break;
        case 6:
            console.log("English name of digit 6 is: six");
            document.getElementById("result").innerText = "English name of digit 6 is: six ";
            break;
        case 7:
            console.log("English name of digit 7 is: seven");
            document.getElementById("result").innerText = "English name of digit 7 is: seven ";
            break;
        case 8:
            console.log("English name of digit 8 is: eight");
            document.getElementById("result").innerText = "English name of digit 8 is: eight ";
            break;
        case 9:
            console.log("English name of digit 9 is: nine");
            document.getElementById("result").innerText = "English name of digit 9 is: nine ";
            break;
        case 10:
            console.log("English name of digit 10 is: ten");
            document.getElementById("result").innerText = "English name of digit 10 is: ten ";
            break;
        default:
            console.log("Wrong input display only digits between 1 and 10");
            document.getElementById("result").innerText = "Wrong input display only digits between 1 and 10 ";
            break;
    }
}

// 6 Write a script that enters the coefficients a, b and c of a quadratic equation a*x2 + b*x + c = 0
// and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.

function solveQuadraticEquation() {

    var a = parseInt(prompt("Enter 'a'"));
    var b = parseInt(prompt("Enter 'b'"));
    var c = parseInt(prompt("Enter 'c'"));

    // determinant
    var D = b * b - 4 * a * c;
    if (D < 0) {
        // if D is less than 0, we don't have real roots
        console.log("There aren't any real roots");
        document.getElementById("result").innerText = "There aren't any real roots ";
    } else if (D == 0) {
        // if D = 0, there is 1 real root
        console.log("There is only one double root x = " + -b / (2 * a));
        document.getElementById("result").innerText = "There is only one double root x = " + -b / (2 * a);
    } else {
        // if D is greater than 0, there are two real roots that we can find
        D = Math.sqrt(D);
        console.log("x1 = " + parseFloat((-b + D) / (2 * a)));
        console.log("x2 = " + parseFloat((-b - D) / (2 * a)));

        document.getElementById("result").innerHTML = "x1 = " + parseFloat((-b + D) / (2 * a)) + "<br />x2 = " + parseFloat((-b - D) / (2 * a));
    }
}

// 7 Write a script that finds the greatest of given 5 variables.

function findGreatestOfFive() {

    var number;
    var max = Number.MIN_VALUE;
    var i;

    // loop 5 times
    for (i = 0; i < 5; i++) {
        number = parseFloat(prompt("Enter number " + i));

        if (max < number) {
            max = number;
        }
    }
    // printing the max value
    console.log("Greatest of the given 5 variables is " + max);
    document.getElementById("result").innerText = "Greatest of the given 5 variables is " + max;
}

// 8 Write a script that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
//  0 -> 'Zero'
//  273 -> 'Two hundred seventy three'
//  400 -> 'Four hundred'
//  501 -> 'Five hundred and one'
//  711 -> 'Seven hundred and eleven'

function convertBigNumberToWord() {

    var thousandMillion = [" thousand ", " million "];
    var number = parseInt(prompt("Enter an integer"));
    var tempNumber = Math.abs(number); // holding the absolute value of "number" in case we need "number" later 
    var index = 0;  // this index will be used with thousandMillion
    var name = "";   // string for the number's name

    // if the number is 0
    if (tempNumber == 0) {
        name = "zero";
    }

    // while the number is bigger than 0
    while (tempNumber != 0) {
        // if the number is from 10 to 19
        if (Math.abs((tempNumber / 10)) % 10 != 1) {
            // if the number isn't from 10 to 19
            // adding the name of the first digit before the string "name"
            switch (tempNumber % 10) {
                case 1: name = "one" + name; break;
                case 2: name = "two" + name; break;
                case 3: name = "tree" + name; break;
                case 4: name = "four" + name; break;
                case 5: name = "five" + name; break;
                case 6: name = "six" + name; break;
                case 7: name = "seven" + name; break;
                case 8: name = "eight" + name; break;
                case 9: name = "nine" + name; break;
            }
        } else {
            // if the number is from 10 to 19
            // adding the name of the digit before the string "name"
            switch (tempNumber % 10) {
                case 0: name = "ten" + name; break;
                case 1: name = "eleven" + name; break;
                case 2: name = "twelve" + name; break;
                case 3: name = "thirteen" + name; break;
                case 4: name = "fourteen" + name; break;
                case 5: name = "fifteen" + name; break;
                case 6: name = "sixteen" + name; break;
                case 7: name = "seventeen" + name; break;
                case 8: name = "eighteen" + name; break;
                case 9: name = "nineteen" + name; break;
            }
        }
        // dividing the number by 10
        tempNumber = Math.floor(tempNumber / 10);
        // if the first digit of the new number is not 0
        if (tempNumber % 10 != 0) {
            // adding the name of the first digit of the new number before the string "name"
            switch (tempNumber % 10) {
                case 2: name = "twenty " + name; break;
                case 3: name = "thirty " + name; break;
                case 4: name = "forty " + name; break;
                case 5: name = "fifty " + name; break;
                case 6: name = "sixty " + name; break;
                case 7: name = "seventy " + name; break;
                case 8: name = "eighty " + name; break;
                case 9: name = "ninety " + name; break;
                default:
                    break;
            }

        }
        // dividing the number by 10
        tempNumber = Math.floor(tempNumber / 10);

        // if the first digit of the new number is not 0
        if (tempNumber % 10 != 0) {
            if (name != "" && (tempNumber > 0)) {
                name = " and " + name;
            }
            // adding the name of the first digit of the new number as hundreds before the string "name"
            switch (tempNumber % 10) {
                case 1: name = "one hundred" + name; break;
                case 2: name = "two hundred" + name; break;
                case 3: name = "tree hundred" + name; break;
                case 4: name = "four hundred" + name; break;
                case 5: name = "five hundred" + name; break;
                case 6: name = "six hundred" + name; break;
                case 7: name = "seven hundred" + name; break;
                case 8: name = "eight hundred" + name; break;
                case 9: name = "nine hundred" + name; break;
            }
        }
            // if the number is bigger than 999, "tempNumber" will be bigger than 0 and string "and" will be added before the string "name"
        else if (tempNumber > 0) {
            // in case there is a number like 100 1000 1100 ex. "and" wont be added because this will break our name
            if (name != "") {
                name = "and " + name;
            }
        }

        // dividing the number by 10
        tempNumber = Math.floor(tempNumber / 10);

        // if tempNumber is bigger than 1000 that means that "thousand" or "million" string will be added to name
        if (tempNumber > 0 && tempNumber % 1000 != 0) {
            name = thousandMillion[index] + name;
            // switching from thousand to million
            index++;
        }
        else {
            index++;
        }
    }// end of while
    // if negative number is given as input string "negative" will be added before printing the name 

    // this makes the first letter of the string "name" to upper case
    name = name[0].toString().toUpperCase() + name.substring(1, name.length);

    if (number < 0) {
        name = "negative " + name;
    }

    // printing the name of the digit
    console.log("The number (" + number + ") is " + name);
    document.getElementById("result").innerText = "The number (" + number + ") is " + name;

}
