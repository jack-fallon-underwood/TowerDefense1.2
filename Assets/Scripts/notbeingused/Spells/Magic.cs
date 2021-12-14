using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Magic: MonoBehaviour

{

private Vector2 direction;
    private float speed;
    private int damage;
    private float castTime;
    private GameObject projectilePrefab;

    private Animator myAnimator;

    public Vector2 MyDirection
    {
        get
        {
            return direction;
        }

        set
        {
            direction = value;
        }
    }

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
    // Property for reading the speed
    public float MySpeed
    {
        get
        {
            return speed;
        }
    }
    /// <summary>
    /// Property for reading the cast time
    public float MyCastTime
    {
        get
        {
            return castTime;
        }
    }
    /// <summary>
    /// Property for reading the spell's prefab
    public GameObject MyProjectilePrefab
    {
        get
        {
            return projectilePrefab;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Monster")
        {
            myAnimator.SetTrigger("Impact");
        }
    }
}