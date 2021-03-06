﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour {

    public void Fire(GameObject bullet, Transform bulletSpawn) {
        print("Fire in the hole!");

        GameObject shot = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        shot.GetComponent<BulletMover>().speed = 240.0f;
        shot.GetComponent<BulletMover>().destiny = transform.forward;
    }

    public void Fire3d(GameObject bullet, Transform bulletSpawn, Vector3 target, float speed) {

        Vector3 spawn = new Vector3(bulletSpawn.position.x, bulletSpawn.position.y, bulletSpawn.position.z);
        float distance = Vector3.Distance(spawn, target);

        Vector3 direction = target - spawn;
        direction = direction / distance;

        GameObject shot = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);

        shot.GetComponent<BulletMover>().destiny = direction;
        shot.GetComponent<BulletMover>().speed = speed;
    }

}
