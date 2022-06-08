using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCheckpoint : MonoBehaviour
{
    public int currentCheckpoint;
    public int currentLap;
    public int totalCheckpoints;
    public GameObject[] checkpoints;
    // Start is called before the first frame update
    void Start()
    {
        currentCheckpoint = 0;
        totalCheckpoints = 0;
        currentLap = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCheckpoint == checkpoints.Length - 1)
        {
            if(Vector3.Distance(checkpoints[currentCheckpoint].transform.GetChild(0).transform.position, gameObject.transform.position) <= 10f)
        {
            currentCheckpoint = 0;
            currentLap++;
            totalCheckpoints++;
        }
        }

        else
        {
            if(Vector3.Distance(checkpoints[currentCheckpoint].transform.GetChild(0).transform.position, gameObject.transform.position) <= 10f)
        {
            currentCheckpoint++;
            totalCheckpoints++;
        }
        }
    }
}
