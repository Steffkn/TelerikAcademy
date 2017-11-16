var Classes;
(function (Classes) {
    var BaseClass = (function () {
        // bonuses
        function BaseClass(name, heroClass, strength, constitution, dexterity, intelligence, wisdom, charisma) {
            this.name = name;
            this.heroClass = heroClass;
            this.strength = strength;
            this.constitution = constitution;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
            this.wisdom = wisdom;
            this.charisma = charisma;
        }
        BaseClass.prototype.toString = function () {
            return this.name;
        };
        return BaseClass;
    })();
    Classes.BaseClass = BaseClass;
})(Classes || (Classes = {}));
//# sourceMappingURL=BaseClass.js.map
