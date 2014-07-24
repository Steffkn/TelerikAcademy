(function () {
    var books = [{
        title: 'The Hunger Games (The Hunger Games, #1)',
        author: 'Suzanne Collins'
    }, {
        title: 'Harry Potter and the Order of the Phoenix (Harry Potter, #5)',
        author: 'J.K. Rowling'
    }, {
        title: 'Harry Potter and the Goblet of Fire (Harry Potter, #4)',
        author: 'J.K. Rowling'
    }, {
        title: 'Twilight (Twilight, #1)',
        author: 'Stephenie Meyer'
    }, {
        title: 'Harry Potter and the Half-Blood Prince (Harry Potter, #6)',
        author: 'J.K. Rowling'
    }, {
        title: 'To Kill a Mockingbird',
        author: 'Harper Lee'
    }, {
        title: 'Harry Potter and the Deathly Hallows (Harry Potter, #7)',
        author: 'J.K. Rowling'
    }, {
        title: 'Harry Potter and the Chamber of Secrets (Harry Potter, #2)',
        author: 'J.K. Rowling'
    }, {
        title: 'Catching Fire (The Hunger Games, #2)',
        author: 'Suzanne Collins'
    }, {
        title: 'Harry Potter and the Sorcerer\'s Stone (Harry Potter, #1)',
        author: 'J.K. Rowling'
    }, {
        title: 'New Moon (Twilight, #2)',
        author: 'Stephenie Meyer'
    }, {
        title: 'Breaking Dawn (Twilight, #4)',
        author: 'Stephenie Meyer'
    }, {
        title: 'Eclipse (Twilight, #3)',
        author: 'Stephenie Meyer'
    }]

    function printBook(book) {
        console.log('Book: ' + book.title);
        console.log(' by ' + book.author);
    }

    function printAllBooks(books) {
        _.chain(books)
            .sortBy(function (book) { return book.author;})
            .each(printBook);
    }

    function findMostPopularAuthor(books) {
        var mostPopularAuthorBooks = _.max(_.groupBy(books, 'author'), function (book) {
            return book.length;
        });
        // mostPopularAuthorBooks contains all these books writen by the author that has most books in this collection
        return mostPopularAuthorBooks[0].author;
    }

    console.log('A list of books');
    printAllBooks(books);

    var mostPopularAuthor = findMostPopularAuthor(books);
    console.log('The most popular author in this collection is ' + mostPopularAuthor);
}());