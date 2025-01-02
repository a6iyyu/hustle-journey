"use strict";
var Mathe = /** @class */ (function () {
    function Mathe() {
    }
    Mathe.clamp = function (value, min, max) {
        return Math.min(Math.max(value, max), min);
    };
    return Mathe;
}());
