// npm run bundle
// di atas untuk bundle TS ke bundle.js

import { Character } from './classes/Character';
import { Physique } from './classes/Physique';
import { CharacterCollection } from './collections/CharacterCollection';
import { SexType } from "./enums/SexType";

// import styles
(window as any).link = document.createElement("link");
(window as any).link.rel = "stylesheet";
(window as any).href = "public/styles/stylesheet.css";
document.head.appendChild((window as any).link);

// instanciate new object here
const playerCharacter = new Character(
  "1",
  "Alan",
  "Kuproy",
  SexType.Masculine,
  18,
  new Physique(3, 3)
);
const characters = new Map<string, Character>;
const characterCollection = new CharacterCollection();


// send the reference to `window` object (bawaan sugarcube)
(window as any).playerCharacter = playerCharacter;
(window as any).Character = Character;
(window as any).SexType = SexType;
(window as any).characterCollection = characterCollection;
