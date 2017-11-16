module Classes {
    export class BaseClass implements Interfaces.IHeroClass {

        // bonuses

        constructor(
            public name: string,
            public heroClass: Enumerations.Classes,
            public strength: number,
            public constitution: number,
            public dexterity: number,
            public intelligence: number,
            public wisdom: number,
            public charisma: number) {
        }

        toString() {
            return this.name;
        }
    }
} 