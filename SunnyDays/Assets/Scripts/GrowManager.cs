using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrowManager : MonoBehaviour {

    private int currentShownPlantIndex;                                 //The number of the plant currently being shown
    private GameObject currentShownPlant;                               //The actual game object of the plant being shown;
    private List<GameObject> plants;                                           //A list of all the plant objects in the scene
	public HitManager hitManager;
	public BarController barController;

    public GameObject plant0;
    public GameObject plant1;
    public GameObject plant2;
    public GameObject plant3;

    // Use this for initialization
    void Start () {

        plants = new List<GameObject>();
        plants.Add(plant0);
        plants.Add(plant1);
        plants.Add(plant2);
        plants.Add(plant3);

        currentShownPlantIndex = 0;
        currentShownPlant = plants[currentShownPlantIndex] as GameObject;
	

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && hitManager.isValid)
        {
            GrowPlant();
        }
	}

    public void GrowPlant()
    {
        //There are only 4 plant images
        if (currentShownPlantIndex < 3)
        {
            currentShownPlantIndex++;
            //Set the current plant image to inactive so it is no longer shown
            currentShownPlant.SetActive(false);
            currentShownPlant = plants[currentShownPlantIndex] as GameObject;
            //Enable the new plant image
            currentShownPlant.SetActive(true);

        }
        else
        {
            StartCoroutine(GameManager.instance.NextLevel());
        }
    }
}
