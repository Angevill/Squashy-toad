using UnityEngine;
using System.Collections;


public class FireWall : MonoBehaviour {
    public float creepSpeed = 0.01f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        FollowPlayer();
        CreepForward();
    }

    private void CreepForward()
    {
        transform.position += Vector3.forward * creepSpeed;
    }

    private void FollowPlayer()
    {
        GameObject player = GameObject.Find("CardboardPlayer");
        Vector3 deltaVector = player.transform.position - transform.position;
        Vector3 projectedDeltaVector = Vector3.Project(deltaVector, Vector3.left);
        transform.position += projectedDeltaVector;
    }
}
