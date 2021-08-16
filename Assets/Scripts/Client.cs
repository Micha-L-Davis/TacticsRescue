using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : Actor, ISaveable
{
    int _perilCountdown;
    bool _imperiled = true;

    public int PerilCountdown => _perilCountdown;

    public bool Imperiled => _imperiled;

    protected override void Start()
    {
        base.Start();
        GameManager.OnTurnEnd += ProcessPeril;
    }

    public void Rescue()
    {
        _imperiled = false;
    }

    void ProcessPeril()
    {
        if (Imperiled)
        {
            _perilCountdown--;
            if (PerilCountdown < 1)
            {
                Debug.Log(gameObject.name + " has succumbed to peril!");
            }
        }
    }

    public void AIDeclareAction()
    {

    }

    public override int RollInitiative()
    {
        int roll = Random.Range(0, 10);
        Debug.Log(gameObject.name + " rolls a " + roll + " for initiative.");
        return roll;
    }
}
