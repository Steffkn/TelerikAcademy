function printInElement(output, clear) {
    if (clear === true) {
        document.getElementById("result").innerText = "";
    }
    document.getElementById("result").innerText = document.getElementById("result").innerText + output;
    console.log(output);
}

/* Problem 1. Make person
Write a function for creating persons.
Each person must have firstname, lastname, age and gender (true is female, false is male)
Generate an array with ten person with different names, ages and genders
*/

function taskOneCreatePeople() {
    printInElement('', true);
    var persons = createPeople();
    printInElement(JSON.stringify(persons, true));
}

function createPeople() {
    var persons = [
        new Person('Stefan', 'Kermenliiski', 25, 'male'),
        new Person('Petra', 'Gancheva', 29, 'female'),
        new Person('Vladi', 'Nikolov', 15, 'male'),
        new Person('Gergana', 'Gancheva', 17, 'female'),
        new Person('Bobi', 'Ivanov', 32, 'male'),
        new Person('Lachezara', 'Stefanova', 39, 'female'),
        new Person('Aleksandyr', 'Tanev', 21, 'male'),
        new Person('Bobi', 'Djoneva', 41, 'female'),
        new Person('Kircho', 'Stavrev', 42, 'male'),
        new Person('Krisi', 'Chifudova', 29, 'female')
    ];

    return persons;
}

function Person(firstName, lastName, age, gender) {

    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.gender = gender;
}

/* Problem 2. People of age
Write a function that checks if an array of person contains only people of age (with age 18 or greater)
Use only array methods and no regular loops (for, while)
*/

function taskTwoCheckForAdouts() {
    printInElement('', true);
    var persons = createPeople();


    var isAllAdult = persons.every(function (item) {
        return item.age >= 18;
    });

    console.log('Task 02:');

    printInElement('Is everyone over 18 years old? ' + isAllAdult, false);
    var isAllUnder50 = persons.every(function (item) {
        return item.age < 50;
    });

    printInElement('\nIs everyone under 50 years old? ' + isAllUnder50, false);
}

/* Problem 3. Underage people
Write a function that prints all underaged persons of an array of person
Use Array#filter and Array#forEach
Use only array methods and no regular loops (for, while)
*/

function task3CheckForUnderagedPPL() {
    printInElement('', true);
    var persons = createPeople();

    console.log('Task 03:');

    var allUnderage = [];

    allUnderage = persons.filter(function (item) {
        return item.age < 18;
    });

    console.log('Everyone who is under 18:');

    allUnderage.forEach(function (item) {
        printInElement(JSON.stringify(item) + '\n');
    });

}

/* Problem 4. Average age of females
Write a function that calculates the average age of all females, extracted from an array of persons
Use Array#filter
Use only array methods and no regular loops (for, while)
*/
function task4AVGAgeOfAllFemales() {
    printInElement('',true);
    var persons = createPeople();

    var allWomen = persons.filter(function (item) {

        if (item.gender === 'female') {
            return item.age;
        }
    });

    var sumAge = allWomen.reduce(function (sumAge, person) {
        return sumAge + person.age;
    }, 0);

    console.log('Task 04: ');
    printInElement('The average age of all Women is ' + (sumAge / allWomen.length).toFixed(2) + ' years old\n');

}
/*Problem 5. Youngest person
Write a function that finds the youngest male person in a given array of people and prints his full name
Use only array methods and no regular loops (for, while)
Use Array#find
*/
function task5FindYoungestMale() {
    printInElement('', true);
    var persons = createPeople();

    persons.sort(function (first, second) { // will change the original array
        return first.age - second.age;
    });

    // If it is not predefined you may get: Uncaught TypeError: persons.find is not a function
    if (!Array.prototype.find) {
        Array.prototype.find = function (callback) {
            var i, len = this.length;
            for (i = 0; i < len; i += 1) {
                if (callback(this[i], i, this)) {
                    return this[i];
                }
            }
        }
    }

    var youngestPerson = persons.find(function (item) {
        if (item !== undefined) {
            return item; // In a sorted array by age the very first element will do the job
        }
    });

    console.log('Task 05:');
    printInElement('Youngest person is:' + youngestPerson.firstName + ' ' + youngestPerson.lastName + ' with age of ' + youngestPerson.age);
}

/* Problem 6. Group people
Write a function that groups an array of persons by first letter of first name and returns the groups as a JavaScript Object
Use Array#reduce
Use only array methods and no regular loops (for, while)
*/

function task6GroupPeopleByFirstLetter() {
    printInElement('', true);
    var persons = createPeople();

    var sorted = persons.reduce(function (obj, item) {

        if (obj[item.firstName[0]]) {
            obj[item.firstName[0]].push(item);
        } else {
            obj[item.firstName[0]] = [item];
        }
        return obj;
    }, {});

    console.log('Task 06:');

    printInElement(JSON.stringify(sorted));
}