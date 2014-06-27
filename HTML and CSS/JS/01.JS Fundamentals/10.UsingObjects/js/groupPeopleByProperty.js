// 6 Write a function that groups an array of persons by age, first or last name. 
// The function must return an associative array, with keys - the groups, and values -arrays with persons in this groups
//      Use function overloading (i.e. just one function)
// var persons = {…};
// var groupedByFname = group(persons, 'firstname');
// var groupedByAge= group(persons, 'age');

function onGroupByProperty() {
    printInElement('',true);
    var people = [
        { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
        { firstname: 'Pesho', lastname: 'Dochev', age: 16 },
        { firstname: 'Gergana', lastname: 'Stamenova', age: 18 },
        { firstname: 'Bay', lastname: 'Goshkov', age: 81 },
        { firstname: 'Ivan', lastname: 'Petrov', age: 32 },
        { firstname: 'Pesho', lastname: 'Dochev', age: 16 },
        { firstname: 'Gergana', lastname: 'Stamenova', age: 18 },
        { firstname: 'Bay', lastname: 'Ivan', age: 81 }
    ];

    var peopleGroupedByFirstName = group(people, 'firstname');
    var peopleGroupedByLastName = group(people, 'lastname');
    var peopleGroupedByAge = group(people, 'age');

    for (var i in peopleGroupedByFirstName) {
        printInElement(i + " => " + peopleGroupedByFirstName[i] + "\n");
    }

    for (var i in peopleGroupedByLastName) {
        printInElement(i + " => " + peopleGroupedByLastName[i] + "\n");
    }

    for (var i in peopleGroupedByAge) {
        printInElement(i + " => " + peopleGroupedByAge[i] + "\n");
    }
}

function group(person, property) {
    var array = [];

    for (var i = 0; i < person.length; i++) {
        for (var j in person[i]) {
            if (j === property) {
                array.push(person[i][j]);
            }
        }
    }

    var wordsCount = {};
    var word = {};
    for (var index in array) {
        word = array[index];
        if (wordsCount[word]) {
            wordsCount[word]++;
        }
        else {
            wordsCount[word] = 1;
        }
    }

    return wordsCount;
}