namespace model {
  export class Need {
    private _need: number = 100;
    protected readonly _min: number = 0;
    protected readonly _max: number = 100;
    constructor(need: number = 100) {
      this._need = Math.max(this._min, Math.min(this._max, need));
    }
    get need(): number {
      return this._need;
    }
    set need(value: number) {
      this._need = Math.max(this._min, Math.min(this._max, value));
    }
  }
}
