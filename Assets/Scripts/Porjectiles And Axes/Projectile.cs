using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private Vector2 direction;
    private float attackspeed;
    [SerializeField] private float currentSpeed;
    [SerializeField] protected int damage = 8;
    [SerializeField] private float castTime;
    public Player PlayerOrigin;
    private string noidea;
    
    private GameObject projectilePrefab;
    private PooledObject swimmyswimmy;
    private Animator myAnimator;
    private Rigidbody2D body;
    public Rigidbody2D MyBody
    {get{return body;}}




    public Vector2 MyDirection
    { get {return direction;}
        set {direction = value;}
    }

      /// <summary>
    /// Property for reading the damage
    public int MyDamage
    {
        get
        {
            return damage;
        }

    }
    /// <summary>
    // Property for reading the currentspeed
    public float MySpeed
    {
        get
        {
            return currentSpeed;
        }
    }
    /// <summary>
    /// Property for reading the cast time
    public float MyCastTime
    {
        get
        {
            return castTime;
        }
    }
    /// <summary>
    /// Property for reading the spell's prefab
    public GameObject MyProjectilePrefab
    {
        get
        {
            return projectilePrefab;
        }

        
   }

   [SerializeField] private float decay_value = 2.01f;


    //for reflections
    private Collider2D parentCollider;
    private ContactPoint2D myCP;
    private Vector2 myCPVn;

    // Start is called before the first frame update
    void Start()
    {   
      
        myAnimator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        swimmyswimmy = GetComponent<PooledObject>();
        attackspeed = 30;
        currentSpeed = attackspeed;


    }
    public void Initialize(int damage)
    {
        this.damage = damage;
        StartCoroutine(Decay(noidea));
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Reflector")
        {
            myCP = new ContactPoint2D();
            myCPVn = myCP.normal;


            MyBody.velocity = MyBody.velocity * -1;


       

            
        }



        if (collision.tag == "Enemy")
        {
            
                Character c = collision.GetComponentInParent<Enemy>();
                currentSpeed = 0;

               // GetComponent<Animator>().SetTrigger("Impact");
                //Character m = GetComponentInParent<Transform.root>();
                //myRigidBody.velocity = Vector2.zero;
                Release();

            if (c != null)
            {
                c.TakeDamage(damage, PlayerOrigin.transform);
            }
            
        }
        if (collision.tag == "Enemy/Boss")
        {
            Character c = collision.GetComponentInParent<Enemy>();
            currentSpeed = 0;

            GetComponent<Animator>().SetTrigger("Impact");
            //Character m = GetComponentInParent<Transform.root>();
            //myRigidBody.velocity = Vector2.zero;
            Release();

        
            c.TakeDamage(damage, PlayerOrigin.transform);
        }

        if (collision.tag == "Obstacle")
        {
 
            currentSpeed = 0;

            GetComponent<Animator>().SetTrigger("Impact");
           
            Release();
        }
    }

    protected IEnumerator Decay(string nounderstand)
    {

        //Creates a new spell, so that we can use the information form it to cast it in the game

        
        yield return new WaitForSeconds(decay_value); //This is a hardcoded cast time, for debugging 
        Release();

    }
    public void Release()
    {
        swimmyswimmy.ReturnToPool();
        currentSpeed = attackspeed;
    }
}

