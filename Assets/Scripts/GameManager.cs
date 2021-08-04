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
    List<Actor> _actors = new List<Actor>();
    public bool PlayerTurn { get; private set; }
    Turn _thisTurn;
    int _actionCount = 1;
    LinkedList<Turn> Round = new LinkedList<Turn>();


    private void Start()
    {
        RallyActors();
        StartCoroutine(RoundRoutine());
    }

    void RallyActors()
    {
        GameObject[] rallyCall = GameObject.FindGameObjectsWithTag("Actor");
        foreach (var go in rallyCall)
        {
            Actor actor = go.GetComponent<Actor>();
            if (actor == null)
            {
                Debug.LogError("GameObject " + go.name + " is missing its actor component, or has been improperly assigned an Actor tag");
            }
            _actors.Add(actor);
        }

        Debug.Log(_actors.Count + " actors rallied.");
    }

    IEnumerator RoundRoutine()
    {
        while (!levelComplete)
        {
            RoundStart();
            yield return DeclareActions();
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
        }
        else
        {
            Debug.Log("OnRoundStart has no subscribers");
        }

    }

    IEnumerator DeclareActions()
    {
        //for loop on number of actors in play
        for (int i = 0; i < _actors.Count; i++)
        {
            //select the last initiative member
            SelectionManager.Instance.SelectActor(_initiativeOrder.Last.Value.Key);
            Actor actor = SelectionManager.Instance.SelectedActor;
            //if actor.IsHero
            _thisTurn = new Turn();
            if (actor.IsHero)
            {
                PlayerTurn = true;
                Debug.Log("Hero" + actor.name + " is chosing an action");
                yield return new WaitUntil(ActionSelected);
            }
            else
            {
                yield return new WaitForSeconds(1.5f);
                Debug.Log("Client " + actor.name + " chooses to panic!");
                Feat feat = new Feat(0, Feat.ActionType.Panic);
                LogFeat(feat);
            }
            //Add Turn to Round.First
            Round.AddFirst(_thisTurn);
            //move last initiative member to front of line
            var current = _initiativeOrder.Last;
            _initiativeOrder.RemoveLast();
            _initiativeOrder.AddFirst(current);
        }
        foreach (var item in Round)
        {
            Debug.Log(item.actionList.ToString());
        }
    }

    bool ActionSelected()
    {
        return _thisTurn.actionList.Count == _actionCount;
    }

    public void LogFeat(object target, Feat feat = null)
    {
        _thisTurn.AddAction(target, feat);
    }

    public void LogFeat(Feat feat, object target = null)
    {
        _thisTurn.AddAction(feat, target);
    }

    IEnumerator ProcessRound()
    {
        //var currentTurn = Round.First
        //var currentAction = currentTurn.action.first

        //while Round.Count > 0
        //yield return ExecuteAction(currentAction)
        
        //currentAction = currentAction.Next
        //if currentAction != null
            //currentTurn.action.Remove(currentAction.Previous)
        //else
            //currentTurn.action.Clear()
            //currentTurn = currentTurn.Next
            //if currentTurn != null
                //Round.Remove(currentTurn.Previous)
            //else
                //Round.Clear();

        

        yield break; 
    }

    void AIDeclareAction()
    {

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
