// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""46d919d1-32d5-46b1-9c9e-5cc3959bf490"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1e43d6ec-aa3c-4215-9bf2-4ce3a678a6ab"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""51ea9719-fb34-49bb-ac0a-adac072337b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jam"",
                    ""type"": ""Button"",
                    ""id"": ""7523cccb-2c64-4fdb-ba91-25dff00b280b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Solo"",
                    ""type"": ""Button"",
                    ""id"": ""15640cbe-51ee-4e39-9984-92ad2072c231"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""f53b548c-cafb-410b-9b1e-f1ad49c4f294"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""02f62413-40ac-4bcc-9556-f67aef3b3c66"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Change Item Left"",
                    ""type"": ""Button"",
                    ""id"": ""d2e62af3-f670-4506-847e-c126b1ecea8d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Change Item Right"",
                    ""type"": ""Button"",
                    ""id"": ""98d8cd14-637a-46cd-acb5-1e65a84f185e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""05640d46-eebd-4f8b-aff9-db34b5b558b3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord"",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4fe3cb5d-fefe-4441-bad9-ae06eb7f0fcd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""10b53a06-5273-4cab-821a-ffed0373d591"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7024dcfc-150e-4c88-ade6-4e72f21cd7c4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""019dfaa2-9383-4f9b-8901-416f1bdcb6bc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""57028873-772a-42c1-a058-026893778665"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3839a467-de44-4862-aca6-6af93357206a"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch Pro"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3f8c3538-82b6-4ba6-882d-762c98633edc"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch Pro"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""35ede509-37a7-4aea-a24b-66a818ce6cff"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch Pro"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b6319ce3-3abf-4aa4-8568-e43e1cb16c12"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch Pro"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6c704f4b-7918-480c-b738-290d17584b5a"",
                    ""path"": ""<SwitchProControllerHID>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch Pro"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3da0f8ab-c170-4e43-a18d-73b2581c55ca"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b5b669a5-7a40-49c8-8cce-4b5c245f1247"",
                    ""path"": ""<HID::Logitech Logitech(R) Precision(TM) Gamepad>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""684e1f8b-e911-4cb1-bad5-0517a2f0e752"",
                    ""path"": ""<HID::Logitech Logitech(R) Precision(TM) Gamepad>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8ab6d09e-2e38-4d66-b253-1e7cf74a14f0"",
                    ""path"": ""<HID::Logitech Logitech(R) Precision(TM) Gamepad>/button6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e7241ccb-0fc1-4eed-85e6-2fe0e80e154e"",
                    ""path"": ""<HID::Logitech Logitech(R) Precision(TM) Gamepad>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7ecc1f56-9f33-4f55-8666-9140134a8f87"",
                    ""path"": ""<SwitchProControllerHID>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch Pro"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3b5c75ec-bf11-42fa-bc66-b969c99d9c77"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8a81f783-c539-4741-ab9f-f56637ffd5d3"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch Pro"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""de4a5c20-e95e-4fe2-a1e7-f8a061e4fefa"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch Pro"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""628a4f6e-c53d-42b4-bfaf-ec7dd5e0c68d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch Pro"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8405281a-02e8-461f-8bd8-622580e8890f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch Pro"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e054203d-2cce-47b2-aadd-2ab7ac3d3ef5"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b101643d-6ef2-4722-9805-2afd32b35e8f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""217e6b38-514c-4f1f-949d-1f7b612abb59"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Logictech"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""92a1a739-e10c-4eb8-b858-381903d82795"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Logictech"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3aa3064c-fa83-4b58-9ba2-100a235a9fd6"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Logictech"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""deb87847-05f0-4ddf-839d-8c943833316d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Logictech"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""402f1b5d-4aee-4a75-8da8-c9a0b93694a8"",
                    ""path"": ""<HID::Logitech Logitech(R) Precision(TM) Gamepad>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Logictech"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64360f59-56e8-4bf8-873c-e0e1c3b7dcee"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad;Switch Pro;Keybord"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""983e1973-7f8a-4691-802c-a039635f0c06"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad;Keybord"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2c98fd9-3326-41da-b0be-0a292207871e"",
                    ""path"": ""<Keyboard>/period"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87b9626a-b301-419f-a102-de274f827b19"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c75966c4-9ba5-4eb3-9c1a-d0a0551fba89"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch Pro"",
                    ""action"": ""Jam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c581c14-9b55-417b-b263-3cf9ee7f8329"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord"",
                    ""action"": ""Jam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ccd5c86-6eed-4bc2-b83a-b09d75829d5d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Solo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05bbeeca-b7e5-4dd5-929a-d7024eabf882"",
                    ""path"": ""<Keyboard>/quote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord"",
                    ""action"": ""Solo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8ad8b34-0f6f-4b0e-9aae-61dee22e4ca3"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9cb97a93-6c90-41b8-83e0-9adc730d575e"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ffd840c-0be3-4a4f-a836-0a0eae6cd6c2"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b4421e1-8189-46ed-9b88-7799b9d3e6c3"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord"",
                    ""action"": ""Change Item Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8069daa5-6407-44d4-94c2-a48c7262f402"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord"",
                    ""action"": ""Change Item Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keybord"",
            ""bindingGroup"": ""Keybord"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Switch Pro"",
            ""bindingGroup"": ""Switch Pro"",
            ""devices"": [
                {
                    ""devicePath"": ""<SwitchProControllerHID>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        },
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": []
        },
        {
            ""name"": ""Logictech"",
            ""bindingGroup"": ""Logictech"",
            ""devices"": []
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Attack = m_Gameplay.FindAction("Attack", throwIfNotFound: true);
        m_Gameplay_Jam = m_Gameplay.FindAction("Jam", throwIfNotFound: true);
        m_Gameplay_Solo = m_Gameplay.FindAction("Solo", throwIfNotFound: true);
        m_Gameplay_Dash = m_Gameplay.FindAction("Dash", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        m_Gameplay_ChangeItemLeft = m_Gameplay.FindAction("Change Item Left", throwIfNotFound: true);
        m_Gameplay_ChangeItemRight = m_Gameplay.FindAction("Change Item Right", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Attack;
    private readonly InputAction m_Gameplay_Jam;
    private readonly InputAction m_Gameplay_Solo;
    private readonly InputAction m_Gameplay_Dash;
    private readonly InputAction m_Gameplay_Pause;
    private readonly InputAction m_Gameplay_ChangeItemLeft;
    private readonly InputAction m_Gameplay_ChangeItemRight;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Attack => m_Wrapper.m_Gameplay_Attack;
        public InputAction @Jam => m_Wrapper.m_Gameplay_Jam;
        public InputAction @Solo => m_Wrapper.m_Gameplay_Solo;
        public InputAction @Dash => m_Wrapper.m_Gameplay_Dash;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputAction @ChangeItemLeft => m_Wrapper.m_Gameplay_ChangeItemLeft;
        public InputAction @ChangeItemRight => m_Wrapper.m_Gameplay_ChangeItemRight;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @Jam.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJam;
                @Jam.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJam;
                @Jam.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJam;
                @Solo.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSolo;
                @Solo.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSolo;
                @Solo.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSolo;
                @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @ChangeItemLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeItemLeft;
                @ChangeItemLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeItemLeft;
                @ChangeItemLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeItemLeft;
                @ChangeItemRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeItemRight;
                @ChangeItemRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeItemRight;
                @ChangeItemRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeItemRight;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Jam.started += instance.OnJam;
                @Jam.performed += instance.OnJam;
                @Jam.canceled += instance.OnJam;
                @Solo.started += instance.OnSolo;
                @Solo.performed += instance.OnSolo;
                @Solo.canceled += instance.OnSolo;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @ChangeItemLeft.started += instance.OnChangeItemLeft;
                @ChangeItemLeft.performed += instance.OnChangeItemLeft;
                @ChangeItemLeft.canceled += instance.OnChangeItemLeft;
                @ChangeItemRight.started += instance.OnChangeItemRight;
                @ChangeItemRight.performed += instance.OnChangeItemRight;
                @ChangeItemRight.canceled += instance.OnChangeItemRight;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_KeybordSchemeIndex = -1;
    public InputControlScheme KeybordScheme
    {
        get
        {
            if (m_KeybordSchemeIndex == -1) m_KeybordSchemeIndex = asset.FindControlSchemeIndex("Keybord");
            return asset.controlSchemes[m_KeybordSchemeIndex];
        }
    }
    private int m_SwitchProSchemeIndex = -1;
    public InputControlScheme SwitchProScheme
    {
        get
        {
            if (m_SwitchProSchemeIndex == -1) m_SwitchProSchemeIndex = asset.FindControlSchemeIndex("Switch Pro");
            return asset.controlSchemes[m_SwitchProSchemeIndex];
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
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    private int m_LogictechSchemeIndex = -1;
    public InputControlScheme LogictechScheme
    {
        get
        {
            if (m_LogictechSchemeIndex == -1) m_LogictechSchemeIndex = asset.FindControlSchemeIndex("Logictech");
            return asset.controlSchemes[m_LogictechSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnJam(InputAction.CallbackContext context);
        void OnSolo(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnChangeItemLeft(InputAction.CallbackContext context);
        void OnChangeItemRight(InputAction.CallbackContext context);
    }
}
