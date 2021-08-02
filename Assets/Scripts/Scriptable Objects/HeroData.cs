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
    public int strength;
    public int fortitude;
    public int coordination;
    //public int martial;
    public int awareness;
    //public int logic;
    public int will;

    [Header("Derived Attributes")]
    public int maxHealth;
    public int currentHealth;
    public int experience;
    public int initiativeBonus;
}
