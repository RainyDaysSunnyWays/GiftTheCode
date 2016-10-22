﻿using UnityEngine;
using System.Collections;

public class RobotController : MonoBehaviour {
	bool isSuccess = false;
	public float stepSize = 20f;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("space pressed");

			if (isSuccess) {
				StartCoroutine (GameManager.instance.NextLevel ());
			} else {
				rb.AddForce(new Vector2(70, 0));
			}

		}
	}

	void OnTriggerEnter2D(Collider2D other){
		isSuccess = true;

		// Make sure he stops at the finish line
		rb.drag = 100f;

		// Go to the next level
		StartCoroutine(GameManager.instance.NextLevel());

	}


}
