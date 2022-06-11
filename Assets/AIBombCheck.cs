using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBombCheck : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject explosion;
    public float expForce,radius;
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag =="Bomb"){
            GameObject exp = Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(exp,3);
            knockback(collision);
            Destroy(collision.gameObject);
        }
    }
    void knockback(Collision collision){
        rb.AddExplosionForce(expForce, collision.gameObject.transform.position, radius);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
