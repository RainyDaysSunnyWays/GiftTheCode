using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
	public AudioSource ding;
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(GameManager.instance.NextLevel());
			ding.Play ();
        }
    }
}
