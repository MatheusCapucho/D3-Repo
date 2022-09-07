using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private Transform _target;
    public StateMachine StateMachine => GetComponent<StateMachine>();

    private void Awake()
    {   
        InitializeStateMachine();
    }

    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(SearchState), new SearchState(this) }//,
        };

        StateMachine.SetStates(states);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

}
