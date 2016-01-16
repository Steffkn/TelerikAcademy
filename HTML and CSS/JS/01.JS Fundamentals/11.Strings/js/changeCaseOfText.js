// 4 You are given a text. Write a function that changes the text in all regions:
//      <upcase>text</upcase> to uppercase.
//      <lowcase>text</lowcase> to lowercase
//      <mixcase>text</mixcase> to mix casing(random)

function onChangeText() {
    printInElement('', true);
    var text = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.";
    var stringObject = new String(text);

    stringObject = doMixCase(stringObject);
    stringObject = doUpcase(stringObject);
    stringObject = doLowCase(stringObject);

    printInElement(stringObject);
}

function doMixCase(text) {
    var indexStart = text.indexOf("<mixcase>");
    while (indexStart > -1) {
        var insedeText = text.substring(indexStart + 9, text.indexOf("</mixcase>", indexStart));
        var mixedText = new String(insedeText);
        for (var i = 0; i < mixedText.length ; i++) {
            if (i % 2 == 0) {
                mixedText = mixedText.replace(mixedText[i], mixedText[i].toUpperCase())
            }
            else {
                mixedText = mixedText.replace(mixedText[i], mixedText[i].toLowerCase())
            }
        }
        text = text.replace(insedeText, mixedText);
        indexStart = text.indexOf("<mixcase>", indexStart + 1);
    }
    return text;
}

function doUpcase(text) {
    var indexStart = text.indexOf("<upcase>");
    while (indexStart > -1) {
        var insedeText = text.substring(indexStart + 8, text.indexOf("</upcase>", indexStart))
        var upperText = insedeText.toUpperCase();
        text = text.replace(insedeText, upperText);
        indexStart = text.indexOf("<upcase>", indexStart + 1);
    }
    return text;
}

function doLowCase(text) {
    var indexStart = text.indexOf("<lowcase>");
    while (indexStart > -1) {
        var insedeText = text.substring(indexStart + 9, text.indexOf("</lowcase>", indexStart));
        var lowerText = insedeText.toLowerCase();
        text = text.replace(insedeText, lowerText);
        indexStart = text.indexOf("<lowcase>", indexStart + 1);
    }

    return text;
}