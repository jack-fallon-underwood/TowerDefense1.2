using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glut : Enemy
{
    //Vector to help control its size
    private Vector3 muddy = new Vector3(9f, 9f,1f);
    private float sizeVariable;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    protected virtual void Awake()
    {
        base.Awake();
    }

        // Update is called once per frame
        void Update()
    {
        base.Update();
    }

    // Fixed---------------------------------- per frame
    void FixedUpdate()
    {

       sizeVariable = health.MyCurrentValue / initHealth;
        health.MyCurrentValue += 0.5f;
       muddy = new Vector3(3.0f * sizeVariable, 3.0f * sizeVariable, 1);
       this.transform.localScale = muddy;
    
        base.FixedUpdate();

        if(sizeVariable <= 0.05f)
        {
            myDumbAssFace.ReturnToPool();
            health.MyCurrentValue = initHealth;
            Reset();
        }
    }
}
