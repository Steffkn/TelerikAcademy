﻿// 2 Write a function that removes all elements with a given value
//    var arr = [1,2,1,4,1,3,4,1,111,3,2,1,'1'];
//    arr.remove(1); //arr = [2,4,3,4,111,3,2,'1'];
//  Attach it to the array type
//  Read about prototype and how to attach methods

function onCallRemoveAllElements() {
    printInElement('', true);
    Array.prototype.remove = removeAll;

    var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];

    printInElement(arr + '\n');
    arr.remove(1);

    //arr = [2,4,3,4,111,3,2,'1'];
    printInElement(arr);
}

function removeAll(toRemove) {
    for (var i = 0, len = this.length; i < len; i++) {
        if (this[i] === toRemove) {
            this.splice(i, 1);
        }
    }
}