using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class countdownTimer : MonoBehaviour
{   
    public GameObject countDown;
    public GameObject playerTime;
    public AudioSource threeSound;
    public AudioSource twoSound;
    public AudioSource oneSound;
    public AudioSource goSound;
    public AudioSource soundtrack;
    public GameObject lapTimer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountRoutine());
    }

    IEnumerator CountRoutine()
    {
        yield return new WaitForSeconds(1f);
        countDown.GetComponent<TMPro.TextMeshProUGUI>().SetText("3");
        threeSound.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1f);
        countDown.SetActive(false);
        countDown.GetComponent<TMPro.TextMeshProUGUI>().SetText("2");  
        countDown.GetComponent<TMPro.TextMeshProUGUI>().color = new Color32(242,182, 2, 255);
        twoSound.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1f);
        countDown.SetActive(false);
        countDown.GetComponent<TMPro.TextMeshProUGUI>().SetText("1");   
        countDown.GetComponent<TMPro.TextMeshProUGUI>().color = new Color32(239, 255, 0 ,255);
        oneSound.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1f);
        countDown.GetComponent<TMPro.TextMeshProUGUI>().fontSize = 72;
        countDown.GetComponent<TMPro.TextMeshProUGUI>().SetText("GO!");
        countDown.GetComponent<TMPro.TextMeshProUGUI>().color = new Color32(2, 242, 11, 255);
        goSound.Play();
        yield return new WaitForSeconds(1f);
        //set text inactive
        countDown.SetActive(false);
        //find by tag "player" and its controller script and set active
        playerTime.GetComponent<CarController>().enable = true;
        PlayerPrefs.SetInt("playerActive", 1);
        soundtrack.Play();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
