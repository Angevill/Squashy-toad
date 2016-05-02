using UnityEngine;
using System.Collections;
using System;

public class FireWall : MonoBehaviour {
    public float creepSpeed = 0.01f;

    private Player toadPlayer;
    private GameState state; 
    // Use this for initialization
    void Start () {
        toadPlayer = GameObject.FindObjectOfType<Player>();
        state = GameObject.FindObjectOfType<GameState>();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!state.isGameOver)
        {
            FollowPlayer();
            CreepForward();
            CheckPlayerBurnt();
        }
    }

    private void CheckPlayerBurnt()
    {
        if(toadPlayer.transform.position.z < transform.position.z)
        {
            state.isGameOver = true;
        }
    }

    private void CreepForward()
    {
        transform.position += Vector3.forward * creepSpeed;
    }

    private void FollowPlayer()
    {
        Vector3 deltaVector = toadPlayer.transform.position - transform.position;
        Vector3 projectedDeltaVector = Vector3.Project(deltaVector, Vector3.left);
        transform.position += projectedDeltaVector;
    }
}
