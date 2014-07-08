module Interfaces {
    export interface IPlayer {
        heroes: Array<IHero>;
        username: string;
        accountBalance: number; // because we are greedy

        addHero(newHero: IHero): void;
        removeHero(heroToRemove: IHero): void;
    }
}