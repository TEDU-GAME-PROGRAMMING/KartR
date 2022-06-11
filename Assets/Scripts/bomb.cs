using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bomb : MonoBehaviour
{
    public GameObject explosion;
    public float expForce,radius;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag=="CarColliderTag" || collision.gameObject.tag == "AICollider"){
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(exp,3);
            knockback(collision);
            Destroy(gameObject);
        }    
    }

    void knockback(Collision collision)
    {
        //Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        //foreach (Collider nearby in colliders)
        //{
           // Rigidbody rb = nearby.GetComponent<Rigidbody>();

            //if (rb != null)
            //{           
                //push back impacted object with add force
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                rb.AddForce(-transform.forward * expForce,ForceMode.Force);
                //get navmesh agent component
                if(collision.gameObject.tag=="AICollider"){
                   collision.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                }

                //rb.AddExplosionForce(expForce, transform.position, radius);
            //}
        //}

        
        
    }







}
