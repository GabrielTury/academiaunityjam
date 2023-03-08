//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Inputs/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9748cd88-e49b-4384-8f01-1e6e2d8860be"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""72133bb6-33a0-4c9a-97af-2d7f5bf1b14e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""edba87d4-b59a-4c5a-9f58-3a22242c75e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack1"",
                    ""type"": ""Button"",
                    ""id"": ""27162e74-48b0-4250-8ba2-dcaea896fb1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack2"",
                    ""type"": ""Button"",
                    ""id"": ""efcd94ae-633f-4baa-98bd-0a330af8483c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack3"",
                    ""type"": ""Button"",
                    ""id"": ""45d6b221-91b4-4077-a209-5ab728fd423f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack4"",
                    ""type"": ""Button"",
                    ""id"": ""ca38d304-f845-4c9d-af77-91418ce3754b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Morph"",
                    ""type"": ""Button"",
                    ""id"": ""bea8fd21-48ab-42e7-aea2-9329acbfba67"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NextDialogue"",
                    ""type"": ""Button"",
                    ""id"": ""7587d5b6-b6ae-4bb7-9bab-744049be3de3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""164a9001-d96f-4e46-9a03-0812fb7f5d9b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fedb85d-a0aa-4e5c-99a3-5699e0bd7d34"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""a4249ada-8070-4cd8-8ec2-87b0a9b1de68"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""36b7b687-2aa1-4741-9e1b-9e6da5e71409"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8e46960d-b5dc-4ad3-b8e7-1677ddf18e63"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""eeef8e65-4a0d-4205-95fe-c427fc460665"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5997e691-7e66-4914-be01-6d223acc93a9"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Morph"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""efbff3bf-7cb0-4009-89fa-7c400a20164f"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2edc5a92-9930-46de-b197-08de662ae815"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30e7b1b1-2d35-47b4-8791-f59644b3ee7a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1288ee62-94da-48bb-9a49-03d336cded84"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextDialogue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Lobo"",
            ""id"": ""c61719bf-4ee0-4069-bf73-2fe99c5722af"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""b3cbe05e-484e-4ebd-b562-70174261319a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b3d88819-8774-4c20-84aa-a13ca8abb7b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attacks"",
                    ""type"": ""Button"",
                    ""id"": ""7ee91ce5-c607-410c-8fbe-8406d17d60e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Morph"",
                    ""type"": ""Button"",
                    ""id"": ""812ffa2a-ca81-41c8-a2d4-1e4054c91b9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c29d602b-fc00-4724-bc30-8c04790de78d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e979ffea-ea4c-45be-b2a1-16527cd2f9d6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""beacf9d0-e60c-4367-aeae-7f3cdc0d4be0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4de301b9-8f56-4a41-bb82-225a92c41f36"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a25a5cc8-8ace-47cf-8810-9d2337c8286c"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attacks"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbbac06a-6bba-4d06-88f2-888965a68c52"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attacks"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""869a9ddf-4dec-4ea8-aeaf-0b6548ff0e33"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Morph"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Attack1 = m_Player.FindAction("Attack1", throwIfNotFound: true);
        m_Player_Attack2 = m_Player.FindAction("Attack2", throwIfNotFound: true);
        m_Player_Attack3 = m_Player.FindAction("Attack3", throwIfNotFound: true);
        m_Player_Attack4 = m_Player.FindAction("Attack4", throwIfNotFound: true);
        m_Player_Morph = m_Player.FindAction("Morph", throwIfNotFound: true);
        m_Player_NextDialogue = m_Player.FindAction("NextDialogue", throwIfNotFound: true);
        // Lobo
        m_Lobo = asset.FindActionMap("Lobo", throwIfNotFound: true);
        m_Lobo_Movement = m_Lobo.FindAction("Movement", throwIfNotFound: true);
        m_Lobo_Jump = m_Lobo.FindAction("Jump", throwIfNotFound: true);
        m_Lobo_Attacks = m_Lobo.FindAction("Attacks", throwIfNotFound: true);
        m_Lobo_Morph = m_Lobo.FindAction("Morph", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Attack1;
    private readonly InputAction m_Player_Attack2;
    private readonly InputAction m_Player_Attack3;
    private readonly InputAction m_Player_Attack4;
    private readonly InputAction m_Player_Morph;
    private readonly InputAction m_Player_NextDialogue;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Attack1 => m_Wrapper.m_Player_Attack1;
        public InputAction @Attack2 => m_Wrapper.m_Player_Attack2;
        public InputAction @Attack3 => m_Wrapper.m_Player_Attack3;
        public InputAction @Attack4 => m_Wrapper.m_Player_Attack4;
        public InputAction @Morph => m_Wrapper.m_Player_Morph;
        public InputAction @NextDialogue => m_Wrapper.m_Player_NextDialogue;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Attack1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack1;
                @Attack1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack1;
                @Attack1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack1;
                @Attack2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack2;
                @Attack2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack2;
                @Attack2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack2;
                @Attack3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack3;
                @Attack3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack3;
                @Attack3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack3;
                @Attack4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack4;
                @Attack4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack4;
                @Attack4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack4;
                @Morph.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMorph;
                @Morph.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMorph;
                @Morph.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMorph;
                @NextDialogue.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextDialogue;
                @NextDialogue.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextDialogue;
                @NextDialogue.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextDialogue;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack1.started += instance.OnAttack1;
                @Attack1.performed += instance.OnAttack1;
                @Attack1.canceled += instance.OnAttack1;
                @Attack2.started += instance.OnAttack2;
                @Attack2.performed += instance.OnAttack2;
                @Attack2.canceled += instance.OnAttack2;
                @Attack3.started += instance.OnAttack3;
                @Attack3.performed += instance.OnAttack3;
                @Attack3.canceled += instance.OnAttack3;
                @Attack4.started += instance.OnAttack4;
                @Attack4.performed += instance.OnAttack4;
                @Attack4.canceled += instance.OnAttack4;
                @Morph.started += instance.OnMorph;
                @Morph.performed += instance.OnMorph;
                @Morph.canceled += instance.OnMorph;
                @NextDialogue.started += instance.OnNextDialogue;
                @NextDialogue.performed += instance.OnNextDialogue;
                @NextDialogue.canceled += instance.OnNextDialogue;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Lobo
    private readonly InputActionMap m_Lobo;
    private ILoboActions m_LoboActionsCallbackInterface;
    private readonly InputAction m_Lobo_Movement;
    private readonly InputAction m_Lobo_Jump;
    private readonly InputAction m_Lobo_Attacks;
    private readonly InputAction m_Lobo_Morph;
    public struct LoboActions
    {
        private @Controls m_Wrapper;
        public LoboActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Lobo_Movement;
        public InputAction @Jump => m_Wrapper.m_Lobo_Jump;
        public InputAction @Attacks => m_Wrapper.m_Lobo_Attacks;
        public InputAction @Morph => m_Wrapper.m_Lobo_Morph;
        public InputActionMap Get() { return m_Wrapper.m_Lobo; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LoboActions set) { return set.Get(); }
        public void SetCallbacks(ILoboActions instance)
        {
            if (m_Wrapper.m_LoboActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_LoboActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_LoboActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_LoboActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_LoboActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_LoboActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_LoboActionsCallbackInterface.OnJump;
                @Attacks.started -= m_Wrapper.m_LoboActionsCallbackInterface.OnAttacks;
                @Attacks.performed -= m_Wrapper.m_LoboActionsCallbackInterface.OnAttacks;
                @Attacks.canceled -= m_Wrapper.m_LoboActionsCallbackInterface.OnAttacks;
                @Morph.started -= m_Wrapper.m_LoboActionsCallbackInterface.OnMorph;
                @Morph.performed -= m_Wrapper.m_LoboActionsCallbackInterface.OnMorph;
                @Morph.canceled -= m_Wrapper.m_LoboActionsCallbackInterface.OnMorph;
            }
            m_Wrapper.m_LoboActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attacks.started += instance.OnAttacks;
                @Attacks.performed += instance.OnAttacks;
                @Attacks.canceled += instance.OnAttacks;
                @Morph.started += instance.OnMorph;
                @Morph.performed += instance.OnMorph;
                @Morph.canceled += instance.OnMorph;
            }
        }
    }
    public LoboActions @Lobo => new LoboActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack1(InputAction.CallbackContext context);
        void OnAttack2(InputAction.CallbackContext context);
        void OnAttack3(InputAction.CallbackContext context);
        void OnAttack4(InputAction.CallbackContext context);
        void OnMorph(InputAction.CallbackContext context);
        void OnNextDialogue(InputAction.CallbackContext context);
    }
    public interface ILoboActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttacks(InputAction.CallbackContext context);
        void OnMorph(InputAction.CallbackContext context);
    }
}
