using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    
    private Transform target;
    public Transform Target     {
        get{ return target; }
        set{ target = value; }
                                }
    /// <summary>
    /// A canvasgroup for the healthbar
    /// </summary>
    [SerializeField]
    private CanvasGroup healthGroup;

    /// <summary>
    /// The enemys current state
    /// </summary>
    protected IState currentState;

    /// <summary>
    /// The enemys attack range
    /// </summary>
    public float MyAttackRange { get; set; }

    /// <summary>
    /// How much time has passed since the last attack
    /// </summary>
    public float MyAttackTime { get; set; }

    public Vector3 MyStartPosition { get; set; }

    [SerializeField]
    public float initAggroRange;

    public float MyAggroRange { get; set; }

    public bool InRange
    {
        get
        {   
            if(MyTarget != null){
            return Vector2.Distance(transform.position, MyTarget.position) < MyAggroRange;
            }
            else{return false;}
        }
    }

    protected PooledObject myDumbAssFace;

    public Player LastPersonToHitMe;
    protected virtual void Awake()
    {   
        
        MyStartPosition = transform.position;
        MyAggroRange = initAggroRange;
        MyAttackRange = 2;
        healthGroup.alpha = 1;
        myDumbAssFace = GetComponent<PooledObject>();
        

        ChangeState(new IdleState());

        if(!(target == null) && (InRange))
        {
            ChangeState(new FollowState());
        }

    }

    private void OnEnable()
    {
        for (int i = 2; i < 2.5; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    protected override void Update()
    {
        base.Update();
  
        HandleLayers();
        
    }

    protected  void FixedUpdate()
    {
       // base.FixedUpdate();

        if (IsAlive)
        {
            if (!IsAttacking)
            {
                MyAttackTime += Time.deltaTime;
            }

            if(!(this is Sender))
            {
             currentState.Update();

              /*  if (health.MyCurrentValue <= 0)
                {
                    myDumbAssFace.ReturnToPool();
                    health.MyCurrentValue = initHealth;
                    Reset();
                }*/
            }       
        }

        if (!(IsAlive))
        {

            LastPersonToHitMe.P1(1);
            myDumbAssFace.ReturnToPool();
            health.MyCurrentValue = initHealth;
            Reset();
        }

    }
    /// <summary>
    /// Makes the enemy take damage when hit
    /// </summary>
    /// <param name="damage"></param>
    public override void TakeDamage(float damage, Transform source)
    {
        if (!(currentState is EvadeState))
        {
            SetTarget(source);

            base.TakeDamage(damage, source);
        }
    }
    /// <summary>
    /// Changes the enemys state
    /// </summary>
    /// <param name="newState">The new state</param>
    public void ChangeState(IState newState)
    {
        if (currentState != null) //Makes sure we have a state before we call exit
        {
            currentState.Exit();
        }

        //Sets the new state
        currentState = newState;

        //Calls enter on the new state
        currentState.Enter(this);
    }

    public void SetTarget(Transform target)
    {
        if (MyTarget == null && !(currentState is EvadeState))
        {
            float distance = Vector2.Distance(transform.position, target.position);
            MyAggroRange = initAggroRange;
            if(!(this is Enemy_Portal) & !(this is Sender)){
            MyAggroRange += distance;}
            MyTarget = target;
        }
    }

    public void Reset()
    {
        this.MyTarget = null;
        this.MyAggroRange = initAggroRange;
        this.MyHealth.MyCurrentValue = this.MyHealth.MyMaxValue;
    }

    public void Spawn(int health)
    {
        transform.position = transform.root.position;
        //this.health.Bar.Reset();
        //failed attempt tonull checkif (this.MyHealth.CuurentValue != 0)
       // {
            this.MyHealth.MyMaxValue = health;
            this.MyHealth.MyCurrentValue = this.MyHealth.MyMaxValue;

            StartCoroutine(Scale(new Vector3(0.1f, 0.1f), new Vector3(1, 1)));
       // }
    }

    public IEnumerator Scale(Vector3 from, Vector3 to)
    {
        float progress = 0;
        while(progress <=1)
        {
            transform.localScale = Vector3.Lerp(from,to,progress);
            progress += Time.deltaTime;
            yield return null;
        }
        transform.localScale = to; 
    }
}
