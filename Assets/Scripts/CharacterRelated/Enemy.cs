using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
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
    private IState currentState;

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
    private float initAggroRange;

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

    private PooledObject myDumbAssFace;
    protected virtual void Awake()
    {   
        
        MyStartPosition = transform.position;
        MyAggroRange = initAggroRange;
        MyAttackRange = 3;
        healthGroup.alpha = 1;
        myDumbAssFace = GetComponent<PooledObject>();
        

        ChangeState(new IdleState());

        if(!(target == null) && (InRange))
        {
            ChangeState(new FollowState());
        }
        
        
    }

    protected override void Update()
    {

        base.Update();

        if (IsAlive)
        {

            if (!IsAttacking)
            {
                MyAttackTime += Time.deltaTime;
            }

            if(!(this is Enemy_Portal) & !(this is Sender))
            {
            currentState.Update();

                if (health.MyCurrentValue <= 0)
                {
                    myDumbAssFace.ReturnToPool();
                    health.MyCurrentValue = initHealth;
                    Reset();
                }
            }       
        }

        

        if (health.MyCurrentValue <= 0 && !(this is Enemy_Portal))
        {
            myDumbAssFace.ReturnToPool();
            health.MyCurrentValue = initHealth;
            Reset();
        }

    }

  

    /// <summary>
    /// When the enemy is selected
    /// </summary>
    /// <returns></returns>
    public override Transform Select()
    {
        //Shows the health bar
        healthGroup.alpha = 1;

        return base.Select();
    }

    /// <summary>
    /// When we deselect our enemy
    /// </summary>
    public override void DeSelect()
    {
        //Hides the healthbar
        healthGroup.alpha = 0;

        base.DeSelect();
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

            OnHealthChanged(health.MyCurrentValue);
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
        OnHealthChanged(health.MyCurrentValue);
    }

    public void Spawn(int health)
    {
        transform.position = transform.root.position;
        //this.health.Bar.Reset();
        this.MyHealth.MyMaxValue = health;
        this.MyHealth.MyCurrentValue = this.MyHealth.MyMaxValue;

        StartCoroutine(Scale(new Vector3(0.1f,0.1f), new Vector3(1,1)));
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
