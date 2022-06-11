using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
                //lose
                SceneManager.LoadScene("ResultScreenLose");
                Time.timeScale = 0;
            }   
        }
        if(LapsDone == totalLap + 1)
        {
            //win
            SceneManager.LoadScene("ResultScreen"); 
            Time.timeScale = 0;
        }
        else {
            LapCounter.GetComponent<TMPro.TextMeshProUGUI>().SetText(""+ LapsDone);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
