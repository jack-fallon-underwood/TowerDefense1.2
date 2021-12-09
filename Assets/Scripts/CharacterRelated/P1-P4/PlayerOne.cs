using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerOne : Player
{   
    

    // Start is called before the first frame update
    void Start() //maybe protect and overrride this(ssee player script)
    {
        
    }

 


    void OnEnable()
    {
       // controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        //controls.Gameplay.Disable();

    }
    // Update is called once per frame
    void Update()
    {
        //Executes the GetInput function
        GetInput();
        base.Update();
    }


    /// <summary>
    /// Listen's to the players input
    /// </summary>
    private void GetInput()
    {
    // Direction = Vector2.zero;

    // ///THIS IS USED FOR DEBUGGING ONLY
    // if (Input.GetKeyDown(KeyCode.I))
    // {
    
    //     mana1.MyCurrentValue -= 10;
    //     P1(10);
    // }
    // if (Input.GetKeyDown(KeyCode.O))
    // {
    //     health.MyCurrentValue += 10;
    //     mana1.MyCurrentValue += 10;
    // }

    //     if (Input.GetKey(KeybindManager.MyInstance.Player1binds["UP1"])) //Moves up
    //     {
    //         P1exitIndex = 0;
    //         Direction += Vector2.up;
            
    //     }
    //     if (Input.GetKey(KeybindManager.MyInstance.Player1binds["LEFT1"])) //Moves left
    //     {
            
    //         P1exitIndex = 3;
    //         Direction += Vector2.left; 
    //     }
    //     if (Input.GetKey(KeybindManager.MyInstance.Player1binds["DOWN1"]))
    //     {
    //         P1exitIndex = 2;
    //         Direction += Vector2.down;
    //     }
    //     if (Input.GetKey(KeybindManager.MyInstance.Player1binds["RIGHT1"])) //Moves right
    //     {
    //         P1exitIndex = 1;
    //         Direction += Vector2.right;
    //     }
    
    //     if (Input.GetKey(KeybindManager.MyInstance.Player1binds["ATTACK1"])) //Basic attack
    //     {
    //     if(IsAttacking == false){
    //     StartCoroutine(Attack(projectileType));
    //     }

    //     }
        
 
        
     
    }


}
