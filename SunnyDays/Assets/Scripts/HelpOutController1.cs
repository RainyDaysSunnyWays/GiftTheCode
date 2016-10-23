using UnityEngine;
using System.Collections;

public class HelpOutController1 : MonoBehaviour {

	public float speed;
	public int radius;
	float timeCounter = 0;

	public GameObject bootLevel;
	public GameObject shirtLevel;
	public GameObject tieLevel;
	public GameObject pantsLevel;
	public GameObject select;

	bool inSelectTrigger = false;
	bool timeStop 		 = false;

	void Start(){
		bootLevel 	 = GameObject.Find ("BootLevel");
		shirtLevel 	 = GameObject.Find ("ShirtLevel");
		tieLevel     = GameObject.Find ("TieLevel");
		pantsLevel   = GameObject.Find ("PantsLevel");

		(gameObject.GetComponent("Halo") as Behaviour).enabled = false;

		select = GameObject.Find ("Select");

	}

	void Update() {

		if (gameObject == bootLevel) {

			timeCounter += Time.deltaTime * speed;
			float x = Mathf.Cos (timeCounter) * radius;
			float y = Mathf.Sin (timeCounter) * radius;
			float z = 0;

			transform.position = new Vector3 (x, y, z);

		} 
		else if (gameObject == shirtLevel) {

			timeCounter -= Time.deltaTime * speed;
			float x = Mathf.Sin (timeCounter) * radius;
			float y = Mathf.Cos (timeCounter) * radius;
			float z = 0;

			transform.position = new Vector3 (x, y, z);

		} else if (gameObject == tieLevel) {

			timeCounter += Time.deltaTime * speed;
			float x = -Mathf.Cos (timeCounter) * radius;
			float y = -Mathf.Sin (timeCounter) * radius;
			float z = 0;

			transform.position = new Vector3 (x, y, z);

		} else if (gameObject == pantsLevel) {

			timeCounter -= Time.deltaTime * speed;
			float x = -Mathf.Sin (timeCounter) * radius;
			float y = -Mathf.Cos (timeCounter) * radius;
			float z = 0;

			transform.position = new Vector3 (x, y, z);

		}

		if (Input.GetKey (KeyCode.Space)) {
			if (inSelectTrigger) {
				Select();
			} else {
				Debug.Log ("pressed space not in the right area");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Entered select");  

		(gameObject.GetComponent("Halo") as Behaviour).enabled = !(gameObject.GetComponent("Halo") as Behaviour).enabled;
		if (other.gameObject.CompareTag("Select")) {
			inSelectTrigger = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log("exit Select");

		(gameObject.GetComponent("Halo") as Behaviour).enabled = !(gameObject.GetComponent("Halo") as Behaviour).enabled;
		if (other.gameObject.CompareTag("Select")) {
			inSelectTrigger = false;
		}
	}

	void Select() {
		timeStop = true;
		if (gameObject == bootLevel) {
			Debug.Log ("boot Level");
			Time.timeScale = 0;
		} else if (gameObject == shirtLevel) {
			Debug.Log ("shit Level");
		} else if (gameObject == pantsLevel) {
			Debug.Log ("pants Level");
		} else if (gameObject == tieLevel) {
			Debug.Log ("tie Level");
		}
	}
}
