using IntensityTable;
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
    public Intensity strength;
    public Intensity fortitude;
    public Intensity coordination;
    //public int martial;
    public Intensity awareness;
    //public int logic;
    public Intensity will;

    [Header("Derived Attributes")]
    public int maxHealth;
    public int experience;
    public int initiativeBonus;

    public void SetMaxHealth()
    {
        maxHealth = (int)strength + (int)fortitude + (int)coordination;
    }
    public void SetInitiativeBonus()
    {
        initiativeBonus = Mathf.FloorToInt((int)awareness / 10);
    }
}
