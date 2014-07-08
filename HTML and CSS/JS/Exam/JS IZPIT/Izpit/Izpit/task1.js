window.onload = function () {

    function solve(params) {
        var numberOfWheels = params;
        var count = 0;
        var mashini = [3, 4, 10];
        var guess = 0;

        while (guess < numberOfWheels) {
            guess += mashini[2];
            count++;
        }


        console.log(count);
    }
    solve(10);
}