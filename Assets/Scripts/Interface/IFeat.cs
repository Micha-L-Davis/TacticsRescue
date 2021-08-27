using IntensityTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IFeat 
{
    void Queue();
    void UnQueue();
    void Execute();
    void Undo();

    float ExecutionTime { get; }
    Outcome ActionOutcome { get; }

}
