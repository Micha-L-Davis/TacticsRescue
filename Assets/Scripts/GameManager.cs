using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //turn change event notifications go here
    //public static Action OnRoundStart;
    public static Func<int> OnRoundStart;


    public static Action OnTurnChange;

    public Dictionary<GameObject, int> initiativeDictionary = new Dictionary<GameObject, int>();

    public bool levelComplete;



    //IEnumerator StartRoundRoutine()
    //{
    //    while (!levelComplete)
    //    {
    private void Start()
    {
        if (OnRoundStart != null)
        {
            foreach (Func<int> func in OnRoundStart.GetInvocationList())
            {
                Agent agent = (Agent)func.Target;
                int init = func.Invoke();
                initiativeDictionary.Add(agent.gameObject, init);
            }
            foreach (var item in initiativeDictionary)
            {
                Debug.Log(item.Key + " " + item.Value);
            }
        }
        else
        {
            Debug.Log("OnRoundStart has no subscribers");
        }

    }
    //  yield on a bool checking to see if the initiative round is complete.
    //}
}
