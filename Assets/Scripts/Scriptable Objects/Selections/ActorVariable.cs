using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Actor")]
public class ActorVariable : ScriptableObject
{
    [SerializeField]
    public Actor Value;

    public void SetValue(Actor value)
    {
        Value = value;
    }

    public void SetValue(Hero value)
    {
        Value = value;
    }

    public void SetValue(Client value)
    {
        Value = value;
    }
}
