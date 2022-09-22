using UnityEngine;
using System;
using System.Threading.Tasks;

public class KillNpcState : BaseState
{
    private Enemy enemy;
    private Animator anim;

    private float timer = 0f;
    private float endTimer = 4f;

    private ClassroomHolder classroomHolder;

    public KillNpcState(Enemy enemy) : base(enemy.gameObject)
    {
        this.enemy = enemy;
        anim = enemy.GetComponent<Animator>();
        classroomHolder = GameObject.Find("ClassroomHolder").GetComponent<ClassroomHolder>();

    }
    public override Type Tick()
    {
        if (CheckFOV())
            return typeof(ChaseState);
       
        timer += Time.deltaTime;
        return Attack();

    }

    private  Type Attack()
    {
       

        if (timer < endTimer)
        {
            //AtackAnim - trigger 1x
            return typeof(KillNpcState);
        }
        else
        {
            timer = 0f;
            Debug.Log("Destroyed");
            enemy.Target.gameObject.SetActive(false);
            enemy.SetTarget(null);

            EndingManager.Instance.NPCKilled();
            classroomHolder.SetNPC();
            return typeof(SearchState);
        }

    }


    private bool CheckFOV()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, enemy.detectionRadius, enemy.targetMask);

        if (colliders.Length > 0)
        {
            Transform player = colliders[0].transform;
            Vector3 dir = (player.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dir) < enemy.detectionAngle / 2)
            {
                float distance = Vector3.Distance(transform.position, player.position);

                if (!Physics.Raycast(transform.position, dir, distance, enemy.wallMask))
                {
                    enemy.SetTarget(player);
                    return true;
                }
            }
        }

        return false;
    }

}
