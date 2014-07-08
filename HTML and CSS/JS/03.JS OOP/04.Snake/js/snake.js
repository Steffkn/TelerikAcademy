$(document).ready(function () {

    var Game = (function () {

        var canvas = $("#snake")[0];
        var ctx = canvas.getContext("2d");

        var screenWidth = $("#snake").width();
        var screenHeight = $("#snake").height();

        var cellWidth = 10;
        var direction;
        var food;
        var score;
        var snake;

        var PartGenerator = (function () {
            function generateSnake() {
                snake = [];
                var length = 5; //Length of the snake
                for (var i = length - 1; i >= 0; i--) {
                    snake.push({ x: i, y: 0 });
                }
            }

            function generateFood() {
                food = {
                    x: Math.round(Math.random() * (screenWidth - cellWidth) / cellWidth),
                    y: Math.round(Math.random() * (screenHeight - cellWidth) / cellWidth),
                };
            }
            return {
                snake: generateSnake(),
                food: generateFood(),
            }
        });


        var Rembrant = (function () {
            function drawBoard() {
                ctx.fillStyle = "black";
                ctx.fillRect(0, 0, screenWidth, screenHeight);
                ctx.strokeStyle = "green";
                ctx.strokeRect(0, 0, screenWidth, screenHeight);
            }

            function painCell(x, y) {
                ctx.fillStyle = "green";
                ctx.fillRect(x * cellWidth, y * cellWidth, cellWidth, cellWidth);
                ctx.strokeStyle = "black";
                ctx.strokeRect(x * cellWidth, y * cellWidth, cellWidth, cellWidth);
            }

            function drawFood() {
                painCell(food.x, food.y);
            }

            function drawScore() {
                var scoreString = "Score: " + score;
                ctx.fillText(scoreString, 5, screenHeight - 5);
            }
            function drawSnake() {
                for (var i = 0; i < snake.length; i++) {
                    var cell = snake[i];
                    painCell(cell.x, cell.y);
                }
            }

            return {
                board: drawBoard(),
                food: drawFood(),
                score: drawScore(),
                snake: drawSnake(),
            }
        });


        function startGame() {
            direction = "right"; //default direction

            var partGenerator = new PartGenerator();
            partGenerator.snake;
            partGenerator.food;

            console.log('restart');
            score = 0;

            if (typeof game_loop !== "undefined") clearInterval(game_loop);
            game_loop = setInterval(paint, 60);
        }

        // Paint everything
        function paint() {
            var drawer = new Rembrant();
            drawer.board;

            var newHeadX = snake[0].x;
            var newHeadY = snake[0].y;

            if (direction === "right") { newHeadX++; }
            else if (direction === "left") { newHeadX--; }
            else if (direction === "up") { newHeadY--; }
            else if (direction === "down") { newHeadY++; }

            if (collisionDetection(newHeadX, newHeadY, snake)) {
                startGame()
                return;
            }

            if (newHeadX == food.x && newHeadY == food.y) {
                var tail = { x: newHeadX, y: newHeadY };
                score++;

                // generate new food
                food = {
                    x: Math.round(Math.random() * (screenWidth - cellWidth) / cellWidth),
                    y: Math.round(Math.random() * (screenHeight - cellWidth) / cellWidth),
                };
            }
            else {
                var tail = snake.pop(); //pops out the last cell
                tail.x = newHeadX; tail.y = newHeadY;
            }

            snake.unshift(tail); //puts back the tail as the first cell

            drawer.snake;
            drawer.food;
            drawer.score;
        }

        function collisionDetection(headX, headY, array) {
            if ((headX === -1 || headX === screenWidth / cellWidth) ||
                (headY === -1 || headY === screenHeight / cellWidth)) {
                return true;
            }
            for (var i = 0; i < array.length; i++) {
                if (array[i].x === headX && array[i].y === headY) {
                    return true;
                }
            }
            return false;
        }

        // Keyboard controls 
        $(document).keydown(function (e) {
            var key = e.which;
            if (key == "37" && direction != "right") direction = "left";
            else if (key == "38" && direction != "down") direction = "up";
            else if (key == "39" && direction != "left") direction = "right";
            else if (key == "40" && direction != "up") direction = "down";
        });

        return {
            start: startGame(),
        };
    });

    var snake = new Game();
    snake.start;
});