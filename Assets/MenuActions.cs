/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;


//this script allows you to move around menus with a controller
public class MenuSelections : AudioHandler
{
    [Header("Menu Sounds")]
    public AudioClip[] changeSelections;
    public AudioClip[] selects;

    [Header("Menu Selections")]
    public bool menuActive;
    public StarSelectors[] menuSelections;
    public GameObject[] subMenus;
    public int currentSelector = 0;

    //for controller selections 
    bool canChange;
    float changeTimer, changeReset = 0.25f;
    InputDevice inputDevice;

    private void Start()
    {
        //assign within star selectors 
        for(int i = 0; i < menuSelections.Length; i++)
        {
            menuSelections[i].menuSelections = this;
        }
    }

    void Update ()
    {
        //get input device 
        inputDevice = InputManager.ActiveDevice;

        if (menuActive)
        {
            //controller 
            if (inputDevice.DeviceClass == InputDeviceClass.Controller)
            {
                //handles controller inputs for the menu
                ControllerSelection();
                //resets when you change selectors
                ChangeReset();
            }
        }

        //detection of closing submenus
        if (inputDevice.Action2.WasPressed)
        {
            DeactivateAllSubMenus();
        }
    }

    //activates menu and resets selection
    public void ActivateMenu()
    {
        menuActive = true;

        //deactivate all stars 
        for (int i = 0; i < menuSelections.Length; i++)
        {
            menuSelections[i].DeactivateStars();
        }

        //reset to selector 0
        currentSelector = 0;
        if (menuSelections.Length > 0)
            menuSelections[currentSelector].ActivateStars();
    }
    
    public void DeactivateMenu()
    {
        menuActive = false;

        Debug.Log("deactivated" + gameObject.name);
    }

    //function controls selection with controller
    void ControllerSelection()
    {
        //get inputY
        float inputValY = inputDevice.LeftStickY;

        //detection of changing 
        if (canChange)
        {
            //pos val, selection moves up
            if (inputValY < 0)
            {
                ChangeMenuSelector(true);
            }
            //neg val, selection moves down
            else if (inputValY > 0)
            {
                ChangeMenuSelector(false);
            }
        }

        //detection of selection
        if (inputDevice.Action1.WasPressed)
        {
            if (menuSelections[currentSelector])
                menuSelections[currentSelector].SelectMe();
        }

        
    }

    //allows you to increment menu selector & change stars
    public void ChangeMenuSelector(bool upOrDown)
    {
        if (menuSelections.Length > 1)
        {
            //deactivate current stars
            menuSelections[currentSelector].DeactivateStars();

            //up
            if (upOrDown)
            {
                //increment up
                if (currentSelector < menuSelections.Length - 1)
                {
                    currentSelector++;
                }
                else
                {
                    currentSelector = 0;
                }
            }
            //down
            else
            {
                //increment down
                if (currentSelector > 0)
                {
                    currentSelector--;
                }
                else
                {
                    currentSelector = menuSelections.Length - 1;
                }
            }

            //activate next stars
            menuSelections[currentSelector].ActivateStars();

            //change reset called 
            canChange = false;
            changeTimer = 0;
        }
    }

    //handles reset timer for controller selection
    void ChangeReset()
    {
        if (canChange == false)
        {
            changeTimer += Time.deltaTime;

            if (changeTimer > changeReset)
            {
                canChange = true;
            }
        }
    }

    //turns on all menu selections
    public void ActivateSelections()
    {
        for (int i = 0; i< menuSelections.Length; i++)
        {
            menuSelections[i].gameObject.SetActive(true);
        }
    }

    //turns off all menu selections
    public void DeactivateSelections()
    {
        for (int i = 0; i < menuSelections.Length; i++)
        {
            menuSelections[i].gameObject.SetActive(false);
        }

        //Debug.Log("deactivated" + gameObject.name + " selections");
    }

    //turns off all subMenus
    public void DeactivateAllSubMenus()
    {
        for (int i = 0; i < subMenus.Length; i++)
        {
            subMenus[i].SetActive(false);
        }

        //reactivate menu if it was disabled by opening a submenu
        if(menuActive == false)
        {
            ActivateMenu();
        }
    }

    //checks if there is a sub menu open
    public bool CheckSubMenusActive()
    {
        for (int i = 0; i < subMenus.Length; i++)
        {
            if (subMenus[i].activeSelf)
                return true;
        }

        return false;
    }
}
/*public class PlayerActions : PlayerActionSet
{

	public PlayerAction Attack;
	public PlayerAction Solo;
	public PlayerAction Jam;
	public PlayerAction Dash;
	public PlayerAction Left;
	public PlayerAction Right;
	public PlayerAction Up;
	public PlayerAction Down;
	public PlayerTwoAxisAction Walk;


	public PlayerActions()
	{
		Attack = CreatePlayerAction("Attack");
		Solo = CreatePlayerAction("Solo");
		Jam = CreatePlayerAction("Jam");
		Dash = CreatePlayerAction("Dash");
		Left = CreatePlayerAction("Left");
		Right = CreatePlayerAction("Right");
		Up = CreatePlayerAction("Up");
		Down = CreatePlayerAction("Down");
		Walk = CreateTwoAxisPlayerAction(Left, Right, Down, Up);
	}


	public static PlayerActions CreateWithKeyboardBindings()
	{
		var actions = new PlayerActions();

		actions.Up.AddDefaultBinding(Key.A);
		actions.Down.AddDefaultBinding(Key.S);
		actions.Right.AddDefaultBinding(Key.D);
		actions.Left.AddDefaultBinding(Key.F);

		actions.Attack.AddDefaultBinding(Key.UpArrow);
		actions.Solo.AddDefaultBinding(Key.DownArrow);
		actions.Jam.AddDefaultBinding(Key.LeftArrow);
		actions.Dash.AddDefaultBinding(Key.RightArrow);

		return actions;
	}


	public static PlayerActions CreateWithJoystickBindings()
	{
		var actions = new PlayerActions();

		actions.Attack.AddDefaultBinding(InputControlType.Action1);
		actions.Solo.AddDefaultBinding(InputControlType.Action2);
		actions.Jam.AddDefaultBinding(InputControlType.Action3);
		actions.Dash.AddDefaultBinding(InputControlType.Action4);

		actions.Up.AddDefaultBinding(InputControlType.LeftStickUp);
		actions.Down.AddDefaultBinding(InputControlType.LeftStickDown);
		actions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);
		actions.Right.AddDefaultBinding(InputControlType.LeftStickRight);

		actions.Up.AddDefaultBinding(InputControlType.DPadUp);
		actions.Down.AddDefaultBinding(InputControlType.DPadDown);
		actions.Left.AddDefaultBinding(InputControlType.DPadLeft);
		actions.Right.AddDefaultBinding(InputControlType.DPadRight);

		return actions;
	}

}
*/