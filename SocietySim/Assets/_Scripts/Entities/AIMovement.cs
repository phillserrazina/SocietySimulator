using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : Movement
{
    // VARIABLES

    private NavMeshAgent navMeshAgent;
    private NavMeshPath navMeshPath;
    [SerializeField] private float newPathTimer = 0;
    private bool inCoroutine;
    private Vector3 currentTarget;

    // EXECUTION FUNCTIONS

    private void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshPath = new NavMeshPath();
    }

    private void Update() {
        if (!inCoroutine) StartCoroutine(WalkToDestination());
    }

    // METHODS

    private IEnumerator WalkToDestination() {
        inCoroutine = true;
        yield return new WaitForSeconds(newPathTimer);
        GetNewPath();

        bool validPath = navMeshAgent.CalculatePath(currentTarget, navMeshPath);
        while (!validPath) {
            yield return new WaitForSeconds(0.01f);
            GetNewPath();
            validPath = navMeshAgent.CalculatePath(currentTarget, navMeshPath);
        }

        newPathTimer = Random.Range(2, 10);
        inCoroutine = false;
    }

    private Vector3 GetNewRandomPos() {
        float x = Random.Range(-100, 100);
        float z = Random.Range(-100, 100);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }

    private void GetNewPath() {
        currentTarget = GetNewRandomPos();
        navMeshAgent.SetDestination(currentTarget);
    }
}
