function Solve(args) {

    function inRange(pos, range) {
        return 0 <= pos && pos < range;
    }

    var nmkStr = args[0].split(" ");
    var n = parseInt(nmkStr[0]);
    var m = parseInt(nmkStr[1]);
    var d = parseInt(nmkStr[2]);
    var posStr = args[1].split(" ");
    var row = parseInt(posStr[0]);
    var column = parseInt(posStr[1]);
    var dirsArr = args.slice(2);
    var dirs = [dirsArr.length];
    for (var i = 0; i < dirsArr.length; i++) {
        var dir = dirsArr[i].split(" ");
        dirs[i] = {
            row: parseInt(dir[0]),
            column: parseInt(dir[1])
        }
    }

    var used = {};
    var sum = 0;
    var dir = 0;
    var count = 0;
    while (true) {
        if (!inRange(row, n) || !inRange(column, m)) {
            return "escaped " + sum;
        }
        if (used[row * m + column]) {
            return "caught " + count;
        }
        count++;
        used[row * m + column] = true;
        sum += row * m + column + 1;
        row += dirs[dir].row;
        column += dirs[dir].column;
        dir++;
        dir %= dirs.length;
    }
}