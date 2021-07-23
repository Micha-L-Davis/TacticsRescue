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
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""0443841c-08ff-48e9-9eb8-bcf0bfa388db"",
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
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;Touch"",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
        m_Agent_MouseClick = m_Agent.FindAction("MouseClick", throwIfNotFound: true);
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
    private readonly InputAction m_Agent_MouseClick;
    public struct AgentActions
    {
        private @Input m_Wrapper;
        public AgentActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_Agent_MousePosition;
        public InputAction @MouseClick => m_Wrapper.m_Agent_MouseClick;
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
                @MouseClick.started -= m_Wrapper.m_AgentActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_AgentActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_AgentActionsCallbackInterface.OnMouseClick;
            }
            m_Wrapper.m_AgentActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
            }
        }
    }
    public AgentActions @Agent => new AgentActions(this);
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
        void OnMouseClick(InputAction.CallbackContext context);
    }
}
