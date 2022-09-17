using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChaseState : BaseState
{
    private Enemy enemy;
   

    public ChaseState(Enemy enemy) : base(enemy.gameObject)
    {
        this.enemy = enemy;
      
    }
    public override Type Tick()
    {
        if (!PlayerInRange())
            return typeof(SearchState);

        if (AttackRange())
        {

        }

        return typeof(ChaseState);
    }

    private bool PlayerInRange()
    {
        var distance = Vector3.Distance(transform.position, enemy.Target.position);
        if (distance < enemy.detectionRadius + 1f)
            return true;

        enemy.SetTarget(null);
        return false;
    }

    private bool AttackRange()
    {
        return false;
    }

   

}
