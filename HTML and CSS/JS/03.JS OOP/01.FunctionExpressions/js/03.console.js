var fansyConsole = (function () {
    function placeHolder(input) {
        var format = input[0];
        for (var i = 0; i < 30; i++) {
            while (format.indexOf('{' + i + '}') != -1) {
                format = format.replace('{' + i + '}', input[i + 1]);
            }
        }
        return format;
    }
    function writeLine(message, holderElements) {
        var argsLenght = arguments.length;
        if (argsLenght == 1) {
            console.log(message.toString());
        } else {

            var string = placeHolder(arguments);
            console.log(string.toString());
        }
    }
    function writeWarning(message, holderElements) {
        var argsLenght = arguments.length;
        if (argsLenght == 1) {
            console.warn(message.toString());
        } else {

            var string = placeHolder(arguments);
            console.warn(string.toString());
        }
    }
    function writeError(message, holderElements) {
        var argsLenght = arguments.length;
        if (argsLenght == 1) {
            console.error(message.toString());
        } else {
            var string = placeHolder(arguments);
            console.error(string.toString());
        }
    }
    return {
        writeLine: writeLine,
        writeWarning: writeWarning,
        writeError: writeError
    }
}());