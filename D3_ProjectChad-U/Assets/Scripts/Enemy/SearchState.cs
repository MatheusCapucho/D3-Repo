using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{
    private Enemy enemy;

    public SearchState(Enemy enemy) : base (enemy.gameObject)
    {
        this.enemy = enemy;
    }

    // Search Logic, return typeof(nextState)
    public override Type Tick()
    {
        return typeof(SearchState);
    }
}
