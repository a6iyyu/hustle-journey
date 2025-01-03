"use strict";
var model;
(function (model) {
    var Need = /** @class */ (function () {
        function Need(need) {
            if (need === void 0) { need = 100; }
            this._need = 100;
            this._min = 0;
            this._max = 100;
            this._need = Math.max(this._min, Math.min(this._max, need));
        }
        Object.defineProperty(Need.prototype, "need", {
            get: function () {
                return this._need;
            },
            set: function (value) {
                this._need = Math.max(this._min, Math.min(this._max, value));
            },
            enumerable: false,
            configurable: true
        });
        return Need;
    }());
    model.Need = Need;
})(model || (model = {}));
