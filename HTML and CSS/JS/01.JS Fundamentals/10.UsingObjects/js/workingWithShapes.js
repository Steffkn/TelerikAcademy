// 1 Write functions for working with shapes in  standard Planar coordinate system
//     Points are represented by coordinates P(X, Y)
//     Lines are represented by two points, marking their beginning and ending
//     L(P1(X1,Y1), P2(X2,Y2))
//     Calculate the distance between two points
//     Check if three segment lines can form a triangle

function onMakePointsAndLines() {
    printInElement('', true);
    var point1 = new Point(0, 0),
        point2 = new Point(4, 3);

    var point3 = new Point(0, 0),
        point4 = new Point(0, 4);

    var point5 = new Point(4, 0),
        point6 = new Point(4, 3);

    var sideC = new Line(point1, point2);
    var sideB = new Line(point3, point4);
    var sideA = new Line(point5, point6);

    printInElement('Lines: \n');
    printInElement('A: ' + sideA.toString + ' with length: ' + sideA.length + '\n');
    printInElement('B: ' + sideB.toString + ' with length: ' + sideB.length + '\n');
    printInElement('C: ' + sideC.toString + ' with length: ' + sideC.length + '\n');

    if (canFormTriangle(sideA, sideB, sideC)) {
        printInElement('Can form a triangle!\n');
    } else {
        printInElement('These lines can NOT form a triangle!\n');
    }
}

function Point(newX, newY) {
    this.x = newX || 0;
    this.y = newY || 0;
    this.toString = '[' + this.x + ', ' + this.y + ']';
}

function Line(pointA, pointB) {
    if (pointA instanceof Point && pointB instanceof Point) {
        this.pointA = pointA;
        this.pointB = pointB;
        this.length = calculateDistanceBetween2Points(this.pointA, this.pointB);
        this.toString =  '{' + this.pointA.toString + ', ' + this.pointB.toString + '}';
    } else {
        console.log('Invalid points of the line!\n');
    }
}

function calculateDistanceBetween2Points(pointA, pointB) {
    var sideC = 0,
        sideA = Math.abs(pointA.x - pointB.x),
        sideB = Math.abs(pointA.y - pointB.y);

    sideC = Math.sqrt(sideA * sideA + sideB * sideB);
    return sideC;
}

function canFormTriangle(lineA, lineB, lineC) {
    if (lineA instanceof Line && lineB instanceof Line && lineC instanceof Line) {
        // if every line is smaller than the sum of the other 3
        if (lineA.length < lineB.length + lineC.length && 
                lineB.length < lineA.length + lineC.length &&
                lineC.length < lineA.length + lineB.length) {
            return true;
        } else {
            return false;
        }
    } else {
        console.log('Invalid lines!\n');
        return false;
    }
}