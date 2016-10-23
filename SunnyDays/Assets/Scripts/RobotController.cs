using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RobotController : MonoBehaviour {
	bool isSuccess;
	public float stepSize = 20f;
	public AudioSource iamarobot;
	private Rigidbody2D rb;
    private Animator animator;
	private GameObject replay;

	private bool doRestart = false;

	// Use this for initialization
	void Start () {
		isSuccess = false;
		rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
		Scene scene = SceneManager.GetActiveScene();

		// name of scene
		if (scene.name == "Summary") { 
			replay = GameObject.Find ("replay");
			(replay.GetComponent ("Halo") as Behaviour).enabled = false;
		}

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {

			if (isSuccess) {
				StartCoroutine (GameManager.instance.NextLevel ());
			} else if(doRestart){
				SceneManager.LoadScene("Push");	

			}else {
                animator.SetTrigger("robotWalk");
				rb.AddForce(new Vector2(70, 0));
                animator.SetTrigger("robotIdle");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		isSuccess = true;

		// Make sure he stops at the finish line
		rb.drag = 100f;
        animator.SetTrigger("robotWin");
		iamarobot.Play ();
		if ((replay != null)) {
			(replay.GetComponent("Halo") as Behaviour).enabled = !(replay.GetComponent("Halo") as Behaviour).enabled;

		}



		if ((replay != null) && ((replay.GetComponent ("Halo") as Behaviour).enabled)) {
			doRestart = true;		
			isSuccess = false;



		} else {
			// Go to the next level
			StartCoroutine(GameManager.instance.NextLevel());
		}
	}



}
