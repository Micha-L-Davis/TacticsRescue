using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Feat")]
public class FeatVariable : ScriptableObject
{
    public IFeat Value;

    public void SetValue(IFeat value)
    {
        Value = value;
    }
}
