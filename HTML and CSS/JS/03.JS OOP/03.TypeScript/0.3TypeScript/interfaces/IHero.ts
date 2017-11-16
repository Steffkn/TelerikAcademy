module Interfaces {
    export interface IHero {
        heroRace: IHeroRace;
        heroClass: IHeroClass;

        name: string;

        strength: number;
        constitution: number;
        dexterity: number;
        intelligence: number;
        wisdom: number;
        charisma: number;

        toString(): string;
    }
}