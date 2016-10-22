using UnityEngine;
using System.Collections;

public class BarController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateSize(){
		Debug.Log ("resizing bar");
		Vector3 scale = transform.localScale;
		scale.x = scale.x - 1;
		transform.localScale = scale;

	}
}
