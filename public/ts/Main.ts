// npm run bundle
    // di atas untuk bundle TS ke bundle.js

import { Character } from "./classes/Character";
import { Magnitude } from "./classes/Magnitude";
import { SexType } from "./enums/SexType";

// import styles
const link : HTMLLinkElement = document.createElement("link");
link.rel = "stylesheet";
link.href = "/public/styles/stylesheet.css";
document.head.appendChild(link);

// instanciate new object here
const playerCharacter = new Character("1", "Alan", "Kuproy", SexType.Masculine, 18, new Magnitude(2), new Magnitude(2));

// send the reference to `window` object (bawaan sugarcube)
(window as any).playerCharacter = playerCharacter;


function createPlayerCharacter(id: string, forename: string, surname: string, sexType: SexType, intAge: number, fat: Magnitude, muscle: Magnitude) {
    let character= new Character(id, forename, surname, sexType, intAge, fat, muscle);
    (window as any).playerCharacter = character;
}