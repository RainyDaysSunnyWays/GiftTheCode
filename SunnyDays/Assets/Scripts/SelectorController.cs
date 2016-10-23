using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectorController : MonoBehaviour {
	private int NUM_OPTIONS = 6;
	public GameObject option0;
	public GameObject option1;
	public GameObject option2;
	public GameObject option3;
	public GameObject option4;
	public GameObject option5;
	public AudioSource youdidit;
	public AudioSource ohno;
	List<GameObject> options;
	public Text verbText;



	int currentOptionIndex = 0;


	// Use this for initialization
	void Start () {
		options = new List<GameObject> (){ option0, option1, option2, option3, option4, option5 };
		InvokeRepeating ("nextOption", 1.5f, 1.5f);
		verbText.text = "Who doesn't belong?";

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (currentOptionIndex != 4) {
				verbText.text = "Oops! Who doesn't belong?";
				ohno.Play ();
			} else {
				verbText.text = "Yay! Silly hedgehog!";
				youdidit.Play ();
				CancelInvoke ();
				StartCoroutine(GameManager.instance.NextLevel ());
			}
		}
	}

	public void nextOption(){
		(options[currentOptionIndex].GetComponent("Halo") as Behaviour).enabled = false;

		currentOptionIndex += 1;

		if (currentOptionIndex == 6) {
			currentOptionIndex = 0;
		}


		(options [currentOptionIndex].GetComponent("Halo") as Behaviour).enabled = true;

	}



}
