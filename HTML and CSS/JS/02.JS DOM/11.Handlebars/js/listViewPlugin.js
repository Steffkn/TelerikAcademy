(function ($) {
    var books = [{
        id: 1,
        title: 'JavaScript for beginners'
    }, {
        id: 2,
        title: 'JavaScript - jQuery'
    }, {
        id: 3,
        title: 'JavaScript - Handlebars'
    }, {
        id: 4,
        title: 'JavaScript - Canvas & SVG'
    }, {
        id: 5,
        title: 'JavaScript - KineticJS'
    }];

    var students = [{
        number: 1,
        name: 'Peter Petrov',
        mark: 5.5
    }, {
        number: 2,
        name: 'Stamat Georgiev',
        mark: 4.7
    }, {
        number: 3,
        name: 'Maria Todorova',
        mark: 6
    }, {
        number: 4,
        name: 'Georgi Geshov',
        mark: 3.7
    }];
    
    $.fn.listview = function (items) {
        var $this = $(this);
        var $elementID = '#' + $this.attr('data-template');

        var templateString = '{{#items}}';
        templateString += $($elementID).text();
        templateString += '{{/items}}';

        var listViewTemplate = Handlebars.compile(templateString);
        var listViewHTML = listViewTemplate({ items: items });

        $this.html($this.html() + listViewHTML);

        return $this;
    }

    $.fn.listviewExtended = function (items) {
        var $this = $(this);
        var templateString = '{{#items}}';
        templateString += $this.html();
        templateString += '{{/items}}';

        var listViewTemplate = Handlebars.compile(templateString);
        var listViewHTML = listViewTemplate({ items: items });
        $this.html(listViewHTML);

        return $this;
    }

    $('#books-list').listview(books);
    $('#students-table').listview(students);

    // i changed the id so that it can be generated in the same file
    $('#books-list-extended').listviewExtended(books);
    $('#students-table-extended').listviewExtended(students);
})(jQuery);