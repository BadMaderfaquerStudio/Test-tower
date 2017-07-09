using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject bullet;
    public Transform bulletSpawn;
    public float distance = 5000f;
    public float speed = 150f;
    // public Camera cam;
    // public Rigidbody rb;
    // public float speed;

    private GunShot gun;

    // Use this for initialization
    void Start () {
        gun = bulletSpawn.GetComponent<GunShot>();
        // rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {

            //create a ray cast and set it to the mouses cursor position in game
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.PositiveInfinity))
            {
                //draw invisible ray cast/vector
                Debug.DrawLine(ray.origin, hit.point);
                //log hit area to the console
                // Debug.Log(hit.point);

                gun.Fire3d(bullet, bulletSpawn, hit, speed);

            }
            
        }
    }

}

