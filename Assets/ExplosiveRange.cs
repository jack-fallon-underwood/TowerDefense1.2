using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveRange : MonoBehaviour

{

    private Kamikazee parent;





    private void Start()
    {
        parent = GetComponentInParent<Kamikazee>();
        



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.DropPayLoad();
           
        }
    }
}
