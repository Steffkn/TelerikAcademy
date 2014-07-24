$(document).ready(function () {

    $('#userData').hide();
    $('#topScores').show();

    // enchanced method addEventListener
    function addEventListener(selector, eventType, listener) {
        $(selector).on(eventType, listener);
    }

    function trigerClick($button) {
        $button.click();
    }

    var GameManager = (function () {
        var numberToGuess = [];
        var guessNumber = [];
        var guesses = 0;

        function getRandomNumber() {
            var newNumber = [];
            guesses = 0;
            newNumber[0] = Math.round(Math.random() * 8 + 1); // first digit must be bigger than 0
            newNumber[1] = Math.round(Math.random() * 9);
            newNumber[2] = Math.round(Math.random() * 9);
            newNumber[3] = Math.round(Math.random() * 9);
            numberToGuess = newNumber;
        }

        function getUserInput(value) {
            value = validateNumber(value);
            guessNumber = String(parseInt(value)).split('');
        }

        function validateNumber(number) {
            number = number.trim();
            if (number.length != 4) {
                throw new Error("The number must be 4 digits long!");
            }

            number = String(parseInt(number));
            if (isNaN(number) || (number < 1000 || number > 10000)) {
                throw new Error("This is not a 4 digit number!");
            }
            return number;
        }

        function checkNumber() {
            var rams = 0;
            var sheeps = 0;

            guesses += 1;

            //numberToGuess = [6, 1, 5, 4];
            //guessNumber = [2, 3, 4, 5];

            //numberToGuess = [5, 5, 8, 8];
            //guessNumber = [8, 8, 8, 5];

            var counted = [false, false, false, false];
            //console.log(numberToGuess);
            //console.log(guessNumber);
            for (var i = 0; i < numberToGuess.length; i++) {
                if (guessNumber[i] == numberToGuess[i]) {
                    //console.log(i + ' - ' + guessNumber[i] + ' ' + numberToGuess[i] + ' <- ram');
                    rams++;
                    if (counted[i]) {
                        sheeps--;
                    }
                    counted[i] = true;
                }
                else {
                    for (var j = 0; j < numberToGuess.length; j++) {
                        if (!counted[j] && guessNumber[i] == numberToGuess[j]) {
                            //console.log(i + ' ' + j + ' - ' + guessNumber[i] + ' ' + numberToGuess[j] + ' <- sheep');
                            sheeps++;
                            counted[j] = true;
                            break;
                        }
                    }
                }
            }
            manageResult(guessNumber, rams, sheeps);
        }

        function manageResult(guessNumber, rams, sheeps) {
            var ul = $('#guesses ul');
            var li = $('<li>');
            if (rams < 4) {
                li.text(guesses + ': (' + guessNumber.join('') + ') You have ' + rams + ' rams and ' + sheeps + ' sheeps!');
                ul.prepend(li);
            }
            else {
                $('#guesses').hide();
                $('#userData').fadeIn();
            }
        }

        function getUserName(name) {
            //validations
            return name;
        }
        function getUserGuesses() {
            return guesses;
        }
        return {
            getRandomNumber: getRandomNumber,
            getUserInput: getUserInput,
            getUserName: getUserName,
            getUserGuesses: getUserGuesses,
            checkNumber: checkNumber
        }
    })();

    var HighScores = (function () {
        var ramsAndSheepsHighScores = JSON.parse(localStorage.getItem('ramsAndSheepsHighScores')) || [];

        function addScore(name, guesses) {
            var user = {
                name: name,
                score: guesses
            }

            ramsAndSheepsHighScores.push(user);

            var sortedHighScores = _.chain(ramsAndSheepsHighScores)
                .sortBy(function (user) { return user.name; })
                .sortBy(function (user) { return user.score; })
                .first(5).value();
            console.log(sortedHighScores);
            localStorage.setItem('ramsAndSheepsHighScores', JSON.stringify(sortedHighScores));
        }

        function showAll() {
            var allScores = JSON.parse(localStorage.getItem('ramsAndSheepsHighScores')) || [];

            var ol = $('#topScores ol');
            ol.empty();
            _.chain(ramsAndSheepsHighScores)
               .each(function (user) {
                    var li = $('<li>');
                   li.text(user.name + ' ' + user.score);
                   ol.append(li);
               });
        }

        return {
            addScore: addScore,
            showAll: showAll
        }
    })();

    // hack the input for non digits
    $("#userInput").on({
        // When a new character was typed in
        keydown: function (e) {
            var key = e.which;

            // the enter key code
            if (key == 13) {
                trigerClick($('#guessBtn'));
                return false;
            }
            // if something else than [0-9] or BackSpace (BS == 8) is pressed, cancel the input
            if (((key < 48 || key > 57) && (key < 96 || key > 105)) && key !== 8) {
                return false;
            }
        },
        // When non digits managed to "sneak in" via copy/paste
        change: function () {
            // Regex-remove all non digits in the final value
            this.value = this.value.replace(/\D/g, "")
        }
    });

    addEventListener('#guessBtn', 'click', function (event) {
        var $userInput = $('#userInput');
        GameManager.getUserInput($userInput[0].value);
        GameManager.checkNumber();
    });

    addEventListener('#getNameBtn', 'click', function (event) {
        var $userName = $('#userName');
        var userName = GameManager.getUserName($userName[0].value);
        HighScores.addScore(userName, GameManager.getUserGuesses());

        $('#userData').hide();
        HighScores.showAll();
        $('#topScores').fadeIn();
    });

    addEventListener('#resetBtn', 'click', function (event) {
        var userInput = $('#userInput');
        var guessesUl = $('#guesses ul');
        guessesUl.empty();
        userInput[0].value = "";
        GameManager.getRandomNumber();
    });

    // add the scores
    HighScores.showAll();
    // start the game
    GameManager.getRandomNumber();
});