import { Character } from "../classes/Character";

export class CharacterCollection {
    private _characters: Map<string, Character>;
    constructor(map: Map<string, Character> = new Map()) {
        this._characters = map;
    }

    get characters(): Map<string, Character> {
        return this._characters;
    }

    getCharacter(id: string): Character | undefined {
        return this._characters.get(id);
    }
}