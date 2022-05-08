using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfLapTrigger : MonoBehaviour
{   
    public GameObject setTrueTrigger;
    public GameObject setFalseTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CarColliderTag")
        {
            setTrueTrigger.SetActive(true);
            setFalseTrigger.SetActive(false);
        }
    }
}
