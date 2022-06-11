using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    private LoadCharacter LoadCharacter;
    private GameObject player;
    private List<GameObject> currentRacers;

    public GameObject playerPosition;
    public GameObject outOfPosition;

    // Start is called before the first frame update
    void Start()
    {
        LoadCharacter = GameObject.Find("GameManager").GetComponent<LoadCharacter>();
        currentRacers = new List<GameObject>();

        currentRacers.Add(LoadCharacter.character);

        foreach(GameObject AI in LoadCharacter.AIracers)
        {
            currentRacers.Add(AI);
        }
        
        outOfPosition.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + currentRacers.Count);
    }

    // Update is called once per frame
    void Update()
    {
        currentRacers.Sort((x, y) => y.GetComponent<PositionFormulaCalculator>().positionFormula.CompareTo(x.GetComponent<PositionFormulaCalculator>().positionFormula));
        player = currentRacers.Find(x => x.name == LoadCharacter.character.name);
        playerPosition.GetComponent<TMPro.TextMeshProUGUI>().SetText(""+(currentRacers.IndexOf(player) + 1));
        PlayerPrefs.SetString("firstCharacter", currentRacers[0].name);
        PlayerPrefs.SetString("secondCharacter", currentRacers[1].name);
        PlayerPrefs.SetString("thirdCharacter", currentRacers[2].name);  
        PlayerPrefs.SetString("playerOrder",(currentRacers.IndexOf(player)+1).ToString());
    }
}
