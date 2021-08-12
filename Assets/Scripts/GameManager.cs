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
    int _initiativeIndex;
    [SerializeField]
    LinkedList<KeyValuePair<Actor, int>> _initiativeOrder = new LinkedList<KeyValuePair<Actor, int>>();
    public bool levelComplete;
    [SerializeField]
    int _currentRound;
    public int CurrentRound { get; }
    List<Actor> _actors = new List<Actor>();
    public bool PlayerTurn { get; private set; }
    LinkedList<ICommand> _thisTurn;
    int _actionCount = 1;
    LinkedList<LinkedList<ICommand>> _roundBuffer = new LinkedList<LinkedList<ICommand>>();
    private LinkedList<ICommand> _commandBuffer = new LinkedList<ICommand>();

    public void AddCommand(ICommand command)
    {
        _commandBuffer.AddLast(command);
        Debug.Log("Command queued, " + _commandBuffer.Count + " commands in turn buffer");
    }

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
            UIManager.Instance.UpdateInitiativeRoster(_initiativeOrder);;
        }
        else
        {
            Debug.Log("OnRoundStart has no subscribers");
        }

    }

    IEnumerator DeclareActions()
    {
        for (int i = 0; i < _actors.Count; i++)
        {
            _commandBuffer = new LinkedList<ICommand>();
            //select the last initiative member
            SelectionManager.Instance.SelectActor(_initiativeOrder.Last.Value.Key);
            Actor actor = SelectionManager.Instance.SelectedActor;
            //if actor.IsHero
            if (actor.IsHero)
            {
                _actionCount = 2;
                UIManager.Instance.ToggleCommandPanel();
                PlayerTurn = true;
                Debug.Log("Hero" + actor.name + " is chosing an action");
                yield return new WaitUntil(ActionsSelected);
                UIManager.Instance.ToggleCommandPanel();
            }
            else
            {
                _actionCount = 1;
                //AI decisions will run from here--for now all clients do is cower.
                yield return new WaitForSeconds(1.5f);
                Debug.Log("Client " + actor.name + " chooses to panic!");
                Feat feat = new Feat(0, Feat.ActionType.Panic);
                _commandBuffer.AddLast(new PanicCommand(SelectionManager.Instance.SelectedActor, .5f));
            }
            //Add commands for this turn to Round.First
            _roundBuffer.AddFirst(_commandBuffer);
            Debug.Log("Command Buffer loaded into round list. There are currently " + _roundBuffer.Count + " turns in round.");
            //move last initiative member to front of line
            var current = _initiativeOrder.Last;
            _initiativeOrder.RemoveLast();
            _initiativeOrder.AddFirst(current);
        }
    }

    bool ActionsSelected()
    {
        return _commandBuffer.Count == _actionCount;
    }

    IEnumerator ProcessRound()
    {
        Debug.Log(_roundBuffer.Count + " turns in queue");
        LinkedListNode<LinkedList<ICommand>> currentTurnNode = _roundBuffer.First;
        Debug.Log("Current turn loaded. " + currentTurnNode.Value.Count + " actions queued");
        LinkedListNode<ICommand> currentActionNode = currentTurnNode.Value.First;
        Debug.Log("Current action loaded: " + currentActionNode.Value.ToString());
        SelectionManager.Instance.SelectActor(_initiativeOrder.First.Value.Key);

        while (_roundBuffer.Count > 0)
        {
            Debug.Log("Beginning " + SelectionManager.Instance.SelectedActor.name + "'s turn");
            yield return new WaitForSeconds(.5f);
            currentActionNode.Value.Execute();
            if (currentActionNode.Value.ToString() == "ActorMovementCommand")
            {
                yield return new WaitUntil(SelectionManager.Instance.SelectedActor.MovementComplete);
            }
            else
            {
                yield return new WaitForSeconds(currentActionNode.Value.ExecutionTime);
            }
            currentActionNode = currentActionNode.Next;
            if (currentActionNode != null)
            {
                currentTurnNode.Value.Remove(currentActionNode.Previous);
            }
            else
            {
                Debug.Log("Last action on list reached");
                currentTurnNode.Value.Clear();
                currentTurnNode = currentTurnNode.Next;
                AdvanceTurn();

                if (currentTurnNode != null)
                {
                    _roundBuffer.Remove(currentTurnNode.Previous);
                    currentActionNode = currentTurnNode.Value.First;
                }
                else
                {
                    _roundBuffer.Clear();
                }
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
