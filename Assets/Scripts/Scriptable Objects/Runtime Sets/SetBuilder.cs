using UnityEditor;
using UnityEngine;

public class SetBuilder : MonoBehaviour
{
    private void Start()
    {
        InitiativeRuntimeSet runtimeSet = ScriptableObject.CreateInstance<InitiativeRuntimeSet>();
        AssetDatabase.CreateAsset(runtimeSet, "Assets/Scripts/Scriptable Objects/Runtime Sets/InitiativeRuntimeSet.asset");
    }
}
