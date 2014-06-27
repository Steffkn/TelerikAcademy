// 1 Write a JavaScript function that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. 
// Sample HTML fragment:
// <p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
// <p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>

function onTagAReplasing() {
    printInElement('', true);
    var text = '<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';
    var index = text.indexOf("<a");

    printInElement("Before: " + text + "\n");
    while (index > -1) {
        text = text.replace('<a href="', '[URL=');
        text = text.replace('">', ']');
        text = text.replace("</a>", "[/URL]");
        index = text.indexOf("<a", index + 1);
    }

    printInElement("After: "+ text);
}
