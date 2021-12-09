// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class PlayerThree : Player
// {
//         //CharacterInstrument
//     [SerializeField] private string instrument3; 

//      //Defense stats
//     [SerializeField] private int helmetD3;
//     [SerializeField] private int shieldD3;
//     [SerializeField] private int bootsD3;
    

//     /// <summary>
//     /// The player's mana
//     /// </summary>
//     [SerializeField]
//     private Stat mana3;

//     [SerializeField]
//     private Stat exp3;

//     [SerializeField]
//     private Text levelText3;

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

//     // Start is called before the first frame update
//     void Start()
//     {
//         mana3.Initialize(initMana, initMana);
//         exp3.Initialize(0, Mathf.Floor(100*MyLevel*Mathf.Pow(MyLevel, 0.5f)));
//         levelText3.text = MyLevel.ToString();
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

//           if (Input.GetKey(KeybindManager.MyInstance.Player3binds["UP3"])) //Moves up
//           {
//              exitIndex = 0;
//              Direction += Vector2.up;
             
//           }
//           if (Input.GetKey(KeybindManager.MyInstance.Player3binds["LEFT3"])) //Moves left
//           {
              
//               exitIndex = 3;
//               Direction += Vector2.left; 
//           }
//           if (Input.GetKey(KeybindManager.MyInstance.Player3binds["DOWN3"]))
//           {
//               exitIndex = 2;
//               Direction += Vector2.down;
//           }
//           if (Input.GetKey(KeybindManager.MyInstance.Player3binds["RIGHT3"])) //Moves right
//           {
//               exitIndex = 1;
//               Direction += Vector2.right;
//           }
//      }

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

//     public void P3(int xp)
//     {
//     exp3.MyCurrentValue += xp;

//     if (exp3.MyCurrentValue >= exp3.MyMaxValue)
//     {
//         StartCoroutine(Ding());

//     }}

//     private IEnumerator Ding()
//     {
//         while (!exp3.IsFull)
//         {
//         yield return null;  

//         }
 
//         MyLevel++;
//         levelText3.text = MyLevel.ToString();
//         exp3.MyMaxValue = 100 * MyLevel*Mathf.Pow(MyLevel, 0.5f);
//         exp3.MyMaxValue = Mathf.Floor(exp3.MyMaxValue);
//         exp3.MyCurrentValue = exp3.MyOverflow;
//         exp3.Reset();

//     }
// }
