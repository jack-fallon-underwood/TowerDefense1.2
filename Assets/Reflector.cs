using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflector : MonoBehaviour
{

    private Collider2D parentCollider;
    private ContactPoint2D myCP;
    private Vector2 myCPVn;
    // Start is called before the first frame update
    void Start()
    {
        parentCollider = GetComponentInParent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myCP = new ContactPoint2D();
        myCPVn = myCP.normal;
       // Debug.Log(collision);
        if (collision is Projectile)
        {//

            Projectile p = collision.GetComponentInParent<Projectile>();
            p.MyDirection = Vector2.Reflect(p.MyDirection, myCPVn);

        }



        if (collision is EvilProjectile)
        {

            EvilProjectile e = collision.GetComponentInParent<EvilProjectile>();
            e.MyDirection = Vector2.Reflect(e.MyDirection, myCPVn);
        


        }
        if (collision is LoveProjectile)
        {
            

   
          
        }

    }
}
