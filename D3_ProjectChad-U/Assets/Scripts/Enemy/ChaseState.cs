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

    // Chase Logic, return typeof(nextState)
    public override Type Tick()
    {
        return typeof(SearchState);
    }
}
