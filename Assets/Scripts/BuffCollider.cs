using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffCollider : MonoBehaviour
{
    public GameObject bomb;
    private GameObject bombPosition;
    public GameObject[] bombPositions;
    public float timeStart=2f;
    private bool HasSpeed=false;
    private bool HasBomb=false;
    private bool isactiveBomb=false;
    public GameObject Bomb;
    public GameObject Nitro;
    public GameObject prefabOfBuff;
    public GameObject nitroRemaining;
    public AudioSource GetBuffSound;
   void Update() {
     //get parent
     GameObject parent = transform.parent.gameObject;
     //parent.transform.Rotate(new Vector3(0f,1f,0f),Time.deltaTime * 35f);
    if(Input.GetKeyDown(KeyCode.V) && HasBomb==true){
        isactiveBomb=true;
        HasBomb=false;
        Bomb.SetActive(false);
    }

    SpeedUp();
   }

  void Start(){
    if(PlayerPrefs.GetInt("selectedCharacter")==0){
      bombPosition = bombPositions[0];
    }
    else if(PlayerPrefs.GetInt("selectedCharacter")==1){
      bombPosition = bombPositions[1];
    }
  }
   void FixedUpdate(){
        if(HasSpeed){
          nitroRemaining.GetComponent<TMPro.TextMeshProUGUI>().SetText(timeStart.ToString("F2"));
        }
         if(isactiveBomb==true){
           Instantiate(bomb,bombPosition.transform.position, bombPosition.transform.rotation);
           isactiveBomb=false;  
         }
   }
   
   
   
   void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarColliderTag"))
        {
            StartCoroutine(PickUp());
            float RandomNumber=Random.Range(1, 3);
            if(RandomNumber == 1 && HasSpeed==false){
              GetBuffSound.Play();
              HasSpeed=true;
              timeStart=2f;
              HasBomb=false;
              //set active Bomb image in Canvas
              Nitro.SetActive(true);
              Bomb.SetActive(false);
            }
            
            if(RandomNumber == 2 && HasBomb==false){
              GetBuffSound.Play();
              HasSpeed=false;
              HasBomb=true;
              //set active Bomb image in Canvas
              Bomb.SetActive(true);
              Nitro.SetActive(false);
            }
        }
    }
    IEnumerator PickUp()
    {
      //set in active of parent
      GameObject parent = transform.parent.gameObject;
      foreach(Transform child in parent.transform){
        foreach(SkinnedMeshRenderer child2 in parent.GetComponentsInChildren<SkinnedMeshRenderer>()){
          child2.enabled = false;
        }
        foreach(Collider child3 in parent.GetComponentsInChildren<Collider>()){
          child3.enabled = false;
        }
      }
      //wait 2 seconds
      yield return new WaitForSeconds(2f);
      //again active
      foreach(Transform child in parent.transform){
        foreach(SkinnedMeshRenderer child2 in parent.GetComponentsInChildren<SkinnedMeshRenderer>()){
          child2.enabled = true;
        }
        foreach(Collider child3 in parent.GetComponentsInChildren<Collider>()){
          child3.enabled = true;
        }
      }
    }
    void SpeedUp(){
        CarController Player = GameObject.FindGameObjectWithTag("Player").GetComponent<CarController>();
        if(Input.GetKey(KeyCode.V) && HasSpeed==true && timeStart > 0){
          //if particle plays then stop
          if(!Player.nitroParticlesR.isPlaying && !Player.nitroParticlesL.isPlaying){
            Player.nitroParticlesR.Play();
            Player.nitroParticlesL.Play();
          } 
          Player.maxForwardSpeed=150;
          timeStart-=Time.deltaTime ;
          //find gameobject by tag as a Player
          Player.forwardSpeed*=1.5f;
          if(timeStart<=0){
              HasSpeed=false;
              Nitro.SetActive(false);
              Player.forwardSpeed/=1.5f;
              Player.maxForwardSpeed = 100;
          }
        }
        if(Input.GetKeyUp(KeyCode.V)){
          Player.maxForwardSpeed=100;
          Player.nitroParticlesR.Stop();
          Player.nitroParticlesL.Stop();
          if(timeStart<=0){
            Player.nitroParticlesR.Stop();
            Player.nitroParticlesL.Stop();
            Player.forwardSpeed/=1.5f;
            HasSpeed=false;
            Nitro.SetActive(false);
            Player.maxForwardSpeed = 100;
          }
        }
        if(timeStart<=0){
          HasSpeed=false;
          Nitro.SetActive(false);
          Player.maxForwardSpeed = 100;
        }
    }
}
