export class Physique{
    private _fat:number;
    private _muscle:number;
    _bodytypes = [
        ["Emaciated", "Thin", "Lean", "Toned", "Defined", "Sculpted", "Ripped"],
        ["Gaunt", "Slender", "Slim", "Fit", "Taut", "Cut", "Shredded"],
        ["Underweight", "Svelte", "Lithe", "Athletic", "Muscular", "Built", "Solid"],
        ["Average", "Wiry", "Balanced", "Stocky", "Husky", "Buff", "Hefty"],
        ["Soft", "Slightly Firm", "Firm", "Bulky", "Strong", "Burly", "Massive"],
        ["Pudgy", "Chubby", "Stout", "Robust", "Thick", "Powerhouse", "Brawny"],
        ["Overweight", "Portly", "Heavyset", "Large", "Hulking", "Gargantuan", "Herculean"],
    ];

    constructor(fat: number, muscle: number) {
        this._fat = Math.max(0, Math.min(6, fat));
        this._muscle = Math.max(0, Math.min(6, muscle));
    }
    get physique(): string {
        return this._bodytypes[this._fat][this._muscle];
    }

    set fat(value: number) {
        this._fat = Math.max(0, Math.min(6, value));
    }

    set muscle(value: number) {
        this._muscle = Math.max(0, Math.min(6, value));
    }

    get fat(): number {
        return this._fat;
    }

    get muscle(): number {
        return this._muscle;
    }
}