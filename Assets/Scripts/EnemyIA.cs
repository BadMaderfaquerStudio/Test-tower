using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {
   
    public GameObject bullet;
    public Transform bulletSpawn;
    public float firerate = 30;
    public float speed = 150f;

    private GunShot gun;

    // Use this for initialization
    void Start () {
        gun = bulletSpawn.GetComponent<GunShot>();
    }
	
	// Update is called once per frame
	void Update () {
        float rand = Random.Range(0.0f, 1000.0f);

        if(rand < firerate) {
            print("Fire in the hole!!!");
            gun.Fire(bullet, bulletSpawn);
        }
	}
}
