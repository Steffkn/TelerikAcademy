// Write an expression that checks if given integer is odd or even.

console.log("First task")
document.writeln("First task <br/>")
var integer = 5;

if (integer % 2 === 0) {
	console.log(integer + " is event!")
	document.writeln(integer + " is event! <br/>")
} else {
	console.log(integer + " is odd!")
	document.writeln(integer + " is odd! <br/>")
}

// Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

console.log("Second task")
document.writeln("<br/>")
document.writeln("Second task <br/>")

var integer = 210;

if (integer % (35) === 0) {
	console.log(integer + " can be divided (without remainder) by 7 and 5 in the same time!")
	document.writeln(integer + " can be divided (without remainder) by 7 and 5 in the same time! <br/>")
} else {
	console.log(integer + " can NOT be divided (without remainder) by 7 and 5 in the same time!")
	document.writeln(integer + " can NOT be divided (without remainder) by 7 and 5 in the same time! <br/>")
}

// Write an expression that calculates rectangle’s area by given width and height.

console.log("Third task")
document.writeln("<br/>")
document.writeln("Third task <br/>")

var width = 10;
var height = 5;
var area = width * height;
console.log("The area of the rectangle (a = 10, b = 5) is " + area);
document.writeln("The area of the rectangle (a = 10, b = 5) is " + area + " <br/>")

// Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.

console.log("Fourth task")
document.writeln("<br/>")
document.writeln("Fourth task <br/>")

var integer = 1732;
var position = 3;
var temp = integer;
var index;

for (index = 1; index < position; index++) {
	temp = Math.floor(temp / 10);
}
if (temp % 10 == 7) {
	console.log("True: the third digit (right-to-left) of the number " + integer + " is 7");
	document.writeln("True: the third digit (right-to-left) of the number " + integer + " is 7 <br/>")
}
else {
	console.log("False: the third digit (right-to-left) of the number " + integer + " is NOT 7");
	document.writeln("False: the third digit (right-to-left) of the number " + integer + " is NOT 7 <br/>")
}

// Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

console.log("Fifth task")
document.writeln("<br/>")
document.writeln("Fifth task <br/>")

var integer = 8;
var position = 3;

if ((integer & (1 << position)) == 1 << position) {
	console.log("The bit 3 (counting from 0) of the number " + integer + " is 1!");
	document.writeln("The bit 3 (counting from 0) of the number " + integer + " is 1! <br/>")
} else {
	console.log("The bit 3 (counting from 0) of the number " + integer + " is 0!");
	document.writeln("The bit 3 (counting from 0) of the number " + integer + " is 0! <br/>")
}

// Write an expression that checks if given print (x,  y) is within a circle K(O, 5).

console.log("Sixth task")
document.writeln("<br/>")
document.writeln("Sixth task <br/>")

var point = new Object;
point.x = 1;
point.y = 2;

var circle = new Object;
circle.radius = 5;
circle.x = 0;
circle.y = 0;

// the expression Math.sqrt(Math.pow(point.x - circle.x, 2) + Math.pow(point.y - circle.y, 2)) < circle.radius
// will solve the problem if the circle's center is not at (0, 0)

// finds the length of the line between (0, 0) and the given point (Pitagor: a² + b² = c²)
// then checks if that length is less than the radius of the circle
if (Math.sqrt(Math.pow(point.x, 2) + Math.pow(point.y, 2)) < circle.radius) {
	console.log("The point (" + point.x + ", " + point.y + ") is within a circle K(O, 5).");
	document.writeln("The point (" + point.x + ", " + point.y + ") is within a circle K(O, 5). <br />");
} else {
	console.log("The point (" + point.x + ", " + point.y + ") is NOT within a circle K(O, 5).");
	document.writeln("The point (" + point.x + ", " + point.y + ") is NOT within a circle K(O, 5). <br />");
}

// 7 Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

console.log("Seventh task")
document.writeln("<br/>")
document.writeln("Seventh task <br/>")

var integer = 47;
// the number must be less than or equal to 100 => we don't have to check for the prime numbers above 7 ( 11 * 11 > 1000)

if (integer == 2 || integer == 3 || integer == 5 || integer == 7) {
	console.log("The number " + integer + " is a prime number!");
	document.writeln("The number " + integer + " is a prime number! <br />");
} else if (integer % 2 == 0 || integer % 3 == 0 || integer % 5 == 0 || integer % 7 == 0)
{
	console.log("The number " + integer + " is NOT a prime number!");
	document.writeln("The number " + integer + " is NOT a prime number! <br />");
} else
{
	console.log("The number " + integer + " is a prime number!");
	document.writeln("The number " + integer + " is a prime number! <br />");
}

// 8 Write an expression that calculates trapezoid's area by given sides a and b and height h.

console.log("Eight task")
document.writeln("<br/>")
document.writeln("Eight task <br/>")
var trapezoid = new Object;
trapezoid.a = 3;
trapezoid.b = 4;
trapezoid.h = 5;

trapezoid.area = (trapezoid.a + trapezoid.b) * trapezoid.h / 2;

console.log("The area of the trapezoid is " + trapezoid.area);
document.writeln("The area of the trapezoid is " + trapezoid.area + "<br />");

// 9 Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

console.log("Ninth task")
document.writeln("<br/>")
document.writeln("Ninth task <br/>")

// object for the point
var point = new Object;
point.x = 4;
point.y = 0;

// object for the circle
var circle = new Object;
circle.radius = 3;
circle.x = 1;
circle.y = 1;

// object for the rectangle
var rectangle = new Object;
rectangle.top = 1;
rectangle.left = -1;
rectangle.width = 6;
rectangle.height = 2;


// finds the length of the line between (0, 0) and the given point (Pitagor: a² + b² = c²)
// then checks if that length is less than the radius of the circle
if (Math.sqrt(Math.pow(point.x - circle.x, 2) + Math.pow(point.y - circle.y, 2)) < circle.radius) {
    console.log("The point (" + point.x + ", " + point.y + ") is within a circle K( (1,1), 3).");
    document.writeln("The point (" + point.x + ", " + point.y + ") is within a circle K( (1,1), 3). <br />");
} else {
    console.log("The point (" + point.x + ", " + point.y + ") is NOT within a circleK( (1,1), 3).");
    document.writeln("The point (" + point.x + ", " + point.y + ") is NOT within a circle K( (1,1), 3). <br />");
}

// check if the point is within the rectangle
// if the point lies on the sides of the rectangle the result is false
if (point.y < rectangle.top && point.y > rectangle.top - rectangle.height &&
    point.x > rectangle.left && point.x < rectangle.left + rectangle.width) {
    console.log("The point (" + point.x + ", " + point.y + ") is within a rectangle R(top = 1, left = -1, width = 6, height = 2).");
    document.writeln("The point (" + point.x + ", " + point.y + ") is within a rectangle R(top = 1, left = -1, width = 6, height = 2). <br />");
} else {
    console.log("The point (" + point.x + ", " + point.y + ") is NOT within a rectangle R(top = 1, left = -1, width = 6, height = 2).");
    document.writeln("The point (" + point.x + ", " + point.y + ") is NOT within a rectangle R(top = 1, left = -1, width = 6, height = 2). <br />");
}