using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControllerForMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] checkpoints;
    private NavMeshAgent AI;
    private int currentCheckpoint;
    void Awake()
    {
        AI = GetComponent<NavMeshAgent>();
        int currentCheckpoint = 0;
        AI.destination = checkpoints[currentCheckpoint].transform.GetChild(Random.Range(1,6)).transform.position;
    }
    void Update()
    {
        if (AI.remainingDistance <= 5f)
        {
            currentCheckpoint++;
            if (currentCheckpoint >= checkpoints.Length)
            {
                currentCheckpoint = 0;
            }
            AI.destination = checkpoints[currentCheckpoint].transform.GetChild(Random.Range(1,6)).transform.position;
}
}
}