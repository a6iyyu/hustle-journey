"use strict";
var model;
(function (model) {
    var Scale = /** @class */ (function () {
        function Scale(scale) {
            if (scale === void 0) { scale = 1; }
            this._scale = 1;
            this.min = 1;
            this.max = 20;
            this._scale = Math.max(this.min, Math.min(this.max, scale));
        }
        Object.defineProperty(Scale.prototype, "scale", {
            get: function () {
                return this._scale;
            },
            set: function (value) {
                this._scale = Math.max(this.min, Math.min(this.max, value));
            },
            enumerable: false,
            configurable: true
        });
        return Scale;
    }());
    model.Scale = Scale;
})(model || (model = {}));
