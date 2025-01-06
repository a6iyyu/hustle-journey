import { Character } from "../classes/Character";
import { Physique } from "../classes/Physique";
import { SexType } from "../enums/SexType";

export class RandomGenerator {
    private static maleForenames: string[] = [
        "James", "John", "Robert", "Michael", "William",
        "David", "Joseph", "Thomas", "Charles", "Christopher",
        "Daniel", "Matthew", "Anthony", "Mark", "Donald",
        "Steven", "Paul", "Andrew", "Joshua", "Kenneth",
        "Kevin", "Brian", "George", "Edward", "Ronald",
        "Timothy", "Jason", "Jeffrey", "Ryan", "Jacob"
    ];

    private static femaleForenames: string[] = [
        "Emma", "Olivia", "Ava", "Isabella", "Sophia",
        "Mia", "Charlotte", "Amelia", "Harper", "Evelyn",
        "Abigail", "Emily", "Lily", "Madison", "Victoria",
        "Jessica", "Samantha", "Avery", "Riley", "Zoey",
        "Natalie", "Grace", "Hannah", "Elizabeth", "Taylor",
        "Kayla", "Hailey", "Jasmine", "Julia", "Sydney"
    ];

    private static surnames: string[] = [
        "Smith", "Johnson", "Williams", "Brown", "Jones",
        "Davis", "Miller", "Wilson", "Moore", "Taylor",
        "Anderson", "Thomas", "Jackson", "White", "Harris",
        "Martin", "Thompson", "Garcia", "Martinez", "Robinson",
        "Clark", "Rodriguez", "Lewis", "Lee", "Walker",
        "Hall", "Allen", "Young", "Hernandez", "King"
    ];

    private static getRandomElement<T>(array: T[]): T {
        const index = Math.floor(Math.random() * array.length);
        return array[index];
    }

    public static generateMaleForename(): string {
        return this.getRandomElement(this.maleForenames);
    }

    public static generateFemaleForename(): string {
        return this.getRandomElement(this.femaleForenames);
    }

    public static generateSurname(): string {
        return this.getRandomElement(this.surnames);
    }

    public static generateSexType(): SexType {
        return Math.random() < 0.5 ? SexType.Masculine : SexType.Feminime;
    }

    public static generateIntAge(): number {
        return Math.floor(Math.random() * (23 - 17)) + 17;
    }

    public static generatePhysique(): Physique {
        return new Physique(Math.floor(Math.random() * 7), Math.floor(Math.random() * 7));
    }
    public static generateCharacterId(): string {
        return crypto.randomUUID().toString();
    }

    public static generateCharacter(): Character {
        const sexType = this.generateSexType();
        const forename = sexType === SexType.Masculine
            ? this.generateMaleForename()
            : this.generateFemaleForename();

        return new Character(this.generateCharacterId(), forename, this.generateSurname(), sexType, this.generateIntAge(), this.generatePhysique());
    }
}
