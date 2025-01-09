import { Need } from "./Need";
import { Skill } from "./Skill";
import { SexType } from "../enums/SexType";
import { Apparel } from "./Apparel";
import { ApparelSlot } from "../enums/ApparelSlot";
import { IClass } from "./IClass";
import { RandomGenerator } from "../tools/RandomGenerator";
import { Physique } from "./Physique";

export class Character implements IClass {
  // Main Attributes
  id: string;
  forename: string | null;
  surname: string;

  // Appearance Magnitude
  sexType: SexType;
  age: number;
  physique: Physique;

  // Equipped Apparels
  EquippedApparels: Map<ApparelSlot, Apparel[]>;

  // Needs
  rest: Need;
  painlessness: Need;
  satiety: Need;
  comfort: Need;
  entertainment: Need;
  social: Need;
  hygiene: Need;

  // Skills
  charisma: Skill;

  constructor(
    id: string = "default value",
    forename: string | null = "Hans",
    surname: string = "Laneway",
    sexType: SexType = SexType.Masculine,
    age: number = 18,
    physique: Physique = new Physique(3, 3),
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
    this.age = age;
    this.physique = physique;
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

  static randomizeProperties(): Character {
    const newCharacter = RandomGenerator.generateCharacter();
    return newCharacter;
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
    let calling: string;
    if (this.forename) {
      calling = this.forename;
    } else {
      calling = this.surname;
    }
    return calling;
  }

  clone() {
    // Return a new instance containing our own data.
    return new Character(
      this.id,
      this.forename,
      this.surname,
      this.sexType,
      this.age,
      this.physique,
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

  toJSON() {
    let code: string =
      "new Character(" +
      JSON.stringify(this.id) +
      "," +
      JSON.stringify(this.forename) +
      "," +
      JSON.stringify(this.surname) +
      "," +
      JSON.stringify(this.sexType) +
      "," +
      JSON.stringify(this.age) +
      "," +
      JSON.stringify(this.physique) +
      "," +
      JSON.stringify(this.rest) +
      "," +
      JSON.stringify(this.painlessness) +
      "," +
      JSON.stringify(this.satiety) +
      "," +
      JSON.stringify(this.comfort) +
      "," +
      JSON.stringify(this.entertainment) +
      "," +
      JSON.stringify(this.social) +
      "," +
      JSON.stringify(this.hygiene) +
      "," +
      JSON.stringify(this.charisma) +
      ")";
    // return Serial.createReviver(code);
  }
}