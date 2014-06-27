// 10 Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".


function onSearchPolindromes() {
    printInElement('', true);
    var strBuilder = buildStringBuilder();
    var text = "Text with some ABBA and lamal. It has exe too!"

    printInElement("Text: " + text + "\n");
    text = text.toLowerCase();
    text = text.replace(".", " ").replace("!", " ").replace("?", " ").replace(",", " ");
    text = text.replace("  ", " ");
    var wordsArr = text.split(" ");
    for (var i = 0; i < wordsArr.length; i++) {
        strBuilder = buildStringBuilder();
        for (var j = wordsArr[i].length - 1; j >= 0 ; j--) {
            strBuilder.append(wordsArr[i][j]);
        }
        if (strBuilder.toString() === wordsArr[i]) {
            printInElement(wordsArr[i] + '\n');
        }
    }
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