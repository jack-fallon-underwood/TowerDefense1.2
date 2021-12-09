using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeybindManager : MonoBehaviour
{
    /// <summary>
    /// A reference to the singleton instance
    /// </summary>
    private static KeybindManager instance;

    /// <summary>
    /// Property for accessing the singleton instance
    /// </summary>
    public static KeybindManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<KeybindManager>();
            }

            return instance;
        }
    }

    /// <summary>
    /// A dictionary for all movement keybinds
    /// </summary>
    public Dictionary<string, KeyCode> Player1binds { get; private set; }
    public Dictionary<string, KeyCode> Player2binds { get; private set; }
    public Dictionary<string, KeyCode> Player3binds { get; private set; }
    public Dictionary<string, KeyCode> Player4binds { get; private set; }

  

    /// <summary>
    /// The name of the keybind we are trying to set or change
    /// </summary>
    private string bindName;

    // Use this for initialization
    void Start ()
    {
        Player1binds = new Dictionary<string, KeyCode>();
        Player2binds = new Dictionary<string, KeyCode>();
        Player3binds = new Dictionary<string, KeyCode>();
        Player4binds = new Dictionary<string, KeyCode>();


        //Generates the default keybinds
        BindKey("UP1", KeyCode.W);
        BindKey("LEFT1", KeyCode.A);
        BindKey("DOWN1", KeyCode.S);
        BindKey("RIGHT1", KeyCode.D);

        BindKey("ATTACK1", KeyCode.Alpha1);
        BindKey("DASH1", KeyCode.Alpha2);
        BindKey("JAM1", KeyCode.Alpha3);
        BindKey("SOLO1", KeyCode.Alpha4);

        //Generates the default for player 2
        BindKey("UP2", KeyCode.O);
        BindKey("LEFT2", KeyCode.K);
        BindKey("DOWN2", KeyCode.L);
        BindKey("RIGHT2", KeyCode.Semicolon);

        BindKey("ATTACK2", KeyCode.Alpha0);
        BindKey("DASH2", KeyCode.Minus);
        BindKey("JAM2", KeyCode.Equals);
        BindKey("SOLO2", KeyCode.Delete);

        //Generates the default for player 3
        BindKey("UP3", KeyCode.UpArrow);
        BindKey("LEFT3", KeyCode.LeftArrow);
        BindKey("DOWN3", KeyCode.DownArrow);
        BindKey("RIGHT3", KeyCode.RightArrow);

        BindKey("ATTACK3", KeyCode.M);
        BindKey("DASH3", KeyCode.Comma);
        BindKey("JAM3", KeyCode.Period);
        BindKey("SOLO3", KeyCode.Slash);

        //Generates the default for player 4
        BindKey("UP4", KeyCode.T);
        BindKey("LEFT4", KeyCode.F);
        BindKey("DOWN4", KeyCode.G);
        BindKey("RIGHT4", KeyCode.H);

        BindKey("ATTACK4", KeyCode.Alpha6);
        BindKey("DASH4", KeyCode.Alpha7);
        BindKey("JAM4", KeyCode.Alpha8);
        BindKey("SOLO4", KeyCode.Alpha9);
    }

    /// <summary>
    /// Binds a specific key
    /// </summary>
    /// <param name="key">Key to bind</param>
    /// <param name="keyBind">Keybind to set</param>
    public void BindKey(string key, KeyCode keyBind)
    {
        //Sets the default dictionary to the keybinds
        Dictionary<string, KeyCode> currentDictionary = Player1binds;

        if (key.Contains("1" )) //If we are trying to bind an actionbutton, then we use the actionbinds dictionary instead
        {
            currentDictionary = Player1binds;
        }
        if (key.Contains("2" )) //If we are trying to bind an actionbutton, then we use the actionbinds dictionary instead
        {
            currentDictionary = Player2binds;
        }
        if (key.Contains("3" )) //If we are trying to bind an actionbutton, then we use the actionbinds dictionary instead
        {
            currentDictionary = Player3binds;
        }
        if (key.Contains("4" )) //If we are trying to bind an actionbutton, then we use the actionbinds dictionary instead
        {
            currentDictionary = Player4binds;
        }


        if (!currentDictionary.ContainsKey(key))//Checks if the key is new
        {
            //If the key is new we add it
            currentDictionary.Add(key, keyBind);

            //We update the text on the button
            UIManager.MyInstance.UpdateKeyText(key, keyBind);
        }
        else if (currentDictionary.ContainsValue(keyBind)) //If we already have the keybind, then we need to change it to the new bind
        {
            //Looks for the old keybind
            string myKey = currentDictionary.FirstOrDefault(x => x.Value == keyBind).Key;

            //Unassigns the old keybind
            currentDictionary[myKey] = KeyCode.None;
            UIManager.MyInstance.UpdateKeyText(key, KeyCode.None);
        }

        //Makes sure the new key is bound
        currentDictionary[key] = keyBind;
        UIManager.MyInstance.UpdateKeyText(key, keyBind);
        bindName = string.Empty;
    }

    /// <summary>
    /// Function for setting a keybind, this is called whenever a keybind button is clicked on the keybind menu
    /// </summary>
    /// <param name="bindName"></param>
    public void KeyBindOnClick(string bindName)
    {
        this.bindName = bindName;
    }


    private void OnGUI()
    {
        if (bindName != string.Empty)//Checks if we are going to save a keybind
        {
            Event e = Event.current; //Listens for an event

            if (e.isKey) //If the event is a key, then we change the keybind
            {
                BindKey(bindName, e.keyCode);
            }
        }
    }
}
