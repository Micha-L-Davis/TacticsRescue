using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hero Data", menuName = "HeroData")]
public class HeroData : ScriptableObject
{
    public string heroName;
    public enum HeroicOrigin { Physical,Mental };
    public HeroicOrigin heroicOrigin;
    [Header("Attributes")]
    public IntensityTable.Intensity strength;
    public IntensityTable.Intensity fortitude;
    public IntensityTable.Intensity coordination;
    //public int martial;
    public IntensityTable.Intensity awareness;
    //public int logic;
    public IntensityTable.Intensity will;

    [Header("Derived Attributes")]
    public int maxHealth;
    public int currentHealth;
    public int experience;
    public int initiativeBonus;

    
}
