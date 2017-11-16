var Races;
(function (Races) {
    var Race = (function () {
        function Race(name, heroRace, strength, constitution, dexterity, intelligence, wisdom, charisma) {
            this.name = name;
            this.heroRace = heroRace;
            this.strength = strength;
            this.constitution = constitution;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
            this.wisdom = wisdom;
            this.charisma = charisma;
        }
        Race.prototype.toString = function () {
            return this.name;
        };
        return Race;
    })();
    Races.Race = Race;
})(Races || (Races = {}));
//# sourceMappingURL=Race.js.map
