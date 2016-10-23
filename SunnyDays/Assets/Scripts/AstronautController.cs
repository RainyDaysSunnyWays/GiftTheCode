using UnityEngine;
using System.Collections;

public class AstronautController : MonoBehaviour {
	[HideInInspector] public bool jump = true;

	public float jumpForce = 600;
	public Transform groundCheck;
	

	private bool grounded = false;
	private Rigidbody2D rb2d;

	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
		
	void Update () {
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		if (Input.GetButtonDown ("Jump") && grounded) {
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
		}
	}

}