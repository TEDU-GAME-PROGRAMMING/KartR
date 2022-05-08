using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIcheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject[] checkpoints;
    private NavMeshAgent AI;
    private int currentCheckpoint;
    public GameObject player;
    public int lapsDone;
    void Awake()
    {
        AI = GetComponent<NavMeshAgent>();
        int currentCheckpoint = 0;
        if(player.GetComponent<CarController>().enable)
        {
            AI.destination = checkpoints[currentCheckpoint].transform.GetChild(Random.Range(1,6)).transform.position;
        }
        
    }
    void Update()
    {     
        if(player.GetComponent<CarController>().enable){
            if (AI.remainingDistance <= 3f){
            currentCheckpoint++;
            if (currentCheckpoint >= checkpoints.Length)
            {
                currentCheckpoint = 0;
            }
            AI.destination = checkpoints[currentCheckpoint].transform.GetChild(Random.Range(1,6)).transform.position;
            }
        }
    }
        
}