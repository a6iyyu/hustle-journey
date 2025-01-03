import { Character } from "./classes/Character";
import { SexType } from "./enums/SexType";

const playerCharacter = new Character("1", "Alan", "Kuproy", SexType.Masculine, 18, 2, 2);
(window as any).playerCharacter = playerCharacter;

