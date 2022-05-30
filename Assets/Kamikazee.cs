using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikazee : Enemy
{

    [SerializeField] protected GameObject payLoad;
    [SerializeField] protected float payLoadSpeed;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

     
    }

    void FixedUpdate()
    {
        if (IsAlive)
        {
            if (!IsAttacking)
            {
                MyAttackTime += Time.deltaTime;
            }

            if (!(this is Sender))
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
            DropPayLoad();
            myDumbAssFace.ReturnToPool();
            health.MyCurrentValue = initHealth;
            Reset();
        }


    }

    public void DropPayLoad()

    {
        payLoad.active = true;
        payLoad.transform.SetParent(null);
        TakeDamage(500, MyTarget);
    }
}
