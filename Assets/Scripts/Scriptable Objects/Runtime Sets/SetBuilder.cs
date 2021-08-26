using System;
using UnityEditor;
using UnityEngine;

public class SetBuilder : MonoBehaviour
{
    public QuickButton createAsset = new QuickButton("CreateRuntimeAsset");
    [SerializeField]
    private object _setToCreate;

    // Edit this script as needed to create new kinds of Runtime Set assets.  
    private void CreateRuntimeSetAsset()
    {
        PanelRuntimeSet runtimeSet = ScriptableObject.CreateInstance<PanelRuntimeSet>();
        // Remember to change the file name of the saved asset.
        AssetDatabase.CreateAsset(runtimeSet, "Assets/Scripts/Scriptable Objects/Runtime Sets/PanelRuntimeSet.asset");
    }
}
