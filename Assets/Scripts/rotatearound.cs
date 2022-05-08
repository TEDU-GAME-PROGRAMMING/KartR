using UnityEngine;
using System.Collections;
 
public class rotatearound : MonoBehaviour
{
    
    private Vector3 targetPos1;
    
    private Vector3 targetPos2;

    public float speed = 0.5f;

    public bool canMove=true;

    public bool firstMove=true;

    public float moveAmount=0.5f;

    public float rotateSpeed=10f;
    
    void Start()
    {
     
        firstMove = true;
        targetPos1=transform.position+new Vector3(0,moveAmount,0);
         targetPos2=targetPos1-new Vector3(0,moveAmount,0);
    }
    void Update()
    {
         transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);

        if(transform.position == targetPos1)
        {
            firstMove = false;
        }
        if (transform.position == targetPos2)
        {
            firstMove = true;
        }
        if (canMove)
        {
            if (firstMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos1, speed* Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos2, speed* Time.deltaTime);
            }
        }
     
    }
}