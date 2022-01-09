using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender: Enemy
{
    // Start is called before the first frame update

    /// <summary>
    /// Exit points for the spells
    /// </summary>
    [SerializeField]
    private Transform[] exitPoints;

    /// <summary>
    /// Index that keeps track of which exit point to use, 2 is default down
    /// </summary>
    private int exitIndex = 0;

    [SerializeField] private ObjectPooler GuitarShooter;
    [SerializeField] protected GameObject myDrumExits;
    private Vector3 min, max, moveDirection = Vector3.zero;
    private Vector2 currentRoration;

     protected override void Start()
    {
        base.Start();
        
        
    }
    protected override void Awake()
    {
        base.Awake();
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
 
        if(InRange ==true && !IsAttacking)
        {
            
            
            StartCoroutine(Attack("whydoineedastring"));

            if(MyAggroRange < Vector2.Distance(transform.position, MyTarget.position))
            {
                Debug.Log(MyAggroRange+" <" +Vector2.Distance(transform.position, MyTarget.position));
             this.MyTarget = null;
            }
        }
    }

           /// <summary>
    /// A co routine for attacking
    /// </summary>
    /// <returns></returns>
    private IEnumerator Attack(string goname)
    {

        //Creates a new spell, so that we can use the information form it to cast it in the game
        
        IsAttacking = true; //Indicates if we are attacking

        GameObject p = GuitarShooter.GrabObject();
        //GameObject pp = GuitarShooter.GrabObject();
      //  totems have no practical use in the dreeam
       // p.transform.rotation = ;
       // pp.transform.rotation = ;
        p.transform.position = exitPoints[0].position; //keeps it firing from the front
//        pp.transform.position = exitPoints[1].position; //keeps it firing from the front
          yield return new WaitForSeconds(1); //This is a hardcoded cast time, for debugging
    //135 beats per minutes divided by 60 = 2.25 
        EvilProjectile q = p.GetComponent<EvilProjectile>();
        MyAnimator.SetBool("attack", IsAttacking); //Starts the attack animation
        q.Initialize(q.MyDamage);
       // q.MyEvilBody.velocity = (MyTarget.position - p.transform.position );// * -1 * q.MySpeed;
        

        
        //EvilProjectile qq = pp.GetComponent<EvilProjectile>();
        //qq.PlayerOrigin = 1;
        //qq.Initialize(qq.MyDamage);
        q.MyEvilBody.velocity = Vector2.down * q.MySpeed;
        
        StopAttack(); //Ends the attack

    
        
    
        
    }

    /// <summary>
    /// Stops the attack
    /// </summary>
    public void StopAttack()
    {

        IsAttacking = false; //Makes sure that we are not attacking

        MyAnimator.SetBool("attack", false); //Stops the attack animation

        if (attackRoutine != null) //Checks if we have a reference to an co routine
        {
            StopCoroutine(attackRoutine);
        }
    }
}