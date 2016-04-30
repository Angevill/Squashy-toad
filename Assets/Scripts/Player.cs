using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Text gazeText;
    public float jumpAngleInDegree = 30;
    public float jumpSpeed = 3;

    private CardboardHead gazeHead;
    private Rigidbody gazeRigid;
    private bool onFloor;
    

	// Use this for initialization
	void Start () {
        Cardboard.SDK.OnTrigger += PullTrigger;
        gazeHead = GameObject.FindObjectOfType<CardboardHead>();
        gazeRigid = GetComponent<Rigidbody>();
	
	}

    private void PullTrigger()
    {
        if (onFloor)
        {
            float jumpAngleInRadians = jumpAngleInDegree * Mathf.Deg2Rad;
            Vector3 projectedVector = Vector3.ProjectOnPlane(gazeHead.Gaze.direction, Vector3.up);
            Vector3 jumpVector = Vector3.RotateTowards(projectedVector, Vector3.up, jumpAngleInRadians, 0);
            gazeRigid.velocity = jumpVector * jumpSpeed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        onFloor = true;
    }

    void OnCollisionExit(Collision collision)
    {
        onFloor = false;
    }

    // Update is called once per frame
    void Update () {
        if (gazeText != null)
        {
            gazeText.text = gazeHead.Gaze.ToString();
        }
        else
        {
            print("Dont forget to pick text object!!");
        }
	}
}
