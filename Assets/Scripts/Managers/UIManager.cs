using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    protected UIManager() {}

    public Action OnFirstFeatSelect;
    public Action OnSecondFeatSelect;
    public Action OnThirdFeatSelect;
    [SerializeField]
    List<Image> _initiativeRoster = new List<Image>();
    [SerializeField]
    List<TMP_Text> _initiativeText = new List<TMP_Text>();
    [SerializeField]
    GameObject _commandPanel;

    public void UpdateInitiativeRoster(LinkedList<KeyValuePair<Actor, int>> initList)
    {
        for (int i = _initiativeRoster.Count-1; i >= 0; i--)
        {
            var current = initList.Last;
            _initiativeRoster[i].sprite = current.Value.Key.portrait;
            _initiativeText[i].text = "" + current.Value.Value;
            initList.RemoveLast();
            initList.AddFirst(current);
        }



        //int i = _initiativeRoster.Count -1;               
        //foreach (KeyValuePair<Actor, int> actor in initList)
        //{
        //    if (i < 0)
        //    {
        //        break;
        //    }
        //    _initiativeRoster[i].sprite = actor.Key.portrait;
        //    _initiativeText[i].text = "" + actor.Value;
        //    i--;
        //}
    }

    public void MoveFeatButton()
    {
        Debug.Log("Move button clicked");
        OnFirstFeatSelect?.Invoke();
    }

    public void BreakFeatButton()
    {
        OnSecondFeatSelect?.Invoke();
    }

    public void SaveFeatButton()
    {
        OnThirdFeatSelect?.Invoke();
    }

    public void EndTurnButton()
    {
        GameManager.Instance.AdvanceTurn();
    }

    public void ToggleCommandPanel()
    {
        bool toggle = (_commandPanel.activeInHierarchy) ? false : true;
        _commandPanel.SetActive(toggle);

    }
}
