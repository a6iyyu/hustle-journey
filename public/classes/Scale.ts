namespace model{
    export class Scale{
        private _scale: number = 1;
        private readonly min: number = 1;
        private readonly max: number = 20;
        constructor(scale: number = 1){
            this._scale = Math.max(this.min, Math.min(this.max, scale));
        }
        get scale(): number{
            return this._scale;
        }
        set scale(value: number){
            this._scale = Math.max(this.min, Math.min(this.max, value));
        }
    }
}