using UnityEngine;
using System.Collections;

public class RunController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(GameManager.instance.NextLevel());
        }
	}
}
