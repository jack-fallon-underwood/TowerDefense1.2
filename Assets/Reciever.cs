using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciever : Enemy
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
        MyAnimator.SetBool("attack", IsAttacking); //Starts the attack animation
        GameObject p = GuitarShooter.GrabObject();
        GameObject pp = GuitarShooter.GrabObject();
      //  totems have no practical use in the dreeam
       // p.transform.rotation = ;
       // pp.transform.rotation = ;
        p.transform.position = exitPoints[0].position; //keeps it firing from the front
        pp.transform.position = exitPoints[1].position; //keeps it firing from the front
          
        EvilProjectile q = p.GetComponent<EvilProjectile>();

        
       
        
        q.Initialize(q.MyDamage);
        Debug.Log(p.transform.position+" - "+ MyTarget.position+" * ");
        Debug.Log(p.transform.position);

       // q.MyEvilBody.velocity = (MyTarget.position - p.transform.position );// * -1 * q.MySpeed;
        
        Debug.Log(myRigidbody.velocity);
        
        EvilProjectile qq = pp.GetComponent<EvilProjectile>();
        qq.PlayerOrigin = 1;
        qq.Initialize(qq.MyDamage);
      // qq.MyEvilBody.velocity = currentRoration * qq.MySpeed;
        
   yield return new WaitForSeconds(3.0f); //This is a hardcoded cast time, for debugging 
        
    
        StopAttack(); //Ends the attack
    }

    /// <summary>
    /// Stops the attack
    /// </summary>
    public void StopAttack()
    {

        IsAttacking = false; //Makes sure that we are not attacking

        MyAnimator.SetBool("attack", IsAttacking); //Stops the attack animation

        if (attackRoutine != null) //Checks if we have a reference to an co routine
        {
            StopCoroutine(attackRoutine);
        }
    }
}