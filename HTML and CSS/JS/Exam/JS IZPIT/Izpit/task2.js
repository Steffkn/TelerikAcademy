window.onload = function () {

    function solve(params) {
        var dimensions = params[0].split(' ');
        var rows = parseInt(dimensions[0]);
        var cols = parseInt(dimensions[1]);
        var score = 0;
        var matrixNumbers = [];
        var matrixDirections = [];

        var canMove = true;

        for (var i = 0; i < rows; i++) {
            matrixDirections[i] = params[i + 1].split(' ');
        }

        for (var i = 0; i < rows; i++) {
            var first = Math.pow(2, i);
            var rowOfNumbers = first;
            first++;
            for (var j = 0; j < cols; j++, first++) {
                rowOfNumbers = rowOfNumbers + " " + first;
            }
            matrixNumbers[i] = rowOfNumbers.split(" ");
        }

        var currentRow = 0;
        var currentCol = 0;

        while (canMove) {

            switch (matrixDirections[currentRow][currentCol]) {

                case 'dr':
                    matrixDirections[currentRow][currentCol] = "v";
                    score += parseInt(matrixNumbers[currentRow][currentCol]);
                    currentRow++;
                    currentCol++;

                    if (currentRow < 0 || currentRow > rows ||  
                        currentCol < 0 || currentCol > cols) {
                        console.log("successed with " + score);
                        canMove = false;
                    }
                    break;
                case "ur":
                    matrixDirections[currentRow][currentCol] = "v";
                    score += parseInt(matrixNumbers[currentRow][currentCol]);
                    currentRow--;
                    currentCol++;

                    if (currentRow < 0 || currentRow > rows ||
                        currentCol < 0 || currentCol > cols) {
                        console.log("successed with " + score);
                        canMove = false;
                    }
                    break;
                case "dl":
                    matrixDirections[currentRow][currentCol] = "v";
                    score += parseInt(matrixNumbers[currentRow][currentCol]);
                    currentRow++;
                    currentCol--;

                    if (currentRow < 0 || currentRow > rows ||
                        currentCol < 0 || currentCol > cols) {
                        console.log("successed with " + score);
                        canMove = false;
                    }
                    break;
                case "ul":
                    matrixDirections[currentRow][currentCol] = "v";
                    score += parseInt(matrixNumbers[currentRow][currentCol]);
                    currentRow--;
                    currentCol--;

                    if (currentRow < 0 || currentRow > rows ||
                        currentCol < 0 || currentCol > cols) {
                        console.log("successed with " + score);
                        canMove = false;
                    }
                    break;
                case "v":
                    console.log("failed at (" + currentRow + ", " + currentCol + ")");
                    canMove = false;
                default:
            }
        }

    }

    args = [
      '3 5',
      'dr dl dr ur ul',
      'dr dr ul ur ur',
      'dl dr ur dl ur'
    ]


    solve(args);
}