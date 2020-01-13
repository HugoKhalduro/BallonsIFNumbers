using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    public GameObject BlowingBalloon;
    public float force = 10f;
    Rigidbody2D rig;
    

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.tag == "Finger"){

            Vector2 direction = (coll.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject blowingBalloon = Instantiate(BlowingBalloon, transform.position, rotation);
            Destroy(blowingBalloon, 2f);
            Destroy(gameObject);
        }
    }
}
