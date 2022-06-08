using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIcheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject[] checkpoints;
    public NavMeshAgent AI;
    public GameObject player;
    public int lapsDone;
    public int currentCheckpoint;
    public int currentLap;
    public int totalCheckpoints;
    void Awake()
    {
        AI = GetComponent<NavMeshAgent>();
        currentCheckpoint = 0;
        totalCheckpoints = 0;
        currentLap = 1;
        if(player.GetComponent<CarController>().enable)
        {
            AI.destination = checkpoints[currentCheckpoint].transform.GetChild(Random.Range(1,6)).transform.position;
        }
    }
    void Update()
    {     
        if(player.GetComponent<CarController>().enable){
            if (currentCheckpoint == checkpoints.Length - 1)
        {
            if(AI.remainingDistance <= 5f)
            {
                currentCheckpoint = 0;
                currentLap++;
                totalCheckpoints++;
                AI.destination = checkpoints[currentCheckpoint].transform.GetChild(Random.Range(1,6)).transform.position;
            }
        }

        else
        {
            if (AI.remainingDistance <= 5f)
        {
            currentCheckpoint++;
            totalCheckpoints++;
            AI.destination = checkpoints[currentCheckpoint].transform.GetChild(Random.Range(1,6)).transform.position;
        }
        }
        }
    }
        
}