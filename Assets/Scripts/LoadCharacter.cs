using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class LoadCharacter : MonoBehaviour
{
	public GameObject[] characterPrefabs;
	public Transform spawnPoint;
	public CinemachineVirtualCamera myCinemachine = null;
	public CinemachineVirtualCamera frontCinemachine = null;
	public GameObject character;
	public GameObject AICheck;
	public GameObject AICheck2;
	public GameObject AICheck3;
	public GameObject AICheck4;
	void Start()
	{	
		//print console index of selected character
		//Debug.Log("selectedCharacter: " + PlayerPrefs.GetInt("selectedCharacter"));
		int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
		//clone it and set it active
		character = characterPrefabs[selectedCharacter];
		//Instantiate(characterPrefabs[selectedCharacter], spawnPoint.position, spawnPoint.rotation);
		character.SetActive(true);
		//get game object of count manager with name 
		GameObject countDown = GameObject.Find("countManager");
		countDown.GetComponent<countdownTimer>().playerTime = character;
		
		if(selectedCharacter == 0){
			AICheck3.GetComponent<AIcheckpoint>().player = character;
			AICheck4.GetComponent<AIcheckpoint>().player = character;
			AICheck3.SetActive(true);
			AICheck4.SetActive(true);
		}
		else if(selectedCharacter == 1){
			AICheck.GetComponent<AIcheckpoint>().player = character;
			AICheck2.GetComponent<AIcheckpoint>().player = character;
			AICheck.SetActive(true);
			AICheck2.SetActive(true);	
		}
		//get cinemachine virtual camera
		myCinemachine = GameObject.Find("Main Cam").GetComponent<CinemachineVirtualCamera>();
		frontCinemachine = GameObject.Find("Main Cam2").GetComponent<CinemachineVirtualCamera>();
	}
	void Update(){
		//change the camera target to the character	
		myCinemachine.m_Follow = character.transform;
		myCinemachine.m_LookAt = character.transform;
		frontCinemachine.m_Follow = character.transform;
		frontCinemachine.m_LookAt = character.transform;
	}
}
