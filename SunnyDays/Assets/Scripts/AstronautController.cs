﻿using UnityEngine;
using System.Collections;

public class AstronautController : MonoBehaviour {
	[HideInInspector] public bool jump = false;

	public float jumpForce = 600;
	public Transform groundCheck;
	public AudioSource boing;
	public AudioSource youdidit;
    private int score;                                          //How many stars the astronaut has collected
	

	private bool grounded = false;
	private Rigidbody2D rb2d;

	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
        jump = false;
	}

    void Start()
    {
        GameManager.instance.SetVerbText("Catch!");
    }
		
	void Update () {
        if (score == 9)
        {
			youdidit.Play ();
            StartCoroutine(GameManager.instance.NextLevel());
        }
        grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
        if (Input.GetButtonDown ("Jump") && grounded) {
			boing.Play ();
			jump = true;
		}
	}

	void FixedUpdate(){
		if (jump) { 
			rb2d.AddForce (new Vector2 (0f, jumpForce));
			jump = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Star")) {
			other.gameObject.SetActive (false);
            score++;
		}
	}

}