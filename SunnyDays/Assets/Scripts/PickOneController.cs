using UnityEngine;
using System.Collections;

public class PickOneController : MonoBehaviour {

	public float speed;
	public int radius;
	float timeCounter = 0;

	public GameObject sportLevel;
	public GameObject scienceLevel;
	public GameObject animalLevel;
	public GameObject natureLevel;
	public GameObject select;

	bool inSelectTrigger = false;
	bool timeStop 		 = false;

	void Start(){
		sportLevel 	 = GameObject.Find ("SportsLevel");
		scienceLevel = GameObject.Find ("ScienceLevel");
		animalLevel  = GameObject.Find ("AnimalLevel");
		natureLevel  = GameObject.Find ("NatureLevel");

		(gameObject.GetComponent("Halo") as Behaviour).enabled = false;

		select = GameObject.Find ("Select");

	}

	void Update() {

		if (gameObject == scienceLevel) {

			timeCounter += Time.deltaTime * speed;
			float x = Mathf.Cos (timeCounter) * radius;
			float y = Mathf.Sin (timeCounter) * radius;
			float z = 0;

			transform.position = new Vector3 (x, y, z);

		} 
		else if (gameObject == animalLevel) {

			timeCounter -= Time.deltaTime * speed;
			float x = Mathf.Sin (timeCounter) * radius;
			float y = Mathf.Cos (timeCounter) * radius;
			float z = 0;

			transform.position = new Vector3 (x, y, z);

		} else if (gameObject == sportLevel) {

			timeCounter += Time.deltaTime * speed;
			float x = -Mathf.Cos (timeCounter) * radius;
			float y = -Mathf.Sin (timeCounter) * radius;
			float z = 0;

			transform.position = new Vector3 (x, y, z);

		} else if (gameObject == natureLevel) {

			timeCounter -= Time.deltaTime * speed;
			float x = -Mathf.Sin (timeCounter) * radius;
			float y = -Mathf.Cos (timeCounter) * radius;
			float z = 0;

			transform.position = new Vector3 (x, y, z);

		}

		if (Input.GetKey (KeyCode.Space)) {
			if (inSelectTrigger) {
				Select();
			} 
		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		(gameObject.GetComponent("Halo") as Behaviour).enabled = !(gameObject.GetComponent("Halo") as Behaviour).enabled;
		if (other.gameObject.CompareTag("Select")) {
			inSelectTrigger = true;
            Debug.Log("inSelectTrigger is true");
		}
	}

	void OnTriggerExit2D(Collider2D other) {
			
		(gameObject.GetComponent("Halo") as Behaviour).enabled = !(gameObject.GetComponent("Halo") as Behaviour).enabled;
		if (other.gameObject.CompareTag("Select")) {
			inSelectTrigger = false;
            Debug.Log("inSelectTrigger is false");
        }
	}

	void Select() {
        StartCoroutine(GameManager.instance.NextLevel());
        //Time.timeScale = 0;
		timeStop = true;
	}
}
