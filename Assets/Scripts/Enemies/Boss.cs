using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{

    public float updateInterval = 0.5F;
    private double lastInterval;
    private int frames;
    private float fps;

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

        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
        
    }
    protected override void Awake()
    {
        base.Awake();
    }

    void OnGUI()
    {
        GUILayout.Label("" + fps.ToString("f2"));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if(InRange ==true && !IsAttacking)
        {
            StartCoroutine(Attack("whydoineedastring"));
        }

        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = timeNow;
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
          yield return new WaitForSeconds(2.25f); //This is a hardcoded cast time, for debugging 
        EvilProjectile q = p.GetComponent<EvilProjectile>();
        q.Initialize(q.MyDamage);

        q.MyEvilBody.velocity = (MyTarget.position - q.transform.position );// * -1 * q.MySpeed;
        EvilProjectile qq = pp.GetComponent<EvilProjectile>();
        qq.PlayerOrigin = 1;
        qq.Initialize(qq.MyDamage);
        qq.MyEvilBody.velocity = (MyTarget.position - q.transform.position ) ;//* qq.MySpeed; 

        IsAttacking = false;
     

        
    
    //     StopAttack(); //Ends the attack
    //     /// <summary>
    // /// Stops the attack
    // /// </summary>
    // public void StopAttack()
    // {

    //     IsAttacking = false; //Makes sure that we are not attacking

    //     MyAnimator.SetBool("attack", IsAttacking); //Stops the attack animation

    //     if (attackRoutine != null) //Checks if we have a reference to an co routine
    //     {
    //         StopCoroutine(attackRoutine);
    //     }
    // }
    }

    
}
