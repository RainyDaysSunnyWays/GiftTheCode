using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HitSensorController : MonoBehaviour {
	private int currentBarIndex = 0;
	private List<GameObject> bars;

	public HitManager hitManager;
	public GameObject bar0;
	public GameObject bar1;
	public GameObject bar2;
	public GameObject bar3;

	// Use this for initialization
	void Start () {
		bars = new List<GameObject> ();
		bars.Add (bar0);
		bars.Add (bar1);
		bars.Add (bar2);
		bars.Add (bar3);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Show the next bar
	public void changeBars(){
		if (currentBarIndex < 3) {
			bars [currentBarIndex].SetActive (false);
			currentBarIndex += 1;
			bars [currentBarIndex].SetActive (true);
			hitManager.offTarget ();
		}
	}
}
