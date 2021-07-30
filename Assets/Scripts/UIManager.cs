using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Action OnMoveSelect;
    public Action OnBreakSelect;
    public Action OnSaveSelect;

    public void MoveFeatButton()
    {
        Debug.Log("Move button clicked");
        OnMoveSelect?.Invoke();
    }

    public void BreakFeatButton()
    {
        OnBreakSelect?.Invoke();
    }

    public void SaveFeatButton()
    {
        OnSaveSelect?.Invoke();
    }

}
