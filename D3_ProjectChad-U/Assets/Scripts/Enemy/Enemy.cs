using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform Target { get; private set; }
    public StateMachine StateMachine => GetComponent<StateMachine>();
    private NavMeshAgent agent => GetComponent<NavMeshAgent>();


    [Header("Masks")]  
    public LayerMask targetMask;  
    public LayerMask wallMask;

    [Header("Field of View")]
    public float detectionRadius = 5f;
    [Range(0, 360)]
    public float detectionAngle = 120f;

    private void Awake()
    {
        Target = null;
        InitializeStateMachine();
    }

    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(SearchState), new SearchState(this) },
            { typeof(ChaseState), new ChaseState(this) }
        };

        StateMachine.SetStates(states);
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }

    private void FixedUpdate()
    {
        if (Target != null)
        agent.destination = Target.position;
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}
