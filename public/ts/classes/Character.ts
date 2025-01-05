import { Need } from "./Need";
import { Skill } from "./Skill";
import { SexType } from "../enums/SexType";
import { Apparel } from "./Apparel";
import { ApparelSlot } from "../enums/ApparelSlot";
import { Magnitude } from "./Magnitude";
import { IClass } from "./IClass";

export class Character implements IClass {
  // main attributes
  id: string;
  forename: string | null;
  surname: string;

  // appearance magnitude
  sexType: SexType;
  age: number;
  fat: Magnitude;
  muscle: Magnitude;

  // equipped apparels
  EquippedApparels: Map<ApparelSlot, Apparel[]>;

  // needs
  rest: Need;
  painlessness: Need;
  satiety: Need;
  comfort: Need;
  entertainment: Need;
  social: Need;
  hygiene: Need;

  // skills
  charisma: Skill;

  constructor(
    id: string = "",
    forename: string | null = null,
    surname: string = "",
    sexType: SexType = SexType.Masculine,
    intAge: number = 18,
    fat: Magnitude = new Magnitude(2),
    muscle: Magnitude = new Magnitude(2),
    rest: Need = new Need(100),
    painlessness: Need = new Need(100),
    satiety: Need = new Need(100),
    comfort: Need = new Need(100),
    entertainment: Need = new Need(100),
    social: Need = new Need(100),
    hygiene: Need = new Need(100),
    charisma: Skill = new Skill(1)
  ) {
    this.id = id;
    this.forename = forename;
    this.surname = surname;
    this.sexType = sexType;
    this.age = intAge;
    this.fat = fat;
    this.muscle = muscle;
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
  // prettier-ignore
  get physique(): string {
      const bodyTypes = [
        ["Emaciated", "Thin", "Lean", "Toned", "Defined", "Sculpted", "Ripped"],
        ["Gaunt", "Slender", "Slim", "Fit", "Taut", "Cut", "Shredded"],
        ["Underweight", "Svelte", "Lithe", "Athletic", "Muscular", "Built", "Solid"],
        ["Average", "Wiry", "Balanced", "Stocky", "Husky", "Buff", "Hefty"],
        ["Soft", "Slightly Firm", "Firm", "Bulky", "Strong", "Burly", "Massive"],
        ["Pudgy", "Chubby", "Stout", "Robust", "Thick", "Powerhouse", "Brawny"],
        ["Overweight", "Portly", "Heavyset", "Large", "Hulking", "Gargantuan", "Herculean"],
      ];
      return bodyTypes[Math.min(this.fat.value, 6)][Math.min(this.muscle.value, 6)];
    }

  get ageDescriptor(): string {
    if (this.age < 17) return "teenage";
    if (this.age < 21) return "grown-up";
    if (this.age < 24) return "early-twenties";
    if (this.age < 27) return "mid-twenties";
    if (this.age < 30) return "late-twenties";
    if (this.age < 34) return "early-thirties";
    if (this.age < 37) return "mid-thirties";
    if (this.age < 40) return "late-thirties";
    return "fuzzy-aged";
  }

  get sexToAgeDescriptor(): string {
    if (this.sexType === SexType.Masculine) {
      return this.age <= 21 ? "Boy" : "Man";
    } else if (this.sexType === SexType.Feminime) {
      return this.age <= 21 ? "Girl" : "Woman";
    }
    return "Hermaphrodite";
  }

  equipApparel(apparel: Apparel): void {
    if (!this.EquippedApparels.has(apparel.apparelSlot)) {
      this.EquippedApparels.set(apparel.apparelSlot, []);
    }
    this.EquippedApparels.get(apparel.apparelSlot)!.push(apparel);
  }
  getApparelsByApparelSlot(apparelSlot: ApparelSlot): Apparel[] {
    return this.EquippedApparels.get(apparelSlot) || [];
  }

  getApparels(): Apparel[] {
    return Array.from(this.EquippedApparels.values()).flat();
  }

  describeCharacterInOneString(): string {
    return `A ${this.physique} ${this.ageDescriptor} ${this.sexToAgeDescriptor}`;
  }

  getCalling(): string {
    return this.forename ? `${this.forename} ${this.surname}` : this.surname;
  }

  clone() {
		// Return a new instance containing our own data.
		return new Character(
    this.id,
    this.forename,
    this.surname,
    this.sexType,
    this.age,
    this.fat,
    this.muscle,
    this.rest,
    this.painlessness,
    this.satiety,
    this.comfort,
    this.entertainment,
    this.social,
    this.hygiene,
    this.charisma
		);
	}
}
