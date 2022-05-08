using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
   //add text object
    
    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(FadeMth());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator FadeMth()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            GetComponent<TMPro.TextMeshProUGUI>().text="";                
            yield return new WaitForSeconds(0.5f);
            GetComponent<TMPro.TextMeshProUGUI>().text="<PRESS ANY KEY TO START>";
        }
        
    }
}
