using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected GameManager() { }

    public static Func<int> OnRoundStart;

    Dictionary<Actor, int> _initiativeDictionary = new Dictionary<Actor, int>();
    int _initiativeIndex, _initiativeCeiling, _initiativeFloor;
    [SerializeField]
    LinkedList<KeyValuePair<Actor, int>> _initiativeOrder = new LinkedList<KeyValuePair<Actor, int>>();
    public bool levelComplete;
    int currentRound;
    public int CurrentRound { get; }

    private void Start()
    {
        RoundStart();
    }

    IEnumerator RoundRoutine()
    {
        while (!levelComplete)
        {
            RoundStart();
            yield return new WaitWhile(RoundComplete);

        }
    }
    public void RoundStart()
    {
        currentRound++;
        if (OnRoundStart != null)
        {
            foreach (Func<int> func in OnRoundStart.GetInvocationList())
            {
                Actor actor = (Actor)func.Target;
                int init = func.Invoke();
                _initiativeDictionary.Add(actor, init);
            }
            foreach (KeyValuePair<Actor, int> actor in _initiativeDictionary.OrderBy(init => init.Value))
            {
                Debug.Log("Actor: " + actor.Key.name + " Intitiative: " + actor.Value);
                _initiativeOrder.AddFirst(actor);
            }
            //update the UI image for the last image in the on-screen initiative roster
            UIManager.Instance.UpdateInitiativeRoster(_initiativeOrder);
            _initiativeCeiling = _initiativeOrder.First.Value.Value;
            _initiativeFloor = _initiativeOrder.Last.Value.Value;
            _initiativeIndex = _initiativeCeiling;
            SelectionManager.Instance.SelectActor(_initiativeOrder.First.Value.Key);

        }
        else
        {
            Debug.Log("OnRoundStart has no subscribers");
        }

    }

    public void AdvanceTurn()
    {
        var current = _initiativeOrder.First;
        _initiativeOrder.RemoveFirst();
        _initiativeOrder.AddLast(current);

        UIManager.Instance.UpdateInitiativeRoster(_initiativeOrder);
        SelectionManager.Instance.SelectActor(_initiativeOrder.First.Value.Key);

        _initiativeIndex = _initiativeOrder.First.Value.Value;
    }

    bool RoundComplete()
    {
        return _initiativeIndex > _initiativeFloor;
    }
}
