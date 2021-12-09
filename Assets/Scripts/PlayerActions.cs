using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerActions : PlayerActionSet
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
	public PlayerAction RB;
	public PlayerAction LB;
	public PlayerAction Pause;

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

		RB = CreatePlayerAction("RB");
		LB = CreatePlayerAction("LB");
		Pause = CreatePlayerAction("Pause");
	}


	public static PlayerActions CreateWithKeyboardBindings()
	{
		var actions = new PlayerActions();

		actions.Up.AddDefaultBinding(Key.W);
		actions.Down.AddDefaultBinding(Key.S);
		actions.Right.AddDefaultBinding(Key.D);
		actions.Left.AddDefaultBinding(Key.A);

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

		actions.RB.AddDefaultBinding(InputControlType.RightTrigger);
		actions.LB.AddDefaultBinding(InputControlType.LeftBumper);
		actions.RB.AddDefaultBinding(InputControlType.RightBumper);
		actions.LB.AddDefaultBinding(InputControlType.LeftTrigger);

		actions.Pause.AddDefaultBinding(InputControlType.Command);


		return actions;
	}

}
