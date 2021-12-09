// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class PlayerTwo : Player
// {

//         //CharacterInstrument
//     [SerializeField] private string instrument2; 


//      //Defense stats
//     [SerializeField] private int helmetD2;
//     [SerializeField] private int shieldD2;
//     [SerializeField] private int bootsD2;
    

//     /// <summary>
//     /// The player's mana
//     /// </summary>
//     [SerializeField]
//     private Stat mana2;

//     [SerializeField]
//     private Stat exp2;

//     [SerializeField]
//     private Text levelText2;


//     /// <summary>
//     /// Exit points for the spells
//     /// </summary>
//     [SerializeField]
//     private Transform[] exitPoints;

//     /// <summary>
//     /// Index that keeps track of which exit point to use, 2 is default down
//     /// </summary>
//     private int exitIndex = 2;
//     [SerializeField] private ObjectPooler GuitarShooter;

//       /// <summary>
//     /// The player's initial mana
//     /// </summary>
//     private float initMana = 50;

//     [SerializeField] private string projectileType;

//     // Start is called before the first frame update
//     void Start()
//     {
//         mana2.Initialize(initMana, initMana);
//         exp2.Initialize(0, Mathf.Floor(100*MyLevel*Mathf.Pow(MyLevel, 0.5f)));
//         levelText2.text = MyLevel.ToString();
//         base.Start();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         //Executes the GetInput function
//         GetInput();
//         base.Update();
//     }
//      /// <summary>
//     /// Listen's to the players input
//     /// </summary>
//     private void GetInput()
//     {
//         Direction = Vector2.zero;

//           if (Input.GetKey(KeybindManager.MyInstance.Player2binds["UP2"])) //Moves up
//           {
//              exitIndex = 0;
//              Direction += Vector2.up;
             
//           }
//           if (Input.GetKey(KeybindManager.MyInstance.Player2binds["LEFT2"])) //Moves left
//           {
              
//               exitIndex = 3;
//               Direction += Vector2.left; 
//           }
//           if (Input.GetKey(KeybindManager.MyInstance.Player2binds["DOWN2"]))
//           {
//               exitIndex = 2;
//               Direction += Vector2.down;
//           }
//           if (Input.GetKey(KeybindManager.MyInstance.Player2binds["RIGHT2"])) //Moves right
//           {
//               exitIndex = 1;
//               Direction += Vector2.right;
//           }
        
//           if (Input.GetKey(KeybindManager.MyInstance.Player2binds["ATTACK2"])) //Basic attack
//           {
//             if(IsAttacking == false){
//             StartCoroutine(Attack(projectileType));
//             }

//           }






//     }

//         /// <summary>
//     /// A co routine for attacking
//     /// </summary>
//     /// <returns></returns>
//     private IEnumerator Attack(string goname)
//     {

//         //Creates a new spell, so that we can use the information form it to cast it in the game

//         IsAttacking = true; //Indicates if we are attacking

//         MyAnimator.SetBool("attack", IsAttacking); //Starts the attack animation

   
//         GameObject p = GuitarShooter.GrabObject();
//         p.transform.position = exitPoints[exitIndex].position;
//         yield return new WaitForSeconds(0.1f); //This is a hardcoded cast time, for debugging

//         //Instantiate(objectPrefabs[i], exitPoints[exitIndex].position, Quaternion.identity).GetComponent<Projectile>();
        
//         //GameObject newObjpect = Instantiate(objectPrefabs[i]);
        
//         Projectile q = p.GetComponent<Projectile>();
//         q.PlayerOrigin = 2;
//         q.Initialize(q.MyDamage);

//         switch(exitIndex)
//         {
//            case 0: q.MyBody.velocity += Vector2.up; break;
//            case 1: q.MyBody.velocity += Vector2.right; break;
//            case 2: q.MyBody.velocity += Vector2.down; break;
//            case 3: q.MyBody.velocity += Vector2.left; break;
//         }
//         StopAttack(); //Ends the attack
//     }

//     public void P2(int xp)
//     {
//     exp2.MyCurrentValue += xp;

//     if (exp2.MyCurrentValue >= exp2.MyMaxValue)
//     {
//         StartCoroutine(Ding());

//     }}

//     private IEnumerator Ding()
//     {
//         while (!exp2.IsFull)
//         {
//         yield return null;  

//         }
 
//         MyLevel++;
//         levelText2.text = MyLevel.ToString();
//         exp2.MyMaxValue = 100 * MyLevel*Mathf.Pow(MyLevel, 0.5f);
//         exp2.MyMaxValue = Mathf.Floor(exp2.MyMaxValue);
//         exp2.MyCurrentValue = exp2.MyOverflow;
//         exp2.Reset();

//     }
// }
