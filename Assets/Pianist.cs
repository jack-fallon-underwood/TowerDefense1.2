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
public class Pianist : Player
{
    [SerializeField] private GameObject pianoHit;
    [SerializeField] private GameObject pianoBurst;
    private Axe myHit;
    private Axe myBurst;
    private bool isStrumming;

    protected string NotSureWhyMyAttackFunctionNeedsAnOBjectCalledGOname;

    [SerializeField] protected ObjectPooler HealthShooter;






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
        myHit = pianoHit.GetComponent<Axe>();
        myBurst = pianoBurst.GetComponent<Axe>();
 
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


        if (mana1.MyCurrentValue > 0)
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
        pianoHit.SetActive(true);
        myHit.PlayerOrigin = this;
        yield return new WaitForSeconds(0.3f);


        pianoHit.SetActive(false);

        StopAttack(); //Ends the attack

    }

    private IEnumerator Solo(string gotname)
    {
        //Attack();

        mana1.MyCurrentValue -= 3;
        //Creates a new spell, so that we can use the information form it to cast it in the game

        IsAttacking = true; //Indicates if we are attacking
        MyAnimator.SetBool("attack", IsAttacking); //Starts the attack animation
        //Creates a new spell, so that we can use the information form it to cast it in the game

       
        GameObject p = GuitarShooter.GrabObject();
        GameObject pp = HealthShooter.GrabObject();
        //  totems have no practical use in the dreeam
        p.transform.rotation = currentRotationQuaternion;
        pp.transform.rotation = currentRotationQuaternion;
        p.transform.position = exitPoints[0].position; //keeps it firing from the front
        pp.transform.position = exitPoints[1].position; //keeps it firing from the front
        yield return new WaitForSeconds(0.01f); //This is a hardcoded cast time, for debugging     



        LoveProjectile q = p.GetComponent<LoveProjectile>();
        q.PlayerOrigin2 = this;
        q.Initialize(q.MyDamage);
        q.MyBody.velocity = currentRoration * q.MySpeed;
        Projectile qq = pp.GetComponent<Projectile>();
        qq.PlayerOrigin = this;
        qq.Initialize(qq.MyDamage);
        qq.MyBody.velocity = currentRoration * qq.MySpeed;




        StopAttack(); //Ends the attack
    }

    private IEnumerator Jam(string gonam)
    {

        isJamming = true;
        isStrumming = true;
        IsAttacking = true; //Indicates if we are attacking
        MyAnimator.SetBool("attack", IsAttacking); //Starts the attack animation
        LoveAxe q = pianoBurst.GetComponent<LoveAxe>();
        q.PlayerOrigin3 = this;
        q.Initialize(q.MyDamage);
        pianoBurst.SetActive(true);
        myBurst.PlayerOrigin = this;
        yield return new WaitForSeconds(0.4f);



        pianoBurst.SetActive(false);
        isStrumming = false;
        StopAttack(); //Ends the attack 
    }



}