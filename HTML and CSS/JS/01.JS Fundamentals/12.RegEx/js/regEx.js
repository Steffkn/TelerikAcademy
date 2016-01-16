// 1 Write a function that formats a string. The function should have placeholders, as shown in the example
//  * Add the function to the String.prototype

// var options = { name: 'John' };
// 'Hello, there! Are you #{name}?'.format(options);

// 'Hello, there! Are you John'


function formatStringExample1() {
    var options = { name: 'John' };
    var template = 'Hello, there! Are you #{name}?';
    var output = template.format(options);
    printInElement(output, true); // just print the result
}


function formatStringExample2() {
    var options = { name: 'John', age: 13 };
    var template = 'My name is #{name} and I am #{age}-years-old ';
    var output = template.format(options);
    printInElement(output, true); // just print the result
}

String.prototype.format = function (options) {
    var openTag = '#{';
    var closeTag = '}';
    var result = this;

    // openTagIndex of the beginning of the placeholder '#{'
    var openTagIndex = result.indexOf(openTag);

    while (openTagIndex !== -1) {
        openTagIndex = result.indexOf(openTag, openTagIndex);

        var propertyStartIndex = openTagIndex + openTag.length;

        // get the property as a string 'name'
        var property = result.substring(propertyStartIndex, result.indexOf(closeTag, openTagIndex));

        // tag reconstruction
        var tag = openTag.concat(property, closeTag);

        // replace the placeholder
        result = result.replace(tag, options[property]);

        // move on
        openTagIndex = result.indexOf(openTag, openTagIndex);
    }

    return result;
}




// 2 Write a function that puts the value of an object into the content/attributes of HTML tags.
// Add the function to the String.prototype

//// example 1
//// var str = '<div data-bind-content="name"></div>';
//// str.bind(str, { name: 'Steven' });

//// <div data-bind-content="name">Steven</div>

//// example 2
//// var bindingString = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>'
//// str.bind(str, { name: 'Elena', link: 'http://telerikacademy.com' });

//// <a data-bind-content="name" data-bind-href="link" data-bind-class="name" href="http://telerikacademy.com" class="Elena">Elena</а>


function fillValuesOfObjectExample1() {
    var str = '<div data-bind-content="name"></div>';
    var output = str.bind(str, { name: 'Steven' });
    printInElement(output, true); // just print the result
}

function fillValuesOfObjectExample2() {
    var str = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>'
    var output = str.bind(str, { name: 'Elena', link: 'http://telerikacademy.com' });
    printInElement(output, true); // just print the result
}

String.prototype.bind = function (str, object) {
    str = new String(str);
    var result = new String();
    var endOfOpenTagIndex = str.indexOf('>'); // plus one to skip the symbol itself 

    var openTag = str.slice(0, endOfOpenTagIndex + 1);
    var closeTag = str.slice(endOfOpenTagIndex + 1, str.len);
    var content = new String();

    if (openTag.indexOf('data-bind-content="name"') > -1) {
        content = object["name"];
    }
    if (openTag.indexOf('data-bind-href="link"') > -1) {
        openTag = [openTag.slice(0, endOfOpenTagIndex), ' href="', object["link"], '"', openTag.slice(endOfOpenTagIndex)].join('');
    }
    if (openTag.indexOf('data-bind-class="name"') > -1) {
        openTag = [openTag.slice(0, endOfOpenTagIndex), ' class="', object["name"], '"', openTag.slice(endOfOpenTagIndex)].join('');
    }

    return result.concat(openTag , content , closeTag)
}