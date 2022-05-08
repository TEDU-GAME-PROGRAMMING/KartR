using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{


    public GameObject[] wheels;
    public float rotationSpeed;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            float verticalAxis = Input.GetAxisRaw("Vertical");
            float horizontalAxis = Input.GetAxisRaw("Horizontal");

            foreach (var wheel in wheels){
                wheel.transform.Rotate(Time.deltaTime * verticalAxis * rotationSpeed,0,0,Space.Self);
            }
            if(horizontalAxis < 0){
                anim.SetBool("isLeft",true);
                anim.SetBool("isRight",false);
            }
            else if (horizontalAxis > 0){
                anim.SetBool("isLeft",false);
                anim.SetBool("isRight",true);
            }
            else{
                anim.SetBool("isLeft",false);
                anim.SetBool("isRight",false);
            }
    }
}
