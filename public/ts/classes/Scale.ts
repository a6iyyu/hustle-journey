export class Scale {
  private _scale: number = 1;
  private readonly min: number = 1;
  constructor(value: number = 1) {
    this._scale = Math.min(this.min, value);
  }
  get value(): number {
    return this._scale;
  }
  set value(value: number) {
    this._scale = Math.min(this.min, value);
  }
}
