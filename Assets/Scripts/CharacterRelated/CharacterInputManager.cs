using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CharacterInputHandler : MonoBehaviour
{   
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
       GetComponent <Player>();  
    }

    // Update is called once per frame
    public void OnMove(CallbackContext context)

    {
        player.SetInputVector(context.ReadValue<Vector2>());
    }
}
