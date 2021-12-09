using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Portal : Enemy
{
    private bool isSpawning;
    private bool isOutOfEnemies = true;
    private Animator myAnimator;
    private CircleCollider2D mySpace;
    public RigidbodySleepMode2D sleepMode;


    private GameObject enemyManager;
    private ObjectPooler eS;


    // Start is called before the first frame update
    void Start()
    {
        mySpace = GetComponent<CircleCollider2D>();
        myAnimator = GetComponent<Animator>();
        base.Start();
        eS = GetComponentInChildren<ObjectPooler>();
        enemyManager = eS.gameObject;
        PoopEnemy();
    }

    // Update is called once per frame
    void Update()
    {   

        
        base.Update();

        if(enemyManager.transform.childCount >= 1)
        {
            isOutOfEnemies = false;

        }
        
        else
        {
            isOutOfEnemies = true;
        }


        if(IsAlive ==false)
        {
            mySpriteRenderer2D.color = Color.red;
            mySpace.enabled = false;
            myRigidbody.Sleep();
        }

        else
        {
            
            if (InRange == true)
            {
                if (isSpawning == false)
                {
                    if (isOutOfEnemies == false)
                    {
                        StartCoroutine(PoopEnemy());
                    }

                }
            }
        }
        

        
       
    }

    public void Open()
    {
        myAnimator.SetTrigger("Open");
    }

    public IEnumerator PoopEnemy()
    {
     
        Open();
        isSpawning = true; //Indicates if we are spwaning an enemy
        yield return new WaitForSeconds(1);
        GameObject p = eS.GrabObject();
        p.transform.position = this.transform.position;
        isSpawning = false;
        
        Enemy q = p.GetComponent<Enemy>();
    }
}

