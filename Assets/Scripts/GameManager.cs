using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected GameManager() { }

    //turn change event notifications go here
    public static Func<int> OnRoundStart;
    //public static Action OnTurnChange;

    Dictionary<Actor, int> _initiativeDictionary = new Dictionary<Actor, int>();
    [SerializeField]
    LinkedList<KeyValuePair<Actor, int>> _initiativeOrder = new LinkedList<KeyValuePair<Actor, int>>();
    public bool levelComplete;



    //IEnumerator StartRoundRoutine()
    //{
    //    while (!levelComplete)
    //    {
    public void RoundStart()
    {
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
                Debug.Log("Actor: " + actor.Key.name + "Intitiative: " + actor.Value);
                _initiativeOrder.AddFirst(actor);


            }
            //update the UI image for the last image in the on-screen initiative roster
            UIManager.Instance.UpdateInitiativeRoster(_initiativeDictionary);
        }
        else
        {
            Debug.Log("OnRoundStart has no subscribers");
        }

    }
    //  yield on a bool checking to see if the initiative round is complete.
    //}


}
