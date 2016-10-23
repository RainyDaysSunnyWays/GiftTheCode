using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RobotController : MonoBehaviour {
	bool isSuccess = false;
	public float stepSize = 20f;
	private Rigidbody2D rb;
    private Animator animator;
	private GameObject replay;

	// Use this for initialization
	void Start () {
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
			} else {
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

		(replay.GetComponent("Halo") as Behaviour).enabled = !(replay.GetComponent("Halo") as Behaviour).enabled;

		if ((replay.GetComponent ("Halo") as Behaviour).enabled) {
			SceneManager.LoadScene("Push");	
		} else {
			// Go to the next level
			StartCoroutine(GameManager.instance.NextLevel());
		}
	}



}
