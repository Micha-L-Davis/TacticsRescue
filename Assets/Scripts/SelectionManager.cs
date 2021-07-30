using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManager : MonoBehaviour
{
    Feat _selectedFeat;
    [SerializeField]
    UIManager _uiManager;
    [SerializeField]
    EventSystem _eventSystem;

    public Hero SelectedHero { get; private set; }

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
        _input.Agent.Select.performed += _ => SelectAgent();
        _input.Agent.Execute.performed += _ => Execute();

        _uiManager.OnMoveSelect += SelectMoveFeat;
        _uiManager.OnBreakSelect += SelectBreakFeat;
        _uiManager.OnSaveSelect += SelectSaveFeat;
    }

    void SelectAgent()
    {
        if (_eventSystem.IsPointerOverGameObject())
        {

        }
        else
        {
            Debug.Log("Left Click performed");
            Vector2 mousePos = _input.Agent.MousePosition.ReadValue<Vector2>();
            Ray clickRay = _camera.ScreenPointToRay(mousePos);
            RaycastHit hitInfo;
            if (Physics.Raycast(clickRay, out hitInfo))
            {
                Debug.Log(hitInfo.transform.name + " hit by ray");
                Hero hero = hitInfo.transform.gameObject.GetComponent<Hero>();
                if (hero != null)
                {
                    //highlight agent with shader
                    //reveal UI buttons
                    SelectedHero = hero;
                    Debug.Log(SelectedHero.name + " selected.");
                    return;
                }
            }
            Debug.Log("Selecting null");
            SelectedHero = null;
        }

    }

    void SelectMoveFeat()
    {
        _selectedFeat = SelectedHero.Move;
    }
    void SelectBreakFeat()
    {
        _selectedFeat = SelectedHero.Break;
    }
    void SelectSaveFeat()
    {
        _selectedFeat = SelectedHero.Save;
    }

    void Execute()
    {
        Debug.Log("Right Click performed");
        Vector2 mousePos = _input.Agent.MousePosition.ReadValue<Vector2>();
        if (SelectedHero != null)
        {
            Ray clickRay = _camera.ScreenPointToRay(mousePos);
            RaycastHit hitInfo;
            if (Physics.Raycast(clickRay, out hitInfo))
            {
                GameObject target = hitInfo.transform.gameObject;
                Debug.Log("Target object is " + target.name);
                float distance = Vector3.Distance(target.transform.position, SelectedHero.transform.position);
                Debug.Log("Distance to target is " + distance);
                if (_selectedFeat != null && _selectedFeat.Range > distance)
                {
                    Debug.Log("Executing Feat");
                    switch (_selectedFeat.Action)
                    {
                        case Feat.ActionType.Move:
                            Debug.Log("Move feat initiated.");
                            IMovable movable = target.GetComponent<IMovable>();
                            if(movable != null)
                            {
                                ////somehow we have to fit another mouse click in here to designate a target. This is not the proper target at all.
                                //float x = Mathf.RoundToInt(hitInfo.point.x);
                                //float y = Mathf.RoundToInt(hitInfo.point.y);
                                //float z = Mathf.RoundToInt(hitInfo.point.z);
                                movable.ExecuteMove(2, SelectedHero);
                            }
                            else
                            {
                                Debug.Log("Object is not movable");
                            }
                            break;
                        case Feat.ActionType.Break:
                            break;
                        case Feat.ActionType.Save:
                            break;
                        default:
                            break;
                    }
                    _selectedFeat = null;
                    return;
                }
                else if (_selectedFeat != null && _selectedFeat.Range < distance)
                {
                    Debug.Log("Out of range, action failed");
                    _selectedFeat = null;
                    return;
                }
                else if (_selectedFeat == null)
                {
                    Debug.Log(SelectedHero.name + " executing movement.");
                    SelectedHero.HandleMove(mousePos);
                }
            }
        }
    }
}
