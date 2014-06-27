// 4 Write a function that checks if a given object contains a given property
//      var obj  = …;
//      var hasProp = hasProperty(obj, 'length');

function onCheckIfObjHasProperty() {
    printInElement('', true);

    var person = {
        name: "Patrik",
        age: 13
    };
    if (hasProperty('age', person)) {
        printInElement('The object person has property age!');
    }
    else {
        printInElement("The object person doesn't have property age!");
    }
}
function hasProperty(property, object) {
    return object.hasOwnProperty(property);
}