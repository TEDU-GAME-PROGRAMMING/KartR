using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour{

public AudioSource selectionSoundtrack;
private AudioSource audioSource;

    void Awake(){
        audioSource = GetComponent<AudioSource>();
        selectionSoundtrack.Play();
    }

    void Update(){
        StartCoroutine("LoadScene");
}
IEnumerator LoadScene(){
if(Input.anyKey)
            {
                audioSource.Play();
                yield return new WaitForSeconds(audioSource.clip.length);
            SceneManager.LoadScene("MainMenu");
            }

    }
}