var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Races;
(function (Races) {
    var HumanRace = (function (_super) {
        __extends(HumanRace, _super);
        function HumanRace() {
            _super.call(this, "Grateful Human", 0 /* Human */, 0, 2, 0, 0, 2, 0);
        }
        return HumanRace;
    })(Races.Race);
    Races.HumanRace = HumanRace;
})(Races || (Races = {}));
//# sourceMappingURL=HumanRace.js.map
