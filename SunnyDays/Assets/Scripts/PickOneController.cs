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


	void Start(){
		sportLevel 	 = GameObject.Find ("SportsLevel");
		scienceLevel = GameObject.Find ("ScienceLevel");
		animalLevel  = GameObject.Find ("AnimalLevel");
		natureLevel  = GameObject.Find ("NatureLevel");

//		if (gameObject == animalLevel) {
//
//			float x = Mathf.Cos (timeCounter) * radius;
//			float y = Mathf.Sin (timeCounter) * radius;
//
//		} else if (gameObject == sportLevel) {
//
//			float x = Mathf.Cos (timeCounter) * radius;
//			float y = Mathf.Sin (timeCounter) * radius;
//
//		} else {
//			
//			float x = Mathf.Cos (timeCounter) * radius;
//			float y = Mathf.Sin (timeCounter) * radius;
//		}
	}

	void Update() {
		//Debug.Log(Mathf.Cos (Mathf.PI));
		//Debug.Log ("SportLevel position" + sportLevel.transform.position);
		//transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
		//Debug.Log("delta time " + Time.deltaTime);
		if (gameObject == scienceLevel) {
			Debug.Log ("science level"); 
			//Debug.Log ("PI" + Mathf.PI);
			timeCounter += Time.deltaTime * speed;
			Debug.Log ("Counter science " + timeCounter);
			float x = Mathf.Cos (timeCounter) * radius;
			float y = Mathf.Sin (timeCounter) * radius;
			float z = 0;
			Debug.Log ("science x " + Mathf.Cos (timeCounter));

			transform.position = new Vector3 (x, y, z);

		} 
		else if (gameObject == animalLevel) {
			//Debug.Log ("animal level");
			//Debug.Log ("PI" + Mathf.PI);
			timeCounter -= Time.deltaTime * speed;
			//Debug.Log ("Counter" + timeCounter);
			float x = Mathf.Sin (timeCounter) * radius;
			float y = Mathf.Cos (timeCounter) * radius;
			float z = 0;

			transform.position = new Vector3 (x, y, z);
		} else if (gameObject == sportLevel) {
			//Debug.Log ("sport level");
			//Debug.Log ("PI" + Mathf.PI);

			timeCounter += Time.deltaTime * speed;
			//Debug.Log ("Counter" + timeCounter);
			float x = -Mathf.Cos (timeCounter) * radius;
			float y = -Mathf.Sin (timeCounter) * radius;
			float z = 0;

			transform.position = new Vector3 (x, y, z);
		} else {
			//Debug.Log ("else level");
			//Debug.Log ("PI" + Mathf.PI);

			timeCounter -= Time.deltaTime * speed;
			//Debug.Log ("Counter" + timeCounter);
			float x = -Mathf.Sin (timeCounter) * radius;
			float y = -Mathf.Cos (timeCounter) * radius;
			float z = 0;
			//Debug.Log ("else x position" + x);

			transform.position = new Vector3 (x, y, z);
		}

	}
}
