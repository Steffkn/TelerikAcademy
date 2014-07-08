module Hero {
    export class Hero implements Interfaces.IHero {

        strength: number = 10;
        constitution: number = 10;
        dexterity: number = 10;
        intelligence: number = 10;
        wisdom: number = 10;
        charisma: number = 10;

        constructor(public name: string, public heroRace: Interfaces.IHeroRace, public heroClass: Interfaces.IHeroClass) {
            this.strength = this.strength + this.heroClass.strength + this.heroRace.strength;
            this.constitution += this.heroClass.constitution + this.heroRace.constitution;
            this.dexterity += this.heroClass.dexterity + this.heroRace.dexterity;
            this.intelligence += this.heroClass.intelligence + this.heroRace.intelligence;
            this.wisdom += this.heroClass.wisdom + this.heroRace.wisdom;
            this.charisma += this.heroClass.charisma + this.heroRace.charisma;
        }

        toString(): string {
            return "Hero name - " + this.name + "\n" +
                "    Race - " + this.heroRace.toString() + "\n" +
                "    Class - " + this.heroClass.toString() + "\n" +
                "    Stats of the hero\n" +
                "       Strength - " + this.strength + "\n" +
                "       Constitution - " + this.constitution + "\n" +
                "       Dexterity - " + this.dexterity + "\n" +
                "       Intelligence - " + this.intelligence + "\n" +
                "       Wisdom - " + this.wisdom + "\n" +
                "       Charisma - " + this.charisma + "\n";
        }
    }
}