using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimorphRange : MonoBehaviour

{

    private Enemy parent;
    private GameObject parentGO;
    private CircleCollider2D finalCollider;

    private bool IsVamping = false;
    [SerializeField] private int newSpeed;

    private void Start()
    {
        parent = GetComponentInParent<Enemy>();
        parentGO = GetComponentInParent<GameObject>();
        //initalCollider = parent.GetComponent<PolygonCollider2D>();
        finalCollider = parentGO.GetComponent<CircleCollider2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsVamping = true;
            parent.SetTarget(collision.transform);
            parent.MovementSpd = newSpeed;
            parent.ActivateLayer("VampLayer");
            parent.MyAnimator.SetBool("vamping", IsVamping);
            finalCollider.enabled = true;

            // parent.ChangeState(new FollowState());
        }
    }
}
