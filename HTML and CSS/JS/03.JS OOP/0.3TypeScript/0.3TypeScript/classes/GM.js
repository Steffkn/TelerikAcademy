var GM;
(function (_GM) {
    var GM = (function () {
        function GM() {
        }
        GM.giveSlotToPlayer = function (player) {
            if (player.accountBalance >= 100) {
                this.code = Math.random().toString(36).substring(15);
                console.log("Your promo code is :" + this.code);
                console.log("Don't give it away!");
            } else {
                console.log("You don't have enough currency");
            }
        };
        GM.code = "";
        return GM;
    })();
    _GM.GM = GM;
})(GM || (GM = {}));
//# sourceMappingURL=GM.js.map
