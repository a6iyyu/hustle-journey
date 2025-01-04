
export class Magnitude{
  private _magnitude: number = 1;
  private readonly _min: number = 0; 
  private readonly _max: number = 6;
  constructor(magnitude: number = 1) {
    this._magnitude = Math.max(this._min, Math.min(this._max, magnitude));
  }
  get value(): number {
    return this._magnitude;
  }
  set value(value: number) {
    this._magnitude = Math.max(this._min, Math.min(this._max, value));
  }
}
