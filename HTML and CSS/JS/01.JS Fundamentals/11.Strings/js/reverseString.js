// 1 Write a JavaScript function reverses string and returns itExample: "sample" -> "elpmas".

function onReverseString() {
    printInElement('', true);
    var string = "the sample";

    printInElement("String - " + string + "\n");
    printInElement("Reversed - " + reverseString(string));


}

function reverseString(givenString) {
    var result = "";
    var stringObj = new String(givenString);
    for (var i = stringObj.length-1 ; i >= 0; i--) {
        result += stringObj[i];
    }

    return result;
}