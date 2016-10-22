using UnityEngine;
using System.Collections;

public class HitManager : MonoBehaviour {
	public bool isValid = false;
	public int moveSpeed = 1;
	public float hitBarXMin = -3.0f;
	public float hitBarXMax = 3.0f;
	public float hitAccel = 20f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// If HIT passes the min of the bar, move it to the right
		if (gameObject.transform.position.x < hitBarXMin) {
			GetComponent<Rigidbody2D> ().velocity = (new Vector2 (hitAccel, 0) * moveSpeed * Time.deltaTime);

			// If HIT passes the max of the bar, move it to the left
		} else if(gameObject.transform.position.x > hitBarXMax){
			GetComponent<Rigidbody2D> ().velocity = (new Vector2 (hitAccel * -1, 0)* moveSpeed *Time.deltaTime);
		}
	}


	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("collided with: " + other.gameObject.name);

			isValid = true;

	}

	void OnTriggerExit2D(Collider2D other){
		Debug.Log ("Exited collision with: " + other.gameObject.name);
			isValid = false;
	}
}
