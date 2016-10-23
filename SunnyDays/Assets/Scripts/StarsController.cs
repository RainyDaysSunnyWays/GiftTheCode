using UnityEngine;
using System.Collections;

public class StarsController : MonoBehaviour {
	public float rotationSpeed = 5.0f;
	public Transform target;

	// Use this for initialization
	void Start () {
	}

	private Vector3 zAxis = new Vector3(0, 0, 1);

	// Update is called once per frame
	void FixedUpdate () {
		transform.RotateAround(target.position, zAxis, rotationSpeed); 
	}
}
