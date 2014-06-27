// 3 Write a JavaScript function that finds how many times a substring is contained in a given text (perform case insensitive search).

function onSearchInString() {
    printInElement('', true);
    var string = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

    var result = findString(string, "in");

    printInElement("The string 'in' is found " + result + " times.");
}

function findString(text, toSearchString) {
    var stringText = new String(text);
    var counter = 0;
    var array = stringText.split(toSearchString);

    return array.length;
}