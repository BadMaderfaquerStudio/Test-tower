using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

	public Transform pos1, pos2, pos3;
	public float speed, waitTime;
	int pos;

	private Rigidbody Player;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		Player = GetComponent<Rigidbody>();
		pos = 1;
	}

	public void move( string dir ) {
		if( dir == "clockwise"){
			switch (pos) {
			case 1:
				direction = new Vector3 (pos2.position.x - pos1.position.x, pos2.position.y - pos1.position.y, pos2.position.z - pos1.position.x);
				Player.velocity = direction * speed;
				Player.velocity = direction * 0;
				Player.position = new Vector3 (pos2.position.x, pos2.position.y, pos2.position.z);
				pos = 2;
				break;
			case 2:
				Player.position = new Vector3 (pos3.position.x, pos3.position.y, pos3.position.z);
				pos = 3;
				break;
			case 3:
				Player.position = new Vector3 (pos1.position.x, pos1.position.y, pos1.position.z);
				pos = 1;
				break;
			}
		}

		/*if( dir == "CountClockwise"){
			switch (pos) {
			case 1:
				Player.transform = pos3;
				break;
			case 2:
				Player.transform = pos1;
				break;
			case 3:
				Player.transform = new Vector3(pos2.position.x, pos2.position.y, pos2.position.z);
				break;
			}
		}*/
	}


}
