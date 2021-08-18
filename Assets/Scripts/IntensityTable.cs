using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IntensityTable
{
    public enum Intensity
    {
        Incapable = 0,
        Weak = 2,
        Minimal = 4,
        Average = 6,
        Competent = 10,
        Exceptional = 20,
        Supremal = 30,
        Fantastic = 40,
        Legendary = 50,
        Colossal = 75,
        Deific = 100,
        Unreal = 150,
        Impossible = 200,
        Transcendant = 500,
        Ineffable = 1000
    }

    public enum Outcome
    {
        Fail,
        Low,
        Medium,
        High
    }
    public class Dice
    {
        public static Outcome Roll(Intensity intensity)
        {
            int roll = Random.Range(1, 101);
            Debug.Log( "Action Roll: " + roll);
            Outcome outcome = Outcome.Fail;
            switch (intensity)
            {
                case Intensity.Incapable:
                    if (roll <= 65) { outcome = Outcome.Fail; }
                    if (roll >= 66 && roll <= 94) { outcome = Outcome.Low; }
                    if (roll >= 95 && roll <= 99) { outcome = Outcome.Medium; } 
                    if (roll == 100) { outcome = Outcome.High; }
                    break;
                case Intensity.Weak:
                    if (roll <= 60) { outcome = Outcome.Fail; }
                    if (roll >= 61 && roll <= 90) { outcome = Outcome.Low; }
                    if (roll >= 91 && roll <= 99) { outcome = Outcome.Medium; }
                    if (roll == 100) { outcome = Outcome.High; }
                    break;
                case Intensity.Minimal:
                    if (roll <= 55) { outcome = Outcome.Fail; }
                    if (roll >= 56 && roll <= 85) { outcome = Outcome.Low; }
                    if (roll >= 86 && roll <= 99) { outcome = Outcome.Medium; }
                    if (roll == 100) { outcome = Outcome.High; }
                    break;
                case Intensity.Average:
                    if (roll <= 50) { outcome = Outcome.Fail; }
                    if (roll >= 51 && roll <= 80) { outcome = Outcome.Low; }
                    if (roll >= 81 && roll <= 97) { outcome = Outcome.Medium; }
                    if (roll >= 98 && roll <= 100) { outcome = Outcome.High; }
                    break;
                case Intensity.Competent:
                    if (roll <= 45) { outcome = Outcome.Fail; }
                    if (roll >= 46 && roll <= 75) { outcome = Outcome.Low; }
                    if (roll >= 76 && roll <= 97) { outcome = Outcome.Medium; }
                    if (roll >= 98 && roll <= 100) { outcome = Outcome.High; }
                    break;
                case Intensity.Exceptional:
                    if (roll <= 40) { outcome = Outcome.Fail; }
                    if (roll >= 41 && roll <= 70) { outcome = Outcome.Low; }
                    if (roll >= 71 && roll <= 94) { outcome = Outcome.Medium; }
                    if (roll >= 95 && roll <= 100) { outcome = Outcome.High; }
                    break;
                case Intensity.Supremal:
                    if (roll <= 35) { outcome = Outcome.Fail; }
                    if (roll >= 36 && roll <= 65) { outcome = Outcome.Low; }
                    if (roll >= 66 && roll <= 94) { outcome = Outcome.Medium; }
                    if (roll >= 95 && roll <= 100) { outcome = Outcome.High; }
                    break;
                case Intensity.Fantastic:
                    if (roll <= 30) { outcome = Outcome.Fail; }
                    if (roll >= 31 && roll <= 60) { outcome = Outcome.Low; }
                    if (roll >= 61 && roll <= 90) { outcome = Outcome.Medium; }
                    if (roll >= 91 && roll <= 100) { outcome = Outcome.High; }
                    break;
                case Intensity.Legendary:
                    if (roll <= 25) { outcome = Outcome.Fail; }
                    if (roll >= 26 && roll <= 55) { outcome = Outcome.Low; }
                    if (roll >= 56 && roll <= 90) { outcome = Outcome.Medium; }
                    if (roll >= 91 && roll <= 100) { outcome = Outcome.High; }
                    break;
                case Intensity.Colossal:
                    if (roll <= 20) { outcome = Outcome.Fail; }
                    if (roll >= 21 && roll <= 50) { outcome = Outcome.Low; }
                    if (roll >= 51 && roll <= 85) { outcome = Outcome.Medium; }
                    if (roll >= 86 && roll <= 100) { outcome = Outcome.High; }
                    break;
                case Intensity.Deific:
                    if (roll <= 15) { outcome = Outcome.Fail; }
                    if (roll >= 16 && roll <= 45) { outcome = Outcome.Low; }
                    if (roll >= 46 && roll <= 85) { outcome = Outcome.Medium; }
                    if (roll >= 86 && roll <= 100) { outcome = Outcome.High; }
                    break;
                case Intensity.Unreal:
                    if (roll <= 10) { outcome = Outcome.Fail; }
                    if (roll >= 11 && roll <= 40) { outcome = Outcome.Low; }
                    if (roll >= 41 && roll <= 80) { outcome = Outcome.Medium; }
                    if (roll >= 81 && roll <= 100) { outcome = Outcome.High; }
                    break;
                case Intensity.Impossible:
                    if (roll <= 6) { outcome = Outcome.Fail; }
                    if (roll >= 7 && roll <= 40) { outcome = Outcome.Low; }
                    if (roll >= 41 && roll <= 80) { outcome = Outcome.Medium; }
                    if (roll >= 81 && roll <= 100) { outcome = Outcome.High; }
                    break;
                case Intensity.Transcendant:
                    if (roll <= 3) { outcome = Outcome.Fail; }
                    if (roll >= 4 && roll <= 35) { outcome = Outcome.Low; }
                    if (roll >= 36 && roll <= 75) { outcome = Outcome.Medium; }
                    if (roll >= 76 && roll <= 100) { outcome = Outcome.High; }
                    break;
                case Intensity.Ineffable:

                    break;
                default:
                    break;
            }
            Debug.Log("Outcome: " + outcome);
            return outcome;
        }
    }
    
}
