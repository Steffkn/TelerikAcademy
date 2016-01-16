// 2 Write a function that removes all elements with a given value
//    var arr = [1,2,1,4,1,3,4,1,111,3,2,1,'1'];
//    arr.remove(1); //arr = [2,4,3,4,111,3,2,'1'];
//  Attach it to the array type
//  Read about prototype and how to attach methods

function onCallRemoveAllElements() {
    printInElement('', true);
    Array.prototype.remove = removeAll;

    var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];

    printInElement("Original array: " + arr + '\n');
    arr.remove(1);

    //arr = [2,4,3,4,111,3,2,'1'];
	// the last element is not a number, so it is not removed!
    printInElement("Array after 'arr.remove(1)': " + arr);
	
	// it messed up task 6 for some reason so I remove the function after we are don using it
	Array.prototype.remove = 'This is interfearance from task 2 ( i couldnt fix it). It disapears if u dont start task 2 after refresh!';
}

function removeAll(toRemove) {
    for (var i = 0, len = this.length; i < len; i++) {
        if (this[i] === toRemove) {
            this.splice(i, 1);
        }
    }
}