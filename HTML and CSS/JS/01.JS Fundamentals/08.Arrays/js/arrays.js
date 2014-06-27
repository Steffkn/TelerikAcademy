function printInElement(output) {
    document.getElementById("result").innerText = output;
    console.log(output);
}

// 1 Write a script that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console.
function initArrayOf20Int() {
    var integerArray = new Array(20);
    var result = "";
    for (var i = 0; i < integerArray.length; i++) {
        integerArray[i] = i * 5;
        result += integerArray[i] + "\n";
    }

    printInElement(result);
}

// 2 Write a script that compares two char arrays lexicographically (letter by letter).
function compare2CharArrays() {
    var firstArray = ['A', 'E', 'D', 'G', 'J', 'B'];
    var secondArray = ['A', 'E', 'D', 'G', 'J', 'B'];
    var areEqual = true;
    var index = 0;
    var result = "";

    if (firstArray.length === secondArray.length) {
        while (areEqual) {
            if (firstArray[index] !== secondArray[index]) {
                areEqual = false;
                break;
            }

            index++;
            if (index > firstArray.length) {
                break;
            }
        }
        if (areEqual) {
            result = "The arrays are lexicographically equal!";
        } else {
            result = "The arrays are NOT lexicographically equal!";
        }
    } else {
        result = "The arrays are NOT the same length!";
    }

    printInElement(result);
}

// 3 Write a script that finds the maximal sequence of equal elements in an array.
//      Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.
function maximalSeqOfEqualElements() {
    var sequence = [2, 1, 1, 2, 3, 3, 3, 3, 2, 2, 2, 1];
    var result = "";
    var i,
        firstElement = sequence[0];
        lenght = sequence.length,
        startingIndex = 0,
        seqLen = 1,
        bestSeqStartInd = 0;
        bestSeqLen = 0;

    // starting from 1, as we have already managed the 1st element
    for (i = 1; i < lenght; i += 1) {

        if (sequence[i] != firstElement) {

            if (bestSeqLen < seqLen) {
                    bestSeqLen = seqLen;
                    bestSeqStartInd = startingIndex;
            }
            // for the new start
            startingIndex = i;
            firstElement = sequence[i];
            seqLen = 1;
        } else {
            seqLen++;
        }
    }

    // after the last element (in case the best sequence is at the end)
    if (bestSeqLen < seqLen) {
        bestSeqLen = seqLen;
        bestSeqStartInd = startingIndex;
    }

    result = "{" + sequence.slice(bestSeqStartInd, bestSeqStartInd + bestSeqLen) + "}";    
    printInElement(result);
}

// 4 Write a script that finds the maximal increasing sequence in an array. 
//      Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.
function maximalIncreasingSeq(){
    var sequence = [3, 2, 3, 4, 2, 2, 4];
    var result = "";
    var i,
        firstElement = sequence[0];
        lenght = sequence.length,
        startingIndex = 0,
        seqLen = 1,
        bestSeqStartInd = 0;
        bestSeqLen = 0;

    // starting from 1, as we have already managed the 1st element
    for (i = 1; i < lenght; i += 1) {

        if (sequence[i] <= firstElement) {

            if (bestSeqLen < seqLen) {
                bestSeqLen = seqLen;
                bestSeqStartInd = startingIndex;
            }
            // for the new start
            startingIndex = i;
            firstElement = sequence[i];
            seqLen = 1;
        } else {
            seqLen++;
        }
    }

    // after the last element (in case the best sequence is at the end)
    if (bestSeqLen < seqLen) {
        bestSeqLen = seqLen;
        bestSeqStartInd = startingIndex;
    }

    result = "{" + sequence.slice(bestSeqStartInd, bestSeqStartInd + bestSeqLen) + "}";
    printInElement(result);
}

// 5 Sorting an array means to arrange its elements in increasing order. Write a script to sort an array. Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.Hint: Use a second array
function sortArray() {
    var arrayToSort = [3, 2, 3, 4, 2, 2, 4, 2, 1, 1, 2, 3, 3, 3, 3, 2, 2, 2, 1];
    var arrayOriginal = arrayToSort.slice(0),  // Keeps the original array
        arrayToSortLenght = arrayToSort.length,
        i, j, temp, temp2;
    var result = "";

    for (i = 0; i < arrayToSortLenght; i++) {
        temp = i;
        for (j = i + 1; j < arrayToSortLenght; j++) {
            if (arrayToSort[j] < arrayToSort[temp]) {
                temp = j;
            }
        }
        temp2 = arrayToSort[temp];
        arrayToSort[temp] = arrayToSort[i];
        arrayToSort[i] = temp2;
    }

    result = "Array = [" + arrayOriginal + "]\n";
    result += "Sorted array = [" + arrayToSort + "]\n";
    printInElement(result);
}

// 6 Write a program that finds the most frequent number in an array. 
//      Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)
function mostFrequentNumber() {
    var givenArray = [ 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 ];
    var maxCounted = 0;
    var maxNumber = 0;
    var result = "";

    for (var i = 0; i < givenArray.length; i++) {
        // counter for the current number
        var counter = 0;
        // we start from the 'i' number because there is no reason to check the previous number again
        // it is not the perfect algorithm because there will be some extra math (no checking for already counted numbers)
        for (var j = i; j < givenArray.length; j++) {

            if (givenArray[i] == givenArray[j]) {
                counter++;
            }
            if (maxCounted < counter) {
                maxNumber = givenArray[i];
                maxCounted = counter;
            }
        }
    }
    result = maxNumber + " (" + maxCounted + " times)";
    printInElement(result);
}

// 7 Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).
function binarySearch() {
    var sortedArray = [ 1, 3, 8, 9, 13, 15, 16, 18, 24, 27, 29, 31, 34, 36, 39, 42, 44, 47, 48, 50 ];
    var output = "Type one of the following integers to find it's index in the array: \nIndex : Number\n";

    for (var i = 0; i < sortedArray.length; i++)
    {
        output = output + i + " : " + sortedArray[i] + "\n";
    }

    printInElement(output);

    var choice = parseInt(prompt("Enter index"));
    var bottom = 0;
    var top = sortedArray.length;
    var mid = (top + bottom) / 2;

    while (true) {

        if (sortedArray[mid] === choice) {
            output += "The index of " + choice + " is " + mid;
            break;
        }

        if (bottom === mid || top === mid) {
            output += "Number not found!";
            break;
        } else if (sortedArray[mid] > choice) {
            top = mid;
            mid = (top + bottom) / 2;
        } else if (sortedArray[mid] < choice) {
            bottom = mid;
            mid = (top + bottom) / 2;
        }
    }

    printInElement(output);
}