using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{   
    public GameObject rotate;
    public float rotateSpeed;
    public int vehiclePointer = 0;
    public VehicleList listOfVehicles;

    private void FixedUpdate()
    {
        rotate.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
    private void Awake(){
        vehiclePointer = PlayerPrefs.GetInt("pointer");

        GameObject childObject = Instantiate(listOfVehicles.vehicleList[vehiclePointer], new Vector3(0,0.5f,0), Quaternion.identity) as GameObject;
        
        childObject.transform.parent = rotate.transform;
    }
    public void rightButton(){
        if(vehiclePointer <listOfVehicles.vehicleList.Length-1){
            Destroy(GameObject.FindGameObjectWithTag("Car"));
            vehiclePointer++;
            PlayerPrefs.SetInt("Pointer", vehiclePointer);
            GameObject childObject = Instantiate(listOfVehicles.vehicleList[vehiclePointer], new Vector3(0,0.5f,0), Quaternion.identity) as GameObject;
            childObject.transform.parent = rotate.transform;
        }       
    }
}
