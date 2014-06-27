// 3 Write a function that makes a deep copy of an object
//      The function should work for both primitive and reference types

function onMakeDeepCopy() {
    printInElement('', true);
    var onePerson = {
        firstName: 'Pesho',
        lastName: 'Peshkov',
        age: 22,
        address: {
            town: 'Sofia',
            street: {
                name: 'Macedonia',
                number: 11
            }
        },
        phone: '159-159-159'
    };

    var copyOfOnePerson = makeDeepCopy(onePerson);

    printInElement("A person's data \n");
    printObj(onePerson);

    printInElement("\nA copy of the person's data \n");
    printObj(copyOfOnePerson);

}

function makeDeepCopy(Object) {
    var copyOfObject = {};
    for (var key in Object) {
        var c = key;
        copyOfObject[c] = Object[key];
        if ((typeof copyOfObject[c]) == "object") {
            makeDeepCopy(Object[key]);
        }
    }
    return copyOfObject;
}

function printObj(Object) {
    for (var key in Object) {
        printInElement('Property -> ' + key + ': ' + Object[key] + ', Type: ' + typeof (Object[key]) + '\n');
        if (typeof (Object[key]) == 'object') {
            printObj(Object[key]);
        }
    }
}

