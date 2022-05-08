using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject explosion;
    public float expForce,radius;


   private void OnCollisionEnter(Collision collision)
    {
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(exp,3);
            knockback();
            Destroy(gameObject);
    }

    void knockback()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearby in colliders)
        {
            Rigidbody rb = nearby.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(expForce, transform.position, radius);
            }
        }

        
        
    }







}
