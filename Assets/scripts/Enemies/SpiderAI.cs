using System.Collections;
using UnityEngine;

public class SpiderAI : AI
{
    [SerializeField]
    private float JumpHeight;

    private void FixedUpdate()
    {
        FollowTarget();
    }
    public override void FollowTarget()
    {  
            base.FollowTarget();
            if (DistanceToTarget <= AttackDistance)
            {
                Attack();
            }      
    }

    public override void Attack()
    {
       base.Attack();

    }

 
}
