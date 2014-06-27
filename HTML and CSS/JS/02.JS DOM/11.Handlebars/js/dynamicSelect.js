(function () {
    var templateNode = document.getElementById('dynamic-select-template');
    var templateString = templateNode.innerHTML;
    var selectTemplate = Handlebars.compile(templateString);


    var items = [{
        value: 1,
        text: 'One'
    }, {
        value: 2,
        text: 'Two'
    }, {
        value: 3,
        text: 'Three'
    }, {
        value: 4,
        text: 'Four'
    }, {
        value: 5,
        text: 'Five'
    }, {
        value: 6,
        text: 'Six'
    }, {
        value: 7,
        text: 'Seven'
    }];


    var selectHTML = selectTemplate({ items: items });

    document.body.innerHTML += selectHTML;
})();