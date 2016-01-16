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
        { firstname: 'Gergana', lastname: 'Stamenova', age: 16 },
        { firstname: 'Bay', lastname: 'Ivan', age: 81 }
    ];

    var peopleGroupedByFirstName = group(people, 'firstname');
    var peopleGroupedByLastName = group(people, 'lastname');
    var peopleGroupedByAge = group(people, 'age');
	
    for (var i in peopleGroupedByFirstName) {
        printInElement("People with first name " + i + " => " + peopleGroupedByFirstName[i] + "\n");
    }

    for (var i in peopleGroupedByLastName) {
        printInElement("People with last name " + i + " => " + peopleGroupedByLastName[i] + "\n");
    }

    for (var i in peopleGroupedByAge) {
        printInElement("People with age of " + i + " => " + peopleGroupedByAge[i] + "\n");
    }
}

function group(person, property) {
    var groupedPeople = [];

    for (var i = 0; i < person.length; i++) {
        for (var j in person[i]) {
            if (j === property) {
                groupedPeople.push(person[i][j]);
            }
        }
    }
	
    var wordsCount = {};
    var word = {};
    for (var index in groupedPeople) {
        word = groupedPeople[index];
        if (wordsCount[word]) {
            wordsCount[word]++;
        }
        else {
            wordsCount[word] = 1;
        }
    }

    return wordsCount;
}