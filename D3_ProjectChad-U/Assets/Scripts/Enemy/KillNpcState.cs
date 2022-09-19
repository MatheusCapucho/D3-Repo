using UnityEngine;
using System;
using System.Threading.Tasks;

public class KillNpcState : BaseState
{
    private Enemy enemy;
    private Animator anim;

    private float timer = 0f;
    private float endTimer = 2f;

    private ClassroomHolder classroomHolder;

    public KillNpcState(Enemy enemy) : base(enemy.gameObject)
    {
        this.enemy = enemy;
        anim = enemy.GetComponent<Animator>();
        classroomHolder = GameObject.Find("ClassroomHolder").GetComponent<ClassroomHolder>();

    }
    public override Type Tick()
    {

        timer += Time.deltaTime;
        return Attack();

    }

    private  Type Attack()
    {
       

        if (timer < endTimer)
            return typeof(KillNpcState);
        else
        {
            timer = 0f;
            Debug.Log("Attack");
            EndingManager.Instance.NPCKilled();
            classroomHolder.SetNPC();
            return typeof(SearchState);
        }

    }

}
