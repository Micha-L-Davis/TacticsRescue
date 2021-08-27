using Opertoon.Panoply;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected GameManager() { }

    public static Action OnRoundStart;
    public static Action OnTurnEnd;

    Dictionary<Actor, int> _initiativeDictionary = new Dictionary<Actor, int>();
    int _initiativeIndex;
    LinkedList<KeyValuePair<Actor, int>> _initiativeOrder = new LinkedList<KeyValuePair<Actor, int>>();
    public bool levelComplete;
    [SerializeField]
    int _currentRound;
    public int CurrentRound { get; }
    [SerializeField]
    ActorRuntimeSet _actorRuntimeSet;
    [SerializeField]
    PanelRuntimeSet _panelRuntimeSet;

    [SerializeField]
    ActorVariable _selectedActor;

    private Actor SelectedActor
    {
        get => _selectedActor.Value;
        set => _selectedActor.SetValue(value);
    }


    List<Actor> Actors
    {
        get
        {
            return _actorRuntimeSet.Items;
        }
    }

    List<Panel> Panels
    {
        get
        {
            return _panelRuntimeSet.Items;
        }
    }

    public bool PlayerTurn { get; private set; }
    LinkedList<IFeat> _thisTurn;
    int _actionCount = 1;
    LinkedList<LinkedList<IFeat>> _roundBuffer = new LinkedList<LinkedList<IFeat>>();
    private LinkedList<IFeat> _commandBuffer = new LinkedList<IFeat>();

    



    public void AddCommand(IFeat command)
    {
        _commandBuffer.AddLast(command);
        Debug.Log("Command queued, " + _commandBuffer.Count + " commands in turn buffer");
    }

    private void Start()
    {
        
        StartCoroutine(RoundRoutine());
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
        if (_actorRuntimeSet.Items != null)
        {
            OnRoundStart?.Invoke();
            foreach (Actor actor in _actorRuntimeSet.Items)
            {
                int init = actor.initiative;
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
        for (int i = 0; i < Actors.Count; i++)
        {
            _commandBuffer = new LinkedList<IFeat>();
            //select the last initiative member
            SelectedActor =_initiativeOrder.Last.Value.Key;
            //if actor.IsHero
            if (SelectedActor.IsHero)
            {
                _actionCount = 2; //temporary magic number
                UIManager.Instance.ToggleCommandPanel();
                PlayerTurn = true;
                Debug.Log("Hero" + SelectedActor.name + " is chosing an action");
                yield return new WaitUntil(ActionsSelected);
                UIManager.Instance.ToggleCommandPanel();
            }
            else
            {
                _actionCount = 1; //probably permanent magic number
                //AI decisions will run from here--for now all clients do is cower.
                yield return new WaitForSeconds(1.5f);
                SelectedActor.client.AIDeclareAction();
                //Debug.Log("Client " + actor.name + " chooses to panic!");
                //Feat feat = new Feat(0, Feat.ActionType.Panic);
                //_commandBuffer.AddLast(new PanicCommand(SelectionManager.Instance.SelectedActor, .5f));
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
        LinkedListNode<LinkedList<IFeat>> currentTurnNode = _roundBuffer.First;
        Debug.Log("Current turn loaded. " + currentTurnNode.Value.Count + " actions queued");
        LinkedListNode<IFeat> currentActionNode = currentTurnNode.Value.First;
        Debug.Log("Current action loaded: " + currentActionNode.Value.ToString());
        SelectionManager.Instance.SelectActor(_initiativeOrder.First.Value.Key);

        while (_roundBuffer.Count > 0)
        {
            Debug.Log("Beginning " + SelectionManager.Instance.SelectedActor.name + "'s turn");
            yield return new WaitForSeconds(.5f);
            currentActionNode.Value.Execute();
            if (currentActionNode.Value.ToString().Equals("ActorMovementCommand"))
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




    public void AdvanceTurn()
    {
        OnTurnEnd?.Invoke();
        var current = _initiativeOrder.First;
        _initiativeOrder.RemoveFirst();
        _initiativeOrder.AddLast(current);

        UIManager.Instance.UpdateInitiativeRoster(_initiativeOrder);
        SelectionManager.Instance.SelectActor(_initiativeOrder.First.Value.Key);

        _initiativeIndex = _initiativeOrder.First.Value.Value;
    }
}
