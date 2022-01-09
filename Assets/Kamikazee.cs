using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikazee : Enemy
{

    [SerializeField] protected GameObject payLoad;
    [SerializeField] protected float payLoadSpeed;
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

    public IEnumerator DropPayLoad()

    {
        payLoad.active = true;

        yield return new WaitForSeconds(payLoadSpeed);
        payLoad.active = false;
        TakeDamage(500, MyTarget);
    }
}
