// 11 Write a function that formats a string using placeholders:
//      var str = stringFormat('Hello {0}!', 'Peter');
        //str = 'Hello Peter!';

function onStringFormat() {
    printInElement('', true);

    var format = 'Hello {0} and {1} !';
    var words = 'Peter, Adams';
    var wordsArr = words.split(", ");
    var result = stringFormat(format, wordsArr);

    printInElement("Format: " + format + "\n");
    printInElement("Fields: " + words + "\n");
    printInElement("Result: " + result + "\n");
}

function stringFormat(text, wordsArr) {
    var result = buildStringBuilder();
    var beggining = 0;
    text = new String(text);
    var index = text.indexOf("{");
    while (index > -1) {
        var number = parseInt(text.substr(index + 1, 1));
        result.append(text.substring(beggining, index));
        result.append(wordsArr[number]);
        beggining = index + 3;
        index = text.indexOf("{", beggining);
    }
    result.append(text.substring(text.lastIndexOf("}") + 1, text.length));
    return result.toString();
}
function buildStringBuilder() {
    return {
        strs: [],
        len: 0,
        append: function (str) {
            this.strs[this.len++] = str;
            return this;
        },
        toString: function () {
            return this.strs.join("");
        }
    };
}