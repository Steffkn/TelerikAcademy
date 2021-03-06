﻿module Player {
    export class Player implements Interfaces.IPlayer {
        heroes: Hero.Hero[];
        private MaxNumberOfHeros: number = 3;
        private numberOfHeroes: number = 0
        username: string;
        accountBalance: number; // because we are greedy

        constructor(username: string) {
            this.username = username;
            this.accountBalance = 0;
            this.heroes = [];
        }

        addHeroSlot(code: string) {
            if (code == GM.GM.code && GM.GM.code.length > 0) {
                this.MaxNumberOfHeros++;
                console.log("You unlocked a new hero slot! Thank you for donations!")
            } else {
                throw new Error("Invalid promo code!");
            }
        }

        addToBalance(amount: number): boolean {
            if (amount <= 0) {
                throw new Error("U can't add negative amount!");
            }
            else {
                this.accountBalance += amount;
                return true;
            }
        }

        takeFromBalance(amount: number): boolean {
            if (amount <= 0) {
                throw new Error("U can't remove negative amount!");
            }
            else {
                this.accountBalance -= amount;
                return true;
            }
        }

        addHero(newHero: Hero.Hero): void {
            if (this.numberOfHeroes < this.MaxNumberOfHeros) {
                this.heroes.push(newHero);
                this.numberOfHeroes++;
            }
            else {
                throw new Error("You have reached the maximum number of heroes!");
            }
        }

        removeHero(heroToRemove: Interfaces.IHero): Interfaces.IHero {
            var heroTobeRemovedIndex = this.heroes.indexOf(heroToRemove);

            if (heroTobeRemovedIndex < 0) {
                throw new Error('The hero could not be found!');
            }
            var removedHero = this.heroes[heroTobeRemovedIndex];
            this.heroes[heroTobeRemovedIndex] = this.heroes[this.heroes.length - 1];
            this.heroes.pop();
            this.numberOfHeroes--;
            return removedHero;
        }

        toString(): string {
            var result: string;
            var i: number = 0;
            result = "Username: " + this.username + "\n";

            for (i = 0; i < this.numberOfHeroes; i++) {
                result += this.heroes[i].toString();
            }
            return result;
        }
    }
}