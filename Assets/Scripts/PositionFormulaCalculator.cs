using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFormulaCalculator : MonoBehaviour
{
    public float positionFormula;
    public AIcheckpoint AIcheckpoint;
    public CarCheckpoint CarCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "AICollider")
        {
            AIcheckpoint = gameObject.GetComponent<AIcheckpoint>();
        }
        else if(gameObject.tag == "Player")
        {
            CarCheckpoint = gameObject.GetComponent<CarCheckpoint>();
        }
    }
    // Update is called once per frame
    void Update()
    {
         if(gameObject.tag == "AICollider")
        {
            positionFormula = (1000*AIcheckpoint.currentLap + 50*AIcheckpoint.totalCheckpoints) - Vector3.Distance(AIcheckpoint.AI.destination, AIcheckpoint.transform.position);
        }
        else if(gameObject.tag == "Player")
        {
            positionFormula = (1000*CarCheckpoint.currentLap + 50*CarCheckpoint.totalCheckpoints) - Vector3.Distance(CarCheckpoint.checkpoints[CarCheckpoint.currentCheckpoint].transform.GetChild(0).transform.position, CarCheckpoint.transform.position);
        }
    }
}
