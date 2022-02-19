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
public class Player : Character
{
    public int Frames = 0;
    public PlayerActions Actions { get; set; }


    /// <summary>
    /// The Player's InputVecor;
    /// </summary>
    private Vector2 InputVector;



    public int playerIndex;
    public string playerName;

    public int GetPlayerIndex()
    {
        return playerIndex;
        playerName = playerIndex.ToString();
    }

    protected string NotSureWhyMyAttackFunctionNeedsAnOBjectCalledGOname;
    protected PlayerControls controls;

     //Defense stats
   // [SerializeField] private int helmetD1;
   // [SerializeField] private int shieldD1;
   // [SerializeField] private int bootsD1;

        [SerializeField] private int endurance;
        [SerializeField] private int attackSpeed = 30;

         public float MyAttackSpeed
    {
        get
        {
            return attackSpeed;
        }
    }
    

    /// <summary>
    /// The player's mana
    [SerializeField]
    protected Stat mana1;

    

    [SerializeField]
    private Stat exp1;

    //[SerializeField]
   // private Text levelText;



    /// <summary>
    /// Exit points for the spells
    /// </summary>
    [SerializeField]
    protected Transform[] exitPoints;

    /// <summary>
    /// Index that keeps track of which exit point to use, 2 is default down
    /// </summary>
    protected int exitIndex = 0;

    [SerializeField] protected ObjectPooler GuitarShooter;

    /// <summary>
    /// The player's initial mana
    /// </summary>
    [SerializeField] private float initMana = 50;
    private Image manabar;

    [SerializeField] protected string projectileType;


    private static Player instance;

    public static Player MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
            }

            return instance;
        }
    }

    protected bool isJamming = false;

    protected Vector3 min, max, moveDirection = Vector3.zero;
    protected Vector2 currentRoration;
    protected Quaternion currentRotationQuaternion;


  

    [SerializeField] protected GameObject mySprite;
    [SerializeField] protected GameObject myDrumExits;

    [SerializeField] protected GameObject MyPlayerPanel;
    protected GameObject PlayerPanelDestination;
    [SerializeField] protected GameObject mainCamera;
    protected CameraFollow mainCam;


    private float dashTimer, dashDuration =1;


    protected override void Start()
    {
        gameObject.layer = 6;
        DontDestroyOnLoad(this.gameObject);
 
        base.Start();

    }


    protected void Awake ()
    {
        controls = new PlayerControls();
        //controls.Gameplay.Attack.performed += Attack;



      mana1.Initialize(initMana, initMana);
      manabar = mana1.GetComponent<Image>();
    //    exp1.Initialize(0, Mathf.Floor(100*MyLevel*Mathf.Pow(MyLevel, 0.5f)));
     //   levelText.text = MyLevel.ToString();
        base.Start();
        PlayerPanelDestination = GameObject.Find("PlayerPanels");//.GetComponent<GameObject>();
        MyPlayerPanel.transform.parent = PlayerPanelDestination.transform;
        mainCamera = GameObject.Find("Main Camera");
        mainCam = mainCamera.GetComponent<CameraFollow>();
        mainCam.Players.Add(this);


        
       // controls = new PlayerControls();

       // controls.Gameplay.Attack.performed += ctx => Attack(NotSureWhyMyAttackFunctionNeedsAnOBjectCalledGOname);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        dashTimer += Time.deltaTime;
        if (dashTimer >= dashDuration)
        {
            if (Actions.Dash.)
            {
                Dash();
            }
            dashTimer = 0;
        }
    }
    /// <summary>
    /// We are overriding the characters update function, so that we can execute our own functions
    /// </summary>
    protected override void Update()
    {


        //Clamps the player inside the tilemap
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, min.x, max.x), 
            //Mathf.Clamp(transform.position.y, min.y, max.y), transform.position.z);

    moveDirection = new Vector3(Actions.Walk.X, Actions.Walk.Y, 0);


        //currentRotationQuaternion = Quaternion.LookRotation(moveDirection, Vector3.forward);

        //transform.rotation = Quaternion.LookRotation(Vector3.forward,-(moveDirection));
        // moveDirection = transform.TransformDirection(moveDirection);

        //moveDirection = moveDirection * MovementSpd;
        MoveVector = moveDirection;
    Move(moveDirection);


           
        base.Update();


      


        if (Actions.Walk.X != 0 || Actions.Walk.Y != 0)
        {
        var angle = (Mathf.Atan2(Actions.Walk.X * -1, Actions.Walk.Y) * Mathf.Rad2Deg);
        currentRotationQuaternion = (Quaternion.AngleAxis(angle, Vector3.forward));
        currentRoration = new Vector2 (Actions.Walk.X, Actions.Walk.Y);
       mySprite.transform.rotation = currentRotationQuaternion;
       myDrumExits.transform.rotation = currentRotationQuaternion;
        }
       

        
        if(isJamming == true)
        {
            manabar.color = new Color32(255,155,0,255);
            DrainManaPool();


           if(mana1.MyCurrentValue == 0)
           {
               isJamming = false;
                manabar.color = new Color32(26,75,228,255);
           }
            
        }
       
        if(isJamming == false)
        {
            FillManaPool();
        }
      

        

    }
    protected void LateUpdate()
    {
        Frames++;
     if (Frames % 9 == 0) { //If the remainder of the current frame divided by 10 is 0 run the function.
        //mana1.MyCurrentValue += 1;
        moveDirection = transform.position;}



        
    }

    void OnDisable()
    {
        if (Actions != null)
        {
            Actions.Destroy();
        }
    }

    void Dash()
    {
     
            StartCoroutine(DashCoroutine());


    }

    private IEnumerator DashCoroutine()
    {
        float startTime = Time.time; // need to remember this to know how long to dash
        while (Time.time < startTime + 0.4f)
        {
            transform.Translate(moveDirection * 10 * Time.deltaTime);
            // or controller.Move(...), dunno about that script
            yield return null; // this will make Unity stop here and continue next frame
        }

    }

    void LChangeItem()
    {

    }

    void RChangeItem()
    {

    }

    void Pause()
    {

    }


    private void FillManaPool()
    {
         if (Frames % 20 == 0) { //If the remainder of the current frame divided by 20 is 0 run the function.
        mana1.MyCurrentValue += 1;

        }
    }

      private void DrainManaPool()
    {
         if (Frames % 5 == 0) { //If the remainder of the current frame divided by 5 is 0 run the function.
        mana1.MyCurrentValue -= (25/endurance);

        }

    }


    protected static Vector2 Rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }





    /// <summary>
    /// Set's the player's limits so that he can't leave the game world
    /// </summary>
    /// <param name="min">The minimum position of the player</param>
    /// <param name="max">The maximum postion of the player</param>
    public void SetLimits(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;

    }

    public void SetInputVector(Vector2 direction)
    {
        InputVector = direction;

    }

   



    public void P1(int xp)
    {
    exp1.MyCurrentValue += xp;

    if (exp1.MyCurrentValue >= exp1.MyMaxValue)
    {
        StartCoroutine(Ding());

    }}

    private IEnumerator Ding()
    {
        while (!exp1.IsFull)
        {
        yield return null;  

        }
 
        MyLevel++;
        //levelText.text = MyLevel.ToString();
        exp1.MyMaxValue = 100 * MyLevel*Mathf.Pow(MyLevel, 0.5f);
        exp1.MyMaxValue = Mathf.Floor(exp1.MyMaxValue);
        exp1.MyCurrentValue = exp1.MyOverflow;
        exp1.Reset();

    }

    /// <summary>
    /// Stops the attack
    /// </summary>
    public void StopAttack()
    {

        IsAttacking = false; //Makes sure that we are not attacking

        MyAnimator.SetBool("attack", IsAttacking); //Stops the attack animation

        if (attackRoutine != null) //Checks if we have a reference to an co routine
        {
            StopCoroutine(attackRoutine);
        }
    }
}