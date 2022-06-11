using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using TMPro;

public class NewGame : MonoBehaviour
{
    public Sprite marioSprite;
    public Sprite kachowSprite;
    public Sprite otherSprite;
    public Image firstPlace;
    public Image secondPlace;
    public Image thirdPlace;
    public TextMeshProUGUI order;
    public TextMeshProUGUI order2;
    void Awake(){
        string[] kachows = new string[] {"Ka-Chow", "AI3", "AI4"};
        string[] marios = new string[] {"AI", "AI2", "MarioKart"};
        string[] others = new string[] {"AI5", "AI6"};
        string first = PlayerPrefs.GetString("firstCharacter");
        string second = PlayerPrefs.GetString("secondCharacter");
        string third = PlayerPrefs.GetString("thirdCharacter");
        //contains the first string 
        if(Array.Exists(kachows, element => element == first))
        {
            firstPlace.sprite = kachowSprite;
        }
        else if(Array.Exists(kachows, element => element == second))
        {
            secondPlace.sprite = kachowSprite;
        }
        else if(Array.Exists(kachows, element => element == third))
        {
            thirdPlace.sprite = kachowSprite;
        }
        if(Array.Exists(marios, element => element == first))
        {
            firstPlace.sprite = marioSprite;
        }
        else if(Array.Exists(marios, element => element == second))
        {
            secondPlace.sprite = marioSprite;
        }
        else if(Array.Exists(marios, element => element == third))
        {
            thirdPlace.sprite = marioSprite;
        }
        if(Array.Exists(others, element => element == first))
        {
            firstPlace.sprite = otherSprite;
        }
        else if(Array.Exists(others, element => element == second))
        {
            secondPlace.sprite = otherSprite;
        }
        else if(Array.Exists(others, element => element == third))
        {
            thirdPlace.sprite = otherSprite;
        }
        String orderNumber = PlayerPrefs.GetString("playerOrder");
        order.SetText(orderNumber);
        if(orderNumber == "1"){
            order2.text = "st";
        }
        else if(orderNumber =="2"){
            order2.text = "nd";
        }
        else if(orderNumber =="3"){
            order2.text = "rd";
        }
        else{
            order2.text = "th";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // if input is space
        if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainMenu");
            }
    }
}
