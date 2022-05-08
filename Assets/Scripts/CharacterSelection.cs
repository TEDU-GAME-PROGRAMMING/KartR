using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;
using System.Collections;

public class CharacterSelection : MonoBehaviour
{
	public GameObject[] characters;
	public int selectedCharacter = 0;
	public AudioSource kachowSound;
	public AudioSource mario;
	public AudioSource menuSoundtrack;
	public void NextCharacter()
	{
		characters[selectedCharacter].SetActive(false);
		selectedCharacter = (selectedCharacter + 1) % characters.Length;
		characters[selectedCharacter].SetActive(true);
	}

	public void PreviousCharacter()
	{
		characters[selectedCharacter].SetActive(false);
		selectedCharacter--;
		if (selectedCharacter < 0)
		{
			selectedCharacter += characters.Length;
		}
		characters[selectedCharacter].SetActive(true);
	}

	public void StartGame()
	{
		if(selectedCharacter == 1)
		{
			//play sound for player 2
			menuSoundtrack.Stop();
			kachowSound.Play();
		}		
		else if(selectedCharacter == 0){
			//play sound for player 1
			menuSoundtrack.Stop();
			mario.Play();
		}
		PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
		StartCoroutine(LoadScreen());
	}
	//start
	void Start(){
		menuSoundtrack.Play();
	}
	//update
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			PreviousCharacter();
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			NextCharacter();
		}
		//if pressed space
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartGame();
		}
		characters[selectedCharacter].transform.Rotate(0, 30 * Time.deltaTime, 0);
	}
	IEnumerator	LoadScreen(){
		if(selectedCharacter == 1)
		{
			yield return new WaitForSeconds(7f);
		}
		else if(selectedCharacter == 0)
		{
			yield return new WaitForSeconds(1.5f);
		}
		SceneManager.LoadScene("TEDUKart");
	}
}
