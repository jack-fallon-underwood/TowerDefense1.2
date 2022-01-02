using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

public class EvilProjectile : MonoBehaviour
{
    private Vector2 direction;
    private float attackspeed;
    [SerializeField] private float currentSpeed;
    [SerializeField] private int damage = 8;
    [SerializeField] private float castTime =5;
    public int PlayerOrigin = 1;
    private string noidea;
    
    private GameObject projectilePrefab;
    private PooledObject swimmyswimmy;
    private Animator myAnimator;
    private Rigidbody2D body;
    public Rigidbody2D MyEvilBody
    {get{return body;}}



    [SerializeField] private GameObject p1, p2, p3, p4;

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
        if (collision.tag == "Reflector")
        {
            myCP = new ContactPoint2D();
            myCPVn = myCP.normal;


            MyEvilBody.velocity = MyEvilBody.velocity * -1;
            damage = damage * -1;

            //attempt to stop collision.tag == player
            return;

        }



        if (collision.tag == "Player")
        {
            Character c = collision.GetComponentInParent<Player>();
            currentSpeed = 0;

            GetComponent<Animator>().SetTrigger("Impact");
            //Character m = GetComponentInParent<Transform.root>();
            //myRigidBody.velocity = Vector2.zero;
            Release();

           
            c.TakeDamage(damage, this.transform.parent);
        }
        if (collision.tag == "Enemy/Boss")
        {
            Character c = collision.GetComponentInParent<Enemy>();
            currentSpeed = 0;

            GetComponent<Animator>().SetTrigger("Impact");
            //Character m = GetComponentInParent<Transform.root>();
            //myRigidBody.velocity = Vector2.zero;
            Release();

            switch(PlayerOrigin)
            {
                case 1: transform.parent = p1.transform;          
                break;
                case 2: transform.parent = p2.transform;
                break;
                case 3: transform.parent = p3.transform;
                break;
                case 4: transform.parent = p4.transform;
                break;
            }
            c.TakeDamage(damage, this.transform.parent);
        }

        if (collision.tag == "Wall")
        {

            currentSpeed = 0;

            GetComponent<Animator>().SetTrigger("Impact");
           
            Release();
        }
    }

    private IEnumerator Decay(string nounderstand)
    {

        //Creates a new spell, so that we can use the information form it to cast it in the game

        
        yield return new WaitForSeconds(4.01f); //This is a hardcoded cast time, for debugging 
        Release();

    }
    public void Release()
    {
        swimmyswimmy.ReturnToPool();
        currentSpeed = attackspeed;
    }
}

