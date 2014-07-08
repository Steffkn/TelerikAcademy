var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Races;
(function (Races) {
    var ElfRace = (function (_super) {
        __extends(ElfRace, _super);
        function ElfRace() {
            _super.call(this, "Wild Elf", 1 /* Elf */, 0, 0, 2, 2, 0, 0);
        }
        return ElfRace;
    })(Races.Race);
    Races.ElfRace = ElfRace;
})(Races || (Races = {}));
//# sourceMappingURL=ElfRace.js.map
