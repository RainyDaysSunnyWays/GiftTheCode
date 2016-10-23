using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float levelStartDelay = 1f;                  //How long to wait before starting next level
    public static GameManager instance = null;
    public Text verbText;


    void Awake()
    {
		
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
        
    }

    // Use this for initialization
    void Start () {
        SetVerbText();
	}

    public IEnumerator ShowStats()
    {

        yield return new WaitForSeconds(5);
        StartCoroutine(NextLevel());
    }

    /// <summary>
    /// Calls the next level in the game
    /// </summary>
    /// <returns></returns>
    public IEnumerator NextLevel()
    {
        SetVerbText("Yay!");
        yield return new WaitForSeconds(levelStartDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);					//Load the next scene

    }

    /// <summary>
    /// Sets the verb text at the top of the screen based on which level we're in
    /// </summary>
    public void SetVerbText()
    {
        verbText.text = SceneManager.GetActiveScene().name + "!";
    }

    public void SetVerbText(string text)
    {
        verbText.text = text;
    }
}
