"use strict";
var ts;
(function (ts) {
    var Apparel = /** @class */ (function () {
        function Apparel(id, basicName, apparelSlot, color, pattern, material, integrity) {
            this.id = id;
            this.basicName = basicName;
            this.apparelSlot = apparelSlot;
            this.color = color;
            this.pattern = pattern;
            this.material = material;
            this.integrity = integrity;
            this.bodyCoverages = new Set();
        }
        return Apparel;
    }());
    ts.Apparel = Apparel;
})(ts || (ts = {}));
