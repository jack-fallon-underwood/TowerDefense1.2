using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

public class GetOffMe : MonoBehaviour
{
    private Vector2 direction;
    private float attackspeed;
    [SerializeField] private float currentSpeed;
    [SerializeField] private int damage = 8;
    [SerializeField] private float castTime;
    public Player PlayerOrigin;
    private string noidea;

    private Animator myAnimator;




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


    // Start is called before the first frame update
    void Start()
    {

        myAnimator = GetComponent<Animator>();
       


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
      



        if (collision.tag == "Enemy")
        {
            Character c = collision.GetComponentInParent<Enemy>();


           // GetComponent<Animator>().SetTrigger("Impact");
            //Character m = GetComponentInParent<Transform.root>();
            //myRigidBody.velocity = Vector2.zero;
            c.gameObject.transform.Translate(c.MovementSpd * new Vector3(-1.0f,-1.0f,1));// * Time.deltaTime);
          //  c.MovementSpd = -c.MovementSpd;
            c.TakeDamage(damage, PlayerOrigin.transform);
            
        }
        if (collision.tag == "Enemy/Boss")
        {
            Character c = collision.GetComponentInParent<Enemy>();
            currentSpeed = 0;

            GetComponent<Animator>().SetTrigger("Impact");
            //Character m = GetComponentInParent<Transform.root>();
            //myRigidBody.velocity = Vector2.zero;



            c.TakeDamage(damage, PlayerOrigin.transform);
        }

     
    }

    private IEnumerator Pushback(string taco)
    {
        //m_Rigidbody.AddForce(transform.up * -5f);
        yield return new WaitForSeconds(2);
        print(Time.time);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
      



        if (collision.tag == "Enemy")
        {
            Character c = collision.GetComponentInParent<Enemy>();





           // c.MovementSpd = -c.MovementSpd;
        }
      

     
    }

    private IEnumerator Decay(string nounderstand)
    {

        //Creates a new spell, so that we can use the information form it to cast it in the game


        yield return new WaitForSeconds(4.01f); //This is a hardcoded cast time, for debugging 


    }
 
}
