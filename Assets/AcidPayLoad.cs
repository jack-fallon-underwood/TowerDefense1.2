using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

public class AcidPayLoad : MonoBehaviour
{

    [SerializeField] private int damage = 8;
    [SerializeField] private float castTime;
    private PooledObject myDumbAssFace;

    //so the poison only hurts every few seconds
    private float nextActionTime = 0.0f;
    public float period = 1.0f;

    /// <summary>
    /// Property for reading the damage
    public int MyDamage
    {
        get
        {
            return damage;
        }

    }
    /// <summary>
    // Property for reading the currentspeed
    

    // Start is called before the first frame update
    void Start()
    {
        myDumbAssFace = GetComponent<PooledObject>();
    }
    public void Initialize(int damage)
    {
        this.damage = damage;

        StartCoroutine(Decay("noidea"));
    }
    // Update is called once per frame
    void Update()
    {
        
      
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Time.time > nextActionTime)
        {
            if (!collision == null)
            {
                Character c = collision.GetComponentInParent<Player>();
                c.TakeDamage(damage, this.transform);
                nextActionTime = Time.time + period;
            }
        }

    }

    private IEnumerator Decay(string nounderstand)
    {

        //Creates a new spell, so that we can use the information form it to cast it in the game


        yield return new WaitForSeconds(4.01f); //This is a hardcoded cast time, for debugging 
        myDumbAssFace.ReturnToPool();



    }

}
