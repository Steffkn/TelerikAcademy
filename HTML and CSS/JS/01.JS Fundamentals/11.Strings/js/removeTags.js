﻿// 6 Write a function that extracts the content of a html page given as text. The function should return anything that is in a tag, without the tags:

function onRemoveTag() {
    printInElement('', true);

    var text = "<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>";

    printInElement(extractContent(text));
}

function extractContent(text) {
    var extractedText = buildStringBuilder();
    var indexRigthBraket = text.indexOf(">");
    while (indexRigthBraket > -1 && indexRigthBraket != text.length - 1) {
        if (text[indexRigthBraket + 1] != "<") {
            var stringStart = text.substring(indexRigthBraket + 1, text.indexOf("<", indexRigthBraket + 1));
            extractedText.append(stringStart).append(" ");
        }
        var indexRigthBraket = text.indexOf(">", indexRigthBraket + 1);
    }
    return extractedText.toString();
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