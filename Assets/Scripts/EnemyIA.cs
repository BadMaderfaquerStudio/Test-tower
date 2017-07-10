using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {
   
    public GameObject bullet;
    public Transform bulletSpawn;
    public float firerate = 30;
    public float speed = 150f;
    public GameObject target;
    public float acuracy = 50;
    public float friendlyFire = 0;

    private GunShot gun;

    // Use this for initialization
    void Start () {
        gun = bulletSpawn.GetComponent<GunShot>();
    }
	
	// Update is called once per frame
	void Update () {
        float randomFirerate = Random.Range(0.0f, 1000.0f);

        if(randomFirerate < firerate) {

            // Get random point
            Vector3 randomShot = getShotPoint();

            // Check shot integrity
            bool shallShot = getIntegrity(randomShot);

            if(shallShot) {
                gun.Fire3d(bullet, bulletSpawn, randomShot, speed);
            }
        }
	}

    /**
     *  getShotPoint
     *  Calculate a random point to shoot to a target in an acuracy radius 
     *  sphere. The lower acuracy, the better precision.
     */
    private Vector3 getShotPoint() {

        // We calculate a random point inside a acuracy radius sphere
        float randX = Random.Range(-acuracy, acuracy);
        float randY = Random.Range(-acuracy, acuracy);
        float randZ = Random.Range(-acuracy, acuracy);
        Vector3 randomPoint = new Vector3(randX, randY, randZ);

        // And center the sphere point to the target center
        // Vector3 randomShot = target.transform.position + randomPoint;
        return target.transform.position + randomPoint;
    }

    private bool getIntegrity(Vector3 shotTarget) {

        var shallShoot = true;

        // Cast a ray to the shoot point. If there is other spaceship or wall on the middle, still shooting.
        RaycastHit hit;
        if (Physics.Raycast(bulletSpawn.position, (shotTarget - bulletSpawn.position).normalized, out hit, float.PositiveInfinity))
        {

            if(hit.collider.CompareTag("Enemy")) {
                // Friendly fire highly probable. Check if shall fire.
                int randomMadness = Random.Range(0, 100);
                print(randomMadness);

                if(randomMadness < friendlyFire) {
                    // Ok, man, bad luck, I'm shoting...
                    shallShoot = true;
                } else {
                    shallShoot = false;
                }

                print(shallShoot);
            // } else if(hit.collider.CompareTag("Wall")) {
            //    shallShoot = false;
            } else {
                Debug.DrawLine(bulletSpawn.position, shotTarget);
            }
            

            //draw invisible ray cast/vector
        }

        return shallShoot;
    }
}
