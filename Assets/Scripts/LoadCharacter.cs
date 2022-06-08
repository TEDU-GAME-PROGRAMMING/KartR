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
	public GameObject[] AIracers;
	public int selectedCharacter;
	void Start()
	{	
		//print console index of selected character
		//Debug.Log("selectedCharacter: " + PlayerPrefs.GetInt("selectedCharacter"));
		selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
		//clone it and set it active
		character = characterPrefabs[selectedCharacter];
		//Instantiate(characterPrefabs[selectedCharacter], spawnPoint.position, spawnPoint.rotation);
		character.SetActive(true);
		//get game object of count manager with name 
		GameObject countDown = GameObject.Find("countManager");
		countDown.GetComponent<countdownTimer>().playerTime = character;
		
		foreach (GameObject gj in AIracers)
		{
			gj.GetComponent<AIcheckpoint>().player = character;
			gj.SetActive(true);
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
