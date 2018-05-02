using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float handling = 30.0f;
	private float speed = 0.0f;
	// Use this for initialization
	void Start () {

	}
	void reset_speed() {
		if (speed > 3) {
			speed = 3;
		}
		else if (speed < -3) {
			speed = -3;
		}
	}
	void apply_friction() {
		if (speed > 0.1) {
			speed -= 0.1f;
		} 
		else if (speed < -0.1) {
			speed += 0.1f;
		} 
		else {
			speed = 0;
		}
	}

	void OnCollisionEnter() {
        Debug.Log("Wheelchair is hitting some sort of object");
        speed = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
		float spinHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = -Input.GetAxis ("Vertical");

		if (moveVertical != 0) {
			speed += moveVertical;
		}

		reset_speed (); //limits speed to a certain range
		apply_friction(); //reduces speed of object
		transform.position += transform.forward * speed * Time.deltaTime;

		Vector3 rotation = new Vector3 (0.0f, spinHorizontal, 0.0f);
		transform.Rotate (rotation * handling * Time.deltaTime);

	}
}
