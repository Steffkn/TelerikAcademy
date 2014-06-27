// 5 Write a function that finds the youngest person in a given array of persons and prints his/hers full name
//      Each person have properties firstname, lastname and age, as shown:
//      var persons = [{ firstname : 'Gosho', lastname: 'Petrov', age: 32 }, { firstname : 'Bay', lastname: 'Ivan', age: 81} ];

function onFindYoungest() { 
    printInElement('', true);
    var persons = [
        { 
            firstname : 'Gosho',
            lastname: 'Petrov', 
            age: 32 
        },
        {
            firstname: 'Pesho',
            lastname: 'Dochev',
            age: 16
        },
        {
            firstname: 'Bay',
            lastname: 'Ivan',
            age: 81
        }
    ];

    var youngest = findYoungest(persons);
    printInElement('full list of people\n');
    showYoungestFullName(persons);
    printInElement('The youngest person/people\n');
    showYoungestFullName(youngest);
}

function findYoungest(persons) {
    var youngest = [],
        age = Number.MAX_VALUE;

    for (var index = 0, len = persons.length; index < len; index++) {
        if (age > persons[index].age) {
            age = persons[index].age;
        }
    }

    for (var index = 0, len = persons.length, youngestIndex = 0; index < len; index++) {
        if (age === persons[index].age) {
            // from previous task 3
            youngest[youngestIndex] = makeDeepCopy(persons[index]);
            youngestIndex++;
        }
    }

    return youngest;
}
function showYoungestFullName(youngest) {
    for (var index = 0, len = youngest.length; index < len; index++) {
        printInElement(youngest[index].firstname + " " + youngest[index].lastname + '\n');
    }
}

