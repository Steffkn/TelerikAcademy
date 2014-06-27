// 5 Write a function that replaces non breaking white-spaces in a text with &nbsp;


function onReplaceWhiteSpace() {
    printInElement('', true);

    var text = new String(' Lorem ipsum dolor sit amet, consectetur adipiscing elit fusce vel sapien elit in malesuada semper mi, id sollicitudin urna fermentum ut fusce varius nisl ac ipsum gravida vel pretium tellus. ');

    printInElement(replaceAllWhiteSpaces(text, '&nbsp;'));
}
function replaceAllWhiteSpaces(text, newSymbol) {
    var result = '';
    for (var i = 0; i < text.length; i++) {
        if (text[i] == ' ') {
            result += newSymbol;
        }
        else {
            result += text[i];
        }
    }
    return result;
}