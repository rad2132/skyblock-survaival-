using UnityEngine;

public class ZombieAI : AI
{

    private void FixedUpdate()
    {
        FollowTarget();
    }
    public override void FollowTarget()
    {
        base.FollowTarget();
        if (DistanceToTarget <= AttackDistance )
        {
            Attack();
        }
    }

    public override void Attack()
    {
        base.Attack();
    }
}
