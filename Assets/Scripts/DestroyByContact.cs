using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    // private GameController gameController;

    private void Start() {
        // GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        // gameController = gameControllerObject.GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other) {

        if (other.tag == "Boundary") {
            return;
        }

        //Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player") {
            //Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            // gameController.GameOver();
        }

        Destroy(gameObject);
    }
}
