using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISpawner : MonoBehaviour
{
    [SerializeField] private GameObject agentPrefab = null;
    [SerializeField] private Transform agentsParent = null;
    private Mesh navMesh;

    private const int NUM_OF_CITIZENS = 50;

    private void Start() {
        NavMeshTriangulation triangulatedNavMesh = NavMesh.CalculateTriangulation();
        navMesh = new Mesh();
        navMesh.vertices = triangulatedNavMesh.vertices;

        for (int i = 0; i < NUM_OF_CITIZENS; i++) {
            GameObject go = Instantiate(agentPrefab, GetRandomPoint(), Quaternion.identity);
            go.transform.parent = agentsParent;
        }
    }

    private Vector3 GetRandomPoint() {
        Vector3 p1 = navMesh.vertices[Random.Range(0, navMesh.vertexCount)];
        Vector3 p2 = navMesh.vertices[Random.Range(0, navMesh.vertexCount)];

        Vector3 ans = Vector3.Lerp(p1, p2, Random.value);
        ans.y = 1;

        return ans;
    }
}
