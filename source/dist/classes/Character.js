"use strict";
var model;
(function (model) {
    var Character = /** @class */ (function () {
        function Character(id, forename, surname, sexType, intAge, fat, muscle, rest, painlessness, satiety, comfort, entertainment, social, hygiene, charisma) {
            if (id === void 0) { id = ""; }
            if (forename === void 0) { forename = null; }
            if (surname === void 0) { surname = ""; }
            if (sexType === void 0) { sexType = enums.SexType.Masculine; }
            if (intAge === void 0) { intAge = 18; }
            if (fat === void 0) { fat = 0; }
            if (muscle === void 0) { muscle = 0; }
            if (rest === void 0) { rest = new model.Need(100); }
            if (painlessness === void 0) { painlessness = new model.Need(100); }
            if (satiety === void 0) { satiety = new model.Need(100); }
            if (comfort === void 0) { comfort = new model.Need(100); }
            if (entertainment === void 0) { entertainment = new model.Need(100); }
            if (social === void 0) { social = new model.Need(100); }
            if (hygiene === void 0) { hygiene = new model.Need(100); }
            if (charisma === void 0) { charisma = new model.Skill(1); }
            this.id = id;
            this.forename = forename;
            this.surname = surname;
            this.sexType = sexType;
            this.intAge = intAge;
            this._fat = Math.min(Math.max(fat, 0), 6);
            this._muscle = Math.min(Math.max(muscle, 0), 6);
            this.EquippedApparels = new Map();
            this.rest = rest;
            this.painlessness = painlessness;
            this.satiety = satiety;
            this.comfort = comfort;
            this.entertainment = entertainment;
            this.social = social;
            this.hygiene = hygiene;
            this.charisma = charisma;
        }
        Object.defineProperty(Character.prototype, "fat", {
            get: function () {
                return this._fat;
            },
            set: function (value) {
                this._fat = Mathe.clamp(value, 0, 6);
            },
            enumerable: false,
            configurable: true
        });
        Object.defineProperty(Character.prototype, "muscle", {
            get: function () {
                return this._muscle;
            },
            set: function (value) {
                this._muscle = Mathe.clamp(value, 0, 6);
            },
            enumerable: false,
            configurable: true
        });
        Object.defineProperty(Character.prototype, "physique", {
            // prettier-ignore
            get: function () {
                var bodyTypes = [
                    ["Emaciated", "Thin", "Lean", "Toned", "Defined", "Sculpted", "Ripped"],
                    ["Gaunt", "Slender", "Slim", "Fit", "Taut", "Cut", "Shredded"],
                    ["Underweight", "Svelte", "Lithe", "Athletic", "Muscular", "Built", "Solid"],
                    ["Average", "Wiry", "Balanced", "Stocky", "Husky", "Buff", "Hefty"],
                    ["Soft", "Slightly Firm", "Firm", "Bulky", "Strong", "Burly", "Massive"],
                    ["Pudgy", "Chubby", "Stout", "Robust", "Thick", "Powerhouse", "Brawny"],
                    ["Overweight", "Portly", "Heavyset", "Large", "Hulking", "Gargantuan", "Herculean"],
                ];
                return bodyTypes[Math.min(this.fat, 6)][Math.min(this.muscle, 6)];
            },
            enumerable: false,
            configurable: true
        });
        Object.defineProperty(Character.prototype, "ageDescriptor", {
            get: function () {
                if (this.intAge < 17)
                    return "teenage";
                if (this.intAge < 21)
                    return "grown-up";
                if (this.intAge < 24)
                    return "early-twenties";
                if (this.intAge < 27)
                    return "mid-twenties";
                if (this.intAge < 30)
                    return "late-twenties";
                if (this.intAge < 34)
                    return "early-thirties";
                if (this.intAge < 37)
                    return "mid-thirties";
                if (this.intAge < 40)
                    return "late-thirties";
                return "fuzzy-aged";
            },
            enumerable: false,
            configurable: true
        });
        Object.defineProperty(Character.prototype, "sexToAgeDescriptor", {
            get: function () {
                if (this.sexType === enums.SexType.Masculine) {
                    return this.intAge <= 21 ? "Boy" : "Man";
                }
                else if (this.sexType === enums.SexType.Feminime) {
                    return this.intAge <= 21 ? "Girl" : "Woman";
                }
                return "Hermaphrodite";
            },
            enumerable: false,
            configurable: true
        });
        Character.prototype.equipApparel = function (apparel) {
            if (!this.EquippedApparels.has(apparel.apparelSlot)) {
                this.EquippedApparels.set(apparel.apparelSlot, []);
            }
            this.EquippedApparels.get(apparel.apparelSlot).push(apparel);
        };
        Character.prototype.getApparelsByApparelSlot = function (apparelSlot) {
            return this.EquippedApparels.get(apparelSlot) || [];
        };
        Character.prototype.getApparels = function () {
            return Array.from(this.EquippedApparels.values()).flat();
        };
        Character.prototype.describeCharacterInOneString = function () {
            return "A ".concat(this.physique, " ").concat(this.ageDescriptor, " ").concat(this.sexToAgeDescriptor);
        };
        Character.prototype.getCalling = function () {
            return this.forename ? "".concat(this.forename, " ").concat(this.surname) : this.surname;
        };
        Character.prototype.writeIntoJSONFile = function () {
            var jsonString = JSON.stringify(this);
            console.log("Character JSON:", jsonString);
        };
        return Character;
    }());
    model.Character = Character;
})(model || (model = {}));
