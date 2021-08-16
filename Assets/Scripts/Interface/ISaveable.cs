using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    int PerilCountdown { get; }
    bool Imperiled { get; }
    void Rescue();

    void UndoRescue();
}
