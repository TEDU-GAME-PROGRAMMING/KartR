using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class CarController : MonoBehaviour
{


    public bool enable = false;
    private float moveInput;
    private float turnInput;
    private bool isGrounded;

    public bool isDrift;
    public float forwardSpeed;
    public float reverseSpeed;
    public float turnSpeed;
    public float maxForwardSpeed;
    public float forwardAccel;
    public float stoppingAccel;

    public Rigidbody rb;
    public Rigidbody carRB;
    public LayerMask groundLayer;


    private float normalDrag;
    public float modifiedDrag;
    public float alignToGroundTime;

    //Particles
    public ParticleSystem driftParticlesR;
    public ParticleSystem driftParticlesL;
    public ParticleSystem nitroParticlesR;
    public ParticleSystem nitroParticlesL;

    public Color[] Colors;

    int selectedCharacter;
    //camera
    public CinemachineVirtualCamera myCinemachine = null;
    public CinemachineVirtualCamera frontCinemachine = null;
    public GameObject [] triggers;
    public GameObject [] spawnPoints;

    public GameObject[] checkpoints;
    public int currentCheckpoint;
    public int currentLap;

    // Start is called before the first frame update
    void Start()
    {
        rb.transform.parent = null;
        carRB.transform.parent = null;
        normalDrag = rb.drag;
        myCinemachine = GameObject.Find("Main Cam").GetComponent<CinemachineVirtualCamera>();
        frontCinemachine = GameObject.Find("Main Cam2").GetComponent<CinemachineVirtualCamera>();
        //set front machine inactive
        currentCheckpoint = 0;
        currentLap = 1;
    }

    // Update is called once per frame
    void Update()
    {   
        if(SceneManager.GetActiveScene().name =="SelectionScene") return;

        var R = driftParticlesR.main;
        var L = driftParticlesL.main;
        if(enable){
                moveInput = Input.GetAxisRaw("Vertical");
                turnInput = Input.GetAxisRaw("Horizontal");
        }

        //when the space button pressed time set turn speed 120
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isDrift = true;
            turnSpeed = 120f;
            forwardSpeed = forwardSpeed/1.5f;
            //drift particles play
            driftParticlesR.Play();
            driftParticlesL.Play();
            //increase drift power
            R.startColor = Colors[0];
            L.startColor = Colors[0];

        }
        //when the button space released turn speed made again normal(70)
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isDrift = false;
            turnSpeed = 70f;
            forwardSpeed = forwardSpeed*1.5f>maxForwardSpeed?maxForwardSpeed:forwardSpeed*1.5f;
            //drift particles stop
            driftParticlesR.Stop();
            driftParticlesL.Stop();
            //decrease drift power

        }
        if(moveInput>0){
                if(forwardSpeed<maxForwardSpeed){
                forwardSpeed += forwardAccel * Time.deltaTime;
                }
                else {
                forwardSpeed = maxForwardSpeed;
                }
        }
        else {
                if(forwardSpeed>0){
                    forwardSpeed -= stoppingAccel * Time.deltaTime;
                }
                else if(forwardSpeed<0){
                    forwardSpeed = 0;
                }
        }
        //to calculate turning rotation
        float newRot = turnInput * turnSpeed * Time.deltaTime * moveInput;

        if(isGrounded){
            transform.Rotate(0, newRot, 0,Space.World);
        }

        //Set cars position to sphere
        transform.position = rb.transform.position;
        //Raycast to the ground and get normal to align with car
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, -transform.up, out hit,1f, groundLayer);


        //rotate car to align with ground
        Quaternion toRotate = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotate, Time.deltaTime * alignToGroundTime);

        //movement
        moveInput *= moveInput > 0 ? forwardSpeed : reverseSpeed;
        
        //to calculate drag
        rb.drag = isGrounded ? normalDrag : modifiedDrag;
        
        //if pressed p, move the car last checkpoint
        if(Input.GetKey(KeyCode.P))
        {
            int number = 0;
            //traverse all checkpoints and find the active one
            foreach(GameObject checkpoint in triggers)
            {
                //check if gameobject is active or not
                if(checkpoint.activeSelf)
                {
                    //get length of checkpoints
                    int length = triggers.Length;
                    //set car position to checkpoint position
                    transform.position = spawnPoints[(number) + length % length].transform.position;
                    rb.position = spawnPoints[(number) + length % length].transform.position;
                    //set car rotation to checkpoint rotation
                    transform.rotation = spawnPoints[(number) + length % length].transform.rotation;
                    rb.rotation = spawnPoints[(number) + length % length].transform.rotation;
                    //set car drag to normal
                    rb.drag = normalDrag;
                    //set car forward speed to normal
                    forwardSpeed = 0;
                    //set car turn speed to normal
                    turnSpeed = 70f;
                    //set car drift particles to normal
                    R.startColor = Colors[0];
                    L.startColor = Colors[0];
                    //set car to normal
                    isDrift = false;
                    //set car to normal
                    isGrounded = true;
                    //set car to normal
                    moveInput = 0;
                    //set car to normal
                    turnInput = 0;
                    //set car to normal
                    forwardSpeed = 0;
                    break;
                }     
                number+=1;        
            }
        }
        //if pressed b, rotate the car to look back
        if(Input.GetKey(KeyCode.B))
        {   
            //set priority
            frontCinemachine.Priority = 10;
            myCinemachine.Priority = 0;
            //set front cinemachine name Main Cam
            //frontCinemachine.name = "Main Cam";
            //set my cinemachine name Main Cam2
            //myCinemachine.name = "Main Cam2";     
        }
        if(Input.GetKeyUp(KeyCode.B)){
            //set priority
            myCinemachine.Priority = 10;
            frontCinemachine.Priority = 0;
            //set front cinemachine name Main Cam2
            //frontCinemachine.name = "Main Cam2";
            //set my cinemachine name Main Cam
            //myCinemachine.name = "Main Cam";
        } 
    }

    private void FixedUpdate(){
        if(enable){
            if(SceneManager.GetActiveScene().name =="SelectionScene") return;
            if(isGrounded){
                rb.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
            }
            else {
                rb.AddForce(transform.forward * 5, ForceMode.Acceleration);
                rb.AddForce(transform.up * -25f);
            }   
            carRB.MoveRotation(transform.rotation);      
        }   
    }
}
