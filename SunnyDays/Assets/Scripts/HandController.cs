/*
 * Ping-pong Source code for this controller taken from  user duck
 * at http://answers.unity3d.com/questions/14279/make-an-object-move-from-point-a-to-point-b-then-b.html
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//TODO: Make a "whoosh" animation for misses

public class HandController : MonoBehaviour {

    public Transform farEnd;                                        //where the hand will move to in its path across the screen
    private Vector3 frometh;
    private Vector3 untoeth;
    private bool highfiving = false;                                //Check if the high-fiving is currently happening        
    private bool faceSlapping = false;                              //Check if face slapping currently happening
    private bool airSlapping = false;                               //Check if air slapping currently happening
    public float secondsForOneLength = 20f;                         //The amount of time it will take for the moving hand to reach the end of the screen

    public Transform highFiveLocation;                              //Where the high five will take place
    public Transform faceSlapLocation;                              //Where the face slap will take place

    bool inHandTrigger = false;                                     //Check if in the hand trigger area
    bool inFaceTrigger = false;                                     //Check if in the face trigger area

    public SealController sealController;

    public float highFiveDuration = 2f;
    public float faceSlapDuration = 2f;

    public AudioSource slapSFX;
    public AudioSource whooshSFX;

    private int numOfHighFives;                                     //How many high-fives have been given


    void Start()
    {
        frometh = transform.position;
        untoeth = farEnd.position;
    }

    void Update()
    {
        if (numOfHighFives == 3)
        {
            StartCoroutine(GameManager.instance.NextLevel());
        }
        switch (numOfHighFives)
        {
            case 0:
                break;
            case 1:
                GameManager.instance.SetVerbText("Again!");
                break;
            case 2:
                GameManager.instance.SetVerbText("One more time!");
                break;
        }

        
        if (!highfiving && !faceSlapping && !airSlapping)
        {
            transform.position = Vector3.Lerp(frometh, untoeth,
             Mathf.SmoothStep(0f, 1f,
              Mathf.PingPong(Time.time / secondsForOneLength, 1f)
            ));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inHandTrigger)
            {
                StartCoroutine(HighFive());
            }
            else if (inFaceTrigger)
            {
                StartCoroutine(FaceSlap());
            }
            else
            {
                StartCoroutine(AirSlap());
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //If within range of the target hand
        if (other.gameObject.CompareTag("EasyCollision"))
        {
            inHandTrigger = true;
        }

        //If within range of the face
        if (other.gameObject.CompareTag("Face"))
        {
            inFaceTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EasyCollision"))
        {
            inHandTrigger = false;
        }

        if (other.gameObject.CompareTag("Face"))
        {
            inFaceTrigger = false;
        }
    }

    IEnumerator HighFive()
    {
        numOfHighFives++;
        highfiving = true;
        slapSFX.Play();
        yield return new WaitForSeconds(0.3f);                          //Sound takes a while to play - lag until it is ready
        //High-five animation for source hand
        transform.position = Vector3.Lerp(transform.position, highFiveLocation.position,
            Mathf.SmoothStep(0f, 1f, 2f));

        //Make the seal sprite happy!
        StartCoroutine(sealController.MakeSealHappy());
        
        yield return new WaitForSeconds(highFiveDuration);

        highfiving = false;
    }

    IEnumerator FaceSlap()
    {
        faceSlapping = true;
        slapSFX.Play();
        yield return new WaitForSeconds(0.3f);                          //Sound takes a while to play - lag until it is ready
        //Face slap animation
        transform.position = Vector3.Lerp(transform.position, faceSlapLocation.position,
            Mathf.SmoothStep(0f, 1f, 2f));

        //Make the seal sprite sad!
        StartCoroutine(sealController.MakeSealSad());
        

        yield return new WaitForSeconds(faceSlapDuration);
        faceSlapping = false;
    }

    IEnumerator AirSlap()
    {
        airSlapping = true;
        whooshSFX.Play();
        yield return new WaitForSeconds(0.5f);
        //Air slap animation
        Vector3 endPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, endPos,
            Mathf.SmoothStep(0f, 1f, 2f));
        yield return new WaitForSeconds(faceSlapDuration);
        airSlapping = false;
    }
}

