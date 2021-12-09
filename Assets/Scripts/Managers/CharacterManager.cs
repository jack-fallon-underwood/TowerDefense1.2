using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using InControl;
public class CharacterManager : MonoBehaviour

{

    public GameObject drummerPrefab;
	public GameObject bassistPrefab;
	public GameObject guitaristPrefab;
	public GameObject pianistPrefab;

	const int maxPlayers = 4;

	List<Vector3> playerPositions = new List<Vector3>() {
			new Vector3( -1, 1, -10 ),
			new Vector3( 1, 1, -10 ),
			new Vector3( -1, -1, -10 ),
			new Vector3( 1, -1, -10 ),
		};

	List<Player> players = new List<Player>(maxPlayers);

	PlayerActions keyboardListener;
	PlayerActions joystickListener;


	void OnEnable()
	{
		InputManager.OnDeviceDetached += OnDeviceDetached;
		keyboardListener = PlayerActions.CreateWithKeyboardBindings();
		joystickListener = PlayerActions.CreateWithJoystickBindings();
	}


	void OnDisable()
	{
		InputManager.OnDeviceDetached -= OnDeviceDetached;
		joystickListener.Destroy();
		keyboardListener.Destroy();
	}


	void Update()
	{
		if (JoinButtonWasPressedOnListener(joystickListener))
		{
			var inputDevice = InputManager.ActiveDevice;

			if (ThereIsNoPlayerUsingJoystick(inputDevice))
			{
				CreatePlayer(inputDevice);
			}
		}

		if (JoinDPadWasPressedOnListener(joystickListener))
		{
			var inputDevice = InputManager.ActiveDevice;

			if (ThereIsNoPlayerUsingJoystick(inputDevice))
			{
				CreateBassist(inputDevice);
			}
		}

		if (JoinButtonWasPressedOnListener(keyboardListener))
		{
			if (ThereIsNoPlayerUsingKeyboard())
			{
				CreatePlayer(null);
			}
		}

		if (JoinBumpsWasPressedOnListener(joystickListener))
		{
			var inputDevice = InputManager.ActiveDevice;

			if (ThereIsNoPlayerUsingJoystick(inputDevice))
			{
				CreateGuitarist(inputDevice);
			}
		}

		if (JoinPauseUnpauseWasPressedOnListener(joystickListener))
		{
			var inputDevice = InputManager.ActiveDevice;

			if (ThereIsNoPlayerUsingJoystick(inputDevice))
			{
				CreatePianist(inputDevice);
			}
		}
	}


	bool JoinButtonWasPressedOnListener(PlayerActions actions)
	{
		return actions.Attack.WasPressed || actions.Solo.WasPressed || actions.Jam.WasPressed || actions.Dash.WasPressed;
	}

	bool JoinDPadWasPressedOnListener(PlayerActions actions)
	{
		return actions.Walk.WasPressed;
	}

	bool JoinBumpsWasPressedOnListener(PlayerActions actions)
	{
		return actions.RB.WasPressed || actions.LB.WasPressed;

	}

	bool JoinPauseUnpauseWasPressedOnListener(PlayerActions actions)
	{
		return actions.Pause.WasPressed;

	}

	Player FindPlayerUsingJoystick(InputDevice inputDevice)
	{
		var playerCount = players.Count;
		for (var i = 0; i < playerCount; i++)
		{
			var player = players[i];
			if (player.Actions.Device == inputDevice)
			{
				return player;
			}
		}

		return null;
	}


	bool ThereIsNoPlayerUsingJoystick(InputDevice inputDevice)
	{
		return FindPlayerUsingJoystick(inputDevice) == null;
	}


	Player FindPlayerUsingKeyboard()
	{
		var playerCount = players.Count;
		for (var i = 0; i < playerCount; i++)
		{
			var player = players[i];
			if (player.Actions == keyboardListener)
			{
				return player;
			}
		}

		return null;
	}


	bool ThereIsNoPlayerUsingKeyboard()
	{
		return FindPlayerUsingKeyboard() == null;
	}


	void OnDeviceDetached(InputDevice inputDevice)
	{
		var player = FindPlayerUsingJoystick(inputDevice);
		if (player != null)
		{
			RemovePlayer(player);
		}
	}


	Player CreatePlayer(InputDevice inputDevice)
	{
		if (players.Count < maxPlayers)
		{
			// Pop a position off the list. We'll add it back if the player is removed.
			var playerPosition = playerPositions[0];
			playerPositions.RemoveAt(0);

			var gameObject = (GameObject)Instantiate(drummerPrefab, playerPosition, Quaternion.identity);
			var player = gameObject.GetComponent<Player>();

			if (inputDevice == null)
			{
				// We could create a new instance, but might as well reuse the one we have
				// and it lets us easily find the keyboard player.
				player.Actions = keyboardListener;
			}
			else
			{
				// Create a new instance and specifically set it to listen to the
				// given input device (joystick).
				var actions = PlayerActions.CreateWithJoystickBindings();
				actions.Device = inputDevice;

				player.Actions = actions;
			}

			players.Add(player);

			return player;
		}

		return null;
	}

	Player CreateBassist(InputDevice inputDevice)
	{
		if (players.Count < maxPlayers)
		{
			// Pop a position off the list. We'll add it back if the player is removed.
			var playerPosition = playerPositions[0];
			playerPositions.RemoveAt(0);

			var gameObject = (GameObject)Instantiate(bassistPrefab, playerPosition, Quaternion.identity);
			var player = gameObject.GetComponent<Player>();

			if (inputDevice == null)
			{
				// We could create a new instance, but might as well reuse the one we have
				// and it lets us easily find the keyboard player.
				player.Actions = keyboardListener;
			}
			else
			{
				// Create a new instance and specifically set it to listen to the
				// given input device (joystick).
				var actions = PlayerActions.CreateWithJoystickBindings();
				actions.Device = inputDevice;

				player.Actions = actions;
			}

			players.Add(player);

			return player;
		}

		return null;
	}

	Player CreateGuitarist(InputDevice inputDevice)
	{
		if (players.Count < maxPlayers)
		{
			// Pop a position off the list. We'll add it back if the player is removed.
			var playerPosition = playerPositions[0];
			playerPositions.RemoveAt(0);

			var gameObject = (GameObject)Instantiate(guitaristPrefab, playerPosition, Quaternion.identity);
			var player = gameObject.GetComponent<Player>();

			if (inputDevice == null)
			{
				// We could create a new instance, but might as well reuse the one we have
				// and it lets us easily find the keyboard player.
				player.Actions = keyboardListener;
			}
			else
			{
				// Create a new instance and specifically set it to listen to the
				// given input device (joystick).
				var actions = PlayerActions.CreateWithJoystickBindings();
				actions.Device = inputDevice;

				player.Actions = actions;
			}

			players.Add(player);

			return player;
		}

		return null;
	}

	Player CreatePianist(InputDevice inputDevice)
	{
		if (players.Count < maxPlayers)
		{
			// Pop a position off the list. We'll add it back if the player is removed.
			var playerPosition = playerPositions[0];
			playerPositions.RemoveAt(0);

			var gameObject = (GameObject)Instantiate(pianistPrefab, playerPosition, Quaternion.identity);
			var player = gameObject.GetComponent<Player>();

			if (inputDevice == null)
			{
				// We could create a new instance, but might as well reuse the one we have
				// and it lets us easily find the keyboard player.
				player.Actions = keyboardListener;
			}
			else
			{
				// Create a new instance and specifically set it to listen to the
				// given input device (joystick).
				var actions = PlayerActions.CreateWithJoystickBindings();
				actions.Device = inputDevice;

				player.Actions = actions;
			}

			players.Add(player);

			return player;
		}

		return null;
	}


	void RemovePlayer(Player player)
	{
		playerPositions.Insert(0, player.transform.position);
		players.Remove(player);
		player.Actions = null;
		Destroy(player.gameObject);
	}


	void OnGUI()
	{
		const float h = 22.0f;
		var y = 10.0f;

		GUI.Label(new Rect(10, y, 300, y + h), "Active players: " + players.Count + "/" + maxPlayers);
		y += h;

		if (players.Count < maxPlayers)
		{
			GUI.Label(new Rect(10, y, 300, y + h), "Press a button or a/s/d/f key to join!");
			y += h;
		}
	}
}


















	/// <summary>
	/// ////////////////////////////////////////////////
	/// </summary>
//	public bool PlayerOneActive = false, PlayerTwoActive = false, PlayerThreeActive = false, PlayerFourActive = false;

//    public GameObject P1Panel, P2Panel, P3Panel, P4Panel;
//    public SaveSlot SaveSlot1, SaveSlot2, SaveSlot3, SaveSlot4, SaveSlot5, SaveSlot6, SaveSlot7, SaveSlot8;
   
//   private List<string> names;
   

//   public Player P1, P2, P3, P4;
//    string sceneName;
//    // Start is called before the first frame update
//    void Start()
//    {
//      DontDestroyOnLoad(this.gameObject);

//      Scene currentScene = SceneManager.GetActiveScene();
//      sceneName = currentScene.name;

//      //if(SaveSlot1.GetSaveDataInUse() == true)
//     // {
//       //  Debug.Log(SaveSlot1.GetSaveDataName());
//      //}

   
        


         
//    }
    
//    // Update is called once per frame
//    void Update()
//    {
//       CheckNewScene();
        
//    }

//    public void SetPlayerOneStatus()
//    {
    
//       PlayerOneActive = !PlayerOneActive; 
//       P1Panel.SetActive(PlayerOneActive);
//    }

//    public void SetPlayerTwoStatus()
//    {
//       PlayerTwoActive = !PlayerTwoActive; 
//       P2Panel.SetActive(PlayerTwoActive);
//    }

//    public void SetPlayerThreeStatus()
//    {
//       PlayerThreeActive = !PlayerThreeActive; 
//       P3Panel.SetActive(PlayerThreeActive);
//    }

//    public void SetPlayerFourStatus()
//    {
//       PlayerFourActive = !PlayerFourActive; 
//       P4Panel.SetActive(PlayerFourActive);
//    }

//    private void CheckNewScene()
//    {
//        Scene currentScene = SceneManager.GetActiveScene();

//        if (currentScene.name != sceneName)
//        {
//         // Retrieve the name of this scene.
//         sceneName = currentScene.name;
        
//         // if (sceneName == "Level-1") 
//         // {
//         //    GameObject P1 = GameObject.Find("Player1");
//         //    P1.SetActive(PlayerOneActive);
//         //    GameObject P2 = GameObject.Find("Player2");
//         //    P2.SetActive(PlayerTwoActive);
//         //    GameObject P3 = GameObject.Find("Player3");
//         //    P3.SetActive(PlayerThreeActive);
//         //    GameObject P4 = GameObject.Find("Player4");
//         //    P4.SetActive(PlayerFourActive);
            
//         // }
//        }
      
//    }

   



//}
