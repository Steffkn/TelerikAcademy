window.onload = function () {

    function solve(params) {
        var n = parseInt(params[0]);
        var m = parseInt(params[n + 1]);

        var parameters = [];
        var arrayOfProperties = [];
        var arrayOfHTMLInput = [];

        var arrayOutput = [];

        for (var i = 1; i <= n; i++) {
            parameters[i - 1] = params[i];

            var key = parameters[i - 1].substring(0, parameters[i - 1].indexOf(':'));
            var value = parameters[i - 1].substring(parameters[i - 1].indexOf(':') + 1, parameters[i - 1].length);

            if (value.indexOf(',') !== -1) {
                value = value.split(',')
            }
            arrayOfProperties[key] = value;
        }
            //console.log(arrayOfProperties);

        var arrayWithSections = [];
        var startOfHTML = false;
        for (var i = 0, len = m; i < len ; i++) {
            if (params[i + n + 2].indexOf('<!') !== -1 || startOfHTML === true) {
                startOfHTML = true;
                arrayOfHTMLInput[i - arrayWithSections.length] = params[i + n + 2];
            }
            else {
                arrayWithSections[i] = params[i + n + 2];
            }
        }

        //console.log(arrayWithSections);
        //console.log(arrayOfHTMLInput);

        var arrayOfSections = [];
        var firstRowOfSection = [];
        var rowOfTags = '';
        var key;
        for (var i = 0, len = arrayWithSections.length; i < len; i++) {
            if (arrayWithSections[i].indexOf('@') !== -1) {

                firstRowOfSection = arrayWithSections[i].split(" ");
                key = firstRowOfSection[1];

            } else if (arrayWithSections[i].indexOf('}') === -1) {

                rowOfTags = rowOfTags + arrayWithSections[i] + "(separator)";

            } else if (arrayWithSections[i].indexOf('}') !== -1) {
                arrayOfSections[key] = rowOfTags.split("(separator)")
                rowOfTags = '';
            }
        }

        var outputArray = renderHTML(arrayOfHTMLInput, arrayOfSections);
        //console.log(outputArray);
        for (var i = 0, len = outputArray.length; i < len; i++) {
            console.log(outputArray[i])
        }

    }
    //arrayOfHTMLInput
    function renderHTML(inputHTML, sectionArray) {
        var arrayOfHTMLOutput = [];
        var counter = 0;
        for (var i = 0, len = inputHTML.length; i < len; i++) {
            if (inputHTML[i].indexOf('@renderSection') !== -1) {
                var key = inputHTML[i].split('"')[1];
                for (var j = 0; j < sectionArray[key].length; j++) {
                    arrayOfHTMLOutput[counter++] = sectionArray[key][j];
                }
            }
            else if (inputHTML[i].indexOf('@@') !== -1) {
                arrayOfHTMLOutput[counter++] = inputHTML[i];
            }
            else {
                arrayOfHTMLOutput[counter++] = inputHTML[i];
            }
        }

        return arrayOfHTMLOutput;
    }
        var input = [
        '6',
        'title:Telerik Academy',
        'showSubtitle:true',
        'subTitle:Free training',
        'showMarks:false',
        'marks:3,4,5,6',
        'students:Pesho,Gosho,Ivan',
        '42',
        '@section menu {',
        '    <ul id="menu">',
        '        <li>Home</li>',
        '        <li>About us</li>',
        '    </ul>',
        '}',
        '@section footer {',
        '    <footer>',
        '        Copyright Telerik Academy 2014',
        '    </footer>',
        '}',
        '<!DOCTYPE html>',
        '<html>',
        '<head>',
        '    <title>Telerik Academy</title>',
        '</head>',
        '<body>',
        '    @renderSection("menu")',
        '',
        '    <h1>@title</h1>',
        '@if (showSubtitle) {',
        '    <h2>@subTitle</h2>',
        '    <div>@@JustNormalTextWithDoubleKliomba ;)</div>',
        '}',
        '',
        '<ul>',
        '    @foreach (var student in students) {',
        '    <li>',
        '        @student ',
        '    </li>',
        '    <li>Multiline @title</li>',
        '}',
        '</ul>',
        '@if (showMarks) {',
        '    <div>',
        '        @marks ',
        '    </div>',
        '    }',
        '',
        '    @renderSection("footer")',
        '</body>',
        '</html>',
        ];
    solve(input);
}