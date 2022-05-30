using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy  : Enemy
{
    [SerializeField] private Enemy[] Enemies;

    private int inside;
    
    protected virtual void Awake()
    {   
        inside = Random.Range(0,8);
        base.Awake();
    
    }
   

    protected override void Update()
    {
        base.Update();
  
        
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
            SpawnInside();
            LastPersonToHitMe.P1(1);
            myDumbAssFace.ReturnToPool();
            health.MyCurrentValue = initHealth;
            Reset();
        }
    }

    private void SpawnInside()
    {
        Enemies[inside].gameObject.SetActive(true);
        Enemies[inside].transform.parent = null;
    }
}
