/*
 * Ping-pong Source code for this controller taken from  user duck
 * at http://answers.unity3d.com/questions/14279/make-an-object-move-from-point-a-to-point-b-then-b.html
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HandController : MonoBehaviour {

    public Transform farEnd;                                        //where the hand will move to in its path across the screen
    private Vector3 frometh;
    private Vector3 untoeth;
    private bool highfiving = false;                                //Check if the high-fiving is currently happening               
    public float secondsForOneLength = 20f;                         //The amount of time it will take for the moving hand to reach the end of the screen

    public Transform highFiveLocation;                              //Where the high five will take place
    public Transform faceSlapLocation;                              //Where the face slap will take place

    bool inHandTrigger = false;                                     //Check if in the hand trigger area
    bool inFaceTrigger = false;                                     //Check if in the face trigger area

    public SealController sealController;

    public float highFiveDuration = 2f;
    public float faceSlapDuration = 0.5f;


    void Start()
    {
        frometh = transform.position;
        untoeth = farEnd.position;
    }

    void Update()
    {
        if (!highfiving)
        {
            transform.position = Vector3.Lerp(frometh, untoeth,
             Mathf.SmoothStep(0f, 1f,
              Mathf.PingPong(Time.time / secondsForOneLength, 1f)
            ));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (inHandTrigger)
            {
                StartCoroutine(HighFive());
            }
            else if (inFaceTrigger)
            {
                StartCoroutine(FaceSlap());
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
        highfiving = true;

        //High-five animation for source hand
        transform.position = Vector3.Lerp(transform.position, highFiveLocation.position,
            Mathf.SmoothStep(0f, 1f, 1f));

        //Make the seal sprite happy!
        StartCoroutine(sealController.MakeSealHappy());

        yield return new WaitForSeconds(highFiveDuration);
        //TODO: Add a slap sound!

        highfiving = false;
        Debug.Log("High-Five!");
    }

    IEnumerator FaceSlap()
    {
        Debug.Log("Face Slap!");
        //Face slap animation
        transform.position = Vector3.Lerp(transform.position, faceSlapLocation.position,
            Mathf.SmoothStep(0f, 1f, 1f));

        //Make the seal sprite sad!
        StartCoroutine(sealController.MakeSealSad());

        yield return new WaitForSeconds(faceSlapDuration);
        //TODO: Add slap and "ow!" sounds


    }
}

