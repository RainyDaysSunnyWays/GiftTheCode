using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float levelStartDelay = 1f;                  //How long to wait before starting each new level
    public Text verbText;

	// Use this for initialization
	void Start () {
        verbText.text = "Push!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerable NextLevel()
    {
        yield return new WaitForSeconds(levelStartDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);					//Load the next scene
    }
}
