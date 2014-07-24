(function () {
    var people = [{
        firstName: 'Georgi',
        lastName: 'Ivanov'
    }, {
        firstName: 'Todor',
        lastName: 'Ivanov'
    }, {
        firstName: 'Ivan',
        lastName: 'Georgiev'
    }, {
        firstName: 'Gustav',
        lastName: 'Ivanov'
    }, {
        firstName: 'Todor',
        lastName: 'Aleksandrov'
    }, {
        firstName: 'Aleksandar',
        lastName: 'Gustavson'
    }, {
        firstName: 'Georgi',
        lastName: 'Aleksandrov'
    }, {
        firstName: 'Todor',
        lastName: 'Zedov'
    }]

    function displayFullname(person) {
        console.log(person.firstName + ' ' + person.lastName);
    }

    function showAllPeopleSorted(people) {
        console.log('List of people');
        _.chain(people)
            .sortBy(function (person) { return person.lastName; }) // if sorted by last name
            .sortBy(function (person) { return person.firstName; }) // sorting by first name wont break the sorting from last name and it will return everyone sorted by first and then by last name
			.each(displayFullname);
    }

    function findMostPopularName(people, nameToGroupBy) {
        var mostCommonName = _.max(_.groupBy(people, nameToGroupBy), function (person) {
            return person.length;
        });
        return mostCommonName[0][nameToGroupBy];
    }

    showAllPeopleSorted(people);
    console.log('Most common first name: ' + findMostPopularName(people, 'firstName'));
    console.log('Most common last name: ' + findMostPopularName(people, 'lastName'));
}());