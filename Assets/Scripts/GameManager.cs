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
    [SerializeField]
    int _currentRound;
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
            yield return ProcessRound();
        }
    }
    public void RoundStart()
    {
        _currentRound++;
        _initiativeDictionary.Clear();
        _initiativeOrder.Clear();
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
            //_initiativeCeiling = _initiativeOrder.First.Value.Value;
            //_initiativeFloor = _initiativeOrder.Last.Value.Value;
            //_initiativeIndex = _initiativeCeiling;
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
                UIManager.Instance.ToggleCommandPanel();
                PlayerTurn = true;
                Debug.Log("Hero" + actor.name + " is chosing an action");
                yield return new WaitUntil(ActionSelected);
                UIManager.Instance.ToggleCommandPanel();
            }
            else
            {
                //AI decisions will run from here--for now all clients do is cower.
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
    }

    bool ActionSelected()
    {
        return _thisTurn.actionList.Count == _actionCount;
    }

    public void LogFeat(object target)
    {
        Debug.Log("Logging movement action to " + (Vector3)target);
        _thisTurn.AddAction(target);
    }

    public void LogFeat(Feat feat)
    {
        Debug.Log("Logging untargeted feat action " + feat.Action);
        _thisTurn.AddAction(feat);
    }

    public void LogFeat(Feat feat, object target)
    {
        Debug.Log("Logging targeted feat action " + feat.Action );
        _thisTurn.AddAction(feat, target);
    }

    IEnumerator ProcessRound()
    {
        LinkedListNode<Turn> currentTurnIndex = Round.First;
        LinkedListNode<object[]> currentActionIndex = currentTurnIndex.Value.actionList.First;
        SelectionManager.Instance.SelectActor(_initiativeOrder.First.Value.Key);

        while (Round.Count > 0)
        {
            Debug.Log("Beginning " + SelectionManager.Instance.SelectedActor.name + "'s turn");
            yield return new WaitForSeconds(1.5f);
            Feat feat = (Feat)currentActionIndex.Value[0];
            object target = currentActionIndex.Value[1];
            if (feat != null && target != null)
            {
                Debug.Log("Sending targeted feat for execution");
                SelectionManager.Instance.ExecuteAction(feat, target);
                yield return new WaitUntil(SelectionManager.Instance.ActionComplete);
            }
            else if (feat != null && target == null)
            {
                Debug.Log("Sending untargeted feat for execution");
                SelectionManager.Instance.ExecuteAction(feat);
                yield return new WaitUntil(SelectionManager.Instance.ActionComplete);
            }
            else if (feat == null && target != null)
            {
                Debug.Log("Sending movement order for execution");
                SelectionManager.Instance.ExecuteAction(target);
                yield return new WaitUntil(SelectionManager.Instance.MovementComplete);
            }
            else if (feat == null && target == null)
            {
                Debug.LogError("Invalid action recorded, cannot transmit--all fields are null");
            }
            
            currentActionIndex = currentActionIndex.Next;
            if (currentActionIndex != null)
            {
                currentTurnIndex.Value.actionList.Remove(currentActionIndex.Previous);
            }
            else
            {
                Debug.Log("Last action on list reached");
                currentTurnIndex.Value.actionList.Clear();
                currentTurnIndex = currentTurnIndex.Next;
                AdvanceTurn();
            }

            if (currentTurnIndex != null)
            {
                Round.Remove(currentTurnIndex.Previous);
                currentActionIndex = currentTurnIndex.Value.actionList.First;
            }
            else
            {
                Round.Clear();
            }
        }
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
}
