using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

public class LoveProjectile : MonoBehaviour
{
    private Vector2 direction;
    private float attackspeed;
    [SerializeField] private float currentSpeed;
    [SerializeField] private int damage = -8;
    [SerializeField] private float castTime;
    public Player PlayerOrigin2;
    private string noidea;

    private GameObject projectilePrefab;
    private PooledObject swimmyswimmy;
    private Animator myAnimator;
    private Rigidbody2D body;
    public Rigidbody2D MyBody
    { get { return body; } }




    public Vector2 MyDirection
    {
        get { return direction; }
        set { direction = value; }
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
        if (collision.tag == "Player")
        {
            Character c = collision.GetComponentInParent<Player>();

            //if (PlayerOrigin.transform != c.transform )
           // {
                myAnimator.SetTrigger("Impact");
                currentSpeed = 0;
                //private GameObject theEnemy = GetParent <GameObject>();
                //other.parent.TakeDamage(MyDamage,this.transform);
                Release();

                c.TakeDamage(damage, PlayerOrigin2.transform);
           // }
        }



        if (collision.tag == "Enemy")
        {
           
        }
        if (collision.tag == "Enemy/Boss")
        {
            Character c = collision.GetComponentInParent<Enemy>();
            currentSpeed = 0;

            GetComponent<Animator>().SetTrigger("Impact");
            //Character m = GetComponentInParent<Transform.root>();
            //myRigidBody.velocity = Vector2.zero;
            Release();


            c.TakeDamage(damage, PlayerOrigin2.transform);
        }

        if (collision.tag == "Obstacle")
        {

            currentSpeed = 0;

            GetComponent<Animator>().SetTrigger("Impact");

            Release();
        }
    }

    private IEnumerator Decay(string nounderstand)
    {

        //Creates a new spell, so that we can use the information form it to cast it in the game


        yield return new WaitForSeconds(2.01f); //This is a hardcoded cast time, for debugging 
        Release();

    }
    public void Release()
    {
        swimmyswimmy.ReturnToPool();
        currentSpeed = attackspeed;
    }
}