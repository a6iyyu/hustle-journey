import { ApparelSlot } from "../enums/ApparelSlot";
import { BodyCoverage } from "../enums/BodyCoverage";

export class Apparel {
  id: string;
  basicName: string;
  apparelSlot: ApparelSlot;
  color: string;
  pattern: string;
  material: string;
  integrity: number;
  bodyCoverages: Set<BodyCoverage>;

  constructor(
    id: string,
    basicName: string,
    apparelSlot: ApparelSlot,
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
    this.bodyCoverages = new Set<BodyCoverage>();
  }
}
