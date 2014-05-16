// Assign all the possible JavaScript literals to different variables.

console.log("First task:");

document.writeln('First task:' + '<br />');

var exampleNumber = 6;
var exampleFloating = 3.1415;
var exampleBoolean = true;
var exampleArray = ["me", "you", "he", "she", "it"];
var exampleString = "Give me the money!";
var exampleObject = new Object();

console.log("Integer -> " + exampleNumber);
console.log("Float -> " + exampleFloating);
console.log("Boolean -> " + exampleBoolean);
console.log("Array -> " + exampleArray);
console.log("String -> " + exampleString);
console.log("Object -> " + exampleObject);

document.writeln("Integer -> " + exampleNumber + '<br />');
document.writeln("Float -> " + exampleFloating + '<br />');
document.writeln("Boolean -> " + exampleBoolean + '<br />');
document.writeln("Array -> " + exampleArray + '<br />');
document.writeln("String -> " + exampleString + '<br />');
document.writeln("Object -> " + exampleObject + '<br />');

// Create a string variable with quoted text in it. For example: 'How you doin'?', Joey said.

console.log("Second task");

var quotedText = "\"How you doin' ?\", Joey said.";

console.log("Quoted text -> " + quotedText);

document.writeln('<br />');
document.writeln("Second task" + '<br />');
document.writeln("Quoted text -> " + quotedText + '<br />');

// Try typeof on all variables you created.

console.log("Third task:");
console.log("Type of Integer-> " + typeof exampleNumber);
console.log("Type of Float -> " + typeof exampleFloating);
console.log("Type of Boolean-> " + typeof exampleBoolean);
console.log("Type of Array -> " + typeof exampleArray);
console.log("Type of String -> " + typeof exampleString);
console.log("Type of Object -> " + typeof exampleObject);
console.log("Type of String (Quoted text) -> " + typeof quotedText);

document.writeln('<br />');
document.writeln("Third task:" + '<br />');
document.writeln("Type of Integer-> " + typeof exampleNumber + '<br />');
document.writeln("Type of Float -> " + typeof exampleFloating + '<br />');
document.writeln("Type of Boolean-> " + typeof exampleBoolean + '<br />');
document.writeln("Type of Array -> " + typeof exampleArray + '<br />');
document.writeln("Type of String -> " + typeof exampleString + '<br />');
document.writeln("Type of Object -> " + typeof exampleObject + '<br />');
document.writeln("Type of String (Quoted text) -> " + typeof quotedText + '<br />');

// Create null, undefined variables and try typeof on them.

console.log("Fourth task:");
document.writeln('<br />');
document.writeln("Fourth task:" + '<br />');
var valueNull = null;
var valueUndefined = undefined;
var valueNotSet;

console.log("Type of null -> " + typeof valueNull);
console.log("Type of undefined -> " + typeof valueUndefined);
console.log("Field without a value -> " + typeof valueNotSet);

document.writeln("Type of null -> " + typeof valueNull + '<br />');
document.writeln("Type of undefined -> " + typeof valueUndefined + '<br />');
document.writeln("Field without a value -> " + typeof valueNotSet + '<br />');