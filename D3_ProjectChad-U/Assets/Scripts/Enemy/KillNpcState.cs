using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KillNpcState : BaseState
{
    private Enemy enemy;
    public KillNpcState(Enemy enemy) : base(enemy.gameObject)
    {
        this.enemy = enemy;

    }
    public override Type Tick()
    {
        return typeof(KillNpcState);
    }
}
