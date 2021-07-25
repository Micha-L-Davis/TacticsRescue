// GENERATED AUTOMATICALLY FROM 'Assets/Input/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Agent"",
            ""id"": ""fc54e80f-fa84-4407-92c2-b96799e8421b"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""323b36ed-2947-4283-8370-769eb1321807"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Execute"",
                    ""type"": ""Button"",
                    ""id"": ""0443841c-08ff-48e9-9eb8-bcf0bfa388db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""c7a473fe-d501-471f-99d0-3e158003e0b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9d54668b-2df1-4bd2-8859-192b409aab3d"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;Touch"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c2f3fce-c5a4-489f-8cd3-b4c3619a1744"",
                    ""path"": ""<Pointer>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;Touch"",
                    ""action"": ""Execute"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b6738c3-f01d-48bf-88a3-a0889dac82e0"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;Touch"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camera"",
            ""id"": ""b885c506-be9c-41bb-9c77-2e8065bf6223"",
            ""actions"": [
                {
                    ""name"": ""Pan"",
                    ""type"": ""Button"",
                    ""id"": ""ad6072b2-2504-4a45-8c87-76884c2eb261"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""87b73c27-1d40-4411-839e-6b527d7009f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Elevate"",
                    ""type"": ""Button"",
                    ""id"": ""96d6bdcc-5c75-4308-9f94-5ecb30e07e2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8df7f3e7-b704-4556-8187-ad792bad3062"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pan"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a9e138b6-97bd-4d7c-afa8-c280546f7be4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2414ea78-5598-4b4f-87c9-d6904732bd16"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""50bcfce6-3c2a-4db5-bdb3-3859dee42b54"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""011366d4-f4f0-4081-aced-0c356f04a409"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ca0e26d0-640d-43fb-be17-20334b68bfc9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d0070403-0012-47bb-8141-fc3dc5a9243a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d9bc7989-17f3-43ad-95db-5e48bd907483"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""acffee10-8ede-462a-9999-9afae42c653a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Elevate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d389d574-aa4f-481d-89a5-104b701807c0"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Elevate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9d5590cb-97a7-4f01-8c4a-4c5a4ec44429"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Elevate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Agent
        m_Agent = asset.FindActionMap("Agent", throwIfNotFound: true);
        m_Agent_MousePosition = m_Agent.FindAction("MousePosition", throwIfNotFound: true);
        m_Agent_Execute = m_Agent.FindAction("Execute", throwIfNotFound: true);
        m_Agent_Select = m_Agent.FindAction("Select", throwIfNotFound: true);
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Pan = m_Camera.FindAction("Pan", throwIfNotFound: true);
        m_Camera_Rotate = m_Camera.FindAction("Rotate", throwIfNotFound: true);
        m_Camera_Elevate = m_Camera.FindAction("Elevate", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Agent
    private readonly InputActionMap m_Agent;
    private IAgentActions m_AgentActionsCallbackInterface;
    private readonly InputAction m_Agent_MousePosition;
    private readonly InputAction m_Agent_Execute;
    private readonly InputAction m_Agent_Select;
    public struct AgentActions
    {
        private @Input m_Wrapper;
        public AgentActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_Agent_MousePosition;
        public InputAction @Execute => m_Wrapper.m_Agent_Execute;
        public InputAction @Select => m_Wrapper.m_Agent_Select;
        public InputActionMap Get() { return m_Wrapper.m_Agent; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AgentActions set) { return set.Get(); }
        public void SetCallbacks(IAgentActions instance)
        {
            if (m_Wrapper.m_AgentActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_AgentActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_AgentActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_AgentActionsCallbackInterface.OnMousePosition;
                @Execute.started -= m_Wrapper.m_AgentActionsCallbackInterface.OnExecute;
                @Execute.performed -= m_Wrapper.m_AgentActionsCallbackInterface.OnExecute;
                @Execute.canceled -= m_Wrapper.m_AgentActionsCallbackInterface.OnExecute;
                @Select.started -= m_Wrapper.m_AgentActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_AgentActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_AgentActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_AgentActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Execute.started += instance.OnExecute;
                @Execute.performed += instance.OnExecute;
                @Execute.canceled += instance.OnExecute;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public AgentActions @Agent => new AgentActions(this);

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_Pan;
    private readonly InputAction m_Camera_Rotate;
    private readonly InputAction m_Camera_Elevate;
    public struct CameraActions
    {
        private @Input m_Wrapper;
        public CameraActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pan => m_Wrapper.m_Camera_Pan;
        public InputAction @Rotate => m_Wrapper.m_Camera_Rotate;
        public InputAction @Elevate => m_Wrapper.m_Camera_Elevate;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @Pan.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnPan;
                @Pan.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnPan;
                @Pan.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnPan;
                @Rotate.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotate;
                @Elevate.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnElevate;
                @Elevate.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnElevate;
                @Elevate.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnElevate;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pan.started += instance.OnPan;
                @Pan.performed += instance.OnPan;
                @Pan.canceled += instance.OnPan;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Elevate.started += instance.OnElevate;
                @Elevate.performed += instance.OnElevate;
                @Elevate.canceled += instance.OnElevate;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IAgentActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnExecute(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
    public interface ICameraActions
    {
        void OnPan(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnElevate(InputAction.CallbackContext context);
    }
}
