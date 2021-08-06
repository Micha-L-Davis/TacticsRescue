using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManager : Singleton<SelectionManager>
{
    protected SelectionManager() { }

    Feat _selectedFeat;
    //[SerializeField]
    //UIManager _uiManager;
    [SerializeField]
    EventSystem _eventSystem;
    Vector3 _destination;
    Vector3 _lastPosition;
    bool _actionComplete;
    public Actor SelectedActor { get; private set; }

    Input _input;
    [SerializeField]
    Camera _camera;

    private void Awake()
    {
        _input = new Input();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Start()
    {
        //_input.Agent.Select.performed += _ => SelectHero();
        _input.Agent.Execute.performed += _ => SelectTarget();
        UIManager.Instance.OnMoveSelect += SelectMoveFeat;
        UIManager.Instance.OnBreakSelect += SelectBreakFeat;
        UIManager.Instance.OnSaveSelect += SelectSaveFeat;
    }

    //old idea
    //////InitiativeRoutine
    //////while (!levelComplete)
    //////...select first initiative agent
    //////...SelectedAgent.BeginTurn();
    //////...yield return CheckForEndOfTurn(); //a bool function that triggers when agent ends their turn
    //////...calculate new initiative and insert into next turn's list
    //////...

    public void SelectActor(Actor actor)
    {
        SelectedActor = actor;
        _lastPosition = SelectedActor.transform.position;
        //highlight actor with shader
        //reveal UI buttons
    }

    //depreciated
    //void SelectHero()
    //{
    //    if (_eventSystem.IsPointerOverGameObject())
    //    {

    //    }
    //    else
    //    {
    //        Debug.Log("Left Click performed");
    //        Vector2 mousePos = _input.Agent.MousePosition.ReadValue<Vector2>();
    //        Ray clickRay = _camera.ScreenPointToRay(mousePos);
    //        RaycastHit hitInfo;
    //        if (Physics.Raycast(clickRay, out hitInfo))
    //        {
    //            Debug.Log(hitInfo.transform.name + " hit by ray");
    //            Hero hero = hitInfo.transform.gameObject.GetComponent<Hero>();
    //            if (hero != null)
    //            {

    //                SelectedActor = hero;
    //                Debug.Log(SelectedActor.name + " selected.");
    //                return;
    //            }
    //        }
    //        Debug.Log("Selecting null");
    //        SelectedActor = null;
    //    }

    //}

    void SelectMoveFeat()
    {
        _selectedFeat = SelectedActor.hero.Move;
        Debug.Log(_selectedFeat.Action);
    }
    void SelectBreakFeat()
    {
        _selectedFeat = SelectedActor.hero.Break;
    }
    void SelectSaveFeat()
    {
        _selectedFeat = SelectedActor.hero.Save;
    }


    void SelectTarget()
    {
        if (GameManager.Instance.PlayerTurn)
        {
            Debug.Log("Right Click performed");
            Vector2 mousePos = _input.Agent.MousePosition.ReadValue<Vector2>();
            Ray clickRay = _camera.ScreenPointToRay(mousePos);
            RaycastHit hitInfo;
            if (Physics.Raycast(clickRay, out hitInfo))
            {
                GameObject target = hitInfo.transform.gameObject;
                Debug.Log("Target object is " + target.name);
                float distance = Vector3.Distance(target.transform.position, _lastPosition);
                Debug.Log("Distance to target is " + distance);
                if (_selectedFeat == null)
                {

                    Debug.Log(hitInfo.point);
                    float x = Mathf.RoundToInt(hitInfo.point.x);
                    float y = Mathf.RoundToInt(hitInfo.point.y);
                    float z = Mathf.RoundToInt(hitInfo.point.z);
                    _destination = new Vector3(x, y, z);
                    GameManager.Instance.LogFeat(_destination);
                    _lastPosition = _destination;
                }
                else if (_selectedFeat != null && _selectedFeat.Range < distance)
                {
                    Debug.Log("Out of range, action failed");
                    _selectedFeat = null;
                }
                else if (_selectedFeat != null && _selectedFeat.Range > distance)
                {
                    GameManager.Instance.LogFeat(_selectedFeat, target);
                    _selectedFeat = null;
                }
            }
            _selectedFeat = null;
        }
    }

    public void ExecuteAction(Feat feat, object target)
    {
        GameObject gO = (GameObject)target;
        Debug.Log("Executing Feat " + feat);
        switch (feat.Action)
        {
            case Feat.ActionType.Move:
                Debug.Log("Move feat initiated.");
                IMovable movable = gO.GetComponent<IMovable>();
                if (movable != null)
                {
                    movable.ExecuteMove(2, (Hero)SelectedActor);
                }
                else
                {
                    Debug.Log("Object is not movable");
                }
                break;
            case Feat.ActionType.Break:
                //break stuff here
                break;
            case Feat.ActionType.Save:
                //save people here
                break;
            default:
                break;
        }
    }

    public void ExecuteAction(Feat feat)
    {
        _actionComplete = false;
        switch (feat.Action)
        {
            case Feat.ActionType.Panic:
                Debug.Log(SelectedActor.name + ": HEEEEEELLLLLLP MEEEEEEEEE!!!");
                break;
            case Feat.ActionType.Loot:
                Debug.Log(SelectedActor.name + " is rummaging for their favorite object");
                break;
            default:
                break;
        }
        _actionComplete = true;
    }

    public void ExecuteAction(object target)
    { 
        _destination = (Vector3)target;
        SelectedActor.HandleMove(_destination);
    }

    public bool MovementComplete()
    {
        float distance = Vector3.Distance(SelectedActor.transform.position, _destination);
        return distance <= 1.4f;
    }
}
