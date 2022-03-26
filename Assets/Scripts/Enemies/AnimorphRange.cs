using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimorphRange : MonoBehaviour

{

    private Enemy parent;

    private CircleCollider2D finalCollider;

    private bool IsVamping = false;
    [SerializeField] private int newSpeed;
    [SerializeField] private int newHealth;

    private void Start()
    {
        parent = GetComponentInParent<Enemy>();
        
        //initalCollider = parent.GetComponent<PolygonCollider2D>();
        finalCollider = parent.gameObject.GetComponent<CircleCollider2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsVamping = true;
            parent.SetTarget(collision.transform);
            parent.MovementSpd = newSpeed;
            parent.MyHealth.MyCurrentValue = newHealth;
            parent.ActivateLayer("VampLayer");
            parent.MyAnimator.SetBool("vamping", IsVamping);
            this.finalCollider.enabled = true;

            // parent.ChangeState(new FollowState());
        }
    }
}
