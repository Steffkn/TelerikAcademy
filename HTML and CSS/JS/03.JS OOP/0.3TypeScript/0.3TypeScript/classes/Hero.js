var Hero;
(function (_Hero) {
    var Hero = (function () {
        function Hero(name, heroRace, heroClass) {
            this.name = name;
            this.heroRace = heroRace;
            this.heroClass = heroClass;
            this.strength = 10;
            this.constitution = 10;
            this.dexterity = 10;
            this.intelligence = 10;
            this.wisdom = 10;
            this.charisma = 10;
            this.strength = this.strength + this.heroClass.strength + this.heroRace.strength;
            this.constitution += this.heroClass.constitution + this.heroRace.constitution;
            this.dexterity += this.heroClass.dexterity + this.heroRace.dexterity;
            this.intelligence += this.heroClass.intelligence + this.heroRace.intelligence;
            this.wisdom += this.heroClass.wisdom + this.heroRace.wisdom;
            this.charisma += this.heroClass.charisma + this.heroRace.charisma;
        }
        Hero.prototype.toString = function () {
            return "Hero name - " + this.name + "\n" + "    Race - " + this.heroRace.toString() + "\n" + "    Class - " + this.heroClass.toString() + "\n" + "    Stats of the hero\n" + "       Strength - " + this.strength + "\n" + "       Constitution - " + this.constitution + "\n" + "       Dexterity - " + this.dexterity + "\n" + "       Intelligence - " + this.intelligence + "\n" + "       Wisdom - " + this.wisdom + "\n" + "       Charisma - " + this.charisma + "\n";
        };
        return Hero;
    })();
    _Hero.Hero = Hero;
})(Hero || (Hero = {}));
//# sourceMappingURL=Hero.js.map
