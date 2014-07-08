module Interfaces {
    export interface IHeroRace {
        heroRace: Enumerations.Races;
        name: string;

        strength?: number;
        constitution?: number;
        dexterity?: number;
        intelligence?: number;
        wisdom?: number;
        charisma?: number;

        toString(): string;
    }

}