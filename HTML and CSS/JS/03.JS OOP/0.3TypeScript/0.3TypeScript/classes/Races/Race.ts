module Races {
    export class Race implements Interfaces.IHeroRace {

        constructor(
            public name: string,
            public heroRace: Enumerations.Races,
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