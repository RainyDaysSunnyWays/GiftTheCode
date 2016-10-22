/*
 * Ping-pong Source code for this controller taken from  user duck
 * at http://answers.unity3d.com/questions/14279/make-an-object-move-from-point-a-to-point-b-then-b.html
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HandController : MonoBehaviour {

    public Transform farEnd;
    private Vector3 frometh;
    private Vector3 untoeth;
    public float secondsForOneLength = 20f;

    public Transform highFiveLocation;

    bool inHandTrigger = false;
    bool inFaceTrigger = false;

    void Start()
    {
        frometh = transform.position;
        untoeth = farEnd.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(frometh, untoeth,
         Mathf.SmoothStep(0f, 1f,
          Mathf.PingPong(Time.time / secondsForOneLength, 1f)
        ));

        if (Input.GetKey(KeyCode.Space))
        {
            if (inHandTrigger)
            {
                HighFive();
            }
            else if (inFaceTrigger)
            {
                FaceSlap();
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

    void HighFive()
    {
        Debug.Log("High-Five!");
        //TODO: High-five animation
        //TODO: Add a slap sound!
    }

    void FaceSlap()
    {
        Debug.Log("Face Slap!");
        //TODO: Face slap animation
        //TODO: Add slap and "ow!" sounds
    }
}

