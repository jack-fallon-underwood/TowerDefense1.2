using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This is an abstract class that all characters needs to inherit from
/// </summary>

[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour
{

    public FMODUnity.EventReference DamageEvent;
    public FMODUnity.EventReference HealEvent;
    // public int Frames = 0;

    //private int maxHealth;
    [SerializeField] private float physicalDmg;
    public float PhysicalDmg
    {
        get
        {
            return physicalDmg;
        }

        set
        {
            physicalDmg = value;
        }
    }
    [SerializeField] private int magicDmg;
    [SerializeField] private int attackSpd;
   
    [SerializeField] private float movementSpd;
    public float MovementSpd
    {
        get
        {
            return movementSpd;
        }

        set
        {
            movementSpd = value;
        }
    }

    private GameObject p1, p2, p3, p4, parentt;

    private ObjectPooler myObjectShooter;

    /// <summary>
    /// A reference to the character's animator
    /// </summary>
    public Animator MyAnimator { get; set; }

    /// <summary>
    /// The Character's rigidbody
    /// </summary>
    protected Rigidbody2D myRigidbody;

    /// <summary>
    /// indicates if the character is attacking or not
    /// </summary>
    public bool IsAttacking { get; set; }

    /// <summary>
    /// A reference to the attack coroutine
    /// </summary>
    protected Coroutine attackRoutine;

    [SerializeField]
    protected Transform hitBox;

    [SerializeField]
    protected Stat health;

    public Transform MyTarget { get; set; }

    public Stat MyHealth
    {
        get { return health; }
    }

    [SerializeField] private int level;

    public int MyLevel
    {
        get{return level;}
        set{level = value;}
    }
    public SpriteRenderer mySpriteRenderer2D;
    
    /// <summary>
    /// The character's initialHealth
    /// </summary>
    [SerializeField]
    protected float initHealth;

    /// <summary>
    /// Indicates if character is moving or not
    /// </summary>
    public bool IsMoving
    {
        get
        {
            return MoveVector.x != 0 || MoveVector.y != 0;
        }
    }

    public Vector3 MoveVector;
   

    public bool IsAlive
    {
        get
        {
          return  health.MyCurrentValue > 0.1f;
        }
    }

    public bool IsFreezing =false;

    private GameObject gameManager;
    public GameManager MyGameManager;
    protected virtual void Start()
    {
      health.Initialize(initHealth, initHealth);     //potentialslowdownproblem

        //Makes a reference to the rigidbody2D
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer2D = GetComponent<SpriteRenderer>();

        //Makes a reference to the character's animator
        MyAnimator = GetComponent<Animator>();

        gameManager = GameObject.FindWithTag("GameManager");
        MyGameManager = gameManager.GetComponent<GameManager>();

        //if(this is Enemy)
        {
        //    if(this is Enemy_Portal)
            {
        //        return;
            }

       //     if(transform.parent == null)
            {
                //myObjectShooter = GameObject.Find("DeadEnemies");
        //        return;
            }

             //parentt = this.transform.parent.gameObject;
           // myObjectShooter = parentt.GetComponent<ObjectPooler>();

        }
    }

    /// <summary>
    /// Update is marked as virtual, so that we can override it in the subclasses
    /// </summary>
    protected virtual void Update ()
    {

        
        
	}

    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected void LateUpdate()
    {
       // Frames++;
 

    }

    /// <summary>
    /// Moves the NPC
    /// </summary>
    public void Move()
    {
       
            //Makes sure that the player moves
            if(IsFreezing == true)
        {
            myRigidbody.velocity = MoveVector.normalized * MovementSpd*0.5f;
        }

            
            else
        {
            myRigidbody.velocity = MoveVector.normalized * MovementSpd;
        }
 
    }

    public void Move(Vector3 InputVector)
    {
       
            //Makes sure that the player moves
            myRigidbody.velocity = InputVector.normalized * MovementSpd;

    
 
    }




    /// <summary>
    /// Makes sure that the right animation layer is playing
    /// </summary>
    public void HandleLayers()
    {


        //Checks if we are moving or standing still, if we are moving then we need to play the move animation
        if (IsAttacking)
        {
            ActivateLayer("AttackLayer");

        }

        else if (IsMoving)
        {
            ActivateLayer("WalkLayer");


            //Sets the animation parameter so that he faces the correct MoveVector
           // MyAnimator.SetFloat("x", MoveVector.x);
          //  MyAnimator.SetFloat("y", MoveVector.y);

        }
        else if(!IsMoving)
            {
            //Makes sure that we will go back to idle when we aren't pressing any keys.
            // ActivateLayer("BaseLayer");
            ActivateBaseLayer();
        }

       
       else
        {  }
       // {
       //     ActivateLayer("DeathLayer");
       // }

    }

    /// <summary>
    /// Activates an animation layer based on a string
    /// </summary>
    public void ActivateLayer(string layerName)
    {
        
        for (int i = 0; i < MyAnimator.layerCount; i++)
        {
            MyAnimator.SetLayerWeight(i, 0);
   
            
        }

       MyAnimator.SetLayerWeight(MyAnimator.GetLayerIndex(layerName),1);
    }

    public void ActivateBaseLayer()
    {
        for (int i = 1; i < MyAnimator.layerCount; i++)
        {
            MyAnimator.SetLayerWeight(i, 0);

            
        }
        MyAnimator.SetLayerWeight(0, 1);
    }

    /// <summary>
    /// Makes the character take damage
    /// </summary>
    /// <param name="damage"></param>
    public virtual void TakeDamage(float damage, Transform source)
    {
        if(this is Enemy)
        {
            Enemy e = GetComponent<Enemy>();
            e.LastPersonToHitMe = source.GetComponentInParent<Player>();
        }
        health.MyCurrentValue -= damage;
        FMODUnity.RuntimeManager.PlayOneShot(DamageEvent, transform.position);
        
        if (health.MyCurrentValue <= 0)
        {
            //Makes sure that the character stops moving when its dead
       //     MoveVector = Vector3.zero;
      //myRigidbody.velocity = MoveVector;
//            SoundManager.Instance.PlaySFX("Splat");
           // MyAnimator.SetTrigger("die");
            if(this is Player)
            {
              // MyGameManager.GameOver();
            }
            if(this is Enemy)
            {   
               // Player p = source.GetComponentInParent<Player>();
               // p.P1(1);
                // //PooledObject Fishyswim = GetComponent<PooledObject>();

                // switch(p.playerNumber)
                // {
                //     case 1: 
                //     p1 = GameObject.Find("Player1");
                //     PlayerOne scr = p1.GetComponent<PlayerOne>();
                //     scr.P1(ExpManager.CalculateXP((this as Enemy)));
                //     break;
                //     case 2: 
                //     p2 = GameObject.Find("Player2");
                //     PlayerTwo scro = p2.GetComponent<PlayerTwo>();
                //     scro.P2(ExpManager.CalculateXP((this as Enemy)));
                //     break;
                //     case 3:
                //     p3 = GameObject.Find("Player3");
                //     PlayerThree scrop = p3.GetComponent<PlayerThree>();
                //     scrop.P3(ExpManager.CalculateXP((this as Enemy)));
                //     break;
                //     case 4: 
                //     p4 = GameObject.Find("Player4");
                //     PlayerFour scropt = p4.GetComponent<PlayerFour>();
                //     scropt.P4(ExpManager.CalculateXP((this as Enemy)));
                //     break;
                //     }

               // yield return new WaitForSeconds(0.9f);

                //Fishyswim.ReturnToPool();

            }
        }
    }
}
