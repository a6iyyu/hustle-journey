import { Need } from "./Need";
import { Skill } from "./Skill";
import { SexType } from "../enums/SexType";
import { Apparel } from "./Apparel";
import { ApparelSlot } from "../enums/ApparelSlot";
import { Magnitude } from "./Magnitude";

export class Character {
  // main attributes
  id: string;
  forename: string | null;
  surname: string;

  // appearance magnitude
  sexType: SexType;
  intAge: number;
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
    this.intAge = intAge;
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

  get sexToAgeDescriptor(): string {
    if (this.sexType === SexType.Masculine) {
      return this.intAge <= 21 ? "Boy" : "Man";
    } else if (this.sexType === SexType.Feminime) {
      return this.intAge <= 21 ? "Girl" : "Woman";
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

  writeIntoJSONFile(): void {
    const jsonString = JSON.stringify(this);
    console.log("Character JSON:", jsonString);
  }
}
