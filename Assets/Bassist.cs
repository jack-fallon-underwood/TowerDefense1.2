using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using InControl;


/// <summary>
/// This is the player script, it contains functionality that is specific to the Player
/// </summary>
public class Bassist : Player
{
    [SerializeField] private GameObject axeHit;
    [SerializeField] private GameObject axeSwing;
    private Axe myHit;
    private Axe mySwing;



    protected override void Start()
    {
        base.Start();
        
    }


    protected void Awake()
    {
        base.Awake();
        myHit = axeHit.GetComponent<Axe>();
        mySwing = axeSwing.GetComponent<Axe>();
    }

    /// <summary>
    /// We are overriding the characters update function, so that we can execute our own functions
    /// </summary>
    protected override void Update()
    {




        base.Update();


        if (Actions.Attack)
        { Attack(); }
        if (Actions.Solo)
        { Solo(); }
        if (Actions.Jam)
        { Jam(); }



        if (Actions.Walk.X != 0 || Actions.Walk.Y != 0)
        {
            var angle = (Mathf.Atan2(Actions.Walk.X * -1, Actions.Walk.Y) * Mathf.Rad2Deg);
            currentRotationQuaternion = (Quaternion.AngleAxis(angle, Vector3.forward));
            currentRoration = new Vector2(Actions.Walk.X, Actions.Walk.Y);
            mySprite.transform.rotation = currentRotationQuaternion;
            myDrumExits.transform.rotation = currentRotationQuaternion;
        }







    }
    protected void LateUpdate()
    {



    }

    void OnDisable()
    {
        if (Actions != null)
        {
            Actions.Destroy();
        }
    }

    public void Attack()
    {
        if (IsAttacking == false)
        {
            StartCoroutine(Attack(projectileType));
        }
    }

    public void Solo()
    {

        if (IsAttacking == false)
        {
            if (mana1.MyCurrentValue > 0)
            {
                StartCoroutine(Solo(projectileType));
            }
        }
    }



    public void Jam()
    {

        if (isJamming == true || (mana1.MyCurrentValue / mana1.MyMaxValue) > 0.95f)

        {
            StartCoroutine(Jam(projectileType));
        }
    }






    private IEnumerator Attack(string goname)
    {

   
       

        IsAttacking = true; //Indicates if we are attacking
        MyAnimator.SetBool("attack", IsAttacking); //Starts the attack animation
        axeSwing.SetActive(true);

        mySwing.PlayerOrigin = this;
        yield return new WaitForSeconds(0.5f);



        axeSwing.SetActive(false);

        StopAttack(); //Ends the attack
    }

    private IEnumerator Solo(string gotname)
    {
        mana1.MyCurrentValue -= 4;
        
        IsAttacking = true; //Indicates if we are attacking
        MyAnimator.SetBool("attack", IsAttacking); //Starts the attack animation
        axeHit.SetActive(true);
        myHit.PlayerOrigin = this;
        yield return new WaitForSeconds(0.5f);


        axeHit.SetActive(false);

        StopAttack(); //Ends the attack


    }

    private IEnumerator Jam(string gonam)
    {

        //Creates a new spell, so that we can use the information form it to cast it in the game

        IsAttacking = true; //Indicates if we are attacking
        isJamming = true;
        MyAnimator.SetBool("attack", IsAttacking); //Starts the attack animation
        GameObject p = GuitarShooter.GrabObject();
        axeSwing.SetActive(true);
        mySwing.PlayerOrigin = this;
        //  totems have no practical use in the dreeam
        p.transform.rotation = currentRotationQuaternion;

        p.transform.position = exitPoints[0].position; //keeps it firing from the front

        yield return new WaitForSeconds(0.01f); //This is a hardcoded cast time, for debugging     



        Projectile q = p.GetComponent<Projectile>();
        q.PlayerOrigin = this;
        q.Initialize(q.MyDamage);
        q.MyBody.velocity = currentRoration * q.MySpeed;
        axeSwing.SetActive(false);





        StopAttack(); //Ends the attack
    }



}