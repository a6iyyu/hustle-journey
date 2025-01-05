import { IClass } from './IClass';
export class Need implements IClass {
  private _value: number = 100;
  protected readonly _min: number = 0;
  protected readonly _max: number = 100;
  constructor(need: number = 100) {
    this._value = Math.max(this._min, Math.min(this._max, need));
  }
  get value(): number {
    return this._value;
  }
  set value(value: number) {
    this._value = Math.max(this._min, Math.min(this._max, value));
  }
  clone()
  {
    return new Need(this._value);
  }
}
