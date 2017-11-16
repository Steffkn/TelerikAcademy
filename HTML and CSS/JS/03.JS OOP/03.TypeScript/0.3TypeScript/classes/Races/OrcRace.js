var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Races;
(function (Races) {
    var OrcRace = (function (_super) {
        __extends(OrcRace, _super);
        function OrcRace() {
            _super.call(this, "Savage Orc", 2 /* Orc */, 2, 0, 2, 0, 0, 0);
        }
        return OrcRace;
    })(Races.Race);
    Races.OrcRace = OrcRace;
})(Races || (Races = {}));
//# sourceMappingURL=OrcRace.js.map
