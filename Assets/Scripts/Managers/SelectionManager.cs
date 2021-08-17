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
    Vector3 _plannedPosition;
    ICommand _command;
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

  

    public void SelectActor(Actor actor)
    {
        SelectedActor = actor;
        _plannedPosition = SelectedActor.transform.position;
        //highlight actor with shader
        //reveal UI buttons
    }

    void SelectMoveFeat()
    {
        _selectedFeat = SelectedActor.hero.Move;
        Debug.Log(_selectedFeat.FeatActionType);
    }
    void SelectBreakFeat()
    {
        _selectedFeat = SelectedActor.hero.Break;
        Debug.Log(_selectedFeat.FeatActionType);
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
                float distance = Vector3.Distance(target.transform.position, _plannedPosition);
                Debug.Log("Distance to target is " + distance);
                if (_selectedFeat == null)
                {
                    Debug.Log(hitInfo.point);
                    float x = Mathf.RoundToInt(hitInfo.point.x);
                    float y = Mathf.RoundToInt(hitInfo.point.y);
                    float z = Mathf.RoundToInt(hitInfo.point.z);
                    _destination = new Vector3(x, y, z);
                    _command = new ActorMovementCommand(SelectedActor, _destination);
                    _plannedPosition = _destination;
                }
                else if (_selectedFeat != null && _selectedFeat.Range < distance)
                {
                    Debug.Log("Out of range, action failed");
                    _selectedFeat = null;
                }
                else if (_selectedFeat != null && _selectedFeat.Range > distance)
                {
                    //switch on feat type 
                    //MoveObject: construct move object command and enqueue
                    //BreakObject: construct break object command and enqueue
                    //SaveClient: construct save client command and enqueue
                    //Panic: construct panic command and enqueue
                    //Loot: construct loot command and enqueue

                    switch (_selectedFeat.FeatActionType)
                    {
                        case Feat.ActionType.MoveObject:
                            IMovable movable = target.GetComponent<IMovable>();
                            if (movable == null)
                            {
                                Debug.Log("Cannot move immovable object");
                            }
                            else
                            {
                                Debug.Log("Creating new move object command");
                                _command = new MoveObjectCommand(movable, 2, (Hero)SelectedActor, 1);
                            }

                            break;
                        case Feat.ActionType.BreakObject:
                            IBreakable breakable = target.GetComponent<IBreakable>();
                            if (breakable == null)
                            {
                                Debug.Log("Cannot break unbreakable object");
                            }
                            else
                            {
                                Debug.Log("Creating new break object command");
                                Hero hero = (Hero)SelectedActor;
                                if (hero.HeroicOrigin == HeroData.HeroicOrigin.Mental)
                                {
                                    _command = new BreakObjectCommand(breakable, (int)hero.Will, hero.Will, 1);
                                }
                                else if (hero.HeroicOrigin == HeroData.HeroicOrigin.Physical)
                                {
                                    _command = new BreakObjectCommand(breakable, (int)hero.Strength, hero.Strength, 1);
                                }

                            }
                            break;
                        case Feat.ActionType.SaveClient:
                            ISaveable saveable = target.GetComponent<ISaveable>();
                            if (saveable == null)
                            {
                                Debug.Log("Cannot save unsaveable object");
                            }
                            else
                            {
                                //construct a new saveobject command
                            }
                            break;
                        case Feat.ActionType.Panic:
                            break;
                        case Feat.ActionType.Loot:
                            break;
                        default:
                            break;
                    }
                    _selectedFeat = null;
                }
            }
            _selectedFeat = null;
        }
    }
}
