import { Need } from "./Need";
export class Magnitude extends Need {
  private _magnitude: number = 1;
  get magnitude(): number {
    return this._magnitude;
  }
  set magnitude(value: number) {
    this._magnitude = Math.max(this._min, Math.min(this._max, value));
  }
}
