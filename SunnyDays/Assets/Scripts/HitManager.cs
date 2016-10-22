using UnityEngine;
using System.Collections;

public class HitManager : MonoBehaviour {
	public bool isValid = false;
	public int moveSpeed = 1;
	public float hitAccel = 20f;

	public Transform farEnd;
	private Vector3 frometh;
	private Vector3 untoeth;
	private float frequencyInSeconds = 2f;

	// Use this for initialization
	void Start () {
		frometh = transform.position;
		untoeth = farEnd.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.Lerp(frometh, untoeth, Mathf.SmoothStep(
			0f, 1f, Mathf.PingPong(Time.time/frequencyInSeconds,1)));
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
