export class Skill {
  private _skill: number = 1;
  private readonly min: number = 1;
  private readonly max: number = 20;
  constructor(skill: number = 1) {
    this._skill = Math.max(this.min, Math.min(this.max, skill));
  }
  get need(): number {
    return this._skill;
  }
  set need(value: number) {
    this._skill = Math.max(this.min, Math.min(this.max, value));
  }
}
