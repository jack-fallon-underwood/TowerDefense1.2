using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooter : Enemy
{

    /// <summary>
    /// Exit points for the spells
    /// </summary>
    [SerializeField]
    private Transform[] exitPoints;

    /// <summary>
    /// Index that keeps track of which exit point to use, 2 is default down
    /// </summary>
    private int exitIndex = 0;

    [SerializeField] private ObjectPooler GuitarShooter;

    private Vector3 min, max, moveDirection = Vector3.zero;
    private Vector2 currentRoration;
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

        if (InRange == true && !IsAttacking)
        {
            StartCoroutine(Attack("ydoineedastring"));
        }
    }

    private IEnumerator Attack(string goname)
    {

        //Creates a new spell, so that we can use the information form it to cast it in the game

        IsAttacking = true; //Indicates if we are attacking
        MyAnimator.SetBool("attack", IsAttacking); //Starts the attack animation
        GameObject p = GuitarShooter.GrabObject();
        p.transform.position = exitPoints[0].position; //keeps it firing from the front
        yield return new WaitForSeconds(0.25f); //This is a hardcoded cast time, for debugging 
        EvilProjectile q = p.GetComponent<EvilProjectile>();
        q.Initialize(q.MyDamage);
        Debug.Log(q.MyEvilBody);
        q.MyEvilBody.velocity = (MyTarget.position - q.transform.position);// * -1 * q.MySpeed;


        IsAttacking = false;

    }
}
