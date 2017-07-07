using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour {

    public Vector3 destiny;
    public float speed;

    private Rigidbody Rb;

    // Use this for initialization
    void Start () {
        Rb = GetComponent<Rigidbody>();
        //Rb.velocity = destiny * speed;
        Rb.velocity = destiny * speed;
    }


}
