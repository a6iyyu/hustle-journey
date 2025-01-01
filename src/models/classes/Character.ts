enum SexType {
  Masculine,
  Feminime,
  Hermaphrodite,
}

enum ApparelSlot {
  Head,
  Body,
  Legs,
  Feet,
}
namespace model {
  export class Character {
    id: string;
    forename: string | null;
    surname: string;
    sexType: SexType;
    intAge: number;
    private _fat: number;
    private _muscle: number;
    EquippedApparels: Map<ApparelSlot, Apparel[]>;

    constructor(
      id: string = "",
      forename: string | null = null,
      surname: string = "",
      sexType: SexType = SexType.Masculine,
      intAge: number = 18,
      fat: number = 0,
      muscle: number = 0
    ) {
      this.id = id;
      this.forename = forename;
      this.surname = surname;
      this.sexType = sexType;
      this.intAge = intAge;
      this.fat = Math.min(Math.max(fat, 0), 6);
      this._muscle = Math.min(Math.max(muscle, 0), 6);
      this.EquippedApparels = new Map();
    }

    get fat(): number {
      return this.fat;
    }

    set fat(value: number) {
      this.fat = Math.min(Math.max(value, 0), 6);
    }

    get muscle(): number {
      return this._muscle;
    }

    set muscle(value: number) {
      this._muscle = Math.min(Math.max(value, 0), 6);
    }

    get physique(): string {
      const bodyTypes = [
        ["Emaciated", "Thin", "Lean", "Toned", "Defined", "Sculpted", "Ripped"],
        ["Gaunt", "Slender", "Slim", "Fit", "Taut", "Cut", "Shredded"],
        [
          "Underweight",
          "Svelte",
          "Lithe",
          "Athletic",
          "Muscular",
          "Built",
          "Solid",
        ],
        ["Average", "Wiry", "Balanced", "Stocky", "Husky", "Buff", "Hefty"],
        [
          "Soft",
          "Slightly Firm",
          "Firm",
          "Bulky",
          "Strong",
          "Burly",
          "Massive",
        ],
        ["Pudgy", "Chubby", "Stout", "Robust", "Thick", "Powerhouse", "Brawny"],
        [
          "Overweight",
          "Portly",
          "Heavyset",
          "Large",
          "Hulking",
          "Gargantuan",
          "Herculean",
        ],
      ];
      return bodyTypes[Math.min(this.fat, 6)][Math.min(this.muscle, 6)];
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

    printCoveredBodyPart(): string {
      const coveredParts = new Set<BodyCoverage>();
      this.EquippedApparels.forEach((apparels) =>
        apparels.forEach((apparel) =>
          apparel.bodyCoverages.forEach((coverage) =>
            coveredParts.add(coverage)
          )
        )
      );
      return Array.from(coveredParts).join(", ");
    }

    getCoveredBodyPart(): BodyCoverage[] {
      const coveredParts = new Set<BodyCoverage>();
      this.EquippedApparels.forEach((apparels) =>
        apparels.forEach((apparel) =>
          apparel.bodyCoverages.forEach((coverage) =>
            coveredParts.add(coverage)
          )
        )
      );
      return Array.from(coveredParts);
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
      // Save to file using Node.js if needed
    }
  }
}
