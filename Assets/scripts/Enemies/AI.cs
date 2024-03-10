using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField]
    protected Transform Target;
    protected NavMeshAgent Agent;
    [SerializeField]
    protected float Speed = 4f;
    [SerializeField]
    protected float ViewRadius = 20f;
    [SerializeField]
    protected float AttackDistance = 3f;
    [SerializeField]
    protected int Damage;
    [SerializeField]
    protected float AttackCooldown;
    protected float TimeUntilAttack = 0;
    protected float DistanceToTarget;
    private void Start()
    {
        Target = Player.Instance.transform;
        Agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        FollowTarget();
    }

    public virtual void FollowTarget()
    {
        DistanceToTarget = Vector3.Distance(Target.position, transform.position);
        if (DistanceToTarget <= ViewRadius)
        {
            Agent.SetDestination(Target.position);
            Agent.speed = Speed;
            transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));
        }
        else
        {
            Agent.speed = 0;
        }
    }
    
    public virtual void Attack()
    {
        if(TimeUntilAttack<=0)
        {
            try
            {
                Target.GetComponent<Health>().ChangeHealthValue(-Damage);
                Debug.Log("attack");
            }
            catch 
            {
            }
            TimeUntilAttack = AttackCooldown;
        }
        else TimeUntilAttack -= Time.deltaTime;
    }
}
