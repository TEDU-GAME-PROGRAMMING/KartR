using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapManager : MonoBehaviour
{
    public static int MinutesTimer;
    public static int SecondsTimer;
    public static float MilliTimer;
    public static string MilliDisplay;

    public GameObject minutesBox;
    public GameObject secondsBox;
    public GameObject milliBox;
    public GameObject gameManager;
    public bool isTimerStart;

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("GameManager");
        LoadCharacter loadCharacter = gameManager.GetComponent<LoadCharacter>();
        isTimerStart = loadCharacter.character.GetComponent<CarController>().enable;
        //check load character is enable or not
        if (isTimerStart)
        {
            MilliTimer += Time.deltaTime*100;
            MilliDisplay = MilliTimer.ToString("F0");
            if(MilliTimer<10){
                milliBox.GetComponent<TMPro.TextMeshProUGUI>().SetText("0" + MilliDisplay);
            }
            else {
                milliBox.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + MilliDisplay);
            }
            
            if(MilliTimer >= 97)
            {
                MilliTimer = 0;
                SecondsTimer += 1;
            }
            if(SecondsTimer <10)
            {
                secondsBox.GetComponent<TMPro.TextMeshProUGUI>().SetText("0" + SecondsTimer);
            }
            else {
                secondsBox.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + SecondsTimer);
            }
            if(SecondsTimer >= 57)
            {
                SecondsTimer = 0;
                MinutesTimer += 1;
            }
            if(MinutesTimer<10)
            {
                minutesBox.GetComponent<TMPro.TextMeshProUGUI>().SetText("0" + MinutesTimer);
            }
            else {
                minutesBox.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + MinutesTimer);
            }
        }

    }
    void Start(){
        MilliTimer = 0;
        SecondsTimer = 0;
        MinutesTimer = 0;
        
    }
}
