﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour {

    public float jumpAngleInDegree = 30;
    public float jumpSpeed = 3;

    private CardboardHead gazeHead;
    private Rigidbody gazeRigid;
    private bool onFloor;
    private float lastJumpRequestTime = 0.0f;
    private GameState state;

	// Use this for initialization
	void Start () {
        Cardboard.SDK.OnTrigger += PullTrigger;
        gazeHead = GameObject.FindObjectOfType<CardboardHead>();
        gazeRigid = GetComponent<Rigidbody>();
        state = GameObject.FindObjectOfType<GameState>();
	
	}

    private void PullTrigger()
    {
        RequestJump();
    }

    private void RequestJump()
    {
        lastJumpRequestTime = Time.time;
        gazeRigid.WakeUp();
    }

    private void Jump()
    {
        if(!state.isGameOver)
        {
            float jumpAngleInRadians = jumpAngleInDegree * Mathf.Deg2Rad;
            Vector3 jumpVector = Vector3.RotateTowards(LookDirection(), Vector3.up, jumpAngleInRadians, 0);
            gazeRigid.velocity = jumpVector * jumpSpeed; 
        }
    }

    public Vector3 LookDirection()
    {
        return Vector3.ProjectOnPlane(gazeHead.Gaze.direction, Vector3.up);
    }

    void OnCollisionStay(Collision collision)
    {
        float delta = Time.time - lastJumpRequestTime;
        if(delta < 0.1f)
        {
            Jump();
            lastJumpRequestTime = 0.0f;
        }
    }

    // Update is called once per frame
    void Update () {

	}
}
