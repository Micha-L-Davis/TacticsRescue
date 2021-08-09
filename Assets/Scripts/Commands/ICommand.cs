using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand 
{
    void Queue();
    void UnQueue();
    void Execute();
    void Undo();

}
