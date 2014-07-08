module GM {
    export class GM {
        static code: string = "";
        static giveSlotToPlayer(player: Interfaces.IPlayer) {
            if (player.accountBalance >= 100) {
                this.code = Math.random().toString(36).substring(15);
                console.log("Your promo code is :" + this.code)
                console.log("Don't give it away!");
            }
            else {
                console.log("You don't have enough currency");
            }
        }
    }
}