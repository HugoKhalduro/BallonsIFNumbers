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

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Finger")){
            GameObject blowingBallon = Instantiate(BlowingBalloon, coll.gameObject.transform.position, Quaternion.identity);
            Destroy(blowingBallon, 0.5f);
            Destroy(gameObject);
        }
        

    }
}