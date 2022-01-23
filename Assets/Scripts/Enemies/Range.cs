using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    private Enemy parent;

    private void Awake()
    {
        gameObject.layer = 3;
        parent = GetComponentInParent<Enemy>();

        //inn an attempt to reducce collision tags, most enemies will start with the target of their portals
        if(parent.Target != null)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            parent.SetTarget(collision.transform);
            parent.ChangeState(new FollowState());
            this.gameObject.SetActive(false);
        }

        
    }


    private void Update()
    {
        if (parent.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(true);
        }
    }
}
