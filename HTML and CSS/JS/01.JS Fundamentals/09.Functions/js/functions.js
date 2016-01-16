function printInElement(output) {
    document.getElementById("result").innerText = output;
    console.log(output);
}


// 1 Write a function that returns the last digit of given integer as an English word. Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine"
function lastNumberAsWord() {
    var number = parseInt(prompt("Enter a number"));
    var result = "";
    switch (number % 10) {
        case 0: result = "zero"; break;
        case 1: result = "one"; break;
        case 2: result = "two"; break;
        case 3: result = "tree"; break;
        case 4: result = "four"; break;
        case 5: result = "five"; break;
        case 6: result = "six"; break;
        case 7: result = "seven"; break;
        case 8: result = "eight"; break;
        case 9: result = "nine"; break;
        default: result = "Invalid number"; break;
    }

    printInElement(result);
}
// 2 Write a function that reverses the digits of given decimal number. Example: 256 -> 652
function reverseDigits() {
    var number = prompt("Enter a number");
    var result = "";
    for (var i = number.length - 1; i >= 0; i--) {
        result += number[i];
    }

    printInElement(result);
}


// 3 Write a function that finds all the occurrences of word in a text
//      The search can case sensitive or case insensitive
//      Use function overloading
function countOccurenceWord(isCaseSensitive) {
    var text = "Write a function that finds all the occurrences of word in a text The search can case sensitive or case insensitive Use function overloading.";
    var wordToSearch = " case ";

    var isCaseSensitive = isCaseSensitive || false;
    var countSearchedWord = 0;
    var result = "Text: " + text + "\n";
    if (isCaseSensitive === false) {
        var strArr = text.split(wordToSearch);

        for (var str in strArr) {
            countSearchedWord++;
        }

        result += "The count of word '" + wordToSearch + "' (case-insensitive search) is: " + countSearchedWord;
        printInElement(result);
    }
    else {
        var index = text.indexOf(wordToSearch);

        while (index >= 0) {
            countSearchedWord++;
            index = text.indexOf(wordToSearch, index + 1);
        }

        result += "The count of word '" + wordToSearch + "' (case-sensitive search) is: " + countSearchedWord;
        printInElement(result);
    }
}

// 4 Write a function to count the number of divs on the web page

function countDivElements() {
    document.getElementById("result").innerHTML = '<button onclick = "makeDiv()">Make a div</button> <button onclick = "countDivs()">Check divs</button>';
}
function makeDiv() {
    var output = document.getElementById("result");
    var div = document.createElement("div");
    var t = document.createTextNode("new div");
    div.appendChild(t);
    output.appendChild(div);
}
function countDivs() {
    var count = 0;
    var output = document.getElementById("result");
    var divs = document.getElementsByTagName("div");
    for (var i = 0; i < divs.length; i++) {
        count++;
    }
    var output = document.getElementById("result");
    var paragraph = document.createElement("p");
    var t = document.createTextNode("There are " + count + " divs in this document");
    paragraph.appendChild(t);
    output.appendChild(paragraph);
}


// 5 Write a function that counts how many times given number appears in given array. Write a test function to check if the function is working correctly.

function countNumber(array, number) {

    if (isNaN(number)) {
        number = parseInt(prompt("Enter number"));
    }
    var counter = 0;
    
    for (var i = 0; i < array.length; i++) {
        if (array[i] === number) {
            counter++;
        }
    }
    return "The number " + number + " is found " + counter + " times";
}

function checkFunction() {
    var array = [1, 2, 3, 4, 5, 6, 5, 5, 2, 31, 23, 5];
    var result = countNumber(array);
    
    printInElement("Array: [" + array + "] -> " + result);   
    //rintInElement(result);
}
// 6 Write a function that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).

function checkNeighbors(array, pos) {
    var result;

    if (isNaN(array[pos]))
    {
      result = "The given position is invalid!"
    }
    else if(isNaN(array[pos - 1]))
    {
      result = "This element doesn't have 'left' neighbor";
    }
    else if(isNaN(array[pos + 1]))
    {
      result = "This element doesn't have 'right' neighbor";
    }
    else
    {
      if(	array[pos] > array[pos - 1] && 
			array[pos] > array[pos + 1])
		{
            result = true;
       }
       else{
        result = "The element at position "+ pos + " is lower than at least one of its neighbors";
       }
    }
    
    return result;
}

function checkNeighborsFunction() {
    var array = [1, 2, 3, 4, 5, 6, 5, 5, 2, 31, 23, 5];
	var position;
	
    if (isNaN(position)) {
        position = parseInt(prompt("Enter position from array["+array+"]:"));
    } 
	
    var result = checkNeighbors(array,position);
	if(result === true){
		output = "The element at position " + position + " is bigger than its neighbors"; 
	}
	else if(result === false){
		output = "The element at position " + position + " is lower than or equal to at least one of its neighbors";
	}
	else{
		output = result;
	}
	
    printInElement("Array: [" + array + "] -> " + output);  
}

// 7 Write a function that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.
//    Use the function from the previous exercise.

function checkAllNeighbors() {
    var array = [1, 2, 3, 4, 5, 6, 5, 5, 2, 31, 23, 5];
    //var array = [1, 2, 3, 4, 5, 5, 5, 5, 2, 20, 23, 50]; // result = -1
	var position = -1;
	
	// eliminate the first and the last elements (they don't have 2 neightbors)
	for (var i = 1; i < array.length - 1; i++) {
		var result = checkNeighbors(array,i);
		console.log(result);
        if (result === true) {
            position = i;
			break;
        }
    }
	
    printInElement("Array: [" + array + "] -> First element that is bigger than its neightbors is at: " + position);  
}
