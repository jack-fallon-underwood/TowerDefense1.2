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
public class Guitarist : Player
{
    [SerializeField] private GameObject axeSpinL;
    [SerializeField] private GameObject axeSpinR;
    [SerializeField] private GameObject axeLaunch;
    [SerializeField] private GameObject axeBoom;
    private Axe mySpinL;
    private Axe mySpinR;
    private Axe myLaunch;
    private Axe myBoom;
    private bool isStrumming;

    protected string NotSureWhyMyAttackFunctionNeedsAnOBjectCalledGOname;

    /// <summary>
    /// Index that keeps track of which exit point to use, 2 is default down
    /// </summary>



    protected override void Start()
    {
        base.Start();

    }


    protected void Awake()
    {    
        base.Awake();
        
        mySpinL = axeSpinL.GetComponent<Axe>();
        mySpinR = axeSpinR.GetComponent<Axe>();
        myLaunch = axeLaunch.GetComponent<Axe>(); 
        myBoom = axeBoom.GetComponent<Axe>();
    }

    /// <summary>
    /// We are overriding the characters update function, so that we can execute our own functions
    /// </summary>
    protected override void Update()
    {




        base.Update();


        if (Actions.Attack)
        { Attack(); }
        if (Actions.Solo.WasPressed)
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


        if (mana1.MyCurrentValue > 26)
        {
            StartCoroutine(Solo(projectileType));
        }
    }

   

    public void Jam()
    {

        if (isJamming == true || (mana1.MyCurrentValue / mana1.MyMaxValue) > 0.95f)

        {
            if (isStrumming == false)
            {
                StartCoroutine(Jam(projectileType));
            }
        }
    }

   




    private IEnumerator Attack(string goname)
    {

        IsAttacking = true; //Indicates if we are attacking
        MyAnimator.SetBool("attack", IsAttacking); //Starts the attack animation
        axeSpinL.SetActive(true);
        axeSpinR.SetActive(true);
        mySpinL.PlayerOrigin = this;
        mySpinR.PlayerOrigin = this;
        yield return new WaitForSeconds(0.5f);


        axeSpinL.SetActive(false);
        axeSpinR.SetActive(false);

        StopAttack(); //Ends the attack

    }

    private IEnumerator Solo(string gotname)
    {
        //Creates a new spell, so that we can use the information form it to cast it in the game

        IsAttacking = true; //Indicates if we are attacking
        mana1.MyCurrentValue -= 0;
        MyAnimator.SetBool("attack", IsAttacking); //Starts the attack animation
        GameObject p = GuitarShooter.GrabObject();
        axeLaunch.SetActive(true);
        myLaunch.PlayerOrigin = this;
        //  totems have no practical use in the dreeam
        p.transform.rotation = currentRotationQuaternion;

        p.transform.position = exitPoints[0].position; //keeps it firing from the front

        yield return new WaitForSeconds(0.1f); //This is a hardcoded cast time, for debugging     



        Projectile q = p.GetComponent<Projectile>();
        q.PlayerOrigin = this;
        q.Initialize(q.MyDamage);
        q.MyBody.velocity = currentRoration * q.MySpeed;
        axeLaunch.SetActive(false);





        StopAttack(); //Ends the attack
    }

    private IEnumerator Jam(string gonam)
    {

        
        isJamming = true;
        isStrumming = true;
        IsAttacking = true; //Indicates if we are attacking
        MyAnimator.SetBool("attack", IsAttacking); //Starts the attack animation
        axeBoom.SetActive(true);
        myBoom.PlayerOrigin = this;
        yield return new WaitForSeconds(0.75f);



        axeBoom.SetActive(false);
        isStrumming = false;
        StopAttack(); //Ends the attack

    }



}