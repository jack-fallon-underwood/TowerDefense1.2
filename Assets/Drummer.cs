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
public class Drummer : Player
{






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
    }

    /// <summary>
    /// We are overriding the characters update function, so that we can execute our own functions
    /// </summary>
    protected override void Update()
    {




        base.Update();


        if (Actions.Attack.WasPressed)
        { Attack(); }
        if (Actions.Solo)
        { Solo(); }
        if (Actions.Jam.WasPressed)
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
        if (mana1.MyCurrentValue > 5)
        {
            StartCoroutine(Attack(projectileType));
        }
    }

    public void Solo()
    {

       
            if (mana1.MyCurrentValue > 20)
        {
            StartCoroutine(Solo(projectileType));
        }
    }

   

    public void Jam()
    {

        // if (isJamming == true || (mana1.MyCurrentValue / mana1.MyMaxValue) > 0.95f)

        //  {
        if (mana1.MyCurrentValue > 40)
        {
            StartCoroutine(Jam(projectileType));
        }
      //  }
    }

   




    private IEnumerator Attack(string goname)
    {

        //Creates a new spell, so that we can use the information form it to cast it in the game
        mana1.MyCurrentValue -= 0;
        IsAttacking = true; //Indicates if we are attacking
        MyAnimator.SetBool("attack", IsAttacking); //Starts the attack animation
        GameObject p = GuitarShooter.GrabObject();
        GameObject pp = GuitarShooter.GrabObject();
        //  totems have no practical use in the dreeam
        p.transform.rotation = currentRotationQuaternion;
        pp.transform.rotation = currentRotationQuaternion;
        p.transform.position = exitPoints[0].position; //keeps it firing from the front
        pp.transform.position = exitPoints[1].position; //keeps it firing from the front
        yield return new WaitForSeconds(0.01f); //This is a hardcoded cast time, for debugging     



        Projectile q = p.GetComponent<Projectile>();
        q.PlayerOrigin = this;
        q.Initialize(q.MyDamage);
        q.MyBody.velocity = currentRoration * q.MySpeed;
        Projectile qq = pp.GetComponent<Projectile>();
        qq.PlayerOrigin = this;
        qq.Initialize(qq.MyDamage);
        qq.MyBody.velocity = currentRoration * qq.MySpeed;




        StopAttack(); //Ends the attack
    }

    private IEnumerator Solo(string gotname)
    {
        //Attack();

        mana1.MyCurrentValue -= 9;
        //Creates a new spell, so that we can use the information form it to cast it in the game

        IsAttacking = true; //Indicates if we are attacking
        MoveVector = Vector3.zero;
        MyAnimator.SetBool("attack", IsAttacking); //Starts the attack animation
        GameObject p = GuitarShooter.GrabObject();
        GameObject pp = GuitarShooter.GrabObject();
        GameObject ppp = GuitarShooter.GrabObject();
        GameObject pppp = GuitarShooter.GrabObject();
        //  totems have no practical use in the dreeam
        p.transform.rotation = currentRotationQuaternion;
        pp.transform.rotation = currentRotationQuaternion;
        p.transform.position = exitPoints[0].position; //keeps it firing from the front
        pp.transform.position = exitPoints[1].position; //keeps it firing from the front
        ppp.transform.rotation = currentRotationQuaternion * Quaternion.Euler(0, 0, 180f);
        pppp.transform.rotation = currentRotationQuaternion * Quaternion.Euler(0, 0, 180f);
        ppp.transform.position = exitPoints[2].position; //keeps it firing from the back
        pppp.transform.position = exitPoints[3].position; //keeps it firing from the back
        yield return new WaitForSeconds(0.1f); //This is a hardcoded cast time, for debugging     



        Projectile q = p.GetComponent<Projectile>();
        q.PlayerOrigin = this;
        q.Initialize(q.MyDamage);
        q.MyBody.velocity = currentRoration * q.MySpeed;

        Projectile qq = pp.GetComponent<Projectile>();
        qq.PlayerOrigin = this;
        qq.Initialize(qq.MyDamage);
        qq.MyBody.velocity = currentRoration * qq.MySpeed;

        Projectile qqq = ppp.GetComponent<Projectile>();
        qqq.PlayerOrigin = this;
        qqq.Initialize(qqq.MyDamage);
        qqq.MyBody.velocity = currentRoration * qqq.MySpeed * -1;

        Projectile qqqq = pppp.GetComponent<Projectile>();
        qqqq.PlayerOrigin = this;
        qqqq.Initialize(qqqq.MyDamage);
        qqqq.MyBody.velocity = currentRoration * qqqq.MySpeed * -1;





        StopAttack(); //Ends the attack
    }

    private IEnumerator Jam(string gonam)
    {
        mana1.MyCurrentValue -= 1;
        //Creates a new spell, so that we can use the information form it to cast it in the game

        IsAttacking = true; //Indicates if we are attacking
       // isJamming = true;
        MyAnimator.SetBool("attack", IsAttacking); //Starts the attack animation
        GameObject p = GuitarShooter.GrabObject();
        GameObject pp = GuitarShooter.GrabObject();
        GameObject ppp = GuitarShooter.GrabObject();
        GameObject pppp = GuitarShooter.GrabObject();
        GameObject p5 = GuitarShooter.GrabObject();
        GameObject pp6 = GuitarShooter.GrabObject();
        GameObject ppp7 = GuitarShooter.GrabObject();
        GameObject pppp8 = GuitarShooter.GrabObject();
        //  totems have no practical use in the dreeam
        p.transform.rotation = currentRotationQuaternion;
        pp.transform.rotation = currentRotationQuaternion;
        p.transform.position = exitPoints[0].position; //keeps it firing from the front
        pp.transform.position = exitPoints[1].position; //keeps it firing from the front
        ppp.transform.rotation = currentRotationQuaternion * Quaternion.Euler(0, 0, 180f);
        pppp.transform.rotation = currentRotationQuaternion * Quaternion.Euler(0, 0, 180f);
        ppp.transform.position = exitPoints[2].position; //keeps it firing from the
        pppp.transform.position = exitPoints[3].position; //keeps it firing from the
                                                          //left and right now   
        p5.transform.rotation = currentRotationQuaternion * Quaternion.Euler(0, 0, 90f);
        pp6.transform.rotation = currentRotationQuaternion * Quaternion.Euler(0, 0, 90f);
        p5.transform.position = exitPoints[4].position; //keeps it firing from the front
        pp6.transform.position = exitPoints[5].position; //keeps it firing from the front
        ppp7.transform.rotation = currentRotationQuaternion * Quaternion.Euler(0, 0, 270f);
        pppp8.transform.rotation = currentRotationQuaternion * Quaternion.Euler(0, 0, 270f);
        ppp7.transform.position = exitPoints[6].position; //keeps it firing from the 
        pppp8.transform.position = exitPoints[7].position; //keeps it firing from the 
        yield return new WaitForSeconds(0.01f); //This is a hardcoded cast time, for debugging    



        Projectile q = p.GetComponent<Projectile>();
        q.MyBody.velocity = currentRoration * q.MySpeed;
        q.PlayerOrigin = this;
        q.Initialize(q.MyDamage);


        Projectile qq = pp.GetComponent<Projectile>();
        qq.PlayerOrigin = this;
        qq.Initialize(qq.MyDamage);
        qq.MyBody.velocity = currentRoration * qq.MySpeed;

        Projectile qqq = ppp.GetComponent<Projectile>();
        qqq.PlayerOrigin = this;
        qqq.Initialize(qqq.MyDamage);
        qqq.MyBody.velocity = currentRoration * qqq.MySpeed * -1;

        Projectile qqqq = pppp.GetComponent<Projectile>();
        qqqq.PlayerOrigin = this;
        qqqq.Initialize(qqqq.MyDamage);
        qqqq.MyBody.velocity = currentRoration * qqqq.MySpeed * -1;


        Projectile q5 = p5.GetComponent<Projectile>();
        q5.PlayerOrigin = this;
        q5.Initialize(q5.MyDamage);
        q5.MyBody.velocity = Rotate(currentRoration, 1.5708f) * q5.MySpeed;

        Projectile qq6 = pp6.GetComponent<Projectile>();
        qq6.PlayerOrigin = this;
        qq6.Initialize(qq6.MyDamage);
        qq6.MyBody.velocity = Rotate(currentRoration, 1.5708f) * qq6.MySpeed;

        Projectile qqq7 = ppp7.GetComponent<Projectile>();
        qqq7.PlayerOrigin = this;
        qqq7.Initialize(qqq7.MyDamage);
        qqq7.MyBody.velocity = Rotate(currentRoration, 1.5708f) * qqq7.MySpeed * -1;

        Projectile qqqq8 = pppp8.GetComponent<Projectile>();
        qqqq8.PlayerOrigin = this;
        qqqq8.Initialize(qqqq8.MyDamage);
        qqqq8.MyBody.velocity = Rotate(currentRoration, 1.5708f) * qqqq8.MySpeed * -1;




        StopAttack(); //Ends the attack  
    }


   
}