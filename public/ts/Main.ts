// npm run bundle
    // di atas untuk bundle TS ke bundle.js

import { Character } from "./classes/Character";
import { SexType } from "./enums/SexType";

// import styles
const link : HTMLLinkElement = document.createElement("link");
link.rel = "stylesheet";
link.href = "/public/styles/stylesheet.css";
document.head.appendChild(link);

// instanciate new object here
const playerCharacter = new Character("1", "Alan", "Kuproy", SexType.Masculine, 18, 2, 2);

// send the reference to `window` object (bawaan sugarcube)
(window as any).playerCharacter = playerCharacter;

