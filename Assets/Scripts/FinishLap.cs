using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinishLap : MonoBehaviour
{
    public GameObject LapCounter;
    public GameObject RemainingLaps;
    public int LapsDone;
    public int totalLap;
    public GameObject[] buffs;
    //public GameObject winPanel;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CarColliderTag")
        {
            LapsDone++;
        }
        if(other.tag == "AICollider")
        {
            GameObject AI = other.gameObject;
            AI.GetComponent<AIcheckpoint>().lapsDone += 1;
            if(AI.GetComponent<AIcheckpoint>().lapsDone == totalLap + 1)
            {
                Debug.Log("You Lose");
                Time.timeScale = 0;
            }   
        }
        LapCounter.GetComponent<TMPro.TextMeshProUGUI>().SetText(""+ LapsDone);
        if(LapsDone == totalLap + 1)
        {
            Debug.Log("You Win");
           // winPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
