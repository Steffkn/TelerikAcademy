var Player;
(function (_Player) {
    var Player = (function () {
        function Player(username) {
            this.MaxNumberOfHeros = 3;
            this.numberOfHeroes = 0;
            this.username = username;
            this.accountBalance = 0;
            this.heroes = [];
        }
        Player.prototype.addHeroSlot = function (code) {
            if (code == GM.GM.code && GM.GM.code.length > 0) {
                this.MaxNumberOfHeros++;
                console.log("You unlocked a new hero slot! Thank you for donations!");
            } else {
                throw new Error("Invalid promo code!");
            }
        };

        Player.prototype.addToBalance = function (amount) {
            if (amount <= 0) {
                throw new Error("U can't add negative amount!");
            } else {
                this.accountBalance += amount;
                return true;
            }
        };

        Player.prototype.takeFromBalance = function (amount) {
            if (amount <= 0) {
                throw new Error("U can't remove negative amount!");
            } else {
                this.accountBalance -= amount;
                return true;
            }
        };

        Player.prototype.addHero = function (newHero) {
            if (this.numberOfHeroes < this.MaxNumberOfHeros) {
                this.heroes.push(newHero);
                this.numberOfHeroes++;
            } else {
                throw new Error("You have reached the maximum number of heroes!");
            }
        };

        Player.prototype.removeHero = function (heroToRemove) {
            var heroTobeRemovedIndex = this.heroes.indexOf(heroToRemove);

            if (heroTobeRemovedIndex < 0) {
                throw new Error('The hero could not be found!');
            }
            var removedHero = this.heroes[heroTobeRemovedIndex];
            this.heroes[heroTobeRemovedIndex] = this.heroes[this.heroes.length - 1];
            this.heroes.pop();
            this.numberOfHeroes--;
            return removedHero;
        };

        Player.prototype.toString = function () {
            var result;
            var i = 0;
            result = "Username: " + this.username + "\n";

            for (i = 0; i < this.numberOfHeroes; i++) {
                result += this.heroes[i].toString();
            }
            return result;
        };
        return Player;
    })();
    _Player.Player = Player;
})(Player || (Player = {}));
//# sourceMappingURL=Player.js.map
