namespace ts {
  export class Apparel {
    id: string;
    basicName: string;
    apparelSlot: enums.ApparelSlot;
    color: string;
    pattern: string;
    material: string;
    integrity: number;
    bodyCoverages: Set<enums.BodyCoverage>;

    constructor(
      id: string,
      basicName: string,
      apparelSlot: enums.ApparelSlot,
      color: string,
      pattern: string,
      material: string,
      integrity: number
    ) {
      this.id = id;
      this.basicName = basicName;
      this.apparelSlot = apparelSlot;
      this.color = color;
      this.pattern = pattern;
      this.material = material;
      this.integrity = integrity;
      this.bodyCoverages = new Set<enums.BodyCoverage>();
    }
  }
}