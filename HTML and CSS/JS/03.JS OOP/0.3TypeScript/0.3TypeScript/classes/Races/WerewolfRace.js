var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Races;
(function (Races) {
    var WerewolfRace = (function (_super) {
        __extends(WerewolfRace, _super);
        function WerewolfRace() {
            _super.call(this, "Demon Werewolf", 3 /* Werewolf */, 2, 2, 0, 0, 0, 0);
        }
        return WerewolfRace;
    })(Races.Race);
    Races.WerewolfRace = WerewolfRace;
})(Races || (Races = {}));
//# sourceMappingURL=WerewolfRace.js.map
