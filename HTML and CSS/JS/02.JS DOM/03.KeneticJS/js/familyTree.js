﻿var familyMembers = [
   {
       mother: 'Maria Ivancheva',
       father: 'Kamen Ivanchev',
       children: ['Ivo Ivanchev', 'Delian Ivanchev']
   },
    {
        mother: 'Nadejda Ivancheva',
        father: 'Ivo Ivanchev',
        children: ['Petio Ivanchev', 'Marin Ivanchev']
    },
    {
        mother: 'Natalia Ivancheva',
        father: 'Delian Ivanchev',
        children: ['Galina Hristova']
    },
    {
        mother: 'Galina Opanova',
        father: 'Boian Opanov',
        children: ['Maria Opanova', 'Patar Opanov']
    },
    {
        mother: 'Galina Hristova',
        father: 'Marin Hristov',
        children: ['Petar Hristov', 'Kamen Hristov', 'Ivan Hristov']
    },
    {
        mother: 'Simona Hristova',
        father: 'Kamen Hristov',
        children: ['Elena Hristova', 'Valeria Hristova']
    }
];

window.onload = function () {
    AddLevelAndIndex();
    Draw();
};

function AddLevelAndIndex() {
    // Add the new properties
    for (var i = 0; i < familyMembers.length; i++) {
        familyMembers[i].level = 0;
        familyMembers[i].childrenIndex = [];
    }

    // fill them with values
    for (var i = 0, length = familyMembers.length; i < length; i++) {
        for (var j = 0; j < length; j++) {
            var mother = familyMembers[j].children.indexOf(familyMembers[i].mother),
                father = familyMembers[j].children.indexOf(familyMembers[i].father);

            if (mother != -1 || father != -1) {
                familyMembers[j].childrenIndex.push(i);
                familyMembers[i].level = familyMembers[j].level + 1;
                if (familyMembers[i].childrenIndex.length != 0) {
                    for (var childIndex in familyMembers[i].childrenIndex) {
                        increaseLevels(familyMembers[familyMembers[i].childrenIndex[childIndex]]);
                    }
                }
            }
        }
    }
}

function Draw() {
    var stage = new Kinetic.Stage({
        container: 'container',
        width: 2000,
        height: 2000,
    }),
    layer = new Kinetic.Layer(),
    familyTree = [],
    text;

    // Fill the array familyTree with rectangles and texts
    makeTree(familyTree);

    // Print the array familyTree
    printTree(familyTree, layer);

    stage.add(layer);
}

function makeTree(familyTree) {
    var countOfMembersInLevel = new Array(20).join('0').split('').map(parseFloat),
        parentsWithHeirs = [],
        i, k, corner;

    // First we gonna add all members with Hairs
    for (i = 0, length = familyMembers.length; i < length; i++) {

        countOfMembersInLevel[familyMembers[i].level] = parseInt(countOfMembersInLevel[familyMembers[i].level] + 2);

        for (k = 0; k < 2; k++) {
            if (k === 0) {
                corner = 15;
                text = familyMembers[i]['mother'];
            }
            else {
                corner = 5;
                text = familyMembers[i]['father'];
            }

            parentsWithHeirs.push(text);

            familyTree.push(new Kinetic.Rect({
                x: (k + countOfMembersInLevel[familyMembers[i].level] - 2) * 160,
                y: familyMembers[i].level * 120,
                width: 150,
                height: 40,
                stroke: 'lightblue',
                cornerRadius: corner
            }));

            familyTree.push(new Kinetic.Text({
                x: (k + countOfMembersInLevel[familyMembers[i].level] - 2) * 160 + 30,
                y: familyMembers[i].level * 120 + 13,
                text: text,
                fontFamily: 'Calibri',
                fill: 'black',
            }));
        }
    }

    // In this moment in array parentsWithHeirs we have all parents with children. But there are some members without children 
    // last/bottom part of the tree

    parentsWithHeirs.sort();
    for (i = 0, length = familyMembers.length; i < length; i++) {
        for (var j = 0; j < familyMembers[i].children.length; j++) {
            if (parentsWithHeirs.indexOf(familyMembers[i].children[j]) == -1) {
                text = familyMembers[i].children[j];

                if (isNaN(countOfMembersInLevel[familyMembers[i].level + 1])) {
                    countOfMembersInLevel[familyMembers[i].level + 1] = 0;
                };

                if (text[text.length - 1] === 'а' || text[text.length - 1] === 'a') {
                    corner = 15;
                }
                else {
                    corner = 5;
                }

                familyTree.push(new Kinetic.Rect({
                    x: (countOfMembersInLevel[familyMembers[i].level + 1]) * 160,
                    y: (familyMembers[i].level + 1) * 120,
                    width: 150,
                    height: 40,
                    stroke: 'lightblue',
                    cornerRadius: corner
                }));

                familyTree.push(new Kinetic.Text({
                    x: (countOfMembersInLevel[familyMembers[i].level + 1]) * 160 + 30,
                    y: (familyMembers[i].level + 1) * 120 + 12,
                    text: text,
                    fontFamily: 'Calibri',
                    fill: 'black',
                }));
                countOfMembersInLevel[familyMembers[i].level + 1]++;
            }

        };
    }
}

function printTree(familyTree, layer) {
    for (var i = 0; i < familyTree.length; i++) {
        if (familyTree[i].textArr) {
            var startX = familyTree[i].getX() + 35,
                startY = familyTree[i].getY() + 27,
                parent = familyTree[i].textArr[0].text,
                index = findElement(parent),
                j, k;
            if (index != undefined) {
                for (j = 0; j < familyMembers[index].children.length; j++) {
                    var child = familyMembers[index].children[j];

                    for (k = 0; k < familyTree.length; k++) {
                        if (familyTree[k].textArr) {
                            if (familyTree[k].textArr[0].text === child) {
                                var endX = familyTree[k].getX() + 35,
                                    endY = familyTree[k].getY() - 13;

                                layer.add(new Kinetic.Line({
                                    points: [startX, startY, endX, endY - 15, endX, endY],
                                    stroke: 'lightblue',
                                    tension: 0
                                }));

                                layer.add(new Kinetic.Line({
                                    points: [endX - 15, endY - 10, endX, endY, endX + 15, endY - 10],
                                    stroke: 'lightblue',
                                    tension: 0.3
                                }));
                            }
                        }
                    }
                }
            };
        }
        layer.add(familyTree[i]);
    }
}

function findElement(name) {
    for (var i = 0; i < familyMembers.length; i++) {
        if (familyMembers[i].mother === name || familyMembers[i].father === name) {
            return i;
        }
    }
}

function increaseLevels(family) {
    family.level++;
    if (family.indexWithChildren.length === 0) {
        return;
    }
    for (var childIndex in family.indexWithChildren) {
        increaseLevels(family[family.indexWithChildrens[childIndex]]);
    }
}