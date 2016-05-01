using UnityEngine;
using System.Collections;

public class GameOverMessage : MonoBehaviour {
    public float UIDistance = 25.0f;
    public float UIHeight = 10.0f;

    private Player toadPlayer;

	// Use this for initialization
	void Start () {
        toadPlayer = GameObject.FindObjectOfType<Player>();
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.LookRotation(toadPlayer.LookDirection());
        transform.position = toadPlayer.transform.position;
        transform.position += toadPlayer.LookDirection() * UIDistance;
        transform.position += Vector3.up * UIHeight;
	
	}
}
