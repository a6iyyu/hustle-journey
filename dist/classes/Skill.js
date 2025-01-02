"use strict";
var model;
(function (model) {
    var Skill = /** @class */ (function () {
        function Skill(skill) {
            if (skill === void 0) { skill = 1; }
            this._skill = 1;
            this.min = 1;
            this.max = 20;
            this._skill = Math.max(this.min, Math.min(this.max, skill));
        }
        Object.defineProperty(Skill.prototype, "need", {
            get: function () {
                return this._skill;
            },
            set: function (value) {
                this._skill = Math.max(this.min, Math.min(this.max, value));
            },
            enumerable: false,
            configurable: true
        });
        return Skill;
    }());
    model.Skill = Skill;
})(model || (model = {}));
