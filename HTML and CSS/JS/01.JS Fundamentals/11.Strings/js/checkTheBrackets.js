//Write a JavaScript function to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d).
//    Example of incorrect expression: )(a+b)).


function onBracketsCheck() {
    printInElement('', true);
    var expression = "((a+b)/5-d))";

    printInElement("The expression '"+ expression + "'");
    if (isCorrectExpression(expression)) {
        printInElement(" is correct!");
    } else {
        printInElement(" is NOT correct!");
    }
}

function isCorrectExpression(expression) {
    var correct = 0;
    var stringExpression = new String(expression);
    for (var i = 0; i < stringExpression.length; i++) {
        if (stringExpression[i] === ')') {
            correct--;
        } else if (stringExpression[i] == '(') {
            correct++;
        }
        if (correct < 0) {
            return false;
        }
    }

    if (correct === 0) {
        return true;
    } else {
        return false;
    }
}