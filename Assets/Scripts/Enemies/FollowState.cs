using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/// <summary>
/// The enmy's follow state
/// </summary>
class FollowState : IState
{
    /// <summary>
    /// A reference to the parent
    /// </summary>
    private Enemy parent;
    private float myAngle;
    private Vector2 currentRoration;
    private Quaternion currentRotationQuaternion;

    /// <summary>
    /// This is called whenever we enter the state
    /// </summary>
    /// <param name="parent">The parent enemy</param>
    public void Enter(Enemy parent)
    {
        this.parent = parent;


        
    }

    /// <summary>
    /// This is called whenever we exit the state
    /// </summary>
    public void Exit()
    {
        //parent.Direction = Vector2.zero;
    }

    /// <summary>
    /// This is called as long as we are inside the state
    /// </summary>
    /// 
   

    public void Update()
    {
   
        if (parent.MyTarget != null)//As long as we have a target, then we need to keep moving
        {
             //Find the target's direction
            parent.MoveVector = (parent.MyTarget.transform.position - parent.transform.position).normalized;

            //Moves the enemy towards the target
            parent.transform.position = Vector2.MoveTowards(parent.transform.position, parent.MyTarget.position, parent.MovementSpd * Time.deltaTime);

            //get the enemies to rotate towards their targets
            myAngle = (Mathf.Atan2(parent.MoveVector.x * -1, parent.MoveVector.y) * Mathf.Rad2Deg);
            currentRotationQuaternion = (Quaternion.AngleAxis(myAngle, Vector3.forward));
            currentRoration = new Vector2(parent.MoveVector.x, parent.MoveVector.y);
            parent.transform.rotation = currentRotationQuaternion;



            float distance = Vector2.Distance(parent.MyTarget.position, parent.transform.position);

            if (distance <= parent.MyAttackRange)
            {
                parent.ChangeState(new AttackState());
            }

        }
        if (!parent.InRange)
        {
            parent.ChangeState(new IdleState());
        } //if we don't have a target, then we need to go back to idle.

    }
}
