"use strict";
var Game = (() => {
  var __getOwnPropNames = Object.getOwnPropertyNames;
  var __esm = (fn, res) => function __init() {
    return fn && (res = (0, fn[__getOwnPropNames(fn)[0]])(fn = 0)), res;
  };
  var __commonJS = (cb, mod) => function __require() {
    return mod || (0, cb[__getOwnPropNames(cb)[0]])((mod = { exports: {} }).exports, mod), mod.exports;
  };

  // public/ts/classes/Need.ts
  var Need;
  var init_Need = __esm({
    "public/ts/classes/Need.ts"() {
      "use strict";
      Need = class {
        constructor(need = 100) {
          this._need = 100;
          this._min = 0;
          this._max = 100;
          this._need = Math.max(this._min, Math.min(this._max, need));
        }
        get need() {
          return this._need;
        }
        set need(value) {
          this._need = Math.max(this._min, Math.min(this._max, value));
        }
      };
    }
  });

  // public/ts/classes/Skill.ts
  var Skill;
  var init_Skill = __esm({
    "public/ts/classes/Skill.ts"() {
      "use strict";
      Skill = class {
        constructor(skill = 1) {
          this._skill = 1;
          this.min = 1;
          this.max = 20;
          this._skill = Math.max(this.min, Math.min(this.max, skill));
        }
        get need() {
          return this._skill;
        }
        set need(value) {
          this._skill = Math.max(this.min, Math.min(this.max, value));
        }
      };
    }
  });

  // public/ts/enums/SexType.ts
  var init_SexType = __esm({
    "public/ts/enums/SexType.ts"() {
      "use strict";
    }
  });

  // public/ts/classes/Character.ts
  var Character;
  var init_Character = __esm({
    "public/ts/classes/Character.ts"() {
      "use strict";
      init_Need();
      init_Skill();
      init_SexType();
      Character = class {
        constructor(id = "", forename = null, surname = "", sexType = 0 /* Masculine */, intAge = 18, fat = 0, muscle = 0, rest = new Need(100), painlessness = new Need(100), satiety = new Need(100), comfort = new Need(100), entertainment = new Need(100), social = new Need(100), hygiene = new Need(100), charisma = new Skill(1)) {
          this.id = id;
          this.forename = forename;
          this.surname = surname;
          this.sexType = sexType;
          this.intAge = intAge;
          this._fat = Math.min(Math.max(fat, 0), 6);
          this._muscle = Math.min(Math.max(muscle, 0), 6);
          this.EquippedApparels = /* @__PURE__ */ new Map();
          this.rest = rest;
          this.painlessness = painlessness;
          this.satiety = satiety;
          this.comfort = comfort;
          this.entertainment = entertainment;
          this.social = social;
          this.hygiene = hygiene;
          this.charisma = charisma;
        }
        get fat() {
          return this._fat;
        }
        set fat(value) {
          this._fat = Mathe.clamp(value, 0, 6);
        }
        get muscle() {
          return this._muscle;
        }
        set muscle(value) {
          this._muscle = Mathe.clamp(value, 0, 6);
        }
        // prettier-ignore
        get physique() {
          const bodyTypes = [
            ["Emaciated", "Thin", "Lean", "Toned", "Defined", "Sculpted", "Ripped"],
            ["Gaunt", "Slender", "Slim", "Fit", "Taut", "Cut", "Shredded"],
            ["Underweight", "Svelte", "Lithe", "Athletic", "Muscular", "Built", "Solid"],
            ["Average", "Wiry", "Balanced", "Stocky", "Husky", "Buff", "Hefty"],
            ["Soft", "Slightly Firm", "Firm", "Bulky", "Strong", "Burly", "Massive"],
            ["Pudgy", "Chubby", "Stout", "Robust", "Thick", "Powerhouse", "Brawny"],
            ["Overweight", "Portly", "Heavyset", "Large", "Hulking", "Gargantuan", "Herculean"]
          ];
          return bodyTypes[Math.min(this.fat, 6)][Math.min(this.muscle, 6)];
        }
        get ageDescriptor() {
          if (this.intAge < 17) return "teenage";
          if (this.intAge < 21) return "grown-up";
          if (this.intAge < 24) return "early-twenties";
          if (this.intAge < 27) return "mid-twenties";
          if (this.intAge < 30) return "late-twenties";
          if (this.intAge < 34) return "early-thirties";
          if (this.intAge < 37) return "mid-thirties";
          if (this.intAge < 40) return "late-thirties";
          return "fuzzy-aged";
        }
        get sexToAgeDescriptor() {
          if (this.sexType === 0 /* Masculine */) {
            return this.intAge <= 21 ? "Boy" : "Man";
          } else if (this.sexType === 1 /* Feminime */) {
            return this.intAge <= 21 ? "Girl" : "Woman";
          }
          return "Hermaphrodite";
        }
        equipApparel(apparel) {
          if (!this.EquippedApparels.has(apparel.apparelSlot)) {
            this.EquippedApparels.set(apparel.apparelSlot, []);
          }
          this.EquippedApparels.get(apparel.apparelSlot).push(apparel);
        }
        getApparelsByApparelSlot(apparelSlot) {
          return this.EquippedApparels.get(apparelSlot) || [];
        }
        getApparels() {
          return Array.from(this.EquippedApparels.values()).flat();
        }
        describeCharacterInOneString() {
          return `A ${this.physique} ${this.ageDescriptor} ${this.sexToAgeDescriptor}`;
        }
        getCalling() {
          return this.forename ? `${this.forename} ${this.surname}` : this.surname;
        }
        writeIntoJSONFile() {
          const jsonString = JSON.stringify(this);
          console.log("Character JSON:", jsonString);
        }
      };
    }
  });

  // public/ts/Main.ts
  var require_Main = __commonJS({
    "public/ts/Main.ts"() {
      init_Character();
      init_SexType();
      var playerCharacter = new Character("1", "Alan", "Kuproy", 0 /* Masculine */, 18, 2, 2);
      window.playerCharacter = playerCharacter;
    }
  });
  return require_Main();
})();
