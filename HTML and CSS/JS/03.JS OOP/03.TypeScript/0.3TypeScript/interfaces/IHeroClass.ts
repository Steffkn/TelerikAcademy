module Interfaces {
    export interface IHeroClass {
        heroClass: Enumerations.Classes;
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