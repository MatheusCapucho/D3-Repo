using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{
    private Enemy enemy;
    private GameObject[] classroom;
    private bool[] visited = new bool[3];
    private ClassroomHolder classroomHolder;

    private int _currentTargetID = 0;
    public SearchState(Enemy enemy) : base (enemy.gameObject)
    {
        this.enemy = enemy;
        classroom = GameObject.FindGameObjectsWithTag("Classroom");
        classroomHolder = GameObject.Find("ClassroomHolder").GetComponent<ClassroomHolder>();
    }

    public override Type Tick()
    {
        if (enemy.Target == null)
            SearchTarget();

        if (CheckFOV())
            return typeof(ChaseState);

        if (ReachedTarget())
            return typeof(KillNpcState);
            

        return typeof(SearchState);
    }

    private void SearchTarget()
    {
        int rng = UnityEngine.Random.Range(0, 3);
        _currentTargetID = rng;
        var target = classroom[_currentTargetID].transform;
        if (visited[_currentTargetID] && !AllVisited())
        {
            SearchTarget();
            return;
        }
        enemy.SetTarget(target);
    }

    private bool AllVisited()
    {
        for (int i = 0; i < visited.Length; i++)
            if (!visited[i])
                return false;

        return true;

    }

    private bool ReachedTarget()
    {
        var distance = Vector3.Distance(transform.position, enemy.Target.position);
        if (distance < 0.8f)
        {
            visited[_currentTargetID] = true;
            if (classroomHolder.GetNPC(_currentTargetID))
                return true;
            else
                SearchTarget();
        }
        return false;
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
